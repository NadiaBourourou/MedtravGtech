using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FavoriteService : IFavoriteService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public FavoriteService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }
        public void AddFavorite(t_favorite favorite)
        {
            utwk.FavoriteRepository.Add(favorite);
            utwk.Commit();
        }


        public List<t_favorite> getAllFavorites()
        {
            return utwk.FavoriteRepository.GetAll().ToList();
        }

        public t_favorite GetById(long id)
        {
            return utwk.FavoriteRepository.GetById(id);
        }

        public void DeleteFavorite(t_favorite favorite)
        {
            utwk.FavoriteRepository.Delete(favorite);
            utwk.Commit();
        }

        public void UpdateFavorite(t_favorite favorite)
        {
            utwk.FavoriteRepository.Update(favorite);
            utwk.Commit();
        }
    }

    public interface IFavoriteService
    {
        void AddFavorite(t_favorite favorite);
        List<t_favorite> getAllFavorites();
        t_favorite GetById(long id);
        void DeleteFavorite(t_favorite favorite);
        void UpdateFavorite(t_favorite favorite);
    }

}

