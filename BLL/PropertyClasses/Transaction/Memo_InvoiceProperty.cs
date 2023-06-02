using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PropertyClasses.Transaction
{
    public class Memo_InvoiceProperty
    {
        //private List<ListError> m_lstErrors;

        public int company_id { get; set; }
        public int branch_id { get; set; }
        public int location_id { get; set; }
        public int department_id { get; set; }
        public string memo_date { get; set; }
        public int delivery_type_id { get; set; }
        public int currency_id { get; set; }
        public int rate_type_id { get; set; }
        //public string particulars { get; set; }
        //public int hsn { get; set; }
        //public decimal cgst_rate { get; set; }
        //public decimal cgst_amount { get; set; }
        //public decimal sgst_rate { get; set; }
        //public decimal sgst_amount { get; set; }
        //public decimal igst_rate { get; set; }
        //public decimal igst_amount { get; set; }
        //public decimal net_amount { get; set; }
        public int form_id { get; set; }
        public int Party_Id { get; set; }
        public int Broker_Id { get; set; }
        public string Special_Remark { get; set; }
        public string Client_Remark { get; set; }
        public string Payment_Remark { get; set; }
        public decimal Gross_Amount { get; set; }
        public decimal Brokerage_Per { get; set; }
        public decimal Brokerage_Amt { get; set; }
        //public decimal Discount_Per { get; set; }
        //public decimal Discount_Amt { get; set; }
        //public decimal Interest_Per { get; set; }
        //public decimal Interest_Amt { get; set; }
        //public decimal Shipping_Charge { get; set; }


        public int memo_id { get; set; }
        public string memo_no { get; set; }
        public int assort_id { get; set; }
        public int sieve_id { get; set; }
        public int sub_sieve_id { get; set; }
        public decimal pcs { get; set; }
        public decimal carat { get; set; }
        public decimal rate { get; set; }
        public decimal amount { get; set; }
        public decimal current_rate { get; set; }
        public decimal current_amount { get; set; }
        public string remarks { get; set; }
        public int user_id { get; set; }
        public string entry_date { get; set; }
        public string entry_time { get; set; }
        public string ip_address { get; set; }

    }
}
