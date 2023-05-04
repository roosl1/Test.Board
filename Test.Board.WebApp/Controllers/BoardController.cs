using Microsoft.AspNetCore.Mvc;
using Test.Board.WebApp.DataContext;
using Test.Board.WebApp.Models;

namespace Test.Board.WebApp.Controllers
{
    public class BoardController : Controller
    {
        /// <summary>
        /// 게시판 리스트
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            using (var db = new BoardDbContext())
            {
                var list = db.Boards.ToList();
                return View(list);
            }
        }

        /// <summary>
        /// 게시글 작성 페이지로 이동
        /// </summary>
        /// <returns></returns>
        public IActionResult Write()
        {
            return View();
        }

        /// <summary>
        /// 게시글 추가
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Write(GeneralBoard model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BoardDbContext())
                {
                    db.Boards.Add(model);

                    if (db.SaveChanges() > 0)
                    {
                        return Redirect("List");
                    }

                    ModelState.AddModelError(string.Empty, "게시글을 저장할 수 없습니다");
                }
            }
            return View(model);
        }

        /// <summary>
        /// 게시글 상세 페이지로 이동
        /// </summary>
        /// <returns></returns>
        public IActionResult Detail(int No)
        {
            using (var db = new BoardDbContext())
            {
                var board = db.Boards.FirstOrDefault(n => n.Number.Equals(No));
                return View(board);
            }
        }

        /// <summary>
        /// 게시글 수정 페이지로 이동
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        public IActionResult Edit(int No)
        {
            using (var db = new BoardDbContext())
            {
                var board = db.Boards.FirstOrDefault(n => n.Number.Equals(No));
                return View(board);
            }
        }

        [HttpPost]
        public IActionResult Edit(int number, string writer, string title, string contents)
        {
            GeneralBoard board = new GeneralBoard();
            if (ModelState.IsValid)
            {
                using (var db = new BoardDbContext())
                {
                    var updateBoard = db.Boards.FirstOrDefault(n => n.Number.Equals(number));

                    updateBoard.Writer = writer;
                    updateBoard.Title = title;
                    updateBoard.Contents = contents;

                    if (db.SaveChanges() > 0)
                    {
                        return Json(new { result = 0 });
                    }
                }
            }
            return View(board);
        }
    }
}
