using IBatisNet.DataMapper;
using MessageBoard2.Dao.Interface;
using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.Dao {
    public class MessageDao : IMessageDao {
        public int AddMessage(Message msg, ISqlMapper sqlMapper) {
            int id = 0;
            try {
                id = Convert.ToInt32(sqlMapper.Insert("Message.AddMessage", msg));
            }
            catch (Exception) {
                throw;
            }
            return id;
        }

        public Message GetMessage(Message msg, ISqlMapper sqlMapper) {
            try {
                msg = sqlMapper.QueryForObject<Message>("Message.GetMessage", msg);
            }
            catch (Exception) {
                throw;
            }

            return msg;
        }

        public int GetMessageCountBySql(string whereSql, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.QueryForObject<int>("Message.GetMessageCountBySql", whereSql);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public IList<Message> GetMessagesPageBySql(SelectPageInfo info, ISqlMapper sqlMapper) {
            IList<Message> msgs = new List<Message>();
            try {
                msgs = sqlMapper.QueryForList<Message>("Message.GetMessagesPageBySql", info);
            }
            catch (Exception) {
                throw;
            }
            return msgs;
        }

        public int SwitchMessageState(Message msg, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("Message.SwitchMessageState", msg);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ChangeMessage(Message msg, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("Message.ChangeMessage", msg);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int DeleteMessage(Message msg, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Delete("Message.DeleteMessage", msg);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }

        public int ClearNewReply(Message msg, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = sqlMapper.Update("Message.ClearNewReply", msg);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }
    }
}