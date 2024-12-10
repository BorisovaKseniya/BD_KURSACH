using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_KURSACH.Models
{
    public class DET_type
    {
        [Key]
        public int NS { get; set; }
        public string profile {  get; set; }
        public int S1 { get; set; }
        public string DET_Name { get; set; } = "ремень";
        public string DET_Type { get; set; } = "клиноременной";
        public string DET_Вид { get; set; } = "нормальный";
    }
}
