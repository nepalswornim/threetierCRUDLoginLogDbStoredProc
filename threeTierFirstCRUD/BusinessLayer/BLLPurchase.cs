using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class BLLPurchase
    {
        public int Purchased( string invoiceno, int productid, int categoryid, int quantity, decimal total)
        {
            string sql = "sp_PurchaseCRUD";

            SqlParameter[] param = new SqlParameter[] {
            
          
            new SqlParameter("@invoice", invoiceno),
            new SqlParameter("@productid",productid ),
            new SqlParameter("@categoryid", categoryid),
            new SqlParameter("@quantity", quantity),
            new SqlParameter("@total", total)
            
            
            };

            return DAO.IDU(sql, param, CommandType.StoredProcedure);
        }
    }
}
