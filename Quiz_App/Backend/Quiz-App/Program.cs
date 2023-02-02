using Microsoft.EntityFrameworkCore;
using Quiz_App.Configurations;
using Quizz.Repository;
using Quizz.Service;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddDbContext<QuestionContextRepo>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuestionCS"))
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();

// service injection
builder.Services.AddTransient<IQuizzRepository, QuizzRepository>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.AddGlobalErrorHandler();

app.Run();
