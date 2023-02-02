using Microsoft.EntityFrameworkCore;
using Quizz.Model;

using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using System.Linq;
using System.Text;


namespace Quizz.Repository
{
    public class QuizzRepository : IQuizzRepository
    {
        private readonly QuestionContextRepo DbContext;
        public QuizzRepository(QuestionContextRepo DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<IEnumerable<QuestionModel>> GetQuestions()

        {
            try
            {
                var ques = await DbContext.Questions.ToListAsync();

                return ques.Select(q=>q.ToModel()).ToList();

            }
            catch (Exception ex)
            {
                return  new List<QuestionModel>();
            }
              
        }

        public async Task<QuestionModel> GetQuestionById(int id)
        {
            var quesById = await DbContext.Questions.FindAsync(id);
                
            try
            {
                return quesById?.ToModel();
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public  async Task<Boolean> AddQuestion(QuestionModel question)
        {
            try
            {
                 var ques =await DbContext.Questions.AddAsync(question.ToEntity());
                 await DbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {

                return false;
            }
              
        }

        public async Task UpdateQuestion(int id ,QuestionModel question)
        {
            try
            {
                var result = await DbContext.Questions.FindAsync(id);

                if (result != null)
                {
                    result.QuestionName = question.QuestionName;
                    result.Answer_1 = question.Answer_1;
                    result.Answer_2 = question.Answer_2;
                    result.Answer_3 = question.Answer_3;
                    result.Answer_4 = question.Answer_4;
                    result.CorrectAnswer = question.CorrectAnswer;

                    await DbContext.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteQuestion(int id)
        {
            var result = await DbContext.Questions.FindAsync(id);           
               DbContext.Questions.Remove(result);
               await  DbContext.SaveChangesAsync();           
        }

        public async Task<List<QuestionModel>> GetByPagination(Pagination pagination)
        {
            var pagedData = await DbContext.Questions
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();
            return (pagedData.Select(q=>q.ToModel()).ToList());
        }

        public async Task<IEnumerable<QuestionModel>> Search(string name)
        {
            IQueryable<QuestionEntity> query = DbContext.Questions;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(a => a.QuestionName.Contains(name));
            }
            return await query.Select(q => q.ToModel()).ToListAsync();
        }

        public async Task<IEnumerable<QuestionModel>> Sorting()
        {
            var sort =  DbContext.Questions.OrderByDescending(a => a.QuestionName).ToList();
           
            return sort.Select(q => q.ToModel()).ToList();
        }    
    }
    
}

