using System;
using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3
{
	[TestClass]
	public class TodoItemTests
	{

		[TestMethod]
		public void MarkAsCompletedTest()
		{
			TodoItem testTodoItem = new TodoItem("tester123");
			Assert.AreEqual(testTodoItem.MarkAsCompleted(), true);
			Assert.AreEqual(testTodoItem.MarkAsCompleted(), false);
		}

		[TestMethod]
		public void EqualsTest()
		{
			TodoItem testTodoItem1 = new TodoItem("tester123");
			TodoItem testTodoItem2 = new TodoItem("tester321");

			Assert.AreEqual(testTodoItem1.Equals(testTodoItem2), false);
		}

	}
}