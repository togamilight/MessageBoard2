using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Service.Interface {
    public interface IAdminService {
        int AddAdmin(Admin admin);
        bool CheckAdminName(Admin admin);
        bool CheckAdminPassword(Admin admin);
        int ChangeAdminPassword(Admin admin);
    }
}
