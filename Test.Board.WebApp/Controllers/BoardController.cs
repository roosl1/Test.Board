using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public IActionResult List(int? CategoryId)
        {
            var list = new List<GeneralBoard>();

            using (var db = new BoardDbContext())
            {

                if (CategoryId == null)
                {
                    list = db.Boards.ToList();
                }
                else
                {
                    var category = db.BoardCategories.Find(CategoryId);
                    var categoryName = category.Name;

                    if (categoryName.Equals("ALL"))
                        list = db.Boards.ToList();
                    else
                        list = db.Boards.Where(x => x.Category.Equals(categoryName)).ToList();

                    ViewData["SelectedCategory"] = CategoryId;
                }
                var categories = new SelectList(db.BoardCategories.ToList(), "Id", "Name");
                ViewData["GeneralBoardCategories"] = categories;
            }
            return View(list);
        }

        /// <summary>
        /// 게시글 작성 페이지로 이동
        /// </summary>
        /// <returns></returns>
        public IActionResult Write()
        {
            using (var db = new BoardDbContext())
            {
                var categories = new SelectList(db.BoardCategories.ToList(), "Id", "Name");
                ViewData["GeneralBoardCategories"] = categories;
            }
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
                    var category = db.BoardCategories.Find(Convert.ToInt32(model.Category));
                    var categoryName = category.Name;

                    model.Category = categoryName;
                    db.Boards.Add(model);

                    if (db.SaveChanges() > 0)
                        return Redirect("List");
                }
            }
            else
            {
                using (var db = new BoardDbContext())
                {
                    var categories = new SelectList(db.BoardCategories.ToList(), "Id", "Name");
                    ViewData["GeneralBoardCategories"] = categories;
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

                var category = db.BoardCategories.SingleOrDefault(n => n.Name.Equals(board.Category));
                ViewBag.CategoryId = category.Id;

                var categories = new SelectList(db.BoardCategories.ToList(), "Id", "Name");
                ViewData["GeneralBoardCategories"] = categories;

                return View(board);
            }
        }

        [HttpPost]
        public IActionResult Edit(int number, string writer, string title, string contents, int categoryId)
        {
            GeneralBoard board = new GeneralBoard();
            if (ModelState.IsValid)
            {
                using (var db = new BoardDbContext())
                {
                    var updateBoard = db.Boards.FirstOrDefault(n => n.Number.Equals(number));
                    var category = db.BoardCategories.Find(categoryId);
                    var categoryName = category.Name;

                    updateBoard.Category = categoryName;
                    updateBoard.Writer = writer;
                    updateBoard.Title = title;
                    updateBoard.Contents = contents;

                    db.SaveChanges();
                    
                    return Json(new { result = 0 });
                }
            }
            else
            {
                using (var db = new BoardDbContext())
                {
                    var categories = new SelectList(db.BoardCategories.ToList(), "Id", "Name");
                    ViewData["GeneralBoardCategories"] = categories;
                }
                if (categoryId == 0)
                    return Json(new { result = -1, msg = "카테고리를 선택해주세요." });
            }
            return View(board);
        }

        /// <summary>
        /// 게시글 삭제
        /// </summary>
        /// <param name="No"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int number)
        {
            using (var db = new BoardDbContext())
            {
                var board = db.Boards.FirstOrDefault(n => n.Number.Equals(number));
                db.Boards.Remove(board);
                if (db.SaveChanges() > 0)
                    return Json(new { result = 0 });
                else
                    return View(board);
            }

        }
    }
}
