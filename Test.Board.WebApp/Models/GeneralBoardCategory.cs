using System.ComponentModel.DataAnnotations;

namespace Test.Board.WebApp.Models
{
    public class GeneralBoardCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
