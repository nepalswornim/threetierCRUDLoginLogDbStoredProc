using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class BLLUser
    {
        public void createUser(string name, string email, string usertype)
            {
                string sql = "sp_IUDSUser";
            SqlParameter[] param = new SqlParameter[]{
           new SqlParameter("@username",name),
           new SqlParameter("@email",email),
           new SqlParameter("@usertype",usertype),
            new SqlParameter("@action","Insert")


       };
          DAO.IDU(sql, param, CommandType.StoredProcedure);
            
        }


        public void updateUser(string name, string email, string usertype, int id)
        {
            string sql = "sp_IUDSUser";
            SqlParameter[] param = new SqlParameter[]{
         new SqlParameter("@username",name),
           new SqlParameter("@email",email),
           new SqlParameter("@usertype",usertype),
           new SqlParameter("@userid",id),
           new SqlParameter("@action","Update")
           };
           DAO.IDU(sql, param, CommandType.StoredProcedure);
            
        }
        public void deleteUser(int id)
        {
            string sql = "sp_IUDSUser";
            SqlParameter[] param = new SqlParameter[] { 
            new SqlParameter("@userid",id),
            new SqlParameter("@action", "Delete")
            
            
            };
             DAO.IDU(sql, param, CommandType.StoredProcedure);


        }
        public DataTable GetAllUser() {
            string sql = "SelectUser";
            
            
            DataTable dt = DAO.SelectUser(sql, null, CommandType.StoredProcedure );
            return dt;


        
        }
        public DataTable CheckAvailability(string name)
        {
            string sql = "select* from tbl_User where Name=@a";
           
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@a",name)
            };
            DataTable dt = DAO.SelectUser(sql, param,CommandType.Text);
          
            return dt;



        }
        public DataTable CheckUserLogin(string name,string email,string usertype)
        {
            string sql = "select* from tbl_User where Name=@a and Email=@b and Usertype=@c";
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@a",name),
                new SqlParameter("@b", email),
                new SqlParameter("@c",usertype)
            };
            DataTable dt = DAO.SelectUser(sql, param, CommandType.Text);
            return dt;



        }
    }
}
