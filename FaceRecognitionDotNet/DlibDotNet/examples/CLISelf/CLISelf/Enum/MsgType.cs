using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face.CLISelf.Enum
{
    /// <summary>
    /// 返回对象类型枚举
    /// </summary> 
    [Description("返回对象类型")]
    public enum MsgType
    {
        [Description("成功")]
        Success,
        [Description("提示")]
        Info,
        [Description("警告")]
        Warning,
        [Description("错误")]
        Error,
        [Description("成功但没有任何行受影响")]
        SuccessButNoRowAffected
    }
}
