using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace DifferentTypesOfActionResultsInAspNetCore.Controllers
{
    public class ContentResultTypeController : Controller
    {
        public ContentResult jsonMethod()
        {
            return  new ContentResult()
            {
                Content = "{\"Data\":[],\"Count\":0,\"Page\":1,\"PageCount\":0,\"Msg\":\"" +"Hi "+ "\",\"Code\":403}",
                ContentType = "application/json",
                StatusCode = 200
            };
        }

        public ContentResult plainText(string userName)
        {
            //By default MIME type is text/plain

            string welcomeMsg = "Hi "+ userName + ", Here we are learning about the ContentResult";
            return new ContentResult()
            {
                Content = welcomeMsg,
                ContentType = "text/plain", 
                StatusCode = 200
            };
        }



        public ContentResult HTMLMethod()
        {

            string htmlContent = "<html> <body> <h1> learning about ContentResult using HTML as content type </h1> </body> </html>";
            return new ContentResult()
            {
                Content = htmlContent,
                ContentType = "text/html",
                StatusCode = 200
            };
        }

        public ContentResult XMLMethod()
        {

            string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<product>\r\n  <name>XML Book</name>\r\n  <author>w3schools</author>\r\n  <price>$20</price>\r\n</product>";
            return new ContentResult()
            {
                Content = xmlContent,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }

        public ContentResult getPlainText()
        {
            string welcomeMsg = "Hi User, Here we are learning about the ContentResult";

            return Content(welcomeMsg);
        }

    }
}
