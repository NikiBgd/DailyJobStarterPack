using System;
using System.Collections.Generic;
using DailyJobStarterPack.DataBaseObjects;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using DailyJobStarterPack.Web.ViewModels.Security;

namespace DailyJobStarterPack.Controllers
{
    public class ReportHelper
    {

        #region WORD
        public static byte[] GenerateWordReport(object data, string caller)
        {
            byte[] result = null;
            MemoryStream ms = new MemoryStream();
            switch (caller)
            {
                case "OV_SK":
                    ms = GenerateOV_SKWordDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
                case "I_KA":
                    ms = GenerateI_KAWordDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
                case "O_ZP":
                    ms = GenerateO_ZPWordDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
                case "O_PO":
                    ms = GenerateO_POWordDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
            }
            return result;
        }

        private static MemoryStream GenerateO_POWordDocument(ClientProfile client)
        {
            var stream = new MemoryStream();
            DocumentFormat.OpenXml.Validation.OpenXmlValidator validator = new DocumentFormat.OpenXml.Validation.OpenXmlValidator();
            using (var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph headingPara = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run headingRun = headingPara.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string title = string.Format("OVLASCENJE");
                headingRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(title));


                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties User_heading_pPr = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                DocumentFormat.OpenXml.Wordprocessing.Justification CenterHeading = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                User_heading_pPr.Append(CenterHeading);
                headingPara.PrependChild(User_heading_pPr);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProp = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                DocumentFormat.OpenXml.Wordprocessing.FontSize size = new DocumentFormat.OpenXml.Wordprocessing.FontSize();

                size.Val = new StringValue("40");
                runProp.Append(size);
                headingRun.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(runProp);


                DocumentFormat.OpenXml.Wordprocessing.Paragraph emptyParaf = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run empRun = emptyParaf.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string empText = string.Format(" ");
                empRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(empText));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para1 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run1 = para1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text1 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da u njihovo ime prijavi/odjavi radnika", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                run1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text1));


                DocumentFormat.OpenXml.Wordprocessing.Paragraph para2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run2 = para2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text2 = string.Format("Ovlascenje se daje:");
                run2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text2));

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph par = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run r = par.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    r.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(ctext));
                }


                mainPart.Document.Save();
            }

            return stream;
        }
        private static MemoryStream GenerateO_ZPWordDocument(ClientProfile client)
        {
            var stream = new MemoryStream();
            DocumentFormat.OpenXml.Validation.OpenXmlValidator validator = new DocumentFormat.OpenXml.Validation.OpenXmlValidator();
            using (var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph headingPara = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run headingRun = headingPara.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string title = string.Format("OVLASCENJE");
                headingRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(title));


                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties User_heading_pPr = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                DocumentFormat.OpenXml.Wordprocessing.Justification CenterHeading = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                User_heading_pPr.Append(CenterHeading);
                headingPara.PrependChild(User_heading_pPr);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProp = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                DocumentFormat.OpenXml.Wordprocessing.FontSize size = new DocumentFormat.OpenXml.Wordprocessing.FontSize();

                size.Val = new StringValue("40");
                runProp.Append(size);
                headingRun.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(runProp);


                DocumentFormat.OpenXml.Wordprocessing.Paragraph emptyParaf = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run empRun = emptyParaf.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string empText = string.Format(" ");
                empRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(empText));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para1 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run1 = para1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text1 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da se u njihovo ime izda potvrda zdravstvenog osiguranja.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                run1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text1));


                DocumentFormat.OpenXml.Wordprocessing.Paragraph para2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run2 = para2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text2 = string.Format("Ovlascenje se daje:");
                run2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text2));

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph par = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run r = par.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    r.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(ctext));
                }


                mainPart.Document.Save();
            }

            return stream;
        }
        private static MemoryStream GenerateI_KAWordDocument(ClientProfile client)
        {
            var stream = new MemoryStream();
            DocumentFormat.OpenXml.Validation.OpenXmlValidator validator = new DocumentFormat.OpenXml.Validation.OpenXmlValidator();
            using (var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph headingPara = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run headingRun = headingPara.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string title = string.Format("IZIJAVA");
                headingRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(title));


                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties User_heading_pPr = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                DocumentFormat.OpenXml.Wordprocessing.Justification CenterHeading = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                User_heading_pPr.Append(CenterHeading);
                headingPara.PrependChild(User_heading_pPr);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProp = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                DocumentFormat.OpenXml.Wordprocessing.FontSize size = new DocumentFormat.OpenXml.Wordprocessing.FontSize();

                size.Val = new StringValue("40");
                runProp.Append(size);
                headingRun.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(runProp);


                DocumentFormat.OpenXml.Wordprocessing.Paragraph emptyParaf = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run empRun = emptyParaf.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string empText = string.Format(" ");
                empRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(empText));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para1 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run1 = para1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text1 = string.Format("{0}, {1} {2} {3}, PIB: {4}, zbog tehničkih problema kasni sa prijavom/odjavom radnika.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                run1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text1));


                DocumentFormat.OpenXml.Wordprocessing.Paragraph para2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run2 = para2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text2 = string.Format("Ovlascenje se daje:");
                run2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text2));

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph par = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run r = par.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    r.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(ctext));
                }


                mainPart.Document.Save();
            }

            return stream;
        }
        private static MemoryStream GenerateOV_SKWordDocument(ClientProfile client)
        {
            var stream = new MemoryStream();
            DocumentFormat.OpenXml.Validation.OpenXmlValidator validator = new DocumentFormat.OpenXml.Validation.OpenXmlValidator();
            using (var wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                DocumentFormat.OpenXml.Wordprocessing.Paragraph headingPara = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run headingRun = headingPara.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string title = string.Format("OVLASCENJE");
                headingRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(title));


                DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties User_heading_pPr = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();
                DocumentFormat.OpenXml.Wordprocessing.Justification CenterHeading = new DocumentFormat.OpenXml.Wordprocessing.Justification() { Val = DocumentFormat.OpenXml.Wordprocessing.JustificationValues.Center };
                User_heading_pPr.Append(CenterHeading);
                headingPara.PrependChild(User_heading_pPr);

                DocumentFormat.OpenXml.Wordprocessing.RunProperties runProp = new DocumentFormat.OpenXml.Wordprocessing.RunProperties();
                DocumentFormat.OpenXml.Wordprocessing.FontSize size = new DocumentFormat.OpenXml.Wordprocessing.FontSize();

                size.Val = new StringValue("40");
                runProp.Append(size);
                headingRun.PrependChild<DocumentFormat.OpenXml.Wordprocessing.RunProperties>(runProp);


                DocumentFormat.OpenXml.Wordprocessing.Paragraph emptyParaf = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run empRun = emptyParaf.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string empText = string.Format(" ");
                empRun.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(empText));

                DocumentFormat.OpenXml.Wordprocessing.Paragraph para1 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run1 = para1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text1 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da se u njihovo ime izvrši sinhronizacija kartice zdravstvenog osiguranja.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                run1.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text1));


                DocumentFormat.OpenXml.Wordprocessing.Paragraph para2 = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run2 = para2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                string text2 = string.Format("Ovlascenje se daje:");
                run2.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(text2));

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    DocumentFormat.OpenXml.Wordprocessing.Paragraph par = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run r = par.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    r.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(ctext));
                }


                mainPart.Document.Save();
            }

            return stream;
        }

        #endregion
        #region PDF
        public static byte[] GeneratePdfReport(object data, string caller)
        {
            byte[] result = null;
            switch (caller)
            {
                case "clients":
                    result = GenerateClientListPDFDocument(data as List<ClientProfile>);
                    break;
                case "OV_SK":
                    result = GenerateOV_SKPDFDocument(data as ClientProfile);
                    break;
                case "I_KA":
                    result = GenerateI_KAPDFDocument(data as ClientProfile);
                    break;
                case "O_ZP":
                    result = GenerateO_ZPPDFDocument(data as ClientProfile);
                    break;
                case "O_PO":
                    result = GenerateO_POPDFDocument(data as ClientProfile);
                    break;
                case "creations":
                    result = GenerateCreationDFDocument(data as Creation);
                    break;
                case "WRK_RPR":
                    result = GenerateWorkersOrderPDFDocument(data as WorkersOrder);
                    break;
            }


            return result;
        }

        private static byte[] GenerateO_POPDFDocument(ClientProfile client)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Times New Roman", 12);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                Paragraph title;
                title = new Paragraph("Ovlašenje", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingBefore = 10;
                title.SpacingAfter = 20;
                doc.Add(title);


                string text1 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da u njihovo ime prijavi/odjavi radnika", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Chunk beginning1 = new Chunk(text1, NormalFont);
                Phrase p1 = new Phrase(beginning1);
                Paragraph pr1 = new Paragraph();
                pr1.Add(p1);
                doc.Add(pr1);

                string text2 = "Ovlascenje se daje:";
                Chunk beginning2 = new Chunk(text2, NormalFont);
                Phrase p2 = new Phrase(beginning2);
                Paragraph pr2 = new Paragraph();
                pr2.Add(p2);
                doc.Add(pr2);

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    Chunk cbeg = new Chunk(ctext, NormalFont);
                    Phrase cp = new Phrase(cbeg);
                    Paragraph cpr = new Paragraph();
                    cpr.Add(cp);
                    doc.Add(cpr);
                }

                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }
        }
        private static byte[] GenerateO_ZPPDFDocument(ClientProfile client)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Times New Roman", 12);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                Paragraph title;
                title = new Paragraph("Ovlašenje", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingBefore = 10;
                title.SpacingAfter = 20;
                doc.Add(title);


                string text1 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da se u njihovo ime izda potvrda zdravstvenog osiguranja.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Chunk beginning1 = new Chunk(text1, NormalFont);
                Phrase p1 = new Phrase(beginning1);
                Paragraph pr1 = new Paragraph();
                pr1.Add(p1);
                doc.Add(pr1);

                string text2 = "Ovlascenje se daje:";
                Chunk beginning2 = new Chunk(text2, NormalFont);
                Phrase p2 = new Phrase(beginning2);
                Paragraph pr2 = new Paragraph();
                pr2.Add(p2);
                doc.Add(pr2);

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    Chunk cbeg = new Chunk(ctext, NormalFont);
                    Phrase cp = new Phrase(cbeg);
                    Paragraph cpr = new Paragraph();
                    cpr.Add(cp);
                    doc.Add(cpr);
                }

                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }
        }
        private static byte[] GenerateI_KAPDFDocument(ClientProfile client)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Times New Roman", 12);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                Paragraph title;
                title = new Paragraph("Izijava", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingBefore = 10;
                title.SpacingAfter = 20;
                doc.Add(title);


                string text1 = string.Format("{0}, {1} {2} {3}, PIB: {4}, zbog tehničkih problema kasni sa prijavom/odjavom radnika.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Chunk beginning1 = new Chunk(text1, NormalFont);
                Phrase p1 = new Phrase(beginning1);
                Paragraph pr1 = new Paragraph();
                pr1.Add(p1);
                doc.Add(pr1);



                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }
        }
        private static byte[] GenerateOV_SKPDFDocument(ClientProfile client)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Times New Roman", 12);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                Paragraph title;
                title = new Paragraph("Ovlašenje", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingBefore = 10;
                title.SpacingAfter = 20;
                doc.Add(title);


                string text1 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da se u njihovo ime izvrši sinhronizacija kartice zdravstvenog osiguranja.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Chunk beginning1 = new Chunk(text1, NormalFont);
                Phrase p1 = new Phrase(beginning1);
                Paragraph pr1 = new Paragraph();
                pr1.Add(p1);
                doc.Add(pr1);

                string text2 = "Ovlascenje se daje:";
                Chunk beginning2 = new Chunk(text2, NormalFont);
                Phrase p2 = new Phrase(beginning2);
                Paragraph pr2 = new Paragraph();
                pr2.Add(p2);
                doc.Add(pr2);

                foreach (var courier in SessionData.Courires)
                {
                    string ctext = string.Format("- {0} {1} - JMBG: {2}, {3}", courier.FirstName, courier.LastName, courier.LegalId, courier.Address);
                    Chunk cbeg = new Chunk(ctext, NormalFont);
                    Phrase cp = new Phrase(cbeg);
                    Paragraph cpr = new Paragraph();
                    cpr.Add(cp);
                    doc.Add(cpr);
                }

                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }
        }
        private static byte[] GenerateClientListPDFDocument(List<ClientProfile> clients)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, BaseColor.BLUE);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();


                PdfPTable table = new PdfPTable(3);

                PdfPCell cell = new PdfPCell(new Phrase("Podaci o korisnicima"));
                cell.Colspan = 3;
                cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                table.AddCell(cell);

                foreach (var client in clients)
                {
                    table.AddCell(client.Name);
                    table.AddCell(client.Address + ", " + client.Municipality + ", " + client.Place);
                    table.AddCell(client.PIB);
                }

                doc.Add(table);


                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }


        }
        private static byte[] GenerateCreationDFDocument(Creation creation)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Times New Roman", 12);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 32);
                Paragraph title;
                title = new Paragraph("Ponuda za osnivanje", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingBefore = 10;
                title.SpacingAfter = 20;
                doc.Add(title);


                string text1 = string.Format("Ponuda za osnivanje {0}, {1} {2}", creation.Name, creation.Mail, creation.PhoneNumber);
                Chunk beginning1 = new Chunk(text1, NormalFont);
                Phrase p1 = new Phrase(beginning1);
                Paragraph pr1 = new Paragraph();
                pr1.Add(p1);
                doc.Add(pr1);

                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }
        }
        private static byte[] GenerateWorkersOrderPDFDocument(WorkersOrder order)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                iTextSharp.text.Font NormalFont = FontFactory.GetFont("Times New Roman", 12);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.Open();

                iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 24);
                Paragraph title;
                title = new Paragraph(string.Format("Radni nalog za kurira: {0} {1}", order.Courier.FirstName, order.Courier.LastName), titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingBefore = 10;
                title.SpacingAfter = 20;
                doc.Add(title);


                string text1 = string.Format("Za klijenta: {0} posetiti lokaciju {1} sa dokumentacijom {2}", order.Client.Name, order.Place, order.Documentation);
                Chunk beginning1 = new Chunk(text1, NormalFont);
                Phrase p1 = new Phrase(beginning1);
                Paragraph pr1 = new Paragraph();
                pr1.Add(p1);
                doc.Add(pr1);

                string text2 = string.Format("Opis posla: {0}", order.JobDescription);
                Chunk beginning2 = new Chunk(text2, NormalFont);
                Phrase p2 = new Phrase(beginning2);
                Paragraph pr2 = new Paragraph();
                pr2.Add(p2);
                doc.Add(pr2);

                doc.Close();
                byte[] bytes = ms.ToArray();
                ms.Close();

                return bytes;
            }
        }

        #endregion
        #region EXCELL
        public static byte[] GenerateExcellReport(object data, string caller)
        {
            byte[] result = null;
            MemoryStream ms = new MemoryStream();
            switch (caller)
            {
                case "clients":
                    ms = GenerateClientListEcellDocument(data as List<ClientProfile>);
                    result = ms.ToArray();
                    break;
                case "OV_SK":
                    ms = GenerateOV_SKExcellDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
                case "I_KA":
                    ms = GenerateI_KAExcellDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
                case "O_ZP":
                    ms = GenerateO_ZPExcellDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
                case "O_PO":
                    ms = GenerateO_POExcellDocument(data as ClientProfile);
                    result = ms.ToArray();
                    break;
            }


            return result;
        }

        private static MemoryStream GenerateO_POExcellDocument(ClientProfile client)
        {
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Data"
                };


                Row row = new Row() { RowIndex = 1 };
                Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("OVLASCENJE"), DataType = CellValues.String };
                row.Append(header1);
                sheetData.Append(row);

                Row row2 = new Row() { RowIndex = 2 };
                Cell header2 = new Cell() { CellReference = "A2", CellValue = new CellValue(""), DataType = CellValues.String };
                row2.Append(header2);
                sheetData.Append(row2);

                Row row3 = new Row() { RowIndex = 3 };
                string text3 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da u njihovo ime prijavi/odjavi radnika", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Cell header3 = new Cell() { CellReference = "A3", CellValue = new CellValue(text3), DataType = CellValues.String };
                row3.Append(header3);
                sheetData.Append(row3);


                Row row4 = new Row() { RowIndex = 4 };
                string text4 = string.Format("Ovlašćenje se daje:");
                Cell header4 = new Cell() { CellReference = "A4", CellValue = new CellValue(text4), DataType = CellValues.String };
                row4.Append(header4);
                sheetData.Append(row4);

                UInt32Value i = 4;
                foreach (var courier in SessionData.Courires)
                {
                    i++;
                    Row clientRow = new Row() { RowIndex = i };
                    Cell c1 = new Cell()
                    {
                        CellReference = "A" + i,
                        CellValue = new CellValue(" - " + courier.FirstName + " " + courier.LastName + " - JMBG:" + courier.LegalId + ", " + courier.Address),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c1);
                    sheetData.Append(clientRow);
                }

                sheets.Append(sheet);

                spreadsheetDocument.WorkbookPart.Workbook.Save();

                return ms;
            }
        }
        private static MemoryStream GenerateO_ZPExcellDocument(ClientProfile client)
        {
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Data"
                };


                Row row = new Row() { RowIndex = 1 };
                Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("OVLASCENJE"), DataType = CellValues.String };
                row.Append(header1);

                Row row2 = new Row() { RowIndex = 2 };
                Cell header2 = new Cell() { CellReference = "A2", CellValue = new CellValue(""), DataType = CellValues.String };
                row2.Append(header2);

                Row row3 = new Row() { RowIndex = 3 };
                string text3 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da se u njihovo ime izda potvrda zdravstvenog osiguranja.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Cell header3 = new Cell() { CellReference = "A3", CellValue = new CellValue(text3), DataType = CellValues.String };
                row3.Append(header3);

                Row row4 = new Row() { RowIndex = 4 };
                string text4 = string.Format("Ovlašćenje se daje:");
                Cell header4 = new Cell() { CellReference = "A4", CellValue = new CellValue(text4), DataType = CellValues.String };
                row4.Append(header4);

                sheetData.Append(row);
                sheetData.Append(row2);
                sheetData.Append(row3);
                sheetData.Append(row4);

                UInt32Value i = 4;
                foreach (var courier in SessionData.Courires)
                {
                    i++;
                    Row clientRow = new Row() { RowIndex = i };
                    Cell c1 = new Cell()
                    {
                        CellReference = "A" + i,
                        CellValue = new CellValue(" - " + courier.FirstName + " " + courier.LastName + " - JMBG:" + courier.LegalId + ", " + courier.Address),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c1);
                    sheetData.Append(clientRow);
                }

                sheets.Append(sheet);

                spreadsheetDocument.WorkbookPart.Workbook.Save();

                return ms;
            }
        }
        private static MemoryStream GenerateI_KAExcellDocument(ClientProfile client)
        {
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Data"
                };


                Row row = new Row() { RowIndex = 1 };
                Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("IZIJAVA"), DataType = CellValues.String };
                row.Append(header1);

                Row row2 = new Row() { RowIndex = 2 };
                Cell header2 = new Cell() { CellReference = "A2", CellValue = new CellValue(""), DataType = CellValues.String };
                row2.Append(header2);

                Row row3 = new Row() { RowIndex = 3 };
                string text3 = string.Format("{0}, {1} {2} {3}, PIB: {4}, zbog tehničkih problema kasni sa prijavom/odjavom radnika.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Cell header3 = new Cell() { CellReference = "A3", CellValue = new CellValue(text3), DataType = CellValues.String };
                row3.Append(header3);

                Row row4 = new Row() { RowIndex = 4 };
                string text4 = string.Format("Ovlašćenje se daje:");
                Cell header4 = new Cell() { CellReference = "A4", CellValue = new CellValue(text4), DataType = CellValues.String };
                row4.Append(header4);

                sheetData.Append(row);
                sheetData.Append(row2);
                sheetData.Append(row3);
                sheetData.Append(row4);

                UInt32Value i = 4;
                foreach (var courier in SessionData.Courires)
                {
                    i++;
                    Row clientRow = new Row() { RowIndex = i };
                    Cell c1 = new Cell()
                    {
                        CellReference = "A" + i,
                        CellValue = new CellValue(" - " + courier.FirstName + " " + courier.LastName + " - JMBG:" + courier.LegalId + ", " + courier.Address),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c1);
                    sheetData.Append(clientRow);
                }

                sheets.Append(sheet);

                spreadsheetDocument.WorkbookPart.Workbook.Save();

                return ms;
            }
        }
        private static MemoryStream GenerateOV_SKExcellDocument(ClientProfile client)
        {
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Data"
                };


                Row row = new Row() { RowIndex = 1 };
                Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("OVLAŠĆENJE"), DataType = CellValues.String };
                row.Append(header1);

                Row row2 = new Row() { RowIndex = 2 };
                Cell header2 = new Cell() { CellReference = "A2", CellValue = new CellValue(""), DataType = CellValues.String };
                row2.Append(header2);

                Row row3 = new Row() { RowIndex = 3 };
                string text3 = string.Format("Ovim ovlašćenjem {0}, {1} {2} {3}, PIB: {4}, daje da se u njihovo ime izvrši sinhronizacija kartice zdravstvenog osiguranja.", client.Name, client.Address, client.Place, client.Municipality, client.PIB);
                Cell header3 = new Cell() { CellReference = "A3", CellValue = new CellValue(text3), DataType = CellValues.String };
                row3.Append(header3);

                Row row4 = new Row() { RowIndex = 4 };
                string text4 = string.Format(" Ovlašćenje se daje:");
                Cell header4 = new Cell() { CellReference = "A4", CellValue = new CellValue(text4), DataType = CellValues.String };
                row4.Append(header4);

                sheetData.Append(row);
                sheetData.Append(row2);
                sheetData.Append(row3);
                sheetData.Append(row4);

                UInt32Value i = 4;
                foreach (var courier in SessionData.Courires)
                {
                    i++;
                    Row clientRow = new Row() { RowIndex = i };
                    Cell c1 = new Cell()
                    {
                        CellReference = "A" + i,
                        CellValue = new CellValue(" - " + courier.FirstName + " " + courier.LastName + " - JMBG:" + courier.LegalId + ", " + courier.Address),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c1);
                    sheetData.Append(clientRow);
                }

                sheets.Append(sheet);

                spreadsheetDocument.WorkbookPart.Workbook.Save();

                return ms;
            }
        }
        private static MemoryStream GenerateClientListEcellDocument(List<ClientProfile> clients)
        {
            MemoryStream ms = new MemoryStream();
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                // Add Sheets to the Workbook.
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.
                    AppendChild<Sheets>(new Sheets());

                // Append a new worksheet and associate it with the workbook.
                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.
                    GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Data"
                };


                Row row = new Row() { RowIndex = 1 };
                Cell header1 = new Cell() { CellReference = "A1", CellValue = new CellValue("Interval Period Timestamp"), DataType = CellValues.String };
                row.Append(header1);
                Cell header2 = new Cell() { CellReference = "B1", CellValue = new CellValue("Settlement Interval"), DataType = CellValues.String };
                row.Append(header2);
                Cell header3 = new Cell() { CellReference = "C1", CellValue = new CellValue("Aggregated Consumption Factor"), DataType = CellValues.String };
                row.Append(header3);
                Cell header4 = new Cell() { CellReference = "D1", CellValue = new CellValue("Loss Adjusted Aggregated Consumption"), DataType = CellValues.String };
                row.Append(header4);

                sheetData.Append(row);

                UInt32Value i = 1;
                foreach (var client in clients)
                {
                    i++;
                    Row clientRow = new Row() { RowIndex = i };
                    Cell c1 = new Cell()
                    {
                        CellReference = "A" + i,
                        CellValue = new CellValue(client.Name),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c1);
                    Cell c2 = new Cell()
                    {
                        CellReference = "B" + i,
                        CellValue = new CellValue(client.Address),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c2);
                    Cell c3 = new Cell()
                    {
                        CellReference = "C" + i,
                        CellValue = new CellValue(client.Place),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c3);
                    Cell c4 = new Cell()
                    {
                        CellReference = "D" + i,
                        CellValue = new CellValue(client.Municipality),
                        DataType = CellValues.String
                    };
                    clientRow.Append(c4);
                    sheetData.Append(clientRow);
                }

                sheets.Append(sheet);

                spreadsheetDocument.WorkbookPart.Workbook.Save();

                return ms;
            }
        }
        #endregion
    }
}