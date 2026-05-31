using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace otelRezervasyon1
{
    [Table("Table_Room")]
    public class Table_Room
    {
        [Key]
        public int Room_Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Room_Number { get; set; }

        [Required]
        public decimal Room_Price { get; set; }

        public int RoomType_Id { get; set; }

        public virtual Table_RoomType RoomType { get; set; }

        public virtual ICollection<Table_Reservation> Reservations { get; set; }
    }
}