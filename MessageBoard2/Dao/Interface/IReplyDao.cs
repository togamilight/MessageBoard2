using IBatisNet.DataMapper;
using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Dao.Interface {
    public interface IReplyDao {
        int AddReply(Reply reply, ISqlMapper sqlMapper);
    }
}
