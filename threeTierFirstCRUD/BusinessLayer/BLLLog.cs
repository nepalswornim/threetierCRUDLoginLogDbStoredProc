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
   public class BLLLog
    {
       public int CreateLog(string LoginTime, string LogoutTime, DateTime LoginDate, int UserId)
       {

           string sql = "sp_CreateLog";
           SqlParameter[] param = new SqlParameter[5];

           param[0] = new SqlParameter("@a", LoginTime);
           param[1] = new SqlParameter("@b", LogoutTime);
           param[2] = new SqlParameter("@c", LoginDate);
           param[3] = new SqlParameter("@d", UserId);
           param[4] = new SqlParameter("@logid", SqlDbType.Int, 4);
           param[4].Direction = ParameterDirection.Output;
           DAO.IDU(sql, param, CommandType.StoredProcedure);
           int i = (int)param[4].Value;
           return i;

           




       }
       public int EditLogAddExitTimebyLogId(string LogoutTime, int logid) {

           string sql = "update tbl_Log set LogoutTime=@a where LogId=@logid";
           SqlParameter[] param = new SqlParameter[] { 
           new SqlParameter("@a",LogoutTime),
           new SqlParameter("@logid",logid)
           
           
           };

           int i = DAO.IDU(sql, param, CommandType.Text);
           return i;

       }
    }
}
