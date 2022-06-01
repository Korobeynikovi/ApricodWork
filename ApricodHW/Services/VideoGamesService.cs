using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApricodHW.Models;
using ApricodHW.Services;

namespace ApricodHW.Services
{
	public interface IVideoGamesService
	{
		ActionResult<IEnumerable<VideoGames>> GetVideoGames();
		ActionResult<VideoGames> GetVideoGameById(int id);
		ActionResult<VideoGames> AddVideoGame(VideoGames videoGames);
		ActionResult<VideoGames> DeleteVideoGame(int id);
		ActionResult<IEnumerable<VideoGames>> GetVideoGamesByGenre(string genre);
		ActionResult<VideoGames> EditVideoGame(VideoGames videoGames);

	}
	public class VideoGamesService : IVideoGamesService
	{
		private readonly VideoGamesContext _context;
		
		public VideoGamesService(VideoGamesContext context)
		{
			_context = context;
		}

		public ActionResult<IEnumerable<VideoGames>> GetVideoGames()
		{
			List<VideoGames> videoGames = _context.VideoGames.ToList();

			return videoGames;
		}
		public ActionResult<VideoGames> GetVideoGameById(int id)
		{
			var videoGames = _context.VideoGames.Find(id);

			if (videoGames == null)
				throw new ArgumentNullException("VideoGame");

			return videoGames;
		}
		public ActionResult<VideoGames> AddVideoGame(VideoGames videoGames)
		{
			_context.VideoGames.Add(videoGames);
			_context.SaveChanges();

			return videoGames;
		}
		public ActionResult<VideoGames> DeleteVideoGame(int id)
		{
			var videoGames = _context.VideoGames.Find(id);

			if (videoGames == null)
				throw new ArgumentNullException();

			_context.VideoGames.Remove(videoGames);
			_context.SaveChanges();

			return videoGames;
		}
		public ActionResult<IEnumerable<VideoGames>> GetVideoGamesByGenre(string genre)
		{
			var videoGames = _context.VideoGames.Where(x => x.Genre.Contains(genre)).ToList();

			if (videoGames == null)
				throw new ArgumentNullException("VideoGames");

			return videoGames;
		}
		public ActionResult<VideoGames> EditVideoGame(VideoGames videoGames)
		{
			bool res = _context.VideoGames.Any(e => e.Id == videoGames.Id);

			//if (videoGames.Id != videoGames.Id)
			//	throw new ArgumentNullException();

			var gameToEdit = _context.VideoGames.Find(videoGames.Id);
			if (gameToEdit == null)
				throw new ArgumentNullException("GameToEdit");

			gameToEdit.Name = videoGames.Name;
			gameToEdit.Developer = videoGames.Developer;
			gameToEdit.Genre = videoGames.Genre;

			try
			{
				_context.SaveChanges();
				return gameToEdit;
			}
			catch (DbUpdateConcurrencyException) when (!res)
			{
				throw new ArgumentNullException("CATCH");
			}
		}
	}
}
