using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;


namespace CdOrganizer.Controllers
{
    public class CdController : Controller
    {
        [HttpGet("/artists/{artistId}/cds/new")]
       public ActionResult CreateForm(int artistId)
       {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Artist artist = Artist.Find(artistId);
          return View(artist);
       }
       [HttpGet("/artists/{artistId}/cds/{cdId}")]
       public ActionResult Details(int artistId, int cdId)
       {
          Dictionary<string, object> model = new Dictionary<string, object>();
          Cd cd = Cd.Find(cdId);
          Artist artist = Artist.Find(artistId);
          model.Add("cd", cd);
          model.Add("artist", artist);
          return View(model);
       }
    }
}
