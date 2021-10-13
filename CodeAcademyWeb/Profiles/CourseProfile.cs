using AcademyModel.Entities;
using AutoMapper;
using CodeAcademyWeb.DTOs;
using NodaTime;
using NodaTime.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademyWeb.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDTO>()
                .ForMember(dto => dto.CreationDate, opt => opt.MapFrom(course => course.CreationDate.ToString("yyyy/MM/dd", null)));
            CreateMap<CourseDTO, Course>()
                .ForMember(course => course.CreationDate, opt => opt.MapFrom(dto => Parse(dto.CreationDate)));
        }
        private LocalDate Parse(string dateString)
        {
            LocalDatePattern pattern = LocalDatePattern.CreateWithCurrentCulture("yyyy/MM/dd");
            var result = pattern.Parse(dateString);
            return result.Value;
        }

    }
}
