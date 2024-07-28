using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassroomQuizAPI.Controllers
{
    [Route("[Controller]/[Action]")]
    public class QuestionsController : Controller
    {
        public async Task<List<DataModels.Questions.FullQuestion>> GetQuestions([FromQuery]string quizid, [FromServices]DataServices.QuestionsService  questionsService)
        {
            return await questionsService.RetrieveQuestionsForQuizAsync(quizid);
        }

        public async Task<bool> InsertQuestion([FromBody]DataModels.Questions.NewQuestion question, [FromServices]DataServices.QuestionsService questionsService)
        {
            return await questionsService.InsertNewQuestionAsync(question);
        }
    }
}
