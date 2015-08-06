using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Data
{
    [Serializable] public class BookFinal
    {
        public BookDetail MainInfo { get; set; }
        public BookEvaulation MainValue { get; set; }
        public double Costing { get; set; }
        public double FinalValue { get; set; }
        /// <summary> 计算总成本 </summary>
        /// <param name="r">成本单价</param>
        public void setCosting(ref BookCosting r)
        {
            int dBookCount = (int)MainInfo.BookPrint.BookCount;             // 册数
            int dBookPrint = MainValue.Value.PrintingCount;                 // 印数
            dBookPrint = (dBookPrint >= 2000) ? 2000 : dBookPrint;          // 只资助 2,000 册
            int dWordCount = MainInfo.BookPrint.WordCount;                  // 字数
            int dBookSize = (int)MainInfo.BookPrint.BookSize;               // 开本
            double fSheet = Math.Ceiling(dWordCount * 4 / 3.0 / dBookSize); // 印张
            double fPaperCount = dBookPrint * fSheet / 500.0;               // 令数
            // 印刷方式和印刷用纸
            double fPrintMethod = MainInfo.BookPrint.IsColorful ? r.Colorful : r.Colorless;
            double fPrintPaper = r.W60Costing;
            switch (MainInfo.BookPrint.PaperUsing)
            {
                case _BookPrinting.PaperFormat.w60 : fPrintPaper = r.W60Costing; break;
                case _BookPrinting.PaperFormat.w70 : fPrintPaper = r.W70Costing; break;
                case _BookPrinting.PaperFormat.w80 : fPrintPaper = r.W80Costing; break;
                default: break;
            }
            // 固定项目
            double fConstCosting = r.BindingAndLayout + r.Propagandizing + r.Management;
            // 字数项目
            double fWordsCosting = dWordCount * (r.Remuneration + r.Checking + r.Proofreading);
            // 排版项目
            double fCompsCosting = dWordCount * r.Composing * 4 / 3; 
            // 制版项目
            double fPlateCosting = (r.ArticlePlatemaking + r.CoverPlatemaking) * (fSheet + 2 * dBookCount);
            // 印刷项目
            double fPrintCosting = fPrintMethod * fSheet + fPrintPaper * fPaperCount;
            // 装订项目
            double fCoverCosting = 2 * fSheet * dBookCount * r.Binding;
            // 综合费用
            Costing = fConstCosting + fWordsCosting + fCompsCosting + fPlateCosting + fPrintCosting + fCoverCosting;
        }

        private static double[] scoreA1 = { 1.00, 0.58, 0.42 };
        private static double[] scoreA2 = { 0.00, 0.52, 1.00 };
        private static double[] scoreB0 = { 0.00, 0.22, 0.36 };

        /// <summary> 计算最后资助价格 </summary>
        public void setFinalValue()
        {
            double coefA1 = scoreA1[(int)MainValue.Value.Level];
            double coefA2 = scoreA2[(int)MainValue.Value.ServiceQuality];
            double coefA3 = scoreA2[(int)MainValue.Value.Influence];
            double coefB0 = scoreB0[(int)MainValue.Value.Application];
            double tempA = Costing * (0.6 * coefA1 + 0.15 * coefA2 + 0.15 * coefA3);
            double tempB = Costing * coefB0;
            FinalValue = Math.Ceiling(tempA - tempB);
        }
        /// <summary> 获取最后资助金额 </summary>
        /// <param name="r">成本单价</param>
        /// <returns>最后资助金额</returns>
        public double getFinalValue(ref BookCosting r)
        {
            setCosting(ref r);
            setFinalValue();
            return FinalValue;
        }

        /// <summary> 默认构造函数 </summary>
        public BookFinal() { }
        /// <summary>
        /// 标准构造函数
        /// </summary>
        /// <param name="info">教材属性</param>
        /// <param name="value">教材评价</param>
        public BookFinal(BookDetail info, BookEvaulation value)
        {
            MainInfo = info;
            MainValue = value;
        }
    }
}
