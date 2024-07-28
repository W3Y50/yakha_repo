using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using models = ClassroomQuizAPI.DataModels.Quizzes;

namespace ClassroomQuizAPI.DataServices
{
    public class QuizService
    {
        private readonly SqlConnection _sqlConnection;

        public QuizService()
        {
            _sqlConnection = new SqlConnection(Environment.GetEnvironmentVariable("sqlconn"));
            _sqlConnection.Open();
        }

        ~QuizService()
        {
            _sqlConnection.Close();
        }

        #region Proceedures

        public async Task<string> InsertNewQuizAsync(models.NewQuiz quiz)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_newquiz", _sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Title",  quiz.Title);
                cmd.Parameters.AddWithValue("Description",  quiz.Description);
                cmd.Parameters.AddWithValue("TimeLimit",  quiz.TimeLimit);

               return (await cmd.ExecuteScalarAsync()).ToString();
                
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public async Task<List<models.QuizForSearch>> RetrieveQuizzesAsync()
        {

            try
            {
                SqlCommand cmd = new SqlCommand("GET_quizzes_titleonly", _sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 

                SqlDataReader rd = await cmd.ExecuteReaderAsync();
                var templist = new List<models.QuizForSearch>();
                while (await rd.ReadAsync())
                {
                    templist.Add(new models.QuizForSearch()
                    {
                        Id = rd.GetValue(0).ToString(),
                        Title = rd.GetString(1)
                    });
                }
                await  rd.CloseAsync();
                return templist;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public async Task<models.ExpandedQuiz> RetrieveQuizDetailsAsync(string quizid)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("GET_quizdetails", _sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Id", quizid);

                SqlDataReader rd = await cmd.ExecuteReaderAsync();
                models.ExpandedQuiz output = null;
                while (await rd.ReadAsync())
                {
                 output =  new models.ExpandedQuiz()
                    {
                        Description = rd.GetString(0),
                        TimeLimit = rd.GetInt32(1)
                    };
                }
                return output;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}
