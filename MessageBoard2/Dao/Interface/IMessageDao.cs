using IBatisNet.DataMapper;
using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Dao.Interface {
    public interface IMessageDao {
        int AddMessage(Message msg, ISqlMapper sqlMapper);
        Message GetMessage(Message msg, ISqlMapper sqlMapper);
        int GetMessageCountBySql(string whereSql, ISqlMapper sqlMapper);
        IList<Message> GetMessagesPageBySql(SelectPageInfo info, ISqlMapper sqlMapper);
        int SwitchMessageState(Message msg, ISqlMapper sqlMapper);
        int ChangeMessage(Message msg, ISqlMapper sqlMapper);
        int DeleteMessage(Message msg, ISqlMapper sqlMapper);
        int ClearNewReply(Message msg, ISqlMapper sqlMapper);
    }
}
