using System;
using System.IO;
using System.Web.Mvc;

namespace MuscleTherapyJournal.Controllers
{
    public class ImageController : Controller
    {
        
        [HttpGet]
        public ActionResult GetBase64Image()
        {
            string path 
                = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images")
                 + "\\" + "Treatment.jpg";
 
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[(int)fileStream.Length];
            fileStream.Read(data, 0, data.Length);
 
            var result = Json(new { base64imgage =  Convert.ToBase64String(data) }
                , JsonRequestBehavior.AllowGet);
            result.MaxJsonLength = int.MaxValue;

            return result;
        } 
    }
}