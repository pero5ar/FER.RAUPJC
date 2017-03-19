using Repositories;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interfaces;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ClassLibraryTests
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Add(null);
        }

        [TestMethod]
        public void AddingItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddingExistingItemWillThrowException()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem(" Groceries ");
            repository.Add(todoItem);
            repository.Add(todoItem);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdatingNullToDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.Update(null);
        }

        [TestMethod]
        public void UpdatingNewItemWillAddToDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Update(todoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsTrue(repository.Get(todoItem.Id) != null);
        }

        [TestMethod]
        public void UpdateingExistingDatabaseItemWillChangeAttribute()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Fruit");
            repository.Add(todoItem);
            var newTodoItem = new TodoItem("Apple");
            var id = newTodoItem.Id = todoItem.Id;
            repository.Update(newTodoItem);
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.AreEqual(newTodoItem.Text, repository.Get(id).Text);
        }

        [TestMethod]
        public void GettingExistingItemFromDatabaseReturnsItem()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            Assert.AreEqual(todoItem, repository.Get(todoItem.Id));
        }

        [TestMethod]
        public void GettingNonExistingItemFromDatabaseReturnsNull()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Groceries");
            repository.Add(todoItem);
            Guid newId;
            while ( (newId = Guid.NewGuid()).Equals(todoItem) );
            Assert.AreEqual(null, repository.Get(newId));
        }

        [TestMethod]
        public void RemovingNonExistingItemReturnsFalseAndWillNotRemoveItemFromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Fruit");
            repository.Add(todoItem);
            var newTodoItem = new TodoItem("Apple");
            var result = repository.Remove(newTodoItem.Id);
            Assert.AreEqual(false, result);
            Assert.AreEqual(1, repository.GetAll().Count);
        }

        [TestMethod]
        public void RemovingExistingItemFReturnsTrueAndWillRemoveItemromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Fruit");
            repository.Add(todoItem);
            var result = repository.Remove(todoItem.Id);
            Assert.AreEqual(true, result);
            Assert.AreEqual(0, repository.GetAll().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MarkingAsCompletedNonExistingItemInDatabaseThrowsException()
        {
            ITodoRepository repository = new TodoRepository();
            repository.MarkAsCompleted(Guid.NewGuid());
        }

        [TestMethod]
        public void MarkingAsCompletedActiveItemReturnsTrueAndMarksItemAsCompletedInDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Fruit");
            repository.Add(todoItem);
            Assert.AreEqual(true, repository.MarkAsCompleted(todoItem.Id));
            Assert.AreEqual(true, repository.Get(todoItem.Id).IsCompleted);
        }

        [TestMethod]
        public void MarkingAsCompletedInDatabaseCompletedItemReturnsFalse()
        {
            ITodoRepository repository = new TodoRepository();
            var todoItem = new TodoItem("Fruit");
            todoItem.MarkAsCompleted();
            repository.Add(todoItem);
            Assert.AreEqual(false, repository.MarkAsCompleted(todoItem.Id));
        }

        [TestMethod]
        public void GetingAllReturnsItemsListInDescendingOrderByDateCreatedFromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var list = new List<TodoItem>();

            // create items in order
            var todoItem1 = new TodoItem("First");
            Thread.Sleep(1);
            var todoItem2 = new TodoItem("Second");
            Thread.Sleep(1);
            var todoItem3 = new TodoItem("Third");
            Thread.Sleep(1);

            // add to list in descending order
            list.Add(todoItem3);
            list.Add(todoItem2);
            list.Add(todoItem1);

            // add to repository in random order
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem1);

            // test
            CollectionAssert.AreEqual(list, repository.GetAll());
        }

        [TestMethod]
        public void GettingActiveReturnsNotCompletedItemsListFromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var list = new List<TodoItem>();

            // create items
            var todoItem1 = new TodoItem("First");
            todoItem1.MarkAsCompleted();
            var todoItem2 = new TodoItem("Second");
            var todoItem3 = new TodoItem("Third");

            // add to list 
            list.Add(todoItem2);
            list.Add(todoItem3);

            // add to repository
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem1);

            // test
            CollectionAssert.AreEquivalent(list, repository.GetActive());
        }

        [TestMethod]
        public void GettingCompletedReturnsCompletedItemsListFromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var list = new List<TodoItem>();

            // create items
            var todoItem1 = new TodoItem("First");
            todoItem1.MarkAsCompleted();
            var todoItem2 = new TodoItem("Second");
            todoItem2.MarkAsCompleted();
            var todoItem3 = new TodoItem("Third");

            // add to list 
            list.Add(todoItem2);
            list.Add(todoItem1);

            // add to repository
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem1);

            // test
            CollectionAssert.AreEquivalent(list, repository.GetCompleted());
        }

        public void GettingFilteredReturnsItemsThatSatisfyFilterListFromDatabase()
        {
            ITodoRepository repository = new TodoRepository();
            var list = new List<TodoItem>();

            // create items
            var todoItem1 = new TodoItem("A_First");
            var todoItem2 = new TodoItem("A_Second");
            var todoItem3 = new TodoItem("Third");

            // add to list items which start with 'A'
            list.Add(todoItem2);
            list.Add(todoItem1);

            // add to repository
            repository.Add(todoItem2);
            repository.Add(todoItem3);
            repository.Add(todoItem1);

            // test
            CollectionAssert.AreEquivalent(list, repository.GetFiltered(t => t.Text.StartsWith("A")));
        }

    }
}
