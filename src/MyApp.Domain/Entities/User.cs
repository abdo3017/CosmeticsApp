﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Core.Models;
using MyApp.Domain.Enums;

namespace MyApp.Domain.Entities
{
    public class User : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
