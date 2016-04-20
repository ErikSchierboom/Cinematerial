namespace CinematerialDemo.Controllers
{
    using System;
    using System.Web.Mvc;
    using Cinematerial;
    using Models;

    public class HomeController : Controller
    {
        [OutputCache(Duration = 3600)]
        public ViewResult Index(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                var cinematerialService = new CinematerialService(model.ApiKey, model.ApiSecret);

                if (model.ImdbMovieId.HasValue)
                {
                    model.CinematerialResult = cinematerialService.Search(model.ImdbMovieId.Value, model.ImageWidth);
                }
                else
                {
                    model.CinematerialResult = cinematerialService.Search(new Uri(model.ImdbMovieUrl), model.ImageWidth);
                }
            }
            
            return View(model);
        }
    }
}