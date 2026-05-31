using System.Data.Entity;

namespace otelRezervasyon1
{
    public class otelRezervasyon1Context : DbContext
    {
        public otelRezervasyon1Context() : base("name=otelRezervasyon1Context") { }

        public DbSet<Table_Guest> Table_Guest { get; set; }
        public DbSet<Table_Room> Table_Room { get; set; }
        public DbSet<Table_RoomType> Table_RoomType { get; set; }
        public DbSet<Table_Reservation> Table_Reservation { get; set; }
    }
}