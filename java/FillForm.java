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

import java.io.BufferedReader;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.util.Calendar;

public class FillForm {

	// simple java code that uses itextpdf to insert text onto an existing PDF
	// document.
	public static void main(String[] args) {
		try {
			
			String name = "";
			
			String csvFile = "config.csv";
			BufferedReader br = null;
			String line = "";
			
			br = new BufferedReader(new FileReader(csvFile));
			while ((line = br.readLine()) != null) {

				// use comma as separator
				String[] lineSplit = line.split(",");
				if(lineSplit[0].equals("name"))
					name = lineSplit[1];

			}
			
			br.close();

			
			//create a calendar object to get the current day, month and year.
			Calendar cal = Calendar.getInstance();
			//creates the string used to insert date with correct padding
			String paddedDate = String.valueOf(cal.get(Calendar.DAY_OF_MONTH)) + String.format("%13s", "")
					+ String.valueOf(cal.get(Calendar.MONTH) + 1) + String.format("%14s", "")
					+ String.valueOf(cal.get(Calendar.YEAR));
			//creates font to be reused
			Font fnt = new Font(FontFamily.HELVETICA, 10, Font.NORMAL, new BaseColor(0, 0, 0));
			
			//reads in the existing source PDF
			PdfReader pdfReader = new PdfReader(args[0]);
			
			String[] pdfFile = args[0].split("\\.");
			
			//creates the new PDF and opens source
			PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileOutputStream(pdfFile[0] + "-Filled.pdf"));
			
			//grabs the first page of source
			PdfContentByte canvas = pdfStamper.getUnderContent(1);
			
			String faultText = "";
			
			int i = 2;
			while(i < args.length){
				faultText += args[i] + " ";
				i++;
			}
			
			//adds text to PDF
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(name, fnt), 98, 380, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(paddedDate, fnt), 404, 380, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Out: " + args[1], fnt), 60, 300, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Fault: " + faultText, fnt), 60, 280, 0);

			//saves new pdf
			pdfStamper.close();

		} catch (IOException | DocumentException e) {
			e.printStackTrace();
		}
	}
}