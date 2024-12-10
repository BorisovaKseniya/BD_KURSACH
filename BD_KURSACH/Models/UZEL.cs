using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_KURSACH.Models
{
    public class UZEL
    {
        [Key]
        public Guid KOD_UZ {  get; set; }
        public string UZ_Name {  get; set; }
        public List<SE> ses { get; set; }
  
    }
}
