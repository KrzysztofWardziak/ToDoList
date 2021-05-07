using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Domain.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string ModifiedDate { get; set; }
    }
}
