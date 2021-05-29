using System;
using System.ComponentModel.DataAnnotations;
// Id
// Name
// Data
namespace ScrumBoard.Data.Models
{
    public enum Status
    {
        Doing,
        Todo,
        Done
    }
    public class ScrumTask
    {
        public int ScrumTaskId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(64)]
        public string TaskName { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(256)]
        public string TaskDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0-yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0-yyyy-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime UpdatedOn { get; set; }
    }
}