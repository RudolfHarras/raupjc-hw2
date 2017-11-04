using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3
{
	[TestClass]
	public class TodoRepositoryTests
	{
		[TestMethod]
		public void TodoRepositoryTest()
		{
			GenericList<TodoItem> testGenericList = new GenericList<TodoItem>();
			for (int i = 0; i < 100; i++)
			{
				testGenericList.Add(new TodoItem(i.ToString()));
			}
			TodoRepository testTodoRepository = new TodoRepository(testGenericList);
			for (int i = 0; i < 100; i++)
			{
				Assert.AreEqual(testTodoRepository.Get(testGenericList.GetElement(i).Id), testGenericList.GetElement(i));
			}
		}

		[TestMethod]
		public void GetTest()
		{
			TodoRepository testRepository = new TodoRepository();
			TodoItem testTodoItem = new TodoItem("tester123");
			testRepository.Add(testTodoItem);
			Assert.AreEqual(testTodoItem, testRepository.Get(testTodoItem.Id));
		}

		[TestMethod]
		public void AddTest()
		{
			TodoRepository testTodoRepository = new TodoRepository();
			TodoItem testItem = new TodoItem("tester123");
			Assert.AreEqual(testTodoRepository.Add(testItem), testItem);
		}

		[TestMethod]
		[ExpectedException(typeof(DuplicateTodoItemException))]
		public void AddTestException()
		{
			TodoRepository testRepository = new TodoRepository();
			TodoItem testTodoItem = new TodoItem("tester123");
			testRepository.Add(testTodoItem);
			testRepository.Add(testTodoItem);
		}

		[TestMethod]
		public void RemoveTest()
		{
			TodoRepository testTodoRepository = new TodoRepository();
			TodoItem testTodoItem1 = new TodoItem("tester123");
			TodoItem testTodoItem2 = new TodoItem("tester321");
			testTodoRepository.Add(testTodoItem1);
			testTodoRepository.Add(testTodoItem2);
			Assert.AreEqual(testTodoRepository.Remove(testTodoItem1.Id), true);
			Assert.AreEqual(testTodoRepository.Remove(testTodoItem1.Id), false);
			Assert.AreEqual(testTodoRepository.Remove(new Guid()), false);
		}

		[TestMethod]
		public void UpdateTest()
		{
			TodoRepository todoRepository = new TodoRepository();
			TodoItem todoItem = new TodoItem("tester123");
			todoRepository.Add(todoItem);
			todoItem.Text = "tester321";
			todoRepository.Update(todoItem);
			Assert.AreEqual(todoRepository.Get(todoItem.Id).Text, "tester321");
		}

		[TestMethod]
		public void MarkAsCompletedTest()
		{
			TodoRepository testTodoRepository = new TodoRepository();
			TodoItem testTodoItem1 = new TodoItem("tester123");
			testTodoRepository.Add(testTodoItem1);

			Assert.AreEqual(testTodoRepository.MarkAsCompleted(testTodoItem1.Id), true);
			Assert.AreEqual(testTodoRepository.MarkAsCompleted(testTodoItem1.Id), false);
		}

		[TestMethod]
		public void GetAllTest()
		{
			GenericList<TodoItem> testGenericList = new GenericList<TodoItem>();
			for (int i = 0; i < 101; i++)
			{
				testGenericList.Add(new TodoItem(i.ToString()));
			}
			TodoRepository testTodoRepository = new TodoRepository(testGenericList);

			List<TodoItem> testList = testTodoRepository.GetAll();
			int testAdding = testList.Sum(number => int.Parse(number.Text));
			Assert.AreEqual(testAdding, 5050);
		}

		[TestMethod]
		public void GetActiveTest()
		{
			GenericList<TodoItem> testGenericList = new GenericList<TodoItem>();
			for (int i = 0; i < 100; i++)
			{
				testGenericList.Add(new TodoItem(i.ToString()));
			}
			TodoRepository testTodoRepository = new TodoRepository(testGenericList);

			testTodoRepository.MarkAsCompleted(testGenericList.GetElement(2).Id);
			testTodoRepository.MarkAsCompleted(testGenericList.GetElement(30).Id);
			Assert.AreEqual(testTodoRepository.GetActive().Count, 98);
		}

		[TestMethod]
		public void GetCompletedTest()
		{
			GenericList<TodoItem> testGenericList = new GenericList<TodoItem>();
			for (int i = 0; i < 100; i++)
			{
				testGenericList.Add(new TodoItem(i.ToString()));
			}
			TodoRepository testTodoRepository = new TodoRepository(testGenericList);

			testTodoRepository.MarkAsCompleted(testGenericList.GetElement(2).Id);
			testTodoRepository.MarkAsCompleted(testGenericList.GetElement(30).Id);
			testTodoRepository.MarkAsCompleted(testGenericList.GetElement(55).Id);

			Assert.AreEqual(testTodoRepository.GetCompleted().Count, 3);
		}

		[TestMethod]
		public void GetFilteredTest()
		{
			GenericList<TodoItem> testGenericList = new GenericList<TodoItem>();
			for (int i = 0; i < 5; i++)
			{
				testGenericList.Add(new TodoItem(i.ToString()));
			}
			TodoRepository testTodoRepository = new TodoRepository(testGenericList);
			List<TodoItem> testList1 = testTodoRepository.GetFiltered(i => i.Text.Equals("2"));
			List<TodoItem> testList2 = testGenericList.Where(i => i.Text.Equals("2")).ToList();
			Assert.AreEqual(testList1[0], testList2[0]);
		}
	}
}