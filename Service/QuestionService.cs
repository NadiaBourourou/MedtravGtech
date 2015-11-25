using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    // test testimony
    public class QuestionService : IQuestionService
    {

        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public QuestionService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }
        public void AddQuestion(t_question f)
        {
            utwk.QuestionRepository.Add(f);
            utwk.Commit();
        }

        public List<t_question> getAllQuestions()
        {
            return utwk.QuestionRepository.GetAll().ToList();
        }

        public void DeleteQuestion(t_question a)
        {

            utwk.QuestionRepository.Delete(a);
            utwk.Commit();
        }
        public void UpdateQuestion(t_question a)
        {

            utwk.QuestionRepository.Update(a);
            utwk.Commit();

        }

        public t_question GetById(long id)
        {

            return utwk.QuestionRepository.GetById(id);
        }

    }

    public interface IQuestionService
    {
        void AddQuestion(t_question f);
        List<t_question> getAllQuestions();
        void DeleteQuestion(t_question a);
        void UpdateQuestion(t_question a);
        t_question GetById(long id);
    }


}
