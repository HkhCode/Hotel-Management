using System;
using System.Collections.Generic;
using System.Text;
using Faradars.Models;
using Faradars.Models.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Faradars.Models.ViewModel;


namespace Faradars.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private static bool _Created = false;

        public ApplicationDbContext()
        {
            if (!_Created)
            {
                _Created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Hotels; Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PardakhtHotel>()
                         .HasOne<RezervHotel>(a => a.RezervHotel)
              .WithMany(b => b.PardakhtHotels)
              .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<DargahPardakht> dargahPardakhts { get; set; }
        public DbSet<EmkanatHotel> emkanatHotels { get; set; }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<JozeyatHotel> jozeyatHotels { get; set; }
        public DbSet<Nazarat> nazarats { get; set; }
        public DbSet<OstanHotel> ostanHotels { get; set; }
        public DbSet<PardakhtHotel> pardakhtHotels { get; set; }
        public DbSet<RezervHotel> rezervHotels { get; set; }
        public DbSet<TanzimatEmail> tanzimatEmails { get; set; }
        public DbSet<TasavirHotel> tasavirHotels { get; set; }
        public DbSet<TedadStareh> tedadStarehs { get; set; }
        public DbSet<TedadTakhtHotel> tedadTakhtHotels { get; set; }
        public DbSet<ZarfyatOtaghHotel> zarfyatOtaghHotels { get; set; }
        public DbSet<Faradars.Models.ViewModel.Jostejo> Jostejo { get; set; }

    }
}
