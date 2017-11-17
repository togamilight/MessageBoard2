using MessageBoard2.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using MessageBoard2.Models;

namespace MessageBoard2.Dao {
    public class MyUserDao : IMyUserDao {
        public int AddUser(MyUser user, ISqlMapper sqlMapper) {
            int id = 0;

            try {
                id = Convert.ToInt32(sqlMapper.Insert("MyUser.AddUser", user));
            }
            catch (Exception) {
                throw;
            }

            return id;
        }

        //public IList<MyUser> GetUsersBySql(string whereSql, ISqlMapper sqlMapper) {
        //    IList<MyUser> users = new List<MyUser>();
        //    try {
        //        users = sqlMapper.QueryForList<MyUser>("MyUser.GetUsersBySql", whereSql);
        //    }
        //    catch (Exception) {
        //        throw;
        //    }
        //    return users;
        //}

        public IList<MyUser> GetUsersPageBySql(SelectPageInfo info, ISqlMapper sqlMapper) {
            IList<MyUser> users = new List<MyUser>();
            try {
                users = sqlMapper.QueryForList<MyUser>("MyUser.GetUsersPageBySql", info);
            }
            catch (Exception) {
                throw;
            }
            return users;
        }

        public int GetUserCount(MyUser user, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.QueryForObject<int>("MyUser.GetUserCount", user);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int GetUserCountBySql(string whereSql, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.QueryForObject<int>("MyUser.GetUserCountBySql", whereSql);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ChangeUserInfo(MyUser user, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("MyUser.ChangeUserInfo", user);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ChangeUserInfoByAdmin(MyUser user, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("MyUser.ChangeUserInfoByAdmin", user);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ChangeUserPassword(MyUser user, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("MyUser.ChangeUserPassword", user);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int DeleteUser(MyUser user, ISqlMapper sqlMapper) {
            int count = 0;

            try {
                count = sqlMapper.Delete("MyUser.DeleteUser", user);
            }
            catch (Exception) {
                throw;
            }

            return count;
        }

        public MyUser GetUserInfo(MyUser user, ISqlMapper sqlMapper) {
            try {
                user = sqlMapper.QueryForObject<MyUser>("MyUser.GetUserInfo", user);
            }
            catch (Exception) {
                throw;
            }
            return user;
        }
    }
}