using CoreWebApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Web.Data
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext _db;

        public BoardService(ApplicationDbContext db)
        {
            _db = db;
        }


        public List<Board> GetAllBoards()
        {
            return _db.Boards.ToList();
        }

        public Board GetBoard(int Id)
        {
            return _db.Boards.Find(Id);
        }

        public void AddBoard(Board board)
        {
            _db.Add(board);
            _db.SaveChanges();
        }

    }
}
