using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Domain.Model;

namespace ToDoList.Domain.InterfaceRepository
{
    public interface IToDoRepository
    {
        IQueryable<ToDo> GetAllTasks();
        ToDo GetTask(int todoId);
        int AddTask(ToDo todo);
        void UpdateTask(ToDo todo);
        void DeleteTask(int id);
        ToDo GetTaskById(int id);
    }
}
