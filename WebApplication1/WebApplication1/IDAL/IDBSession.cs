using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.IDAL
{
    
        public partial interface IDBSession
        {
            DbContext Db { get; }
            // IUserInfoDal UserInfoDal { get; set; }
            bool SaveChanges();
            int ExecuteSql(string sql, params SqlParameter[] pars);
            List<T> ExecuteQuery<T>(string sql, params SqlParameter[] pars);
        }
  
}