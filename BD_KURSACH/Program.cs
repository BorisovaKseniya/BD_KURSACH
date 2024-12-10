using System;
using System.Security.Claims;
using BD_KURSACH.DB_Context;
using BD_KURSACH.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static bool Counter(SE se)
    {
        se.Z = (int)(se.F / se.detal.S1 / se.σF) + 1;
        se.Razn = se.Zmax - se.Z;
        se.Status = (se.Razn >= 0 ? 1 : 0);
        if (se.Status == 1)
            return true;
        else
            return false;
    }
    static void Main()
    {
        Console.WriteLine("Hello, My dear engineer! \n Сколько передач будет участвовать в расчете?\n Количество передач: ");
        string I = Console.ReadLine();
        int amount_of_se = int.Parse(I);
        int amount_of_det_types = 4;

        var context = new Context(); // создаю контекст
        var sigma = context.σF0;
        for (int i = 0; i < amount_of_se; i++)
        {
            // узнаю данные от пользователя

            Console.WriteLine("Введите F" + (i + 1) + ": ");

            double f = double.Parse(Console.ReadLine());

            Console.WriteLine("Выберите сигмаF0, при сигма0 = 1,4 MПа: ");
            var sigmaf0 = sigma.Select(x => x.σf0).ToList();
            foreach (var s in sigmaf0) Console.WriteLine(s);
          
            double σF0 = double.Parse(Console.ReadLine());

            // записываю в бд

            SE se = new SE()
            {
                NP = i + 1,
                F = f,
                σF0 = σF0,
                KOD_UZLA = Guid.Parse("08dd18af-1e7f-4d7a-888b-cc9be3c59d27")
            };

            DET detal = new DET
            {
                KOD_SE = se.KOD_SE
            };
            se.detal = detal;
            var detaltype = context.DetalTypes;
            
            for (int j = 0; j < amount_of_det_types; j++)
            {

                string profile = detaltype.FirstOrDefault(b => b.NS == (j + 1)).profile;

                switch (profile)
                {
                    case "О":
                        {
                            if(sigma.FirstOrDefault(b => b.σf0 == σF0).О == 0) 
                                break;
                            else
                            {
                                se.detal.S1 = detaltype.FirstOrDefault(b => b.profile == "О").S1;
                                se.σF = se.σF0;
                            }
                            break;
                        }

                    case "A":
                        {
                            if (sigma.FirstOrDefault(b => b.σf0 == σF0).A == 0)
                                break;
                            else
                            {
                                se.detal.S1 = detaltype.FirstOrDefault(b => b.profile == "A").S1;
                                se.σF = se.σF0;
                            }
                            break;
                        }

                    case "Б":
                        {
                            if (sigma.FirstOrDefault(b => b.σf0 == σF0).Б == 0)
                                break;
                            else
                            {
                                se.detal.S1 = detaltype.FirstOrDefault(b => b.profile == "Б").S1;
                                se.σF = se.σF0;
                            }
                            break;
                        }

                    case "В":
                        {
                            if (sigma.FirstOrDefault(b => b.σf0 == σF0).В == 0)
                                break;
                            else
                            {
                                se.detal.S1 = detaltype.FirstOrDefault(b => b.profile == "В").S1;
                                se.σF = se.σF0;
                            }
                            break;
                        }


                }

                if (Counter(se))
                {
                    context.SE.Add(se);
                    context.Detal.Add(detal);
                    context.SaveChanges();
                    Console.WriteLine("Успешный успех)");
                    break;
                }

            }
            if(se.Status == 0) Console.WriteLine("Невозможно посчитать количество ремней, возможно вы ввели неверные данные!");
        }
    }
}

