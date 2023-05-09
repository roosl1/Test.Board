using System.ComponentModel.DataAnnotations;

namespace Test.Board.WebApp.Models
{
    public class GeneralBoard
    {
        [Key]
        public int Number { get; set; }
        [Required(ErrorMessage = "제목을 입력하세요")]
        public string Title { get; set; }
        [Required(ErrorMessage = "내용을 입력하세요")]
        public string Contents { get; set; }
        [Required(ErrorMessage = "작성자를 입력하세요")]
        public string Writer { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "카테고리를 선택해주세요.")]
        [RegularExpression("^(?!ALL$).+")]
        public string Category { get; set; }
    }
}
