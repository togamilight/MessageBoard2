using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Service.Interface {
    public interface IMyUserService {
        int AddUser(MyUser user);
        bool CheckUsername(MyUser user);
        bool CheckUserPassword(MyUser user);
        int ChangeUserInfo(MyUser user);
        int ChangeUserPassword(MyUser user);
        IList<MyUser> GetAllUser();
        int DeleteUser(MyUser user);
        MyUser GetUserInfo(MyUser user);
    }
}
