using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	public interface ITodoRepository 
	{
		TodoItem Get(Guid todoId);
		TodoItem Add(TodoItem todoItem);
		bool Remove(Guid todoId);
		TodoItem Update(TodoItem todoItem);
		bool MarkAsCompleted(Guid todoId);
		List<TodoItem> GetAll();
		List<TodoItem> GetActive();
		List<TodoItem> GetCompleted();
		List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
	}
	

	public class TodoItem
	{
		public Guid Id { get; }
		public string Text { get; set; }
		public bool IsCompleted => DateCompleted.HasValue;
		public DateTime? DateCompleted { get; set; }
		public DateTime DateCreated { get; set; }

		public TodoItem(string text) {
			Id = Guid.NewGuid();
			DateCreated = DateTime.UtcNow;
			Text = text;
		}

		public bool MarkAsCompleted() 
		{
			if (!IsCompleted) 
			{
				DateCompleted = DateTime.Now;
				return true;
			}
			return false;
		}

		public override bool Equals(object o) {
			if (ReferenceEquals(o, null)) return false;
			return Equals((TodoItem)o);
		}
		public bool Equals(TodoItem todoItem) {
			if (ReferenceEquals(todoItem, null)) return false;
			return this.Id.Equals(todoItem.Id);
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}

		
	}
}

