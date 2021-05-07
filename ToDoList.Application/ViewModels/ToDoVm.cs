using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ToDoList.Application.Mapping;
using ToDoList.Domain.Model;

namespace ToDoList.Application.ViewModels
{
    public class ToDoVm : IMapFrom<ToDo>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ToDo, ToDoVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.IsDone, opt => opt.MapFrom(s => s.IsDone))
                .ForMember(d => d.CreatedDate, opt => opt.MapFrom(s => s.CreatedDate))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => s.ModifiedDate))
                .ReverseMap();
        }

    }
}
