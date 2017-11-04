using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Assignment2 
{
	public class TodoRepository : ITodoRepository {
		private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

		public TodoRepository(IGenericList<TodoItem> initialDbState = null)
		{
			_inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
		}

		public TodoItem Get(Guid todoId)
		{
			if (_inMemoryTodoDatabase.Count == 0) return null;
			return _inMemoryTodoDatabase.FirstOrDefault(t => t.Id == todoId);
		}

		public TodoItem Add(TodoItem todoItem)
		{
			if (_inMemoryTodoDatabase.Contains(todoItem))
				throw new DuplicateTodoItemException("duplicate id: {" + todoItem.Id + "}");

			_inMemoryTodoDatabase.Add(todoItem);
			return _inMemoryTodoDatabase.Last();
		}

		public bool Remove(Guid todoId)
		{
			if (_inMemoryTodoDatabase.Count == 0 || Get(todoId) == null) return false;
			return _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.FirstOrDefault(t => t.Id == todoId));
		}

		public TodoItem Update(TodoItem todoItem)
		{
			if (_inMemoryTodoDatabase.Contains(todoItem) == false)
			{
				return Add(todoItem);
			}
			_inMemoryTodoDatabase.Remove(todoItem);
			return Add(todoItem);
		}

		public bool MarkAsCompleted(Guid todoId)
		{
			if (_inMemoryTodoDatabase.Count == 0 || Get(todoId) == null) return false;
			return _inMemoryTodoDatabase.First(t => t.Id == todoId).MarkAsCompleted();
		}

		public List<TodoItem> GetAll()
		{
			return _inMemoryTodoDatabase.OrderByDescending(t => t.DateCreated).ToList();
		}

		public List<TodoItem> GetActive()
		{
			return _inMemoryTodoDatabase.Where(t => t.IsCompleted == false).ToList();
		}

		public List<TodoItem> GetCompleted()
		{
			return _inMemoryTodoDatabase.Where(t => t.IsCompleted == true).ToList();
		}

		public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
		{
			return _inMemoryTodoDatabase.Where(t => filterFunction(t) == true).ToList();
		}
	}
}
