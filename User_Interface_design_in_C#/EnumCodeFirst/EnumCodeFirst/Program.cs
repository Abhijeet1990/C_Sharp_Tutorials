using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EnumCodeFirst
{
    class Program
    {

        public static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
        static void Main(string[] args)
        {
            using (var context = new EnumTestContext())
            {
                context.Departments.Add(new Department { Name = DepartmentNames.English });
                context.Proffessors.Add(new Proffessor { Names = DepartmentNames.Economics,Research="MacroEconomics",Rating=ProffRatings.Satisfactory});

                context.SaveChanges();

                var department = (from d in context.Departments
                                  where d.Name == DepartmentNames.English
                                  select d).FirstOrDefault();

                var proff = (from p in context.Proffessors
                             where p.Names == DepartmentNames.Economics
                                  && p.Rating == ProffRatings.Satisfactory
                             select p).FirstOrDefault();

                Console.WriteLine(
                    "DepartmentID: {0} Name: {1}",
                    department.DepartmentID,
                    department.Name);

                Console.WriteLine(
                    "ProffID: {0} Dept: {1} Research: {2} Rating: {3}",
                    proff.ProffID,proff.Names,proff.Research,proff.Rating);



                Console.ReadLine();
            }


            using (var db = new EnumTestContext())
            {
                Console.Write("Enter the city");
                var type = Console.ReadLine();
                if (type == "houston")
                {

                    School[] school = Program.InitializeArray<School>(20);
                    HighSchool[] highschool = Program.InitializeArray<HighSchool>(20);



                }
                
            }
        }
    }

    public enum DepartmentNames
    {
        English,
        Math,
        Economics
    }

    public partial class Department
    {
        public int DepartmentID { get; set; }
        public DepartmentNames Name { get; set; }
        public decimal Budget { get; set; }
    }

    public enum ProffRatings
    {
        VeryBad,
        Bad,
        Satisfactory,
        Good,
        Excellent
    }

    public partial class Proffessor
    {
        [Key]
        public int ProffID { get; set; }
        public DepartmentNames Names { get; set; }
        public string Research { get; set; }
        public ProffRatings Rating { get; set; }
    }

    //high school : 
    //school: 
    //univ: 

    public enum SchoolType
    {
        HighSchool,
        School,
        University
    }

    public partial class HighSchool
    {
        public int HighSchoolID { get; set; }
        public string Location { get; set; }
        public string AverageScore { get; set; }
        public int Population { get; set; }
    }

    public partial class School
    {
        public int SchoolID { get; set; }
        public string Location { get; set; }
        public string AverageScore { get; set; }
        public int Population { get; set; }
        public float Tution { get; set; }
    }

    public partial class University
    {
        public int UniversityID { get; set; }
        public string Location { get; set; }
        public string MinGRE { get; set; }
        public int Population { get; set; }
        public float Tution { get; set; }
        public bool Ivy { get; set; }
    }



    public partial class EnumTestContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Proffessor> Proffessors { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<University> Universities { get; set; }
    }
}
