import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import org.apache.poi.ddf.EscherChildAnchorRecord;
import org.apache.poi.xwpf.usermodel.XWPFDocument;
import org.apache.poi.xwpf.usermodel.XWPFParagraph;
import org.apache.poi.xwpf.usermodel.XWPFRun;
import org.apache.poi.xwpf.usermodel.XWPFTable;
import org.apache.poi.xwpf.usermodel.XWPFTableCell;
import org.apache.poi.xwpf.usermodel.XWPFTableRow;

import com.itextpdf.text.BaseColor;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Font.FontFamily;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.pdf.ColumnText;
import com.itextpdf.text.pdf.PdfContentByte;
import com.itextpdf.text.pdf.PdfReader;
import com.itextpdf.text.pdf.PdfStamper;
import com.sun.xml.internal.ws.wsdl.parser.InaccessibleWSDLException;

/**
 * @author Jarred Uses iTextPDF to fill in shipping forms.
 */
public class FillForm {
	public static void main(String[] args) {
		
		//declare variables for fields of form
		String jobType, jobNo, site, inSerial, outSerial, inAsset, outAsset, fault;
		jobType = jobNo = site = inSerial = outSerial = inAsset = outAsset = fault = "";
		
		try {
			//name of user
			String name = "";

			BufferedReader br = null;
			String line = "";
						
			br = new BufferedReader(new FileReader("data.txt"));
			name = br.readLine();
			jobType = br.readLine();
			jobNo = br.readLine();
			inSerial = br.readLine();
			outSerial = br.readLine();
			inAsset = br.readLine();
			outAsset = br.readLine();
			site = br.readLine();
			while((line = br.readLine()) != null){
				fault += line;
			}

			br.close();
			

			
			File data = new File("data.txt");
			//if(data.exists()) data.delete();

			// create a calendar object to get the current day, month and year.
			Calendar cal = Calendar.getInstance();
			// creates the string used to insert date with correct spacing
			String paddedDate = String.valueOf(cal.get(Calendar.DAY_OF_MONTH)) + String.format("%14s", "")
					+ String.valueOf(cal.get(Calendar.MONTH) + 1) + String.format("%14s", "")
					+ String.valueOf(cal.get(Calendar.YEAR));
			
			//formats date to be just the day, month and year
			String dateInString = new SimpleDateFormat("dd-MM-yy").format(new Date());

			// creates font to be reused as Helvetica, size 10 and not bold or italic. Color black.
			Font fnt = new Font(FontFamily.HELVETICA, 10, Font.NORMAL, new BaseColor(0, 0, 0));

			// reads in the existing source PDF document and creates new PDF document of filled form
			PdfReader pdfReader = new PdfReader("shipDoc.pdf");
			PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileOutputStream("shipDoc-Filled.pdf"));
			PdfContentByte canvas = pdfStamper.getUnderContent(1);

			// adds text to PDF
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(name, fnt), 98, 380, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(paddedDate, fnt), 404, 380, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Faulty Serial: " + outSerial, fnt), 50, 280, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Faulty Asset: " + outAsset, fnt), 50, 265, 0);
			
			//adds word-wrapped text for fault as this can be multi-line
			ColumnText ct = new ColumnText(canvas);
			ct.setSimpleColumn(new Phrase("Fault Description: " + fault, fnt), 50, 150, 570, 265, 15,
					Element.ALIGN_LEFT | Element.ALIGN_TOP);
			ct.go();

			// saves new PDF
			pdfStamper.close();
			

			//checks if job is for foodstuffs
			if (jobType.equals("Foodstuffs")) {

		        String fileName = "fsDoc.docx";
		        InputStream fis = new FileInputStream(fileName);
		        
		        XWPFDocument document = new XWPFDocument(fis);

		        List<XWPFTable> tables = document.getTables();
		        
		        setRun(tables.get(0).getRow(4).getCell(1), name);
		        setRun(tables.get(0).getRow(5).getCell(1), dateInString);
		        setRun(tables.get(0).getRow(6).getCell(1), jobNo);
		        setRun(tables.get(0).getRow(7).getCell(1), site);


		        setRun(tables.get(0).getRow(15).getCell(1), inSerial);
		        setRun(tables.get(0).getRow(16).getCell(1), inAsset);
		        
		        setRun(tables.get(0).getRow(22).getCell(1), outSerial);
		        setRun(tables.get(0).getRow(23).getCell(1), outAsset);
		        		        
		        setRun(tables.get(0).getRow(27).getCell(0), fault);
		        
		        OutputStream out = new FileOutputStream("fsDoc-Filled.docx");
		        document.write(out);
		        out.close();
		        
		        document.close();
			}
			else if(jobType.equals("Lotto")){

				DateFormat df = new SimpleDateFormat("dd/MM/yy");
				Date dateobj = new Date();
				
				
		        String fileName = "lottoDoc.docx";
		        InputStream fis = new FileInputStream(fileName);
		        
		        XWPFDocument document = new XWPFDocument(fis);

		        List<XWPFTable> tablesList = document.getTables();
		        XWPFTable table = tablesList.get(0);
		        		        
		        XWPFTableRow tableRow = table.getRow(0);
		        tableRow.getCell(1).setText(df.format(dateobj));
		        
		        tableRow = table.getRow(1);
		        tableRow.getCell(1).setText("Jarred Green");
		        
		        tableRow = table.getRow(2);
		        tableRow.getCell(1).setText(jobNo);
		        
		        tableRow = table.getRow(3);
		        tableRow.getCell(1).setText(site);

		        tableRow = table.getRow(6);
		        tableRow.getCell(1).setText(inSerial);
		        
		        tableRow = table.getRow(7);
		        tableRow.getCell(1).setText(outSerial);
		        
		        tableRow = table.getRow(9);
		        tableRow.getCell(0).setText(fault);
		        
		        OutputStream out = new FileOutputStream("lottoDoc-Filled.docx");
		        document.write(out);
		        out.close();
		        
		        document.close();
		        
			}
			
		} 
		//general catch statement for debug purposes
		catch (IOException | DocumentException e) {
			e.printStackTrace();
		}
	}
	
	private static void setRun (XWPFTableCell cell, String text){
		if(cell.getParagraphs().size() > 0) cell.removeParagraph(0);
		XWPFRun run = cell.addParagraph().createRun();
        run.setFontFamily("Arial"); run.setFontSize(12); run.setText(text);	
	}
}