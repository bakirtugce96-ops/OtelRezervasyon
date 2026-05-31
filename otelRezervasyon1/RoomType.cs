using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace otelRezervasyon1
{
    [Table("Table_RoomType")]
    public class Table_RoomType
    {
        [Key]
        public int RoomType_Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string RoomType_Name { get; set; }

        public virtual ICollection<Table_Room> Rooms { get; set; }
    }
}