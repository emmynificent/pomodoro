using AutoMapper;
using Dto;
using Microsoft.AspNetCore.Identity;
using Pomodoro.Dto;
using Pomodoro.Models;

namespace Pomodoro.Helpers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Assignment, AssignmentDto>();
        CreateMap<AssignmentDto, Assignment>();
        CreateMap<AssignmentOutputDto, Assignment>();
        CreateMap<Assignment, AssignmentOutputDto>();
        CreateMap<AssignmentInputDto, Assignment>();
        CreateMap<Reminder, ReminderDto>();
        CreateMap<ReminderDto, Reminder>();
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();
        //CreateMap<UserRegistration , UserRegistrationDto>();
    }
}