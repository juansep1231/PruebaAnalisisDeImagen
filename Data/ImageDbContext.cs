using Microsoft.EntityFrameworkCore;

namespace PruebaAnalisisDeImagen.Data
{
    public class ImageDbContext : DbContext
    {
        public DbSet<ImageDTO> ImgData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=imgData.db");
        }
    }
}
