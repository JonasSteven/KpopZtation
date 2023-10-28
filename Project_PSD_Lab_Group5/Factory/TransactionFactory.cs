using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader AddToTransactionHeader(DateTime datetime, int custId)
        {
            TransactionHeader transHeader = new TransactionHeader();
            transHeader.TransactionDate = datetime;
            transHeader.CustomerID = custId;

            return transHeader;
        }

        public static TransactionDetail AddToTransactionDetail(int transHeaderId, int albumId, int qty)
        {
            TransactionDetail transDetail = new TransactionDetail();
            transDetail.TransactionID = transHeaderId;
            transDetail.AlbumID = albumId;
            transDetail.Qty = qty;

            return transDetail;
        }
    }
}