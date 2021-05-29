using ScrumBoard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ScrumBoard.Data {
    public class ScrumBoardDbContext : DbContext {
        //public ScrumBoardDbContext() { }
        public ScrumBoardDbContext(DbContextOptions<ScrumBoardDbContext> options) : base(options) { }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<ScrumTask> ScrumTasks { get; set; }
    }
}
