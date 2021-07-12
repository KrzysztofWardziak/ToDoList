using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ToDoList.Application.InterfaceService;
using ToDoList.Application.ViewModels;
using ToDoList.Domain.InterfaceRepository;
using ToDoList.Domain.Model;

namespace ToDoList.Application.Service
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public ListToDoForListVm GetAllTasks(string searchString)
        {
            var tasks = _toDoRepository.GetAllTasks().Where(p => p.Title.StartsWith(searchString))
                .ProjectTo<ToDoVm>(_mapper.ConfigurationProvider).ToList();

            var taskList = new ListToDoForListVm()
            {
                Todos = tasks,
                SearchString = searchString
            };

            return taskList;
        }

        public int AddTask(ToDoVm model)
        {
            var date = DateTime.Now.ToString("D");
            model.CreatedDate = date;
            var task = _mapper.Map<ToDo>(model);
            var id = _toDoRepository.AddTask(task);
            return id;
        }

        public ToDoVm GetTaskDetails(int todoId)
        {
            var task = _toDoRepository.GetTask(todoId);
            var taskVm = _mapper.Map<ToDoVm>(task);
            return taskVm;
        }

        public void DeleteTask(int id)
        {
            _toDoRepository.DeleteTask(id);
        }

        public void UpdateTask(ToDoVm model)
        {
            var date = DateTime.Now.ToString("D");
            model.ModifiedDate = date;
            var task = _mapper.Map<ToDo>(model);
            _toDoRepository.UpdateTask(task);
        }

        public void EditTask(ToDoVm model)
        {
            var task = _toDoRepository.GetTask(model.Id);
            var taskVm = _mapper.Map<ToDoVm>(task);
        }
    }
}
