using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace otelRezervasyon1
{
    [Table("Table_Reservation")]
    public class Table_Reservation
    {
        [Key]
        public int Reservation_Id { get; set; }

        public int Guest_Id { get; set; }
        public int Room_Id { get; set; }

        public DateTime CheckIn_Date { get; set; }
        public DateTime CheckOut_Date { get; set; }

        public virtual Table_Guest Guest { get; set; }
        public virtual Table_Room Room { get; set; }
    }
}