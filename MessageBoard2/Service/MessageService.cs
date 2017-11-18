using IBatisNet.DataMapper;
using MessageBoard2.Dao.Interface;
using MessageBoard2.DataMapper.Interface;
using MessageBoard2.Models;
using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.Service {
    public class MessageService : IMessageService{
        public IMapper DataMapper { get; set; }
        public IMessageDao MessageDao { get; set; }

        public int AddMessage(Message msg) {
            int id = 0;
            msg.DateTime = DateTime.Now;
            try {
                id = MessageDao.AddMessage(msg, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return id;
        }

        public Message GetMessage(Message msg) {
            try {
                msg = MessageDao.GetMessage(msg, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return msg;
        }

        public int GetMessageCountBySql(string whereSql) {
            int count = 0;
            try {
                count = MessageDao.GetMessageCountBySql(whereSql, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public IList<Message> GetMessagesPageBySql(SelectPageInfo info) {
            IList<Message> msgs = new List<Message>();
            try {
                msgs = MessageDao.GetMessagesPageBySql(info, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return msgs;
        }

        public int SwitchMessageState(Message msg) {
            int count = 0;
            try {
                count = MessageDao.SwitchMessageState(msg, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ChangeMessage(Message msg) {
            int count = 0;
            try {
                count = MessageDao.ChangeMessage(msg, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int DeleteMessage(Message msg) {
            int count = 0;
            try {
                count = MessageDao.DeleteMessage(msg, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ClearNewReply(Message msg) {
            int count = 0;
            ISqlMapper sqlMapper = DataMapper.Instance;
            try {
                //因为这个操作包含两条语句，开启事务
                sqlMapper.BeginTransaction();
                count = MessageDao.ClearNewReply(msg, sqlMapper);
                //提交事务
                sqlMapper.CommitTransaction();
            }
            catch (Exception) {
                //回滚事务
                sqlMapper.RollBackTransaction();
                throw;
            }
            return count;
        }
    }
}