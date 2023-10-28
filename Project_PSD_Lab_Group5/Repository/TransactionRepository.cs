using Project_PSD_Lab_Group5.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_PSD_Lab_Group5.Repository
{
    public class TransactionRepository
    {
        public static LocalDBEntities1 db = new LocalDBEntities1();

        public static int AddToTransactionHeader(DateTime datetime, int custId)
        {
            TransactionHeader transHeader = TransactionFactory.AddToTransactionHeader(datetime, custId);

            db.TransactionHeaders.Add(transHeader);

            db.SaveChanges();
            
            return transHeader.TransactionID;
        }

        public static void AddToTransactionDetail(int transHeaderId, int albumId, int qty)
        {
            TransactionDetail transDetail = TransactionFactory.AddToTransactionDetail(transHeaderId, albumId, qty);

            db.TransactionDetails.Add(transDetail);

            db.SaveChanges();
        }

        public static TransactionHeader GetTransactionById(int transId)
        {
            return (from th in db.TransactionHeaders where th.TransactionID == transId select th).FirstOrDefault();
        }

        public static dynamic GetTransactionHistory(Customer cust)
        {
            return db.TransactionDetails.Join(
                db.TransactionHeaders, td => td.TransactionID, th => th.TransactionID,
                (td, th) => new
                {
                    td, th
                }
                ).Join(db.Albums, tranDet => tranDet.td.AlbumID, alb => alb.AlbumID,
                (tranDet, alb) => new
                {
                    transactionId = tranDet.td.TransactionID,
                    customerId = cust.CustomerID,
                    transactionDate = tranDet.th.TransactionDate,
                    courier = "BINUS Si Cepat Courier",
                    customerName = cust.CustomerName,
                    albumImage = alb.AlbumImage,
                    albumName = alb.AlbumName,
                    qty = tranDet.td.Qty,
                    albumPrice = alb.AlbumPrice
                }
                ).Where(custom => custom.customerId == cust.CustomerID).ToList();
        }

        public static TransactionDetail GetTransactionDetailById(int transId)
        {
            return (from td in db.TransactionDetails where td.TransactionID == transId select td).FirstOrDefault();
        }

        public static List<TransactionHeader> GetTransaction()
        {
            return (db.TransactionHeaders.ToList());
        }
    }
}