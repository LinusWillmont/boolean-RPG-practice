using RpgApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgApi.Models
{
    [Table("characters")]
    public class Character
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Player")]
        [Column("player_id")]
        public required string Player_Id { get; set; }
        public Player Player { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("class")]
        public required Class Class {  get; set; }

        [Column("leve")]
        public int Level { get; set; } = 1;

        [Column("gold")]
        public int Gold { get; set; } = 0;
    }
}
