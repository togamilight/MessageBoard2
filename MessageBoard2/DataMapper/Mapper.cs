using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using MessageBoard2.DataMapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.DataMapper {
    public class Mapper : IMapper{
        private static volatile ISqlMapper _mapper = null;
        public ISqlMapper Instance {
            get {
                //如果_mapper为空，实例化
                if(_mapper == null) {
                    lock (typeof(SqlMapper)) {
                        //double check
                        if(_mapper == null) {
                            InitMapper("Setting/ORM/SqlMap.config");
                        }
                    }
                }

                return _mapper;
            }
        }

        public void InitMapper(string sqlMapperPath) {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            //设置文件缓存依赖，每当sqlMapperPath指向的配置文件被修改，就调用handler，即Configure方法将实例置为null，再重新获取
            _mapper = builder.ConfigureAndWatch(sqlMapperPath, handler);
            _mapper.SessionStore = new IBatisNet.DataMapper.SessionStore.HybridWebThreadSessionStore(_mapper.Id);
        }

        protected void Configure(object obj) {
            _mapper = null;
        }
    }
}