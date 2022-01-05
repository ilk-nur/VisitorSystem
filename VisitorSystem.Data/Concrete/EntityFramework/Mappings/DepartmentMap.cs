using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;

namespace VisitorSystem.Data.Concrete.EntityFramework.Mappings
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.CountactNo).HasMaxLength(7);
            builder.Property(d => d.CountactNo).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(50);
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.CreatedByName).IsRequired();
            builder.Property(d => d.CreatedByName).HasMaxLength(50);
            builder.Property(d => d.ModifiedByName).IsRequired();
            builder.Property(d => d.ModifiedByName).HasMaxLength(50);
            builder.Property(d => d.ModifiedDate).IsRequired();
            builder.Property(d => d.CreatedDate).IsRequired();
            builder.Property(d => d.IsActive).IsRequired();
            builder.Property(d => d.IsDeleted).IsRequired();
            builder.ToTable("Departments");
            builder.HasData(new Department()
            {
                Id=1,
                CountactNo=4443636,
                Name="Bilgi Sistemleri Dairesi Başkanlığı",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,

            }, new Department() 
            {
                Id =2 ,
                CountactNo = 4446666,
                Name = "Ağaçlandırma  Dairesi Başkanlığı",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,


            }, new Department()
            {
                Id = 3,
                CountactNo = 4440606,
                Name = "Hukuk Müşavirliği",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,


            }, new Department()
            {
                Id = 4,
                CountactNo = 4443362,
                Name = "Destek Hizmetleri  Dairesi Başkanlığı",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,


            }, new Department()
            {
                Id = 5,
                CountactNo = 4448888,
                Name = "Teftiş Kurulu Başkanlığı",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,


            });
        }
    }
}
