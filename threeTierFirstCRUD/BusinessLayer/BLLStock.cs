using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessLayer
{
  public  class BLLStock
    {
      public DataTable GetStockByProductId(int productid) {

          string sql = "select* from tbl_Stock where ProductId=@a";
          SqlParameter[] param = new SqlParameter[] {
          new SqlParameter("@a", productid)
          };
          return DAO.SelectUser(sql, param, CommandType.Text);
      
      
      }
      public int UpdateStockbyProductId(int productid, int quantity) {
          string sql = "sp_PurchaseCRUD";
          SqlParameter[] param = new SqlParameter[] {
              
              new SqlParameter("@quantity", quantity),
              new SqlParameter("@productid", productid)
          };





          return DAO.IDU(sql, param, CommandType.StoredProcedure);
      }
      public int InsertStock(int productid, int quantity)
      {
          string sql = "sp_PurchaseCRUD";
          SqlParameter[] param = new SqlParameter[] {
              
             new SqlParameter("@productid", productid) ,
              new SqlParameter("@quantity", quantity)
          };





          return DAO.IDU(sql, param, CommandType.StoredProcedure);
      }
    }
}
