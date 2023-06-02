using System;

namespace BLL.PropertyClasses.Master
{
    public class Assort_MasterProperty
    {
        public int assort_id { get; set; }
        public string assortname { get; set; }
        public int? sequence_no { get; set; }
        public bool? active { get; set; }
        public string remarks { get; set; }
        public int? enteredby { get; set; }
        public DateTime? entereddate { get; set; }
        public string ipaddress { get; set; }
    }
}
