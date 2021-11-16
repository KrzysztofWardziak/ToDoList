using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Moq;
using ToDoList.Application.InterfaceService;
using ToDoList.Application.Service;
using ToDoList.Application.ViewModels;
using ToDoList.Domain.InterfaceRepository;
using ToDoList.Domain.Model;
using ToDoList.Infrastructure.Repository;
using Xunit;

namespace ToDoList.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetAllTasks()
        {
            ToDo todo = new ToDo()
            {
                Description = "Test",
                Id = 1,
                IsDone = false,
                Title = "Test"
            };
            ToDo todo2 = new ToDo()
            {
                Description = "Test2",
                Id = 2,
                IsDone = false,
                Title = "Test2"
            };

            var todos = new List<ToDo>();
            todos.Add(todo);
            todos.Add(todo2);
            var todosV2 = todos.AsQueryable();

            var mock = new Mock<IToDoRepository>();
            mock.Setup(s => s.GetAllTasks()).Returns(todosV2);

            var returnedTasks = mock.Object.GetAllTasks();

            Assert.NotNull(returnedTasks);

        }

        [Fact]
        public void CanGetTaskById()
        {
            //Arrange
            ToDo todo = new ToDo()
            {
                Description = "Test", 
                Id = 1,
                IsDone = false,
                Title = "Test"
            };

            var mock = new Mock<IToDoRepository>();
            mock.Setup(s => s.GetTaskById(1)).Returns(todo);
            //Act
            var returnedItem = mock.Object.GetTaskById(todo.Id);

            //Assert
            Assert.Equal(todo, returnedItem);
        }

        [Fact]  
        public void CanDeleteTaskWithProperId()
        {
            ToDo todo = new ToDo()
            {
                Description = "Test",
                Id = 1,
                IsDone = false,
                Title = "Test"
            };

            var mock = new Mock<IToDoRepository>();
            mock.Setup(s => s.GetTaskById(1)).Returns(todo);
            mock.Setup(m => m.DeleteTask(todo.Id));

            mock.Object.DeleteTask(todo.Id);

            mock.Verify(s => s.DeleteTask(todo.Id));
        }
    }
}
