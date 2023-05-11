using Microsoft.AspNetCore.Mvc.Rendering;

namespace Test.Board.WebApp.Models
{
    public class GeneralBoardDto
    {
        public int? Number { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public string? Writer { get; set; }
        public DateTime? Date { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? SelectedItem { get; set; }
        public SelectList? Categories { get; set; }
        public List<SelectListItem>? selectListItems { get; set; }
        public List<GeneralBoard>? generalBoards { get; set; }
        public List<GeneralBoardCategory>? generalBoardCategories { get; set; }
    }
}
