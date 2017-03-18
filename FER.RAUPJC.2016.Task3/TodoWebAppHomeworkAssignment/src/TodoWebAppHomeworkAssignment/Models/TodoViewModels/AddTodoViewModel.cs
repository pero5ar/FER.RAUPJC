using System.ComponentModel.DataAnnotations;

namespace TodoWebAppHomeworkAssignment.Models.TodoViewModels
{
    public class AddTodoViewModel
    {
        [Required]
        public string Text { get; set; }
    }
}
