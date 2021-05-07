using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Application.InterfaceService;
using ToDoList.Application.ViewModels;

namespace ToDoList.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model =_toDoService.GetAllTasks("");
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var model = _toDoService.GetAllTasks(searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View(new ToDoVm());
        }

        [HttpGet]
        public IActionResult AddTask(ToDoVm model)
        {
            if (ModelState.IsValid)
            {
                _toDoService.AddTask(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
