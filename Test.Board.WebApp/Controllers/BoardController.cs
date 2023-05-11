using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            using (var db = new BoardDbContext())
            {
                var categories = db.BoardCategories;
                    
                var boards = from board in db.Boards
                           join category in db.BoardCategories
                           on board.CategoryId equals category.Id
                           select board;

                var boardDto = new GeneralBoardDto
                {
                    generalBoards = boards.ToList(),
                    Categories = new SelectList(categories.ToList(), "Id", "Name") 
                };

                if(CategoryId != null)
                {
                    boardDto.generalBoards = boardDto.generalBoards.Where(x => x.CategoryId == CategoryId).ToList();
                    boardDto.SelectedItem = CategoryId;
                }

                return View(boardDto);
            }
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
                    var categoryName = (from category in db.BoardCategories where category.Id == model.CategoryId select category.Name).FirstOrDefault();
                    model.CategoryName = categoryName;

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
                var boards = (
                    from board in db.Boards
                    join category in db.BoardCategories
                    on board.CategoryId equals category.Id
                    where board.Number == No
                    select board).FirstOrDefault();

                var boardDto = new GeneralBoardDto
                {
                    Number = boards.Number,
                    Title = boards.Title,
                    Contents = boards.Contents,
                    Writer = boards.Writer,
                    Date = boards.Date,
                    CategoryId = boards.CategoryId,
                    CategoryName = boards.CategoryName
                };

                return View(boardDto);
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
                var categories = db.BoardCategories
                    .ToList()
                    .Select(x => new SelectListItem 
                    { 
                        Value = Convert.ToString(x.Id),
                        Text= x.Name
                    });

                var boards = (
                    from board in db.Boards
                    join category in db.BoardCategories
                    on board.CategoryId equals category.Id
                    where board.Number == No
                    select board).FirstOrDefault();

                var boardDto = new GeneralBoardDto
                {
                    Number = boards.Number,
                    Title = boards.Title,
                    Contents = boards.Contents,
                    Writer = boards.Writer,
                    Date = boards.Date,
                    CategoryId = boards.CategoryId,
                    CategoryName = boards.CategoryName,
                    SelectedItem = boards.CategoryId,
                    selectListItems = categories.ToList()
                };

                return View(boardDto);
            }
        }

        [HttpPost]
        public IActionResult Edit(int number, string writer, string title, string contents, int categoryId)
        {
            using (var db = new BoardDbContext())
            {
                var board = new GeneralBoard();

                var categoryName = (from category in db.BoardCategories where category.Id == categoryId select category.Name).FirstOrDefault();

                if (ModelState.IsValid)
                {
                    var recordToUpdate = db.Boards.FirstOrDefault(x => x.Number.Equals(number));
                    if (recordToUpdate != null)
                    {
                        recordToUpdate.Writer = writer;
                        recordToUpdate.Title = title;
                        recordToUpdate.Contents = contents;
                        recordToUpdate.CategoryId = categoryId;
                        recordToUpdate.CategoryName = categoryName;

                        db.SaveChanges();

                        return Json(new { result = 0 });
                    }
                }
                else
                {
                    if (categoryId == 0)
                        return Json(new { result = -1, msg = "카테고리를 선택해주세요." });
                }
                return View(board);
            }
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
                    return View();
            }

        }
    }
}
