using System;
using System.Linq;
using System.Collections.Generic;
using ScrumBoard.Data;
using ScrumBoard.Data.Models;

namespace ScrumBoard.Services
{
    public class ScrumTaskService : IScrumTaskService
    {
        private readonly ScrumBoardDbContext _db;

        public ScrumTaskService(ScrumBoardDbContext db)
        {
            _db = db;
        }

        public List<ScrumTask> GetAllScrumTasks()
        {
            return _db.ScrumTasks.ToList();
        }

        public ScrumTask GetScrumTask(int Id)
        {
            //OR var scrumTask = _db.ScrumTasks.FirstOrDefault(task => task.Id == Id);
            return _db.ScrumTasks.Find(Id);
        }

        public void AddScrumTask(ScrumTask scrumTask)
        {
            _db.Add(scrumTask);
            _db.SaveChanges();
        }

        public void DeleteScrumTask(int Id)
        {
            var taskToDelete = _db.ScrumTasks.Find(Id);
            if (taskToDelete != null)
            {
                _db.Remove(taskToDelete);
            }
            throw new InvalidOperationException("no tasks exists");
        }
    }
}
