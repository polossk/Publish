using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        public BookDetail()
        {
            BookInfo = new _BookInformation();
            BookPrint = new _BookPrinting();
        }

        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="bid">BookID 唯一编号</param>
        /// <param name="info">教材信息元组</param>
        public BookDetail(int bid, _BookInformation info, _BookPrinting print)
        {
            BookID = bid;
            BookInfo = info.Clone();
            BookPrint = print.Clone();
        }

        public BookDetail(int bid, string[] rawData1, string[] rawData2)
        {
            BookID = bid;
            BookInfo = new _BookInformation(rawData1);
            BookPrint = new _BookPrinting(rawData2);
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
        public BookDetail Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as BookDetail;
        }
    }

    public class BookDetailCompare : IEqualityComparer<BookDetail>
    {
        public bool Equals(BookDetail a, BookDetail b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;
            if (Object.ReferenceEquals(a, null) || Object.ReferenceEquals(b, null))
                return false;
            return a.BookInfo.Name == b.BookInfo.Name
                && a.BookInfo.Author == b.BookInfo.Author
                && a.BookInfo.PublishingCompany == b.BookInfo.PublishingCompany;
        }

        public int GetHashCode(BookDetail book)
        {
            if (Object.ReferenceEquals(book, null)) return 0;

            Func<string, int> getHash = (str) => {return str == null ? 0 : str.GetHashCode(); };

            int hashName = getHash(book.BookInfo.Name);
            int hashAuthor = getHash(book.BookInfo.Author);
            int hashPress = getHash(book.BookInfo.PublishingCompany);

            return hashName ^ hashAuthor ^ hashPress;
        }
    }

    [Serializable] public class BookDetailList
    {
        public List<BookDetail> __list { get; set; }
        public int nextBookID { get; set; }
        public BookDetailList()
        {
            __list = new List<BookDetail>();
            nextBookID = 1;
        }
        public int getNextBID() { return nextBookID++; }

        public void ClearAll()
        {
            __list = new List<BookDetail>();
            nextBookID = 1;
        }

        public void Add(int id, BookDetail item, bool isManual = false)
        {
            item.BookID = id;
            __list.Add(item.Clone());
            nextBookID += isManual ? 1 : 0;
        }

        public void ReplaceTo(int id, BookDetail item)
        {
            if (__list.Count == 0) return;
            var result = from book in __list
                         where book.BookID == id
                         select book = item.Clone();
        }

        public bool isExist(int id)
        {
            if (__list.Count == 0) return false;
            var result = from book in __list
                         where book.BookID == id
                         select book.BookID;
            return result.Count() != 0;
        }

        public bool isExist(string bookname, string author, string press)
        {
            if (__list.Count == 0) return false;
            var result = from book in __list
                         where book.BookInfo.Name == bookname
                         where book.BookInfo.Author == author
                         where book.BookInfo.PublishingCompany == press
                         select book.BookID;
            return result.Count() != 0;
        }

        public bool tryFind(int id, out BookDetail res)
        {
            if (__list.Count == 0) { res = null; return false; }
            var result = from book in __list
                         where book.BookID == id
                         select book;
            if (result.Count() == 0) { res = null; return false; }
            res = result.First();
            return true;
        }

        public void MergeWith(BookDetailList another)
        {
            var sub = another.__list.Except<BookDetail>(__list, new BookDetailCompare());
            foreach (var item in sub)
                Add(getNextBID(), item);
        }
    }

}
