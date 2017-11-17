using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.Service.Interface {
    public interface IMessageService {
        Message GetMessage(Message msg);
        int GetMessageCountBySql(string whereSql);
        IList<Message> GetMessagesPageBySql(SelectPageInfo info);
        int SwitchMessageState(Message msg);
        int ChangeMessage(Message msg);
        int DeleteMessage(Message msg);
    }
}
