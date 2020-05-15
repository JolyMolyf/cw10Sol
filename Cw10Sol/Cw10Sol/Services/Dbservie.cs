using System;
using System.Linq;
using System.Text;
using Cw10Sol.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cw10Sol.Services
{
    public class Dbservie : IDbService
    {
        public DbContextEntity dbContext;

        public Dbservie([FromServices] DbContext dbContext)
        {
            this.dbContext = (DbContextEntity) dbContext;
        }

        public string retrieveStudents()
        {
            StringBuilder studentsSb = new StringBuilder();

            var std = dbContext.Student.ToList();

            for (var index = 0; index < std.Count; index++)
            {
                var student = std[index];
                studentsSb.Append(student.IndexNumber).Append(" ").Append(student.FirstName).Append(" ")
                    .Append(student.LastName).AppendLine();
            }

            return studentsSb.ToString();
        }

        public void changeStd(Student updtStd)
        {
            var student = dbContext.Student.Single(s => s.IndexNumber.Equals(updtStd.IndexNumber));

            if (updtStd.FirstName != null && updtStd.LastName != null && updtStd.IdEnrollment != 0 &&
                updtStd.BirthDate != null)
            {

                student.FirstName = updtStd.FirstName;


                student.LastName = updtStd.LastName;

                student.IdEnrollment = updtStd.IdEnrollment;

                student.BirthDate = updtStd.BirthDate;

            }

            dbContext.SaveChanges();
        }


        public void deleteStd(string indexNumber)
        {
            var student = dbContext.Student.Single(s => s.IndexNumber.Equals(indexNumber));
            dbContext.Student.Remove(student);
            dbContext.SaveChanges();
        }
    }
}