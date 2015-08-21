using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Universal.Data
{
    /// <summary> 教材评价信息 </summary>
    [Serializable] public class _Evaluaion
    {
        /// <summary> 评价等级列表 </summary>
        public enum Valuation
        {
            /// <summary> 高 </summary>
            High,
            /// <summary> 中 </summary>
            Medium,
            /// <summary> 低 </summary>
            Low
        };
        /// <summary> 教材水平 </summary>
        public Valuation Level { get; set; }
        /// <summary> 出版社服务质量 </summary>
        public Valuation ServiceQuality { get; set; }
        /// <summary> 出版社影响力 </summary>
        public Valuation Influence { get; set; }
        /// <summary> 教材应用面 </summary>
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
        public _Evaluaion() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="level">教材水平</param>
        /// <param name="service">出版社服务质量</param>
        /// <param name="apply">出版社影响力</param>
        /// <param name="pcount">应用面</param>
        public _Evaluaion(Valuation level, Valuation service, Valuation influ, Valuation apply)
        {
            Level = level;
            ServiceQuality = service;
            Influence = influ;
            Application = apply;
            SetPrintingCount();
        }
        public _Evaluaion Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as _Evaluaion;
        }
    }

    /// <summary> 教材评价信息 带EvalueID </summary>
    [Serializable] public class BookEvaluaion
    {
        /// <summary> 评价编号 </summary>
        public int EvauleID { get; set; }
        /// <summary> 教材编号 </summary>
        public int BookID { get; set; }
        /// <summary> 评委编号 </summary>
        public int UserID { get; set; }
        /// <summary> 评价详情 </summary>
        public _Evaluaion Value { get; set; }
        /// <summary> 默认构造函数 </summary>
        public BookEvaluaion() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="eid">评价编号</param>
        /// <param name="bid">教材编号</param>
        /// <param name="uid">评委编号</param>
        /// <param name="value">评价详情</param>
        public BookEvaluaion(int eid, int bid, int uid, _Evaluaion value)
        {
            EvauleID = eid;
            BookID = bid;
            UserID = uid;
            Value = value;
        }
        public BookEvaluaion Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as BookEvaluaion;
        }
    }

    public class BookEvaluaionCompare : IEqualityComparer<BookEvaluaion>
    {
        public bool Equals(BookEvaluaion a, BookEvaluaion b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null))
                return false;
            return a.BookID == b.BookID;
            /*  
                a.BookInfo.Name == b.BookInfo.Name
                && a.BookInfo.Author == b.BookInfo.Author
                && a.BookInfo.PublishingCompany == b.BookInfo.PublishingCompany;
            */
        }

        public int GetHashCode(BookEvaluaion book)
        {
            if (Object.ReferenceEquals(book, null)) return 0;
            return book.BookID.GetHashCode();
        }
    }
    [Serializable] public class BookEvaluaionList
    {
        public List<BookEvaluaion> Data { get; set; }
        public BookEvaluaionList() { ClearAll(); }
        public void ClearAll() { Data = new List<BookEvaluaion>(); }
        public void Add(BookEvaluaion item) { Data.Add(item); }
        public void ReplaceTo(int id, BookEvaluaion item)
        {
            var result = from book in Data
                         where book.BookID == id
                         select book = item.Clone();
        }

        public bool isExist(int id)
        {
            if (Data.Count == 0) return false;
            var result = from book in Data
                         where book.BookID == id
                         select book.BookID;
            return result.Count() != 0;
        }

        public bool tryFind(int id, out BookEvaluaion res)
        {
            if (Data.Count == 0) { res = null; return false; }
            var result = from book in Data
                         where book.BookID == id
                         select book;
            if (result.Count() == 0) { res = null; return false; }
            res = result.First();
            return true;
        }
        public void MergeWith(BookEvaluaionList another)
        {
            var sub = another.Data.Except<BookEvaluaion>(Data, new BookEvaluaionCompare());
            foreach (var item in sub)
                Add(item);
        }
    }
}
