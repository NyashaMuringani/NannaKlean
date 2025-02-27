using Microsoft.AspNetCore.Mvc;
using NannaKlean.Models;


namespace NannaKlean.Views
{
    public class PhotosController : Controller
    {
        public IActionResult UploadPhotos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadPhotos(Image images)
        {
            //save the photo data here
            return View();
        }
    }
}
