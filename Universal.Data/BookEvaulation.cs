using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Data
{
    /// <summary> 教材评价信息 </summary>
    [Serializable] public class _Evaulation
    {
        /// <summary> 评价等级列表 </summary>
        public enum Valuation
        {
            /// <summary> 低 </summary>
            Low,
            /// <summary> 中 </summary>
            Medium,
            /// <summary> 高 </summary>
            High
        };
        /// <summary> 教材水平 </summary>
        public Valuation Level { get; set; }
        /// <summary> 出版社服务质量 </summary>
        public Valuation ServiceQuality { get; set; }
        /// <summary> 出版社影响力 </summary>
        public Valuation Influence { get; set; }
        /// <summary> 应用面 </summary>
        public Valuation Application { get; set; }
        /// <summary> 印数 </summary>
        public int PrintingCount { get; set; }
        /// <summary> 设置印数 </summary>
        public void SetPrintingCount()
        {
            switch (Application)
            {
                case Valuation.Low: PrintingCount = 1200; break;
                case Valuation.Medium: PrintingCount = 2000; break;
                case Valuation.High: PrintingCount = 4000; break;
                default: PrintingCount = 0; break;
            }
        }
        /// <summary> 默认构造函数 </summary>
        public _Evaulation() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="level">教材水平</param>
        /// <param name="service">出版社服务质量</param>
        /// <param name="apply">出版社影响力</param>
        /// <param name="pcount">应用面</param>
        public _Evaulation(Valuation level, Valuation service, Valuation influ, Valuation apply)
        {
            Level = level;
            ServiceQuality = service;
            Influence = influ;
            Application = apply;
            SetPrintingCount();
        }

    }

    /// <summary> 教材评价信息 带EvalueID </summary>
    [Serializable] public class BookEvaulation
    {
        /// <summary> 评价编号 </summary>
        public int EvauleID { get; set; }
        /// <summary> 教材编号 </summary>
        public int BookID { get; set; }
        /// <summary> 评委编号 </summary>
        public int UserID { get; set; }
        /// <summary> 评价详情 </summary>
        public _Evaulation Value { get; set; }
        /// <summary> 默认构造函数 </summary>
        public BookEvaulation() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="eid">评价编号</param>
        /// <param name="bid">教材编号</param>
        /// <param name="uid">评委编号</param>
        /// <param name="value">评价详情</param>
        public BookEvaulation(int eid, int bid, int uid, _Evaulation value)
        {
            EvauleID = eid;
            BookID = bid;
            UserID = uid;
            Value = value;
        }
    }
}
