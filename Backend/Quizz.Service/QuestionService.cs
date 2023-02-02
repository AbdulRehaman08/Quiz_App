using Microsoft.EntityFrameworkCore;
using Quizz.Model;
using Quizz.Repository;
using System;

namespace Quizz.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuizzRepository QuizzRepo;

        public QuestionService(IQuizzRepository repository)
        {
            this.QuizzRepo= repository;
        }

        public async Task AddQuestion(QuestionModel question)
        {
            await QuizzRepo.AddQuestion(question);
           
        }
        public async Task DeleteQuestion(int id)
        {
            await QuizzRepo.DeleteQuestion(id);
        }

        public Task<QuestionModel> GetQuestionById(int id)
        {
            return QuizzRepo.GetQuestionById(id);
        }

        public Task<IEnumerable<QuestionModel>> GetQuestions()
        {
            return QuizzRepo.GetQuestions();
        }

        public async Task UpdateQuestion(int id, QuestionModel question)
        {
             await QuizzRepo.UpdateQuestion(id,question);
        }


     public async   Task<List<QuestionModel>> GetByPagination(Pagination pagination)
        {
            return await QuizzRepo.GetByPagination(pagination);

        }

        public async Task<IEnumerable<QuestionModel>> Search(string name)
        {
           return await QuizzRepo.Search(name);
        }


        public async Task<IEnumerable<QuestionModel>> Sorting()
        {
            return await QuizzRepo.Sorting();
        }
    }
}