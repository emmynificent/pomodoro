using AutoMapper;
using Pomodoro.Dto;
using Pomodoro.Models;

namespace Pomodoro.Helpers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Assignment, AssignmentDto>();
        CreateMap<AssignmentDto, Assignment>();
        CreateMap<Reminder, ReminderDto>();
        CreateMap<ReminderDto, Reminder>();
        
    }
}