using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_KURSACH.Models
{
    public class DET
    {
        [Key]
        public Guid KOD_DET { get; set; }
        public int S1 {  get; set; }  
        public string DET_Name { get; set; } = "ремень";
        public string DET_Type { get; set; } = "клиноременной";
        public string DET_Вид { get; set; } = "нормальный";

        public Guid KOD_SE { get; set; } // Внешний ключ
        public SE ses { get; set; } // Навигационное свойство
    }
}
