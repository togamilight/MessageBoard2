using IBatisNet.DataMapper;
using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Dao.Interface {
    public interface IAdminDao {
        int AddAdmin(Admin admin, ISqlMapper sqlMapper);
        int GetAdminCount(Admin admin, ISqlMapper sqlMapper);
        int ChangeAdminPassword(Admin admin, ISqlMapper sqlMapper);
    }
}
