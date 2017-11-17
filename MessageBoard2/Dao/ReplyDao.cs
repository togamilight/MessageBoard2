using IBatisNet.DataMapper;
using MessageBoard2.Dao.Interface;
using MessageBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.Dao {
    public class ReplyDao : IReplyDao{
        public int AddReply(Reply reply, ISqlMapper sqlMapper) {
            int count = 0;
            try {
                count = Convert.ToInt32(sqlMapper.Insert("Reply.AddReply", reply));
            }
            catch (Exception) {
                throw;
            }
            return count;
        }
    }
}