using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using models = ClassroomQuizAPI.DataModels.Questions;
namespace ClassroomQuizAPI.DataServices
{
    public class QuestionsService
    {
        private readonly SqlConnection _sqlConnection;

        public QuestionsService()
        {
            _sqlConnection = new SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));
            _sqlConnection.Open();
        }

         ~QuestionsService()
        {
            _sqlConnection.Close();
        }

        #region Proceedures

        public async Task<bool> InsertNewQuestionAsync(models.NewQuestion question)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_newquestion", _sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("TimeLimit", question.TimeLimit);
                cmd.Parameters.AddWithValue("A1", question.A1);
                cmd.Parameters.AddWithValue("A2", question.A2);
                cmd.Parameters.AddWithValue("A3", question.A3);
                cmd.Parameters.AddWithValue("A4", question.A4);
                cmd.Parameters.AddWithValue("Answer", question.Answer);
                cmd.Parameters.AddWithValue("Question", question.Question);
                cmd.Parameters.AddWithValue("QuizId", question.QuizId); 

                await cmd.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<models.FullQuestion>> RetrieveQuestionsForQuizAsync(string id)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("GET_questionsforquiz", _sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("QuizId", id); 

                SqlDataReader rd = await cmd.ExecuteReaderAsync();
                var templist = new List<models.FullQuestion>();
                while (await rd.ReadAsync())
                {
                    templist.Add(new models.FullQuestion()
                    {
                        Id = rd.GetValue(0).ToString(),
                        TimeLimit = rd.GetInt32(1),
                        A1 = rd.GetString(2),
                        A2 = rd.GetString(3),
                        A3 = rd.GetString(4),
                        A4 = rd.GetString(5),
                        Answer = rd.GetInt32(6),
                        Question = rd.GetString(7)
                    });
                }

                return templist;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
