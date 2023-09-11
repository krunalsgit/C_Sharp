using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace Krunal_Dhote_Task1
{
   
    class Student
    {
        public int Id;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int GraduationYear { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            void print(string s)
            {
                Console.WriteLine(s);
            }

            var studentList = new List<Student>()
            {
                new Student() { Id = 1, Name = "Krunal Dhote", Email = "krunal.d@shaligram.com", Address = "Amravati", GraduationYear = 2023 }
            };

            //Student obj1 = new Student();
            //obj1.Id = 2;
            //obj1.Name = "Saurabh Dhote";
            //obj1.Email = "saurabh@gmail.com";
            //obj1.Address = "Amravati";
            //obj1.GraduationYear = 2021;
            //studentList.Add(obj1);
            Console.WriteLine("Who Are You?");
            Console.WriteLine("1. Teacher 2. Student");
            int who = int.Parse(Console.ReadLine());
            CRUD(who);

            void CRUD(int iam)
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

            void InsertStudent()
            {
                Student obj = new Student();
                obj.Id = studentList.Count+1;
                Console.Write("\nEnter Name Of Student : ");
                obj.Name = Console.ReadLine();
                Console.Write("\nEnter Email Of Student : ");
                obj.Email = Console.ReadLine();
                Console.Write("\nEnter Address Of Student : ");
                obj.Address = Console.ReadLine();
                Console.Write("\nEnter GraduationYear Of Student : ");
                obj.GraduationYear = int.Parse(Console.ReadLine());
                studentList.Add(obj);
            }

            void ShowStudents()
            {
               var table = new ConsoleTable("Id","Name","Email","Address","Graduation Year");
                if (studentList.Count > 0)
                {
                    foreach (var student in studentList)
                    {    
                       table.AddRow(student.Id,student.Name,student.Email,student.Address,student.GraduationYear);
                    }
                    table.Write();
                }
                else
                {
                    print("\nNo Data Found");
                }
            }
            

            void DeleteStudent(int id)
            {
                int index=studentList.FindIndex(i => i.Id == id);
                studentList.RemoveAt(index);
            }

            void UpdateStudent(int id)
            {
                int index = studentList.FindIndex(i => i.Id == id);
                print("\nEnter Name Of Student : ");
                studentList[index].Name = Console.ReadLine();
                print("\nEnter Email Of Student : ");
                studentList[index].Email = Console.ReadLine();
                print("\nEnter Address Of Student : ");
                studentList[index].Address = Console.ReadLine();
                print("\nEnter Graduation Year Of Student : ");
                studentList[index].GraduationYear = int.Parse(Console.ReadLine());
            }
            Console.ReadLine();
        }
    }
}
