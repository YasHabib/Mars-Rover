using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Mars_Rover.Models.Entities
{
    public class BaseEntity<TId>
    {
        [Key]
        public TId? Id { get; set; }
    }
}
