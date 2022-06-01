using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApricodHW.Models;
using ApricodHW.Services;

namespace ApricodHW.Controllers
{
	[Route("api/VideoGames")]
	[ApiController]
	public class VideoGamesController : ControllerBase
	{
		private readonly IVideoGamesService _svc;

		public VideoGamesController(IVideoGamesService svc)
		{
			_svc = svc;
		}

		// GET: api/VideoGames
		[HttpGet]
		public ActionResult<IEnumerable<VideoGames>> GetVideoGamesItems()
		{
			return _svc.GetVideoGames();
		}

		// GET: api/VideoGames/5
		[HttpGet("{id}")]
		public ActionResult<VideoGames> GetVideoGames(int id)
		{
			return _svc.GetVideoGameById(id);
		}

		// GET: api/VideoGames/ByGenre/Action
		[HttpGet]
		[Route("ByGenre/{genre}")]
		public ActionResult<IEnumerable<VideoGames>> GetVideoGames(string genre)
		{
			return _svc.GetVideoGamesByGenre(genre);
		}

		// PUT: api/VideoGames/5
		[HttpPut("{id}")]
		public ActionResult<VideoGames> PutVideoGames(VideoGames videoGames)
		{
			return _svc.EditVideoGame(videoGames);
		}

		// POST: api/VideoGames
		[HttpPost]
        public ActionResult<VideoGames> PostVideoGames(VideoGames newVideoGames)
        {
            return _svc.AddVideoGame(newVideoGames);
        }

		//DELETE: api/VideoGames/5
        [HttpDelete("{id}")]
		public ActionResult<VideoGames> DeleteVideoGames(int id)
		{
			return _svc.DeleteVideoGame(id);
		}
	}
}
