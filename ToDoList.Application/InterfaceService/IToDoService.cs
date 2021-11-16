using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Application.ViewModels;

namespace ToDoList.Application.InterfaceService
{
    public interface IToDoService
    {
        ListToDoForListVm GetAllTasks(string searchString);
        int AddTask(ToDoVm model);
        ToDoVm GetTaskDetails(int todoId);
        void DeleteTask(int id);
        void UpdateTask(ToDoVm model);
        ToDoVm GetTaskById(int id);
    }
}
