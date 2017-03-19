using System;
using System.ComponentModel.DataAnnotations;

namespace TodoRepositoryLibrary
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Nullable date time.
        /// DateTime is value type and won’t allow nulls.
        /// DateTime? is nullable DateTime and will accept nulls.
        /// Use null when to-do completed date does not exist (e.g. to-do is still not completed )
        /// </summary>
        public DateTime? DateCompleted { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// User id that owns this TodoItem
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        public TodoItem(string text, Guid userId)
        {
            Id = Guid.NewGuid(); // Generates new unique identifier
            Text = text;
            IsCompleted = false;
            DateCreated = DateTime.Now; // Set creation date as current time
            UserId = userId;
        }

        public void MarkAsCompleted()
        {
            if (IsCompleted) return;
            IsCompleted = true;
            DateCompleted = DateTime.Now;
        }

        public TodoItem()
        {
            // entity framework needs this one
            // not for use :)
        }
    }
}
