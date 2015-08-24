using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishServer
{
    public class ListViewBooksSorter : System.Collections.IComparer
    {
        private int ColumnToSort;
        private System.Windows.Forms.SortOrder OrderOfSort;
        private System.Collections.CaseInsensitiveComparer ObjectCompare;
        public ListViewBooksSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = System.Windows.Forms.SortOrder.Ascending;
            ObjectCompare = new System.Collections.CaseInsensitiveComparer();
        }

        private int BookNumberToInt(string str)
        {
            switch (str)
            {
                case "单册": return 1;
                case "上下册": return 2;
                case "上中下册": return 3;
                default: return 0;
            }
        }

        public int Compare(object x, object y)
        {
            int cmpResult;
            System.Windows.Forms.ListViewItem itemX, itemY;
            itemX = x as System.Windows.Forms.ListViewItem;
            itemY = y as System.Windows.Forms.ListViewItem;
            string xText = itemX.SubItems[ColumnToSort].Text;
            string yText = itemY.SubItems[ColumnToSort].Text;
            double xNum, yNum;
            switch (ColumnToSort)
            {
                case 0: case 7:
                    xNum = double.Parse(xText);
                    yNum = double.Parse(yText);
                    cmpResult = xNum.CompareTo(yNum);
                    break;
                case 10:
                    xNum = BookNumberToInt(xText);
                    yNum = BookNumberToInt(yText);
                    cmpResult = xNum.CompareTo(yNum);
                    break;
                default:
                    cmpResult = xText.CompareTo(yText);
                    break;
            }
            switch (OrderOfSort)
            {
                case System.Windows.Forms.SortOrder.Ascending: return cmpResult;
                case System.Windows.Forms.SortOrder.Descending: return -cmpResult;
                default: return 0;
            }
        }
        public int SortColumn { set { ColumnToSort = value; } get { return ColumnToSort; } }
        public System.Windows.Forms.SortOrder Order
        {
            set { OrderOfSort = value; }
            get { return OrderOfSort; }
        }
    }
}
