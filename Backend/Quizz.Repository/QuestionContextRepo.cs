using Microsoft.EntityFrameworkCore;
using Quizz.Model;
using System.Collections.Generic;

namespace Quizz.Repository
{
    public class QuestionContextRepo : DbContext
    {
            public QuestionContextRepo(DbContextOptions options) : base(options)
            {
            }
            public DbSet<QuestionEntity> Questions { get; set; } 
        
    }
}