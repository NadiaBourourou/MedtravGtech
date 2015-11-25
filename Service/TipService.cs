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

    }

    public interface ITipService
    {
        void AddTip(t_tip tip);
        List<t_tip> GetAllTips();
        t_tip GetById(long id);
        void DeleteTip(t_tip tip);
        void UpdateTip(t_tip tip);
    }

}
