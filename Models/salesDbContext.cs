using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesManagementAPI.Models
{
    public partial class salesDbContext : DbContext
    {
        public salesDbContext()
        {
        }

        public salesDbContext(DbContextOptions<salesDbContext> options)
            : base(options)
        {
          
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketCustomer> TicketCustomer { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=mssql-150227-0.cloudclusters.net,10097;Initial Catalog=salesDb;User ID=test;Password=1998@12Thari;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Nic)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Place)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_event_partner");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("partner");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Nic)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("ticket");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExDate).HasColumnType("datetime");

                entity.Property(e => e.SaleStatus)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.TicketCode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ticket_event");
            });

            modelBuilder.Entity<TicketCustomer>(entity =>
            {
                entity.ToTable("ticketCustomer");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BuyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TicketCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticketCustomer_customer");

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketCustomer)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ticketCustomer_ticket");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_partner");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
