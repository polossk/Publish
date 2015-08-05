using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Data
{
    /// <summary> 教材印刷信息 </summary>
    [Serializable] public class _BookPrinting
    {
        /// <summary> 装订格式列表 </summary>
        public enum Binding
        {
            /// <summary> 精装 </summary>
            Hardback,
            /// <summary> 平装 </summary>
            Paperback
        };
        /// <summary> 纸张大小列表 </summary>
        public enum BookSizeFormat
        {
            /// <summary> 16开 </summary>
            A4Paper = 16,
            /// <summary> 32开 </summary>
            A5Paper = 32
        };
        /// <summary> 册数列表 </summary>
        public enum BookNumer
        {
            /// <summary> 单册 </summary>
            Single = 1,
            /// <summary> 上下册 </summary>
            Double = 2,
            /// <summary> 上中下册 </summary>
            Triple = 3
        };
        /// <summary> 纸张规格列表 </summary>
        public enum PaperFormat
        {
            /// <summary> 60克双胶 </summary>
            w60,
            /// <summary> 70克双胶 </summary>
            w70,
            /// <summary> 80克双胶 </summary>
            w80
        };
        
        /// <summary> 装订规格 </summary>
        public Binding BookBinding { get; set; }
        /// <summary> 开本大小 </summary>
        public BookSizeFormat BookSize { get; set; }
        /// <summary> 册数 </summary>
        public BookNumer BookCount { get; set; }
        /// <summary> 正文用纸 </summary>
        public PaperFormat PaperUsing { get; set; }
        /// <summary> 是否彩印 </summary>
        public bool IsColorful { get; set; }

        /// <summary> 默认构造函数 </summary>
        public _BookPrinting() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="bindingtype">装订规格</param>
        /// <param name="size">开本大小</param>
        /// <param name="count">册数</param>
        /// <param name="papertype">正文用纸</param>
        /// <param name="iscolorful">是否彩印</param>
        public _BookPrinting(
            Binding bindingtype, 
            BookSizeFormat size,
            BookNumer count,
            PaperFormat papertype,
            bool iscolorful
        )
        {
            BookBinding = bindingtype;
            BookSize = size;
            BookCount = count;
            PaperUsing = papertype;
            IsColorful = iscolorful;
        }

    }

    /// <summary> 教材印刷信息 带BookID </summary>
    [Serializable] public class BookPrinting
    {
        /// <summary> 唯一标识ID </summary>
        public int BookID { get; set; }
        /// <summary> 教材具体信息 </summary>
        public _BookPrinting BookPrint { get; set; }

        /// <summary> 默认构造函数 </summary>
        public BookPrinting() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="bid">BookID 唯一编号</param>
        /// <param name="info">教材信息元组</param>
        public BookPrinting(int bid, _BookPrinting print)
        {
            BookID = bid;
            BookPrint = print;
        }
    }
}
