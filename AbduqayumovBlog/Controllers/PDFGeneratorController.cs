using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace BlogWithDb.Controllers
{
    public class PDFGeneratorController : Controller
    {
        public IActionResult Generator(string html)
        {

            HtmlToPdf converter = new HtmlToPdf();

            html = html.Replace("start", "<").Replace("end", ">");

            
            PdfDocument doc = converter.ConvertHtmlString(html);

            // save pdf document
            //doc.Save($@"{AppDomain.CurrentDomain.BaseDirectory}\url.pdf");

            byte[] pdfFile = doc.Save();

            // close pdf document
            return File(pdfFile, "application/pdf");
        }
    }
}
