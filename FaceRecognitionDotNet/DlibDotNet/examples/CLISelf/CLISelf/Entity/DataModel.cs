using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face.CLISelf.Entity
{
    using Face.CLISelf.Enum;
    using System;

    namespace HWKJ.Common.Models
    {
        /// <summary>
        /// 后台返回对象模型
        /// </summary> 
        public class MsgModel
        {
            /// <summary>
            /// 执行是否成功
            /// </summary> 
            public bool Result
            {
                get
                {
                    return this._result ?? true;
                }
                set
                {
                    this._result = new bool?(value);
                }
            }

            /// <summary>
            /// 消息类型
            /// </summary> 
            public MsgType Type { get; set; }

            /// <summary>
            /// 消息标题
            /// </summary> 
            public string Title { get; set; }

            /// <summary>
            /// 消息内容
            /// </summary> 
            public string Content { get; set; }

            /// <summary>
            /// 消息扩展内容
            /// </summary> 
            public object Extend { get; set; }

            /// <summary>
            /// 返回的后续执行的js语句
            /// </summary> 
            public string Javascript { get; set; }

            /// <summary>
            /// 是否自动关闭
            /// </summary> 
            public bool AutoClose
            {
                get
                {
                    return this._autoClose ?? false;
                }
                set
                {
                    this._autoClose = new bool?(value);
                }
            }

            /// <summary>
            /// 构造方法
            /// </summary> 
            public MsgModel(bool result, MsgType type, string content)
            {
                this.Result = result;
                this.Type = type;
                this.Title = MsgModel.GetDefaultTitle(type);
                this.Content = content;
            }

            /// <summary>
            /// 构造方法
            /// </summary> 
            public MsgModel(bool result, MsgType type, string content, object extend)
            {
                this.Result = result;
                this.Type = type;
                this.Title = MsgModel.GetDefaultTitle(type);
                this.Content = content;
                this.Extend = extend;
            }

            /// <summary>
            /// 构造方法
            /// </summary> 
            public MsgModel(bool result, MsgType type, string title, string content)
            {
                this.Result = result;
                this.Type = type;
                this.Title = title;
                this.Content = content;
            }

            /// <summary>
            /// 构造方法
            /// </summary> 
            public MsgModel(bool result, MsgType type, string title, string content, bool autoClose)
            {
                this.Result = result;
                this.Type = type;
                this.Title = title;
                this.Content = content;
                this.AutoClose = autoClose;
            }

            /// <summary>
            /// 构造方法
            /// </summary> 
            public MsgModel(bool result, MsgType type, string title, string content, object extend)
            {
                this.Result = result;
                this.Type = type;
                this.Title = title;
                this.Content = content;
                this.Extend = extend;
            }

            /// <summary>
            /// 构造方法
            /// </summary> 
            public MsgModel()
            {
            }

            /// <summary>
            /// 根据消息类型获取默认的标题文字
            /// </summary> 
            private static string GetDefaultTitle(MsgType type)
            {
                if (type == MsgType.Warning)
                {
                    return "警告";
                }
                if (type != MsgType.Error)
                {
                    return "提示";
                }
                return "错误";
            }

            /// <summary>
            /// 创建一个错误提示-用于在catch错误后返回错误信息
            /// </summary> 
            public static MsgModel CreateError(string error)
            {
                return new MsgModel(false, MsgType.Error, error);
            }

            /// <summary>
            /// 创建一个成功提示-用于执行成功但无返回信息
            /// </summary> 
            public static MsgModel CreateSuccess()
            {
                return new MsgModel(true, MsgType.Success, "执行成功");
            }

            /// <summary>
            /// 创建一个空的成功提示-相当于返回一个bool值
            /// </summary> 
            public static MsgModel CreateEmptySuccess()
            {
                return new MsgModel(true, MsgType.Success, "");
            }

            /// <summary>
            /// 创建一个成功提示-用于执行成功但没有任何行受影响
            /// </summary> 
            public static MsgModel CreateSuccessButNoRowAffected()
            {
                return new MsgModel(true, MsgType.SuccessButNoRowAffected, "执行成功");
            }

            /// <summary>
            /// 创建一个成功提示-用于执行成功返回信息
            /// </summary> 
            public static MsgModel CreateSuccess(string info)
            {
                return new MsgModel(true, MsgType.Success, info);
            }

            /// <summary>
            /// 创建一个带扩展信息的成功提示-用于执行成功返回信息
            /// </summary> 
            public static MsgModel CreateSuccess(string info, object extend)
            {
                return new MsgModel(true, MsgType.Success, info, extend);
            }

            /// <summary>
            /// 创建一个警告提示-用于验证失败或执行失败后返回警告信息
            /// </summary> 
            public static MsgModel CreateWarning(string warning)
            {
                return new MsgModel(false, MsgType.Warning, warning);
            }

            /// <summary>
            /// 创建一个普通的提示
            /// </summary> 
            public static MsgModel CreateInfo(bool result, string info)
            {
                return new MsgModel(result, MsgType.Info, info);
            }

            /// <summary>
            /// 创建一个自动关闭的提示
            /// </summary> 
            public static MsgModel CreateAutoCloseInfo(bool result, string info)
            {
                return new MsgModel(result, MsgType.Info, info)
                {
                    AutoClose = true
                };
            }

            /// <summary>
            /// 创建一个SaveChange的结果提示
            /// </summary> 
            public static MsgModel SaveChangeResult(int changeCount)
            {
                return MsgModel.SaveChangeResult(changeCount, "执行时发生错误");
            }

            /// <summary>
            /// 创建一个SaveChange的结果提示
            /// </summary> 
            public static MsgModel SaveChangeResult(int changeCount, string error)
            {
                if (changeCount > 0)
                {
                    return MsgModel.CreateSuccess();
                }
                if (changeCount != 0)
                {
                    return MsgModel.CreateError(error);
                }
                return MsgModel.CreateSuccess("执行成功，但没有任何数据受到影响");
            }
             
            protected bool Equals(MsgModel other)
            {
                return this._result == other._result && this._autoClose == other._autoClose && this.Type == other.Type && string.Equals(this.Title, other.Title) && string.Equals(this.Content, other.Content) && object.Equals(this.Extend, other.Extend) && string.Equals(this.Javascript, other.Javascript);
            }
             
            public override bool Equals(object obj)
            {
                return obj != null && (this == obj || (!(obj.GetType() != base.GetType()) && this.Equals((MsgModel)obj)));
            }
             
            public override int GetHashCode()
            {
                int num = ((this._result.GetHashCode() * 397 ^ this._autoClose.GetHashCode()) * 397 ^ (int)this.Type) * 397;
                string title = this.Title;
                int num2 = (num ^ ((title != null) ? title.GetHashCode() : 0)) * 397;
                string content = this.Content;
                int num3 = (num2 ^ ((content != null) ? content.GetHashCode() : 0)) * 397;
                object extend = this.Extend;
                int num4 = (num3 ^ ((extend != null) ? extend.GetHashCode() : 0)) * 397;
                string javascript = this.Javascript;
                return num4 ^ ((javascript != null) ? javascript.GetHashCode() : 0);
            }
             
            public static bool operator ==(MsgModel msg, bool value)
            {
                return msg != null && msg.Result == value;
            }
             
            public static bool operator !=(MsgModel msg, bool value)
            {
                return !(msg == value);
            }
             
            public static bool operator !(MsgModel msg)
            {
                return !msg.Result;
            }
             
            public static bool operator true(MsgModel msg)
            {
                return msg == true;
            }
             
            public static bool operator false(MsgModel msg)
            {
                return msg == false;
            }

            /// <summary>
            /// 扩展取2个MsgModel并集的方法(不支持MsgType=Info类型的计算)
            /// <para>[Result属性：取逻辑与][AutoClose属性：只要其中一个为true，结果为true][MsgType属性：自动运算]</para> 
            /// <para>[Title和Content属性：根据MsgType自动设置，可修改][Extend和Javascript属性：忽略]</para> 
            /// </summary> 
            public static MsgModel operator +(MsgModel msg1, MsgModel msg2)
            {
                MsgModel msgModel = new MsgModel
                {
                    Result = (msg1.Result && msg2.Result),
                    AutoClose = (msg1.AutoClose || msg2.AutoClose),
                    Type = MsgModel.ReBuildMsgType(msg1.Type, msg2.Type)
                };
                msgModel.Title = MsgModel.GetDefaultTitle(msgModel.Type);
                MsgModel.SetMsgModelContent(msg1, msg2, msgModel);
                return msgModel;
            }

            /// <summary>
            /// 重新计算新模型的消息类型
            /// </summary> 
            private static MsgType ReBuildMsgType(MsgType type1, MsgType type2)
            {
                if (type1 == MsgType.Error || type2 == MsgType.Error)
                {
                    return MsgType.Error;
                }
                if (type1 == MsgType.Warning || type2 == MsgType.Warning)
                {
                    return MsgType.Warning;
                }
                if (type1 == MsgType.Success || type2 == MsgType.Success)
                {
                    return MsgType.Success;
                }
                return MsgType.SuccessButNoRowAffected;
            }

            /// <summary>
            /// 根据合并的2个消息设置新消息模型的Content属性
            /// </summary> 
            private static void SetMsgModelContent(MsgModel msg1, MsgModel msg2, MsgModel newModel)
            {
                if (newModel.Type == MsgType.Success || newModel.Type == MsgType.SuccessButNoRowAffected)
                {
                    newModel.Content = "执行成功";
                    return;
                }
                if (newModel.Type == MsgType.Error)
                {
                    newModel.Content = msg2.Content;
                    return;
                }
                if (msg1.Type == MsgType.Warning)
                {
                    newModel.Content = string.Join("\r\n", new string[]
                    {
                    newModel.Content,
                    msg1.Content
                    });
                }
                if (msg2.Type == MsgType.Warning)
                {
                    newModel.Content = string.Join("\r\n", new string[]
                    {
                    newModel.Content,
                    msg2.Content
                    });
                }
            }
             
            private bool? _result;
             
            private bool? _autoClose;
        }
    }

}
