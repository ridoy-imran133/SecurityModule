using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Entities
{
    [Table("Screen")]
    public class Screen
    {
        public string ProjectCode { get; set; }
        public string ModuleCode { get; set; }
        [Key]
        public string ScreenCode { get; set; }
        public string ScreenName { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public string ParentsCode { get; set; }        
        public string ScDescription { get; set; }
        public string Sequence { get; set; }
        public string IsActive { get; set; }
        public string IsDelete { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
