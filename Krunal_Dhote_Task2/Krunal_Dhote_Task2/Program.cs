using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Krunal_Dhote_Task2
{
    class Student
    {
        public int Id;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int GraduationYear { get; set; }
        public int BranchId { get; set; }
        public int SectionId { get; set; }
    }

    class Branch
    {
        public int Id;
        public string BranchName { get; set; }
    }
   class Section
    {
        public int Id;
        public string SectionName { get; set; }
    }
    class Program
    {
        public static void print(string s)
        {
            Console.WriteLine(s);
        }

        public static List<Student> StudentList = new List<Student>()
            {
                new Student() { Id = 1, Name = "Krunal Dhote", Email = "krunal.d@shaligram.com", Address = "Amravati", GraduationYear = 2023, BranchId=1,SectionId=1},
                new Student() { Id = 2, Name = "Piyush Sinha", Email = "piyush.d@shaligram.com", Address = "Bhopal", GraduationYear = 2023, BranchId=1,SectionId=2},
                new Student() { Id = 3, Name = "Shuvam Kunwer", Email = "shuvam.d@shaligram.com", Address = "Jamnagar", GraduationYear = 2023, BranchId=1,SectionId=2},
                new Student() { Id = 4, Name = "Varun Potrun", Email = "varun.d@shaligram.com", Address = "Shrikakulam", GraduationYear = 2023, BranchId=1,SectionId=3},
                new Student() { Id = 5, Name = "Bhaskar Rajale", Email = "bharskar.d@shaligram.com", Address = "SambhajiNagar", GraduationYear = 2023, BranchId=1,SectionId=3},
            };

        public static List<Branch> BranchList = new List<Branch>()
            {
                new Branch(){ Id=1,BranchName="CSE" },
                new Branch(){ Id=2,BranchName="Civil" },
                new Branch(){ Id=3,BranchName="Electrical" },
                new Branch(){ Id=4,BranchName="Mechanical" }
            };

        public static List<Section> SectionList = new List<Section>()
            {
                new Section(){ Id=1,SectionName="A" },
                new Section(){ Id=2,SectionName="B" },
                new Section(){ Id=3,SectionName="C" }
            };

        public static void CRUD(int iam)
        {
            switch (iam)
            {
                case 1:
                    Console.WriteLine("\nWhat You Wanna Do?");
                    Console.WriteLine("1. Insert 2. Update 3. Delete 4. Show 5. Nothing");
                    int what = int.Parse(Console.ReadLine());
                    switch (what)
                    {
                        case 1:
                            InsertStudent();
                            print("\nStudent Inserted Successfully");
                            CRUD(iam);
                            break;
                        case 2:
                            print("\nEnter The ID of Student");
                            int uid = int.Parse(Console.ReadLine());
                            UpdateStudent(uid);
                            CRUD(iam);
                            break;
                        case 3:
                            print("\nEnter The ID of Student");
                            int did = int.Parse(Console.ReadLine());
                            DeleteStudent(did);
                            print("\nStudent Deleted Successfully");
                            CRUD(iam);
                            break;
                        case 4:
                            ShowStudents();
                            CRUD(iam);
                            break;
                        case 5:
                            break;
                    }
                    break;
                case 2:
                    print("\nYou Can't Do Anything Just See The Table");
                    ShowStudents();
                    break;
                default:
                    print("\nInvalid Input Given");
                    break;
            }
        }

        public static void InsertStudent()
        {
            Student obj = new Student();
            obj.Id = StudentList.Count + 1;
            Console.Write("\nEnter Name Of Student : ");
            obj.Name = Console.ReadLine();
            Console.Write("\nEnter Email Of Student : ");
            obj.Email = Console.ReadLine();
            Console.Write("\nEnter Address Of Student : ");
            obj.Address = Console.ReadLine();
            Console.Write("\nEnter GraduationYear Of Student : ");
            obj.GraduationYear = int.Parse(Console.ReadLine());
            Console.Write("\nEnter Branch Id Of Student : ");
            obj.BranchId = int.Parse(Console.ReadLine());
            Console.Write("\nEnter Section Id Of Student : ");
            obj.SectionId = int.Parse(Console.ReadLine());
            StudentList.Add(obj);
        }

        public static void ShowStudents()
        {
            var JoinTable = from student in StudentList
                            join branch in BranchList on
                            student.BranchId equals branch.Id
                            join section in SectionList on student.SectionId equals section.Id
                            select new { Id = student.Id, StudentName = student.Name, Email = student.Email, Address = student.Address, Branch = branch.BranchName, Section = section.SectionName, GraduationYear = student.GraduationYear };

            var table = new ConsoleTable("Id", "Name", "Email", "Address", "Graduation Year", "Branch", "Section");

            if (StudentList.Count > 0)
            {
                foreach (var student in JoinTable)
                {
                    table.AddRow(student.Id, student.StudentName, student.Email, student.GraduationYear, student.Address, student.Branch, student.Section);
                }
                table.Write();
            }
            else
            {
                print("\nNo Data Found");
            }
        }


        public static void DeleteStudent(int id)
        {
            int index = StudentList.FindIndex(i => i.Id == id);
            StudentList.RemoveAt(index);
        }

        public static void UpdateStudent(int id)
        {
            int index = StudentList.FindIndex(i => i.Id == id);
            print("\nEnter Name Of Student : ");
            StudentList[index].Name = Console.ReadLine();
            print("\nEnter Email Of Student : ");
            StudentList[index].Email = Console.ReadLine();
            print("\nEnter Address Of Student : ");
            StudentList[index].Address = Console.ReadLine();
            print("\nEnter Graduation Year Of Student : ");
            StudentList[index].GraduationYear = int.Parse(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            //Order By
            //var OrderBy = StudentList.OrderBy(o => o.GraduationYear).ThenBy(o => o.SectionId);
            //foreach (var gr in OrderBy)
            //{
            //    Console.WriteLine(gr.Name);
            //}

            IList<int> intList = new List<int> () { 10, 20, 30 };
            IList<int> intList2 = new List<int> () { 10, 22, 30 };

            var avg = (intList.Join(intList2, l1 => l1, l2 => l2, (l1, l2) => l1).Average()).ToString();
            print(avg);

            //Total Table With Join Table 
            print("\n---------------------------------------------Student Data-----------------------------------------------\n");
            var tab = from student in StudentList
                      join branch in BranchList on student.BranchId equals branch.Id
                      join section in SectionList on student.SectionId equals section.Id
                      //  where section.SectionName == "C"
                      select (student, branch,section);

            var table1 = new ConsoleTable("Id", "Name", "Email", "Address", "Graduation Year", "Branch", "Section");
            foreach (var t in tab)
            {
                table1.AddRow(t.student.Id, t.student.Name, t.student.Email, t.student.Address, t.student.GraduationYear, t.branch.BranchName, t.section.SectionName);
            };
            table1.Write();


//          --------------------------------------------Students--------------------------------------
            
            print("\nWho Are You?");
            print("1. Teacher 2. Student\n");
            int who = int.Parse(Console.ReadLine());
            CRUD(who);
            Console.ReadLine();
        }
    }
}
