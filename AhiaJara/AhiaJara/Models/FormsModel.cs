using System;
using System.Collections.Generic;
using System.Text;

namespace AhiaJara.Models
{
    public class FormsModel
    {
        public class QuestionAndAnswer
        {
            public QuestionAndAnswer(String question, String answer)
            {
                Question = question;
                Answer = answer;
            }
            public string Question { get; set; }
            public string Answer { get; set; }
        }
    }
}
