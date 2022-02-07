using System;
using System.ComponentModel.DataAnnotations;

namespace Jamatu.Auth.Core.Entity
{
    public class TokenEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
