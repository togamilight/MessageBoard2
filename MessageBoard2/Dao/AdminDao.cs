using MessageBoard2.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using MessageBoard2.Models;

namespace MessageBoard2.Dao {
    public class AdminDao : IAdminDao {
        public int AddAdmin(Admin admin, ISqlMapper sqlMapper) {
            int id = 0;
            try {
                id = Convert.ToInt32(sqlMapper.Insert("Admin.AddAdmin", admin));
            }
            catch (Exception) {
                throw;
            }
            return id;
        }

        public int ChangeAdminPassword(Admin admin, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("Admin.ChangeAdminPassword", admin);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int GetAdminCount(Admin admin, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.QueryForObject<int>("Admin.GetAdminCount", admin);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }
    }
}