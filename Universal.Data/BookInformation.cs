using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Universal.Data
{
    /// <summary> 教材基本信息 </summary>
    [Serializable] public class _BookInformation
    {
        public string[] _rawData_ = new string[6];
        /// <summary> 职称列表 </summary>
        public enum AcademicTitle
        {
            /// <summary> 院士 </summary>
            Academician,
            /// <summary> 教授 </summary>
            Professor,
            /// <summary> 副教授 </summary>
            AdjunctProfessor,
            /// <summary> 讲师 </summary>
            Lecturer
        };
        /// <summary> 教材类别列表 </summary>
        public enum Category
        {
            /// <summary> 社会科学 </summary>
            SocialSciences,
            /// <summary> 工科教材 </summary>
            EngineeringTextbook,
            /// <summary> 理科教材 </summary>
            ScienceTextbook
        };
        /// <summary> 教材属性列表 </summary>
        public enum Property
        {
            /// <summary> 专著 </summary>
            Monograph,
            /// <summary> 教材 </summary>
            Textbook
        };
        /// <summary> 教材名称 </summary>
        public string Name { get; set; }
        /// <summary> 作者 </summary>
        public string Author { get; set; }
        /// <summary> 作者职称 </summary>
        public AcademicTitle AuthorTitle { get; set; }
        /// <summary> 出版社 </summary>
        public string PublishingCompany { get; set; }
        /// <summary> 教材类别 </summary>
        public Category Belonging { get; set; }
        /// <summary> 教材属性 </summary>
        public Property Attr { get; set; }
        

        /// <summary> 默认构造函数 </summary>
        public _BookInformation() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="name">教材名称</param>
        /// <param name="author">作者</param>
        /// <param name="title">作者职称</param>
        /// <param name="pressname">出版社</param>
        /// <param name="belonging">教材类别</param>
        /// <param name="attribute">教材属性</param>
        /// <param name="wordcount">字数</param>
        public _BookInformation(
            string name,
            string author,
            AcademicTitle title,
            string pressname,
            Category belonging,
            Property attribute
        )
        {
            Name = name;
            Author = author;
            AuthorTitle = title;
            PublishingCompany = pressname;
            Belonging = belonging;
            Attr = attribute;
            buildRawData();
        }

        public _BookInformation(string[] rawData)
        {
            _rawData_ = (string[])rawData.Clone();
            Name = rawData[0];
            Author = rawData[1];
            switch (rawData[2])
            {
                case "院士":
                    AuthorTitle = AcademicTitle.Academician; break;
                case "教授":
                    AuthorTitle = AcademicTitle.Professor; break;
                case "副教授":
                    AuthorTitle = AcademicTitle.AdjunctProfessor; break;
                case "讲师":
                    AuthorTitle = AcademicTitle.Lecturer; break;
                default: break;
            }
            PublishingCompany = rawData[3];
            switch (rawData[4])
            {
                case "社会科学":
                    Belonging = Category.SocialSciences; break;
                case "工科教材":
                    Belonging = Category.EngineeringTextbook; break;
                case "理科教材":
                    Belonging = Category.ScienceTextbook; break;
                default: break;
            }
            switch (rawData[5])
            {
                case "专著":
                    Attr = Property.Monograph; break;
                case "教材":
                    Attr = Property.Textbook; break;
                default: break;
            }
        }

        public void buildRawData()
        {
            _rawData_[0] = Name;
            _rawData_[1] = Author;
            switch (AuthorTitle)
            {
                case AcademicTitle.Academician:
                    _rawData_[2] = "院士"; break;
                case AcademicTitle.Professor:
                    _rawData_[2] = "教授"; break;
                case AcademicTitle.AdjunctProfessor:
                    _rawData_[2] = "副教授"; break;
                case AcademicTitle.Lecturer:
                    _rawData_[2] = "讲师"; break;
                default: break;
            }
            _rawData_[3] = PublishingCompany;
            switch (Belonging)
            {
                case Category.SocialSciences:
                    _rawData_[4] = "社会科学"; break;
                case Category.EngineeringTextbook:
                    _rawData_[4] = "工科教材"; break;
                case Category.ScienceTextbook:
                    _rawData_[4] = "理科教材"; break;
                default: break;
            }
            switch (Attr)
            {
                case Property.Monograph:
                    _rawData_[5] = "专著"; break;
                case Property.Textbook:
                    _rawData_[5] = "教材"; break;
                default: break;
            }
        }
        public _BookInformation Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as _BookInformation;
        }
    }

    /// <summary> 教材基本信息 带BookID </summary>
    [Serializable] public class BookInformation
    {
        /// <summary> 唯一标识ID </summary>
        public int BookID { get; set; }
        /// <summary> 教材具体信息 </summary>
        public _BookInformation BookInfo { get; set; }

        /// <summary> 默认构造函数 </summary>
        public BookInformation() { }
        /// <summary>
        /// 属性赋值构造函数
        /// </summary>
        /// <param name="bid">BookID 唯一编号</param>
        /// <param name="info">教材信息元组</param>
        public BookInformation(int bid, _BookInformation info)
        {
            BookID = bid;
            BookInfo = info.Clone();
        }
        public BookInformation Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as BookInformation;
        }

    }

    public class BookInformationCompare : IEqualityComparer<BookInformation>
    {
        public bool Equals(BookInformation a, BookInformation b)
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

        public int GetHashCode(BookInformation book)
        {
            if (Object.ReferenceEquals(book, null)) return 0;
            return book.BookID.GetHashCode();
        }
    }

    [Serializable] public class BookInformationList
    {
        public List<BookInformation> Data { get; set; }
        public BookInformationList() { ClearAll(); }
        public void ClearAll() { Data = new List<BookInformation>(); }
        public void Add(BookInformation item) { Data.Add(item); }
        public void ReplaceTo(int id, BookInformation item)
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

        public bool tryFind(int id, out BookInformation res)
        {
            if (Data.Count == 0) { res = null; return false; }
            var result = from book in Data
                         where book.BookID == id
                         select book;
            if (result.Count() == 0) { res = null; return false; }
            res = result.First();
            return true;
        }
        public void MergeWith(BookInformationList another)
        {
            var sub = this.Data.Except<BookInformation>(another.Data, new BookInformationCompare());
            this.Data = new List<BookInformation>();
            foreach (var item in another.Data) this.Add(item);
            foreach (var item in sub) this.Add(item);
        }
    }

}
