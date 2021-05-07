using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Application.ViewModels
{
    public class ListToDoForListVm
    {
        public List<ToDoVm> Todos { get; set; }
        public string SearchString { get; set; }
    }
}
