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

        [HttpPost]
        public IActionResult AddTask(ToDoVm model)
        {
            if (ModelState.IsValid)
            {
                _toDoService.AddTask(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult EditTask(int id)
        {
            var task = _toDoService.GetTaskDetails(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult EditTask(ToDoVm model)
        {
            if (ModelState.IsValid)
            {
                _toDoService.UpdateTask(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var task = _toDoService.GetTaskDetails(id);
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            _toDoService.DeleteTask(id);
            return RedirectToAction("Index");
        }

    }
}
