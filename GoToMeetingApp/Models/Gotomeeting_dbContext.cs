using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoToMeetingApp.Models
{
    public partial class Gotomeeting_dbContext : DbContext
    {
        public Gotomeeting_dbContext()
        {
        }

        public Gotomeeting_dbContext(DbContextOptions<Gotomeeting_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GtmAdminDetails> GtmAdminDetails { get; set; }
        public virtual DbSet<GtmBookingDetails> GtmBookingDetails { get; set; }
        public virtual DbSet<GtmLoginDetails> GtmLoginDetails { get; set; }
        public virtual DbSet<GtmMeetingRoomDetails> GtmMeetingRoomDetails { get; set; }
        public virtual DbSet<GtmRegisterDetails> GtmRegisterDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-4OEBQ7J\\SQLSERVER;Database=Gotomeeting_db; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GtmAdminDetails>(entity =>
            {
                entity.HasKey(e => e.RoomAdminId)
                    .HasName("PK__GTM_Admi__F9F12606D3B7B45E");

                entity.ToTable("GTM_Admin_Details");

                entity.Property(e => e.RoomAdminId)
                    .HasColumnName("room_admin_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApprovedAt)
                    .HasColumnName("approved_at")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("approved_by")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VerificationStatus)
                    .HasColumnName("Verification_status")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtmBookingDetails>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__GTM_Book__5DE3A5B1057B46DF");

                entity.ToTable("GTM_Booking_details");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("approved_by")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationStatus)
                    .HasColumnName("confirmation_status")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EndAt)
                    .HasColumnName("end_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestedBy)
                    .HasColumnName("requested_by")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartAt)
                    .HasColumnName("start_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GtmLoginDetails>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__GTM_Logi__206A9DF837EA3BA8");

                entity.ToTable("GTM_Login_Details");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.ConfirmPassword)
                    .HasColumnName("confirm_password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginPassword)
                    .HasColumnName("login_password")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtmMeetingRoomDetails>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__GTM_meet__B9BE370FB9DD2B29");

                entity.ToTable("GTM_meeting_room_details");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndAt)
                    .HasColumnName("end_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.StartAt)
                    .HasColumnName("start_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GtmRegisterDetails>(entity =>
            {
                entity.HasKey(e => e.RoomId)
                    .HasName("PK__GTM_Regi__19EF6E6B83643D28");

                entity.ToTable("GTM_Register_Details");

                entity.Property(e => e.RoomId).HasColumnName("Room_id");

                entity.Property(e => e.AvailableSpace).HasColumnName("Available_space");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExistSpace).HasColumnName("Exist_space");

                entity.Property(e => e.FullName)
                    .HasColumnName("Full_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MeetingType)
                    .HasColumnName("Meeting_type")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName)
                    .HasColumnName("Organization_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_number");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
