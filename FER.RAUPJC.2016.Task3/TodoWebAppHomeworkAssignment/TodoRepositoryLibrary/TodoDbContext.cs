using System.Data.Entity;

namespace TodoRepositoryLibrary
{
    public class TodoDbContext : System.Data.Entity.DbContext
    {
        public IDbSet<TodoItem> TodoItems { get; set; }

        public TodoDbContext(string connectionString) : base(connectionString) { }
        
    }
}
