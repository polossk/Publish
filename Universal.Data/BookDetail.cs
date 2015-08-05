using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Data
{
    /// <summary> 教材信息 带BookID </summary>
    [Serializable] public class BookDetail
    {
        /// <summary> 唯一标识ID </summary>
        public int BookID { get; set; }
        /// <summary> 教材具体信息 </summary>
        public _BookInformation BookInfo { get; set; }
        /// <summary> 教材具体信息 </summary>
        public _BookPrinting BookPrint { get; set; }

        /// <summary> 默认构造函数 </summary>
        public BookDetail() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="bid">BookID 唯一编号</param>
        /// <param name="info">教材信息元组</param>
        public BookDetail(int bid, _BookInformation info, _BookPrinting print)
        {
            BookID = bid;
            BookInfo = info;
            BookPrint = print;
        }
        /// <summary> 获取教材属性信息 </summary>
        public BookInformation GetBookInfo()
        {
            return new BookInformation(BookID, BookInfo);
        }
        /// <summary> 获取教材印刷信息 </summary>
        public BookPrinting GetBookPrint()
        {
            return new BookPrinting(BookID, BookPrint);
        }
    }
}
