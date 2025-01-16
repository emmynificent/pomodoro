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
using Configuration.Models;
using System.Text;
using System.Diagnostics.SymbolStore;
using Microsoft.IdentityModel.Tokens;

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

builder.Services.AddCors(options =>
{
   options.AddPolicy("AllowAll", policy => 
   {
      policy.AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
   });
});

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));


builder.Services.AddAuthentication(options => 
{
   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   options.DefaultScheme  = JwtBearerDefaults.AuthenticationScheme;
   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(jwt => 
{

   var Key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
   jwt.SaveToken = true;
   jwt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
   {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Key),
      ValidateIssuer = false,
      ValidateAudience = false,
      RequireExpirationTime = false, //update to true when refresh token is added
      ValidateLifetime = true,
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

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();


app.Run();
