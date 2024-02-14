using Microsoft.AspNetCore.Identity;
using RpgApi.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RpgApi.Models
{
    [Table("players")]
    public class Player : IdentityUser
    {
        public bool IsBanned { get; set; } = false;
        public Roles Role { get; set; } = Roles.Player;
    }
}
