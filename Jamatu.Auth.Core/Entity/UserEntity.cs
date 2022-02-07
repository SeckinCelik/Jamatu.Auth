using Jamatu.Auth.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jamatu.Auth.Core.Model.Entity
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [ForeignKey("UserId")]
        public virtual ICollection<TokenEntity> Tokens { get; set; }
    }
}
