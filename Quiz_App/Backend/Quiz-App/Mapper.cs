using Quiz_App;
using Quiz_App.DTOs;
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
        public static QuestionModel ToModel(this QuestionDto questionDto)
        {
            return new QuestionModel
            {
                Id = questionDto.Id,
                QuestionName = questionDto.QuestionName,
                Answer_1 = questionDto.Answer_1,
                Answer_2 = questionDto.Answer_2,
                Answer_3 = questionDto.Answer_3,
                Answer_4 = questionDto.Answer_4,
                CorrectAnswer = questionDto.CorrectAnswer,

            };
        }
        public static QuestionDto ToDTO(this QuestionModel questionModel)
        {
            return new QuestionDto
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
        public static AnswerDto ToAnswerDTO(this QuestionModel questionModelsss) 
        {
            return new AnswerDto
            {
                Id = questionModelsss.Id,
               
                CorrectAnswer = questionModelsss.CorrectAnswer,

            };
        }


    }
}
