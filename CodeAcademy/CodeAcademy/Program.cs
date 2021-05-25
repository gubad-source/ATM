using CodeAcademy.Model;
using CodeAcademy.Storage;
using System;
using System.Text.RegularExpressions;

namespace CodeAcademy
{
    class Program
    {
        static string path = "storage.dat";
        static void Main(string[] args)
        {
            EducationStorage educationStorage = new EducationStorage();
            educationStorage.Load(path);
            foreach(var item in educationStorage)
            {
                Console.WriteLine(item);
            }
            //Student student1 = new Student
            //{
            //    Id = 1,
            //    Name = "Gubad",
            //    Surname = "Mustafayev",
            //    Payment = 4000
            //};
            //Group group1 = new Group
            //{
            //    Id = 1,
            //    Name = "P317"
            //};
            //Education education1 = new Education
            //{
            //    Group = group1,
            //    Student = student1
            //};
            //educationStorage.Add(education1);
            Console.Write("Daxil etmek istediyiniz telebe sayini gosterin: ");
            int count;
            L1:

            if (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Daxil etdiyiniz say duz deyil:");
                goto L1;
            }

            for(int i = 0; i < count; i++)
            {
                string valuePattern = @"^[A-Z]{1}[a-z]{2,}$";

                Student student1 = new Student();
                L2:
                Console.Write("Enter a Student Name: ");
                student1.Name = Console.ReadLine();
                string value = @"^[A-Z]{1}[a-z]{2,}$";
                if (!Regex.IsMatch(student1.Name, value))
                {
                    Console.WriteLine("Duzgun qayda ile yazin");
                    goto L2;
                }

                L3:
                Console.Write("Enter a Student Surname: ");
                student1.Surname = Console.ReadLine();
                if (!Regex.IsMatch(student1.Surname, valuePattern))
                {
                    Console.WriteLine("Duzgun qayda ile yazin");
                    goto L3;
                }

                L4:
                Console.Write("Enter a bill: ");
                if(!int.TryParse(Console.ReadLine(),out int payment) && payment<4000)
                {
                    Console.WriteLine("Duzgun qayda ile yazin");
                    goto L4;
                }
                student1.Payment = payment;


                Model.Group group1 = new Model.Group();
                L5:
                Console.Write("Enter a Group Name: ");
                group1.Name = Console.ReadLine();
                if (!Regex.IsMatch(group1.Name, valuePattern))
                {
                    Console.WriteLine("Duzgun qayda ile yazin");
                    goto L5;
                }

                Education education1 = new Education
                {
                    Group = group1,
                    Student = student1
                };
                educationStorage.Add(education1);
            }

            L6:
            Console.WriteLine("Legv etmek istediyiniz nomreni yazin: ");
            if(! int.TryParse(Console.ReadLine(),out int index) && index <= 0)
            {
                Console.WriteLine("Duzgun daxil edin: ");
                goto L6;
            }
            var founded = educationStorage[index - 1];
            educationStorage.Remove(founded);
            educationStorage.Save(path);
        }
    }
}
