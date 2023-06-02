using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PropertyClasses.Master
{
    public class ConfigRole_MasterProperty
    {
        public int role_id { get; set; }
        public int form_id { get; set; }
        public bool? active { get; set; }
        public string role_name { get; set; }
        public bool? showmfgrates { get; set; }
        public bool? showcostrates { get; set; }
        public bool? showsalerates { get; set; }
        public bool? isactive { get; set; }
        public Int32? enteredby { get; set; }
        public DateTime? entereddate { get; set; }
        public string enteredtime { get; set; }
        public bool? ipaddress { get; set; }
        public int role_permission_id { get; set; }
        public int permission_id { get; set; }
        public int allow_view { get; set; }
        public int allow_add { get; set; }
        public int allow_edit { get; set; }
        public int allow_delete { get; set; }
        public int allow_export { get; set; }
        public int allow_print { get; set; }
        public int allow_email { get; set; }
        public int allow_attachment { get; set; }
        public string allow_password { get; set; }
    }
}
