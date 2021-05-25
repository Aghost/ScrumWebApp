using System;
using System.Linq;
using System.Collections.Generic;
using CoreWebApp.Web.Models;
// Id
// Name
// Data
namespace CoreWebApp.Web.Models {
    public class Board {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public List<ScrumTask> Task { get; set; }
    }
}
