using System;
using System.Linq;
using System.Collections.Generic;
using CoreWebApp.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Web.Models
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<ScrumTask> Task { get; set; }
    }
}