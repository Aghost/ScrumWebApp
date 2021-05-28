using CoreWebApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Web.Data
{
    public class IBoardService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ScrumTask> Task { get; set; }
    }
}
