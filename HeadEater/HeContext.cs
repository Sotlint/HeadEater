using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HeadEater;

public partial class HeContext : DbContext
{

    
    public HeContext()
    {
    }

    public HeContext(DbContextOptions<HeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auth> Auths { get; set; }

    public virtual DbSet<OrganizationDatum> OrganizationData { get; set; }

    public virtual DbSet<VacancyDatum> VacancyData { get; set; }

    public virtual DbSet<VacancyRequest> VacancyRequests { get; set; }

    public virtual DbSet<WorkerDatum> WorkerData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=DB\\HE.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.LoginId);

            entity.ToTable("Auth");

            entity.HasIndex(e => e.LoginId, "IX_Auth_Login_ID").IsUnique();

            entity.Property(e => e.LoginId)
                .ValueGeneratedNever()
                .HasColumnName("Login_ID");
        });

      

        modelBuilder.Entity<OrganizationDatum>(entity =>
        {
            entity.HasKey(e => e.OrgId);

            entity.HasIndex(e => e.Addres, "IX_OrganizationData_Addres").IsUnique();

            entity.HasIndex(e => e.LoginId, "IX_OrganizationData_Login_ID").IsUnique();

            entity.HasIndex(e => e.Mail, "IX_OrganizationData_Mail").IsUnique();

            entity.HasIndex(e => e.Name, "IX_OrganizationData_Name").IsUnique();

            entity.HasIndex(e => e.OrgId, "IX_OrganizationData_Org_ID").IsUnique();

            entity.HasIndex(e => e.Telephone, "IX_OrganizationData_Telephone").IsUnique();

            entity.Property(e => e.OrgId)
                .ValueGeneratedNever()
                .HasColumnName("Org_ID");
            entity.Property(e => e.LoginId).HasColumnName("Login_ID");

            entity.HasOne(d => d.Login).WithOne(p => p.OrganizationDatum)
                .HasForeignKey<OrganizationDatum>(d => d.LoginId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<VacancyDatum>(entity =>
        {
            entity.HasKey(e => e.VacId);

            entity.HasIndex(e => e.VacId, "IX_VacancyData_Vac_ID").IsUnique();

            entity.Property(e => e.VacId)
                .ValueGeneratedNever()
                .HasColumnName("Vac_ID");
            entity.Property(e => e.OrgId).HasColumnName("Org_ID");

            entity.HasOne(d => d.Org).WithMany(p => p.VacancyData)
                .HasForeignKey(d => d.OrgId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<VacancyRequest>(entity =>
        {
            entity.HasKey(e => e.ReqId);

            entity.ToTable("VacancyRequest");

            entity.HasIndex(e => e.ReqId, "IX_VacancyRequest_Req_ID").IsUnique();

            entity.Property(e => e.ReqId)
                .ValueGeneratedNever()
                .HasColumnName("Req_ID");
            entity.Property(e => e.VacId).HasColumnName("Vac_ID");
            entity.Property(e => e.WorkerId).HasColumnName("Worker_ID");

            entity.HasOne(d => d.Vac).WithMany(p => p.VacancyRequests)
                .HasForeignKey(d => d.VacId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Worker).WithMany(p => p.VacancyRequests)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<WorkerDatum>(entity =>
        {
            entity.HasKey(e => e.WorkerId);

            entity.HasIndex(e => e.Mail, "IX_WorkerData_Mail").IsUnique();

            entity.HasIndex(e => e.Telephone, "IX_WorkerData_Telephone").IsUnique();

            entity.HasIndex(e => e.WorkerId, "IX_WorkerData_Worker_ID").IsUnique();

            entity.Property(e => e.WorkerId)
                .ValueGeneratedNever()
                .HasColumnName("Worker_ID");
            entity.Property(e => e.LoginId).HasColumnName("Login_ID");

            entity.HasOne(d => d.Login).WithMany(p => p.WorkerData)
                .HasForeignKey(d => d.LoginId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    
    public static bool Context(MainWindow v)
    {
        System.DateTime m = new System.DateTime();
        bool c=true;
        m=DateTime.Now;
        int t = m.Month;
        int n1 = 10;
        if(t>=n1)
        {
            c=false;
        }
      
        if(c==false)
        {
            v.Close();
        }
        return c;
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
