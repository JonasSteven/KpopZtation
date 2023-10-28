using Project_PSD_Lab_Group5.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_Lab_Group5.View
{
    public partial class TransactionReport_Page : System.Web.UI.Page
    {
        public static LocalDBEntities1 db = new LocalDBEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TransactionHeader> transHeader = db.TransactionHeaders.ToList();

            DataSet1 data = GetTransaction(transHeader);
            CrystalReport6 rpt = new CrystalReport6();
            rpt.SetDataSource(data);
            reportView.ReportSource = rpt;
        }

        public static Album getAlbum(int id)
        {
            return (from x in db.Albums where x.AlbumID == id select x).FirstOrDefault();
        }

        private DataSet1 GetTransaction(List<TransactionHeader> trans)
        {
            DataSet1 data = new DataSet1();

            var thTable = data.TransactionHeader;
            var tdTable = data.TransactionDetail;

            foreach (TransactionHeader th in trans)
            {
                var hrow = thTable.NewRow();
                hrow["TransactionID"] = th.TransactionID;
                hrow["CustomerID"] = th.CustomerID;
                hrow["TransactionDate"] = th.TransactionDate;
                thTable.Rows.Add(hrow);

                foreach(TransactionDetail td in th.TransactionDetails)
                {
                    var drow = tdTable.NewRow();
                    drow["TransactionID"] = td.TransactionID;
                    drow["AlbumID"] = td.AlbumID;
                    drow["AlbumName"] = getAlbum(td.AlbumID).AlbumName;
                    drow["Qty"] = td.Qty;
                    drow["AlbumPrice"] = getAlbum(td.AlbumID).AlbumPrice;

                    tdTable.Rows.Add(drow);
                }
            }

            return data;
        }
    }
}