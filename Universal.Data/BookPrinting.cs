using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Universal.Data
{
    /// <summary> 教材印刷信息 </summary>
    [Serializable] public class _BookPrinting
    {
        public string[] _rawData_ = new string[6];

        /// <summary> 教材字数 </summary>
        public int WordCount { get; set; }
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
            int words,
            Binding bindingtype, 
            BookSizeFormat size,
            BookNumer count,
            PaperFormat papertype,
            bool iscolorful
        )
        {
            WordCount = words;
            BookBinding = bindingtype;
            BookSize = size;
            BookCount = count;
            PaperUsing = papertype;
            IsColorful = iscolorful;
            buildRawData();
        }

        public _BookPrinting(string[] rawData)
        {
            _rawData_ = (string[])rawData.Clone();
            WordCount = int.Parse(rawData[0]);
            switch (rawData[1])
            {
                case "精装":
                    BookBinding = Binding.Hardback; break;
                case "平装":
                    BookBinding = Binding.Paperback; break;
                default: break;
            }
            switch (rawData[2])
            {
                case "16开":
                    BookSize = BookSizeFormat.A4Paper; break;
                case "32开":
                    BookSize = BookSizeFormat.A5Paper; break;
                default: break;
            }
            switch (rawData[3])
            {
                case "单册":
                    BookCount = BookNumer.Single; break;
                case "上下册":
                    BookCount = BookNumer.Double; break;
                case "上中下册":
                    BookCount = BookNumer.Triple; break;
                default: break;
            }
            switch (rawData[4])
            {
                case "60g双胶":
                    PaperUsing = PaperFormat.w60; break;
                case "70g双胶":
                    PaperUsing = PaperFormat.w70; break;
                case "80g双胶":
                    PaperUsing = PaperFormat.w80; break;
                default: break;
            }
            switch (rawData[5])
            {
                case "是":
                    IsColorful = true; break;
                case "否":
                    IsColorful = false; break;
                default: break;
            }
        }

        public void buildRawData()
        {
            _rawData_[0] = WordCount.ToString();
            switch (BookBinding)
            {
                case Binding.Hardback:
                    _rawData_[1] = "精装"; break;
                case Binding.Paperback:
                    _rawData_[1] = "平装"; break;
                default: break;
            }
            switch (BookSize)
            {
                case BookSizeFormat.A4Paper:
                    _rawData_[2] = "16开"; break;
                case BookSizeFormat.A5Paper:
                    _rawData_[2] = "32开"; break;
                default: break;
            }
            switch (BookCount)
            {
                case BookNumer.Single:
                    _rawData_[3] = "单册"; break;
                case BookNumer.Double:
                    _rawData_[3] = "上下册"; break;
                case BookNumer.Triple:
                    _rawData_[3] = "上中下册"; break;
                default: break;
            }
            switch (PaperUsing)
            {
                case PaperFormat.w60:
                    _rawData_[4] = "60g双胶"; break;
                case PaperFormat.w70:
                    _rawData_[4] = "70g双胶"; break;
                case PaperFormat.w80:
                    _rawData_[4] = "80g双胶"; break;
                default: break;
            }
            _rawData_[5] = IsColorful ? "是" : "否";
        }
        public _BookPrinting Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as _BookPrinting;
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
            BookPrint = print.Clone();
        }

        public BookPrinting Clone()
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as BookPrinting;
        }
    }
}
