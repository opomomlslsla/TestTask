using Captcha.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Captcha.Infrastructure.Data
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MousePositionData>().OwnsOne(
                m => m.PositionsData,
                builder =>
                {
                    builder.ToJson();
                }
                );
        }

        DbSet<MousePositionData> mousePositionData {  get; set; }
    }
}
