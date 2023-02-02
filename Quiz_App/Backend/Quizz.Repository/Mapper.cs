using Quizz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.Repository
{
    public static class Mapper
    {
        public static QuestionModel ToModel(this QuestionEntity questionEntity)
        {
            return new QuestionModel
            {
                Id = questionEntity.Id,
                QuestionName = questionEntity.QuestionName,
                Answer_1 = questionEntity.Answer_1,
                Answer_2 = questionEntity.Answer_2,
                Answer_3 = questionEntity.Answer_3,
                Answer_4 = questionEntity.Answer_4,
                CorrectAnswer = questionEntity.CorrectAnswer,

            };
        }
        public static QuestionEntity ToEntity(this QuestionModel questionModel)
        {
            return new QuestionEntity
            {
                Id = questionModel.Id,
                QuestionName = questionModel.QuestionName,
                Answer_1 = questionModel.Answer_1,
                Answer_2 = questionModel.Answer_2,
                Answer_3 = questionModel.Answer_3,
                Answer_4 = questionModel.Answer_4,
                CorrectAnswer = questionModel.CorrectAnswer,

            };
        }
    }
}
