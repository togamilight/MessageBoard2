using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageBoard2.Models {
    //因为sqlserver的分页查询很麻烦,所以用这个类来传递信息
    public class SelectPageInfo {
        //最小条目,不包含
        public int Min { get; set; }
        //条目数
        public int Count { get; set; }
        //查询条件
        public string WhereSql { get; set; }
    }
}