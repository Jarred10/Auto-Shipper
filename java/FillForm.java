import java.io.BufferedReader;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.regex.Pattern;

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

/**
 * @author Jarred Uses iTextPDF to fill in shipping forms.
 */
public class FillForm {
	public static void main(String[] args) {
		
		//declare variables for fields of form
		String jobNo, site, inSerial, outSerial, fault;
		jobNo = site = inSerial = outSerial = fault = "";

		//finds all fields using passed in arguments, seperated by | character
		String argsString = "";
		for (String s : args)
			argsString += s + " ";
		args = argsString.split(Pattern.quote("|"));

		boolean foodstuffsJob = args[0].equalsIgnoreCase("true");
		
		//sets value of fields based on whether or not the job being shipped is for foodstuffs
		//which is passed in as a bool value
		if (foodstuffsJob) {
			jobNo = args[1];
			inSerial = args[2];
			outSerial = args[3];
			site = args[4];
			fault = args[5];
		} else {
			outSerial = args[1];
			fault = args[2];
		}

		try {
			//name of user
			String name = "";

			BufferedReader br = null;
			String line = "";
			
			//reads in name of user from config CSV file
			br = new BufferedReader(new FileReader("config.csv"));
			while ((line = br.readLine()) != null) {

				// use comma as separator
				String[] lineSplit = line.split(";");
				if (lineSplit[0].equalsIgnoreCase("name"))
					name = lineSplit[1];

			}

			br.close();

			// create a calendar object to get the current day, month and year.
			Calendar cal = Calendar.getInstance();
			// creates the string used to insert date with correct spacing
			String paddedDate = String.valueOf(cal.get(Calendar.DAY_OF_MONTH)) + String.format("%13s", "")
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
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Out: " + outSerial, fnt), 50, 300, 0);
			canvas.setTextMatrix(60, 280);
			
			//adds word-wrapped text for fault as this can be multi-line
			ColumnText ct = new ColumnText(canvas);
			ct.setSimpleColumn(new Phrase("Fault: " + fault, fnt), 50, 150, 570, 300, 15,
					Element.ALIGN_LEFT | Element.ALIGN_TOP);
			ct.go();

			// saves new PDF
			pdfStamper.close();

			//checks if job is for foodstuffs
			if (foodstuffsJob) {

				// reads in the existing source PDF document and creates new PDF document of filled form
				pdfReader = new PdfReader("fsDoc.pdf");
				pdfStamper = new PdfStamper(pdfReader, new FileOutputStream("fsDoc-Filled.pdf"));
				canvas = pdfStamper.getUnderContent(1);

				// adds text to PDF
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(name, fnt), 220, 658, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(dateInString, fnt), 220, 632, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(jobNo, fnt), 220, 606, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(site, fnt), 220, 580, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(inSerial, fnt), 220, 412, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(outSerial, fnt), 220, 260, 0);

				//adds word-wrapped text for fault as this can be multi-line
				ct = new ColumnText(canvas);
				ct.setSimpleColumn(new Phrase(fault, fnt), 55, 10, 530, 190, 27,
						Element.ALIGN_LEFT | Element.ALIGN_TOP);
				ct.go();

				// saves new PDF
				pdfStamper.close();
			}
			
		} 
		//general catch statement for debug purposes
		catch (IOException | DocumentException e) {
			e.printStackTrace();
		}
	}
}