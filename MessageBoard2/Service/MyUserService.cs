using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessageBoard2.Models;
using MessageBoard2.DataMapper.Interface;
using MessageBoard2.Dao.Interface;

namespace MessageBoard2.Service {
    public class MyUserService : IMyUserService {
        public IMapper DataMapper { get; set; }
        public IMyUserDao MyUserDao { get; set; }

        public int AddUser(MyUser user) {
            int id = 0;
            user.SignDate = DateTime.Now.Date;
            try {
                id = MyUserDao.AddUser(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return id;
        }

        //判断用户名是否已存在
        public bool CheckUsername(MyUser user) {
            if (user.Username == "" || user.Username == null) return false;
            int count = 0;
            //user的Password置为null，使Dao处只验证用户名
            user.Password = null;
            try {
                count = MyUserDao.GetUserCount(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            if (count == 0) return false;
            return true;
        }

        //判断用户名密码是否正确
        public bool CheckUserPassword(MyUser user) {
            if (user.Username == "" || user.Username == null || user.Password == "" || user.Password == null) return false;
            int count = 0;
            try {
                count = MyUserDao.GetUserCount(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            if (count == 0) return false;
            return true;
        }

        public int ChangeUserInfo(MyUser user) {
            int count = 0;
            try {
                count = MyUserDao.ChangeUserInfo(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ChangeUserPassword(MyUser user) {
            int count = 0;
            try {
                count = MyUserDao.ChangeUserPassword(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int DeleteUser(MyUser user) {
            int count = 0;
            try {
                count = MyUserDao.DeleteUser(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        //得到所有用户
        public IList<MyUser> GetAllUser() {
            IList<MyUser> users = new List<MyUser>();
            try {
                //条件为空字符串，得到所有
                users = MyUserDao.GetUsersBySql("", DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return users;
        }

        //为用户获取用户的基本信息，不含密码
        public MyUser GetUserInfo(MyUser user) {
            try {
                user = MyUserDao.GetUserInfo(user, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return user;
        }
    }
}