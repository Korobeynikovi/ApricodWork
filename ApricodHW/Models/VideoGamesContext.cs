using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ApricodHW.Models
{
	public class VideoGamesContext : DbContext
	{
		public VideoGamesContext(DbContextOptions<VideoGamesContext> options)
			: base(options)
		{

		}
		public DbSet<VideoGames> VideoGames { get; set; } = null!;
	}
}
