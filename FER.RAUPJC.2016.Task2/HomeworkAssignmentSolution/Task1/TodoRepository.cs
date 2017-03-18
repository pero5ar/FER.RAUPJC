using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Task3;

namespace Repositories
{
    /// <summary>
    /// Class that encapsulates all the logic for accessing TodoTtems.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// Repository does not fetch todoItems from the actual database,
        /// it uses in memory storage for this excersise.
        /// </summary>
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            // can't use ?? operator on IGenericList
            _inMemoryTodoDatabase = (initialDbState != null) ? initialDbState : new GenericList<TodoItem>();
        }


        public void Add(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }
            if (_inMemoryTodoDatabase.Any(T => T.Id.Equals(todoItem.Id)))
            {
                throw new DuplicateTodoItemException("duplicate ID: " + todoItem.Id.ToString());
            }
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(T => T.Id.Equals(todoId)).FirstOrDefault(); 
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(T => !T.IsCompleted).OrderByDescending(T => T.DateCreated).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(T => T.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(T => T.IsCompleted).OrderByDescending(T => T.DateCreated).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).OrderByDescending(T => T.DateCreated).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            var item = Get(todoId);
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            if (!item.IsCompleted)
            {
                item.MarkAsCompleted();
                return true;
            }
            return false;
        }

        public bool Remove(Guid todoId)
        {
            var item = Get(todoId);
            _inMemoryTodoDatabase.Remove(item);
            return (item != null);
        }

        public void Update(TodoItem todoItem)
        {
            if (todoItem == null)
            {
                throw new ArgumentNullException();
            }
            if (Remove(todoItem.Id))
            {
                _inMemoryTodoDatabase.Add(todoItem);
            }
            else
            {
                Add(todoItem);
            }
        }
    }
}
