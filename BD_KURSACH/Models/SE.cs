using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace BD_KURSACH.Models
{
    public class SE
    {
        [Key]
        public Guid KOD_SE { get; set; }
        public int NP { get; set; } 

        public int α1 { get; set; } = 180;
        public int V { get; set; } = 10;
        public double C1 { get; set; } = 1;    //?
        public double C2 { get; set; } = 1;    //?
        public double C3 { get; set; } = 1;    //?
        public double σ0 { get; set; } = 1.4; 
        public double σF0 { get; set; } //рассчитывается по формуле
        public double σF { get; set; }  //рассчитывается по формуле
        public double F {  get; set; }  //спрашиваем на входе

       
        public int Zmax { get; set; } = 6;
        public int Z { get; set; }      //рассчитывается по формуле
        public int Razn {  get; set; }  // рассчитывается по формуле
        public int Status {  get; set; } // рассчитывается по логической формуле в зависимости от razn

        public string SE_Name { get; set; } = "Передача";
        public string SE_Type { get; set; } = "Ременная";
        public string SE_Вид { get; set; }= "Клиноременная";
        public string TN { get; set; }= "Спокойная";

        public Guid KOD_UZLA { get; set; }
        public UZEL uzel { get; set; }
        public DET detal { get; set; }
    }
}
