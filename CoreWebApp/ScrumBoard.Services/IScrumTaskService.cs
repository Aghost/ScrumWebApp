using System.Collections.Generic;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;

namespace ScrumBoard.Services
{
    public interface IScrumTaskService
    {
        public List<ScrumTask> GetAllScrumTasks();
        public ScrumTask GetScrumTask(int Id);
        public void AddScrumTask(ScrumTask scrumtask);
        public void DeleteScrumTask(int Id);
    }
}
