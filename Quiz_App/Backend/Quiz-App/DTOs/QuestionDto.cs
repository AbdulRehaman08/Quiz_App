using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public string Answer_1 { get; set; }

        public string Answer_2 { get; set; }

        public string Answer_3 { get; set; }

        public string Answer_4 { get; set; }

        public string CorrectAnswer { get; set; }
    }
}
