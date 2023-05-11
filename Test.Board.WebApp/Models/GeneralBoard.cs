using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Test.Board.WebApp.Models
{
    public class GeneralBoard
    {
        [Key]
        public int Number { get; set; }
        [Required(ErrorMessage = "제목을 입력하세요")]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required(ErrorMessage = "내용을 입력하세요")]
        public string Contents { get; set; }
        [Required(ErrorMessage = "작성자를 입력하세요")]
        [MaxLength(10)]
        public string Writer { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        [MaxLength(10)]
        public string? CategoryName { get; set; }
    }
}
