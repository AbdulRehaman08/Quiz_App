using Quizz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Repository
{
    public interface IQuizzRepository
    {
       Task< IEnumerable<QuestionModel>> GetQuestions();
        Task< QuestionModel> GetQuestionById(int id);
        Task<Boolean>  AddQuestion(QuestionModel question);
        Task UpdateQuestion( int id,QuestionModel question);
        Task DeleteQuestion(int id);
        Task<List<QuestionModel>> GetByPagination(Pagination pagination);
        Task<IEnumerable<QuestionModel>> Search(string name);
        Task<IEnumerable<QuestionModel>> Sorting();
    }
}
