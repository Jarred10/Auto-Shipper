import com.itextpdf.text.*;
import com.itextpdf.text.Font.*;
import com.itextpdf.text.pdf.*;

import java.io.*;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.regex.Pattern;

public class FillForm {

	// simple java code that uses iTextPDF to insert text onto an existing PDF
	// document.
	public static void main(String[] args) {
		String shipDoc = "shipDoc.pdf";
		String fsDoc = "fsDoc.pdf";
		
		String jobNo, site, inSerial, outSerial, fault;
		jobNo = site = inSerial = outSerial = fault = "";
		
		String argsString = "";
		for(String s : args) argsString += s + " ";	
		args = argsString.split(Pattern.quote("|"));
		
		boolean foodstuffsJob = args[0].equalsIgnoreCase("True");
		
		if(foodstuffsJob){
			jobNo = args[1];
			inSerial = args[2];
			outSerial = args[3];
			site = args[4];
			fault = args[5];
		}
		else {
			outSerial = args[1];
			fault = args[2];
		}
		
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
			

			String dateInString = new SimpleDateFormat("dd-MM-yy").format(new Date());
			
			//creates font to be reused
			Font fnt = new Font(FontFamily.HELVETICA, 10, Font.NORMAL, new BaseColor(0, 0, 0));
			
			//reads in the existing source PDF
			PdfReader pdfReader = new PdfReader(shipDoc);
			
			//creates the new PDF and opens source
			PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileOutputStream("shipDoc-Filled.pdf"));
			
			//grabs the first page of source
			PdfContentByte canvas = pdfStamper.getUnderContent(1);
			
			//adds text to PDF
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(name, fnt), 98, 380, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(paddedDate, fnt), 404, 380, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Out: " + outSerial, fnt), 60, 300, 0);
			ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Fault: " + fault, fnt), 60, 280, 0);

			//saves new PDF
			pdfStamper.close();
			
			if(foodstuffsJob){
				pdfReader = new PdfReader(fsDoc);
				
				pdfStamper = new PdfStamper(pdfReader, new FileOutputStream("fsDoc-Filled.pdf"));
				
				canvas = pdfStamper.getUnderContent(1);
				
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(name, fnt), 220, 658, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(dateInString, fnt), 220, 632, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(jobNo, fnt), 220, 606, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(site, fnt), 220, 580, 0);		
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(inSerial, fnt), 220, 412, 0);
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(outSerial, fnt), 220, 260, 0);		
				ColumnText.showTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(fault, fnt), 55, 162, 0);

				pdfStamper.close();
			}

		} catch (IOException | DocumentException e) {
			e.printStackTrace();
		}
	}
}