using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Domain.Model
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
