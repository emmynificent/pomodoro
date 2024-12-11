using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pomodoro;
using Pomodoro.Data;
using Pomodoro.Interface;
using Pomodoro.Repository;
using AutoMapper;
using Pomodoro.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddTransient<IReminderRepository, ReminderRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AssignmentDbContext>(options =>
 {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
 });



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
   {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidAudience = builder.Configuration["Jwt: Audience"],
      IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
         System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
      )
   };
});


 builder.Services.AddIdentityApiEndpoints<User>(opt =>
 {
    opt.Password.RequiredLength = 8;
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.SignIn.RequireConfirmedEmail = true;
 } )
  .AddEntityFrameworkStores<AssignmentDbContext>()
  .AddDefaultTokenProviders()
 .AddDefaultUI();



// builder.Services.AddIdentity<Owner, IdentityRole>()
// .AddEntityFrameworkStores<AssignmentDbContext>();
//  .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
};

//app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();
//app.MapIdentityApi<Owner>();
app.UseAuthentication();


app.MapControllers();

app.Run();
