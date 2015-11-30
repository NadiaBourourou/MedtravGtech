using Data.Infrastructure;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class UserService : IUserService
    {
        static public DatabaseFactory dbFactory = null;
        UnitOfWork utwk = null;

        public UserService()
        {
            dbFactory = new DatabaseFactory();
            utwk = new UnitOfWork(dbFactory);
        }

        // ******************************  DOCTOR ********************************************
        public void AddDoctor(t_user Doctor)
        {
            Doctor.DTYPE = "Doctor";
            Doctor.role = 1;
            Doctor.login = Doctor.firstName + "." + Doctor.lastName;
            Doctor.password = "pwd" + Doctor.firstName;
            utwk.UserRepository.Add(Doctor);
            utwk.Commit();
        }


        // ******************************  PATIENT ********************************************
        public void AddPatient(t_user Patient)
        {
            Patient.DTYPE = "Patient";
            Patient.role = 2;
            utwk.UserRepository.Add(Patient);
            utwk.Commit();
        }

 

        // ******************************  ADMIN ********************************************
        public void AddAdmin(t_user Admin)
        {
            Admin.DTYPE = "Administrator";
            Admin.role = 0;
            utwk.UserRepository.Add(Admin);
            utwk.Commit();
        }


        public t_user authenticate(string Login, string Pwd)
        {
            return utwk.UserRepository.GetMany(u => u.login == Login && u.password == Pwd).FirstOrDefault();

        }

        public IEnumerable<t_user> GetDoctors()
        {

            return utwk.UserRepository.GetAll().Where(u => u.DTYPE == "Doctor");
        }

        public t_user GetUserByID(int UserId)
        {
            return utwk.UserRepository.GetById(UserId);
        }

        public void DeleteUser(int Id)
        {   var User =  GetUserByID(Id);
           utwk.UserRepository.Delete(User);
        }

        public void UpdateUser(t_user User)
        {
           utwk.UserRepository.Update(User);
            utwk.Commit();
        }
    }

    public interface IUserService
    {
        void AddDoctor(t_user Doctor);
        void AddPatient(t_user Patient);
        void AddAdmin(t_user Admin);

        t_user authenticate(string Login, string Pwd);


        IEnumerable<t_user> GetDoctors();
        t_user GetUserByID(int UserId);
        void DeleteUser(int Id);
        void UpdateUser(t_user User);
       

    }


}
