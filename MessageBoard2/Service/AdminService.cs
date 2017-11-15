using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBoard2.Models;
using MessageBoard2.Dao.Interface;
using MessageBoard2.DataMapper.Interface;

namespace MessageBoard2.Service {
    public class AdminService : IAdminService {
        public IMapper DataMapper { get; set; }
        public IAdminDao AdminDao { get; set; }
        public int AddAdmin(Admin admin) {
            int id = 0;
            try {
                id = AdminDao.AddAdmin(admin, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return id;
        }

        public int ChangeAdminPassword(Admin admin) {
            int count = 0;
            try {
                count = AdminDao.ChangeAdminPassword(admin, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public bool CheckAdminName(Admin admin) {
            if (admin.AdminName == "" || admin.AdminName == null) return false;
            int count = 0;
            //Password置为null，使Dao处只验证用户名
            admin.Password = null;
            try {
                count = AdminDao.GetAdminCount(admin, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            if (count == 0) return false;
            return true;
        }

        public bool CheckAdminPassword(Admin admin) {
            if (admin.AdminName == "" || admin.AdminName == null || admin.Password == "" || admin.Password == null) return false;
            int count = 0;
            try {
                count = AdminDao.GetAdminCount(admin, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            if (count == 0) return false;
            return true;
        }
    }
}