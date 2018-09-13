using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;


namespace CdOrganizer.Controllers
{
    public class ArtistController : Controller
    {
        [HttpGet("/artists")]
        public ActionResult Index()
        {
            List<Artist> allArtists = Artist.GetAll();
            return View(allArtists);
        }

        [HttpGet("/artists/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/artists")]
        public ActionResult Create()
        {
            Artist newArtist = new Artist(Request.Form["artist-name"]);
            List<Artist> allArtists = Artist.GetAll();
            return View("Index", allArtists);
        }

        [HttpGet("/artists/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Artist selectedArtist = Artist.Find(id);
            List<Cd> artistCds = selectedArtist.GetCds();
            model.Add("artist", selectedArtist);
            model.Add("cds", artistCds);
            return View(model);
        }


        [HttpPost("/cds")]
        public ActionResult CreateCd(int artistId, string cdTitle)
        {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Artist foundArtist = Artist.Find(artistId);
          Cd newCd = new Cd(cdTitle);
          foundArtist.AddCd(newCd);
          List<Cd> artistCds = foundArtist.GetCds();
          model.Add("cds", artistCds);
          model.Add("artist", foundArtist);
          return View("Details", model);
        }

    }
}
