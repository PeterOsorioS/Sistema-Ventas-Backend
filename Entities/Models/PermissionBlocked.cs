﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PermissionBlocked
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Permission {  get; set; }
    }
}
