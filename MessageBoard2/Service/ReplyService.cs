using MessageBoard2.Dao.Interface;
using MessageBoard2.DataMapper.Interface;
using MessageBoard2.Models;
using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.Service {
    public class ReplyService : IReplyService{
        public IReplyDao ReplyDao { get; set; }
        public IMapper DataMapper { get; set; }

        public int AddReply(Reply reply) {
            int count = 0;
            reply.DateTime = DateTime.Now;
            try {
                count = ReplyDao.AddReply(reply, DataMapper.Instance);
            }
            catch (Exception) {
                throw;
            }
            return count;
        }
    }
}