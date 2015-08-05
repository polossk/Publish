using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Data
{
    /// <summary> 教材基本信息 </summary>
    [Serializable] public class _BookInformation
    {
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
        /// <summary> 教材字数 </summary>
        public int WordCount { get; set; }

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
            Property attribute,
            int wordcount
        )
        {
            Name = name;
            Author = author;
            AuthorTitle = title;
            PublishingCompany = pressname;
            Belonging = belonging;
            Attr = attribute;
            WordCount = wordcount;
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
            BookInfo = info;
        }
    }

}
