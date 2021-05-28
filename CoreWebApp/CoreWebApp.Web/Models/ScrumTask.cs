using System;
using System.ComponentModel.DataAnnotations;
// Id
// Name
// Data
namespace CoreWebApp.Web.Models
{
    public enum Status
    {
        Todo,
        Done
    }
    public class ScrumTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public Status Status { get; set; }
        public string TaskDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0-yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0-yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }
    }
}
