using System;
// Id
// Name
// Data
namespace CoreWebApp.Web.Models
{
    public class ScrumTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskData { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
