using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace TodoRepositoryLibrary
{
    public class TodoSqlRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoSqlRepository(TodoDbContext context)
        {
            _context = context;
        }

        public TodoItem Get(Guid todoId, Guid userId)
        {
            var item = _context.TodoItems.FirstOrDefault(T => T.Id.Equals(todoId));
            if (item == null)
            {
                return null;
            }
            if (!userId.Equals(item.UserId))
            {
                 throw new TodoAccessDeniedException($"User {userId} does not own {userId}");
            }
            return item;
        }

        public void Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem), "Todo item cant be null");
            }
            if (_context.TodoItems.Select(t => t.Id).Contains(todoItem.Id))
            {
                throw new DuplicateTodoItemException($"Duplicate Id: {todoItem.Id}");
            }
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

        public bool Remove(Guid todoId, Guid userId)
        {
            var item = _context.TodoItems.FirstOrDefault(T => T.Id.Equals(todoId));
            if (item == null)
            {
                return false;
            }
            if (!userId.Equals(item.UserId))
            {
                throw new TodoAccessDeniedException($"User {userId} does not own {userId}");
            }
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public void Update(TodoItem todoItem, Guid userId)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException(nameof(todoItem), "Todo item cant be null");
            }
            _context.TodoItems.AddOrUpdate(todoItem);
            _context.SaveChanges();
        }

        public bool MarkAsCompleted(Guid todoId, Guid userId)
        {
            var item = Get(todoId, userId);
            if (item == null)
            {
                return false;
            }
            if (item.IsCompleted)
            {
                return false;
            }
            item.MarkAsCompleted();
            _context.TodoItems.AddOrUpdate(item);
            _context.SaveChanges();
            return true;
        }

        public List<TodoItem> GetAll(Guid userId)
        {
            return _context.TodoItems.Where(t => t.UserId.Equals(userId)).OrderByDescending(t => t.DateCreated).ToList();
        }

        public List<TodoItem> GetActive(Guid userId)
        {
            return GetAll(userId).Where(t => !t.IsCompleted).ToList();
        }

        public List<TodoItem> GetCompleted(Guid userId)
        {
            return GetAll(userId).Where(t => t.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction, Guid userId)
        {
            return GetAll(userId).Where(filterFunction).ToList();
        }
    }
}
