﻿using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class Address : BaseEntity
    {
        [Required]
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}