using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClassroomQuizAPI.Controllers
{
    [Route("[Controller]/[Action]")]
    public class QuizController : Controller
    {
        

        public async Task<JsonResult> InsertNewQuiz([FromBody]DataModels.Quizzes.NewQuiz quiz, [FromServices]DataServices.QuizService quizService)
        {
             
            return Json(await  quizService.InsertNewQuizAsync(quiz));
        }

        public async Task<List<DataModels.Quizzes.QuizForSearch>> RetrieveQuizForSearch([FromServices]DataServices.QuizService quizService)
        {
            return await quizService.RetrieveQuizzesAsync();
        }


        public async Task<DataModels.Quizzes.ExpandedQuiz> RetrieveQuizDetails([FromQuery]string quizid, [FromServices]DataServices.QuizService quizService)
        {
            return await quizService.RetrieveQuizDetailsAsync(quizid);
        }
    }
}
