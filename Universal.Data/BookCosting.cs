using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.Data
{
    [Serializable] public class BookCosting
    {
        /// <summary> 稿费 </summary>
        public double Remuneration { get; set; }
        /// <summary> 编审校对费 </summary>
        public double Checking { get; set; }
        /// <summary> 审读费 </summary>
        public double Proofreading { get; set; }
        /// <summary> 装帧设计费 </summary>
        public double BindingAndLayout { get; set; }
        /// <summary> 正文排版出片 </summary>
        public double Composing { get; set; }
        /// <summary> 拼版晒蓝 </summary>
        public double ArticlePlatemaking { get; set; }
        /// <summary> 封面制版费 </summary>
        public double CoverPlatemaking { get; set; }
        /// <summary> 单色印刷 </summary>
        public double Colorless { get; set; }
        /// <summary> 彩色印刷 </summary>
        public double Colorful { get; set; }
        /// <summary> 装订费 </summary>
        public double Binding { get; set; }
        /// <summary> 正文用纸60g双胶 </summary>
        public double W60Costing { get; set; }
        /// <summary> 正文用纸70g双胶 </summary>
        public double W70Costing { get; set; }
        /// <summary> 正文用纸80g双胶 </summary>
        public double W80Costing { get; set; }
        /// <summary> 封面用纸200g铜胶 </summary>
        public double W200CuCosting { get; set; }
        /// <summary> 宣传推广费 </summary>
        public double Propagandizing { get; set; }
        /// <summary> 运行管理费 </summary>
        public double Management { get; set; }

        /// <summary> 默认构造函数 </summary>
        /// <param name="remuneration">稿费</param>
        /// <param name="checking">编审校对费</param>
        /// <param name="proofreading">审读费</param>
        /// <param name="bindingandlayout">装帧设计费</param>
        /// <param name="composing">正文排版出片</param>
        /// <param name="aplatemaking">拼版晒蓝</param>
        /// <param name="cplatemaking">封面制版费</param>
        /// <param name="colorless">单色印刷</param>
        /// <param name="colorful">彩色印刷</param>
        /// <param name="binding">装订费</param>
        /// <param name="w60costing">正文用纸60g双胶</param>
        /// <param name="w70costing">正文用纸70g双胶</param>
        /// <param name="w80costing">正文用纸80g双胶</param>
        /// <param name="w200cu">封面用纸200g铜胶</param>
        /// <param name="propagandizing">宣传推广费</param>
        /// <param name="manage">运行管理费</param>
        public BookCosting(
            double remuneration = 40.00,  double checking = 15.00, double proofreading = 5.00, 
            double bindingandlayout = 3500, double composing = 15.00, double aplatemaking = 90.00,
            double cplatemaking = 90.00, double colorless = 15.00, double colorful = 30.00, double binding = 0.09,
            double w60costing = 200.00, double w70costing = 233.33, double w80costing = 266.67,
            double w200cu = 900, double propagandizing = 3000, double manage = 8000
        )
        {
            Remuneration = remuneration;        Checking = checking;
            Proofreading = proofreading;        BindingAndLayout = bindingandlayout;
            Composing = composing;              ArticlePlatemaking = aplatemaking;
            CoverPlatemaking = cplatemaking;    Colorless = colorless;
            Colorful = colorful;                Binding = binding;
            W60Costing = w60costing;            W70Costing = w70costing;
            W80Costing = w80costing;            W200CuCosting = w200cu;
            Propagandizing = propagandizing;    Management = manage;
        }
    }
}
