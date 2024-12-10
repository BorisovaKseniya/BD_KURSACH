using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_KURSACH.Models;
using Microsoft.EntityFrameworkCore;

namespace BD_KURSACH.DB_Context
{
    public class Context : DbContext
    {
        // Конструктор с параметрами (для Dependency Injection)
        public Context(DbContextOptions<Context> options) : base(options) { }

        // Параметрless конструктор (для миграций)
        public Context() { }
        public DbSet<UZEL> Uzel { get; set; }
        public DbSet<SE> SE { get; set; }
        public DbSet<DET> Detal{ get; set; }
        public DbSet<DET_type> DetalTypes{ get; set; }
        public DbSet<σF0> σF0 { get; set; }

        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Проверяем, настроен ли контекст
            {
                optionsBuilder.UseMySql(
                    "Server=localhost;Database=dongdvadcatshest;Uid=root;Pwd=vsehorosho123);",
                    new MySqlServerVersion(new Version(8, 0, 33))); // Замените версию на вашу
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка связи один ко многим
            modelBuilder.Entity<SE>()
                .HasOne(p => p.uzel)  // Каждому продукту соответствует одна категория
                .WithMany(c => c.ses) // Каждой категории соответствует множество продуктов
                .HasForeignKey(p => p.KOD_UZLA); // Устанавливаем внешний ключ на поле CategoryId

            base.OnModelCreating(modelBuilder);


            // Один-к-одному между DET и SE
            modelBuilder.Entity<DET>()
                .HasOne(d => d.ses)
                .WithOne(s => s.detal)
                .HasForeignKey<DET>(d => d.KOD_SE) // Связь через KSE
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
