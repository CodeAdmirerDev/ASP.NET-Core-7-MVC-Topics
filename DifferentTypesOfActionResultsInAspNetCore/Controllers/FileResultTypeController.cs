using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class FileResultTypeController : Controller
    {
        public FileResult Index()
        {

            //Get the file location 

            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\"+ "SampleData.pdf";

            //Convert the file content into byte[] using I/O

            byte[] pdfContentBytesInformation = System.IO.File.ReadAllBytes(filePath);

            // Return the byte array 

            return File(pdfContentBytesInformation,"application/pdf","DemoData.pdf");
        }

        public FileResult DisplayPdfFile()
        {

            //Get the file location 

            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\" + "SampleData.pdf";

            //Convert the file content into byte[] using I/O

            byte[] pdfContentBytesInformation = System.IO.File.ReadAllBytes(filePath);

            // Return the byte array 

            return File(pdfContentBytesInformation, "application/pdf");
        }


        public FileResult DownloadPDFFileWithAdditionalOptions()
        {

            //Get the file location 

            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\" + "SampleData.pdf";

            //Convert the file content into byte[] using I/O

            byte[] pdfContentBytesInformation = System.IO.File.ReadAllBytes(filePath);



            var contentDispostion = new ContentDisposition
            {
                FileName = "UserData.pdf",
                Inline=true, //If you want to display the file in the browser
            };

            Response.Headers.Add("Content-Disposition", contentDispostion.ToString());

            // Return the byte array 

            return File(pdfContentBytesInformation, "application/pdf");
        }

        public FileResult DownloadImage()
        {

            //Get the file location 

            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\" + "FileResultExample.jpg";

            //Convert the file content into byte[] using I/O

            byte[] imageContentBytesInformation = System.IO.File.ReadAllBytes(filePath);

            // Return the byte array 

            return File(imageContentBytesInformation, "image/jpeg", "SampleCode.jpg");
        }


        public FileResult DisplayImage()
        {

            //Get the file location 

            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\Images\\" + "FileResultExample.jpg";

            //Convert the file content into byte[] using I/O

            byte[] pdfContentBytesInformation = System.IO.File.ReadAllBytes(filePath);

            var contentDispostion = new ContentDisposition
            {
                FileName = "SampleCode.jpg",
                Inline = true, //If you want to display the file in the browser
            };

            Response.Headers.Add("Content-Disposition", contentDispostion.ToString());


            // Return the byte array 

            return File(pdfContentBytesInformation, "image/jpeg");
        }

        public FileResult DownloadPDFFromPhysicalFile()
        {
            //Get the File Path
            string filePath = Directory.GetCurrentDirectory() + "\\wwwroot\\PDFFiles\\" + "SampleData.pdf";

            //Return the Physical File
            return PhysicalFile(filePath, "application/pdf");
        }

    }
}
