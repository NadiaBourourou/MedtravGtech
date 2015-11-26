using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TipService : ITipService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public TipService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }
        public void AddTip(t_tip tip)
        {
            utwk.TipRepository.Add(tip);
            utwk.Commit();
        }


        public List<t_tip> GetAllTips()
        {
            return utwk.TipRepository.GetAll().ToList();
        }

        public t_tip GetById(long id)
        {
            return utwk.TipRepository.GetById(id);
        }

        public void DeleteTip(t_tip tip)
        {
            utwk.TipRepository.Delete(tip);
            utwk.Commit();
        }

        public void UpdateTip(t_tip tip)
        {
            utwk.TipRepository.Update(tip);
            utwk.Commit();
        }

        public void PositiveVote(t_tip tipFound, int idPatientVoted)
        {
             
           // t_tip tipFound =utwk.TipRepository.GetById(idTip);
            //  if(tipFound.idPatientVoted)
            int valPosInit = tipFound.liked;
            tipFound.liked = valPosInit + 1;
            utwk.TipRepository.Update(tipFound);
            utwk.Commit();

        }

        public void NegativeVote(t_tip tip, int idPatientVoted)
        {
            int valNegInit = tip.disliked;
            tip.disliked = valNegInit + 1;
            utwk.TipRepository.Update(tip);
            utwk.Commit();
        }
    }

    public interface ITipService
    {
        void AddTip(t_tip tip);
        List<t_tip> GetAllTips();
        t_tip GetById(long id);
        void DeleteTip(t_tip tip);
        void UpdateTip(t_tip tip);
        void PositiveVote(t_tip tip, int idPatientVoted);
        void NegativeVote(t_tip tip, int idPatientVoted);
    }

}
