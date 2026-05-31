using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace otelRezervasyon1
{
    [Table("Table_Guest")]
    public class Table_Guest
    {
        [Key]
        public int Guest_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Guest_Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Guest_Surname { get; set; }

        [MaxLength(20)]
        public string Guest_Phone { get; set; }

        [MaxLength(50)]
        public string Guest_Email { get; set; }

        public virtual ICollection<Table_Reservation> Reservations { get; set; }
    }
}