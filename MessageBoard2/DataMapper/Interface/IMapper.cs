using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoard2.DataMapper.Interface {
    public interface IMapper {
        void InitMapper(string sqlMapperPath);
        ISqlMapper Instance { get; }
    }
}
