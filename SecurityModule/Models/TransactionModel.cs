using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Models
{
    public class TransactionModel
    {
        public string TrId { get; set; }
        public DateTime Date { get; set; }
        public float DiscountParcent { get; set; }
        public float FlatDiscount { get; set; }
        public float DiscountAmount { get; set; }
        public float GrandTotal { get; set; }
        public string PaymentType { get; set; }
        public float ColllectedAmount { get; set; }
        public float ChangeAmount { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string OutletCode { get; set; }
    }
}
