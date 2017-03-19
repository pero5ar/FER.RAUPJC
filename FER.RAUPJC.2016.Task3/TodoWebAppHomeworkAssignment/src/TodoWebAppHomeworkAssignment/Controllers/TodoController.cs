using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoRepositoryLibrary;
using TodoWebAppHomeworkAssignment.Models;
using TodoWebAppHomeworkAssignment.Models.TodoViewModels;

namespace TodoWebAppHomeworkAssignment.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TodoController(ITodoRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var activeTodos = _repository.GetActive(await GetCurrentUserIdAsync());
            return View(activeTodos);
        }

        public async Task<IActionResult> CompleteTodo(Guid todoId)
        {
            _repository.MarkAsCompleted(todoId, await GetCurrentUserIdAsync());
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTodoViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var todo = new TodoItem(model.Text, await GetCurrentUserIdAsync());
            _repository.Add(todo);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Completed()
        {
            var completedTodos = _repository.GetCompleted(await GetCurrentUserIdAsync());
            return View(completedTodos);
        }

        private async Task<Guid> GetCurrentUserIdAsync()
        {
            var user = await GetCurrentUserAsync();
            return new Guid(user.Id);
        }

        // copied from: ManageController.cs
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

    }
}