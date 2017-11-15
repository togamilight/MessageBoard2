using IBatisNet.DataMapper;
using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Dao.Interface {
    public interface IMyUserDao {
        int AddUser(MyUser user, ISqlMapper sqlMapper);
        IList<MyUser> GetUsersBySql(string whereSql, ISqlMapper sqlMapper);
        IList<MyUser> GetUsersPageBySql(SelectPageInfo info, ISqlMapper sqlMapper);
        int GetUserCount(MyUser user, ISqlMapper sqlMapper);
        int GetUserCountBySql(string whereSql, ISqlMapper sqlMapper);
        int ChangeUserInfo(MyUser user, ISqlMapper sqlMapper);
        int ChangeUserInfoByAdmin(MyUser user, ISqlMapper sqlMapper);
        int ChangeUserPassword(MyUser user, ISqlMapper sqlMapper);
        int DeleteUser(MyUser user, ISqlMapper sqlMapper);
        MyUser GetUserInfo(MyUser user, ISqlMapper sqlMapper);
    }
}
