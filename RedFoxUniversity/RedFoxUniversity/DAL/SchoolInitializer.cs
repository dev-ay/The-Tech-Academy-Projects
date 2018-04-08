using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RedFoxUniversity.Models;

namespace RedFoxUniversity.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
                new Models.Student {FirstName="Mari", LastName="Little", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="McClain", LastName="Jones", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="Carl", LastName="The Fourth", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="Noodle", LastName="Wiggles", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="Bisbee", LastName="The Frisbee", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="Silvu", LastName="Ericson", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="Bocky", LastName="Bird", EnrollmentDate=DateTime.Parse("2018-01-01")},
                new Models.Student {FirstName="Monty", LastName="Mission", EnrollmentDate=DateTime.Parse("2018-01-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID=1050, Title="Chemistry", Credits=3,},
                new Course {CourseID=1050, Title="Spanish", Credits=3,},
                new Course {CourseID=1050, Title="Bible", Credits=3,},
                new Course {CourseID=1050, Title="Calculus", Credits=4,},
                new Course {CourseID=1050, Title="Pottery", Credits=2,},
                new Course {CourseID=1050, Title="Advanced Writing", Credits=4,},
                new Course {CourseID=1050, Title="Literature", Credits=3,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050,},
                new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}