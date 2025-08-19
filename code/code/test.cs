using System;
using StudentGradeManager.Models;
using StudentGradeManager.Services;

namespace StudentGradeManager.TestProgram
{
    public class Test
    {
        public void Tester()
        {
            StudentManager manager = new StudentManager();
            Console.WriteLine("Welcome to the Student Grade Manager!");
            Console.WriteLine("No data in memory now");
            while (true)
            {
                Console.WriteLine("Please enter a number");
                Console.WriteLine("1.load data\t\t2.quit");
                string? main_read = Console.ReadLine();
                switch(main_read)
                {
                    case "1":
                        Loop(manager);
                        break;
                    default:
                        Console.WriteLine("Thanks for using");
                        break;
                    
                }
                break;
            }
        }
        private string EnterName()
        {
            string? name = Console.ReadLine();
            while (name == null)
            {
                Console.WriteLine("Why is name null?");
                Console.WriteLine("Enter name:");
                name = Console.ReadLine();
            }
            return name;
        }
        private string EnterID()
        {
            string? id = Console.ReadLine();
            while (id == "" || id == null)
            {
                Console.WriteLine("ID shouldn't be empty");
                Console.WriteLine("Enter ID:");
                id = Console.ReadLine();
            }
            return id;
        }
        private string EnterSubject()
        {
            string? subject = Console.ReadLine();
            while (subject == null || subject == "")
            {
                Console.WriteLine("subject shouldn't be empty");
                Console.WriteLine("Enter subject:");
                subject = Console.ReadLine();
            }
            return subject;
        }
        private decimal EnterScore()
        {
            decimal score;
            while (!decimal.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("Enter score:");
            }
            return score;
        }
        public void Loop(StudentManager manager)
        {
            Console.WriteLine("Directory:(Enter an empty line for default)");
            string? filePath = Console.ReadLine();
            manager.LoadData(filePath);
            Console.Clear();
            Console.WriteLine("Data loaded");
            bool isQuit = false;
            while (true)
            {
                Console.Clear();
                if (isQuit)
                {
                    break;
                }
                string name;
                string id;
                string subject;
                decimal score;
                decimal average;
                Console.WriteLine("How can I help you?");
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. Modify the name of a student");
                Console.WriteLine("3. Modify the ID of a student");
                Console.WriteLine("4. Delete a Student");
                Console.WriteLine("5. Find students by name");
                Console.WriteLine("6. Find a student by ID");
                Console.WriteLine("7. Add a grade of a student");
                Console.WriteLine("8. Modify a grade of a student");
                Console.WriteLine("9. Calculate the average score of a student");
                Console.WriteLine("10.Calculate the average score of a course in the class");
                Console.WriteLine("11.Sort the students according to their average");
                Console.WriteLine("12.Quit");
                Console.WriteLine("20.Show");
                Console.Write("Enter your number here:");
                string? number = Console.ReadLine();
                while(number == null || number=="")
                {
                    Console.WriteLine("Enter your number here:");
                    number = Console.ReadLine();
                }
                switch (number)
                {
                    case "1":
                        Console.WriteLine("Enter name:");
                        name = EnterName();
                        Console.WriteLine("Enter ID:");
                        id = EnterID();
                        manager.AddStudent(id, name);
                        break;
                    case "2":
                        Console.WriteLine("Enter the student ID");
                        id = EnterID();
                        Console.WriteLine("Enter the new name:");
                        name = EnterName();
                        manager.ModifyStudentName(id, name);
                        break;
                    case "3":
                        Console.WriteLine("Enter the student ID");
                        id = EnterID();
                        Console.WriteLine("Enter the new ID:");
                        name = EnterName();     //name is used as new ID
                        manager.ModifyStudentId(id,name);
                        break;
                    case "4":
                        Console.WriteLine("Enter the Student ID");
                        id = EnterID();
                        manager.DeleteStudentById(id);
                        break;
                    case "5":
                        Console.WriteLine("Enter the name");
                        name = EnterName();
                        manager.FindStudentByName(name);
                        break;
                    case "6":
                        Console.WriteLine("Enter ID:");
                        id = EnterID();
                        manager.FindStudentById(id);
                        break;
                    case "7":
                        Console.WriteLine("Enter ID:");
                        id = EnterID();
                        Console.WriteLine("Enter subject:");
                        subject = EnterSubject();
                        Console.WriteLine("Enter score");
                        score = EnterScore();
                        manager.AddStudentGrade(id, subject, score);
                        break;
                    case "8":
                        Console.WriteLine("Enter ID:");
                        id = EnterID();
                        Console.WriteLine("Enter subject:");
                        subject = EnterSubject();
                        Console.WriteLine("Enter score");
                        score = EnterScore();
                        manager.ModifyStudentGrade(id, subject, score);
                        break;
                    case "9":
                        Console.WriteLine("Enter ID:");
                        id = EnterID();
                        average = manager.GetStudentAverage(id);
                        Console.WriteLine(average);
                        break;
                    case "10":
                        Console.WriteLine("Enter subject");
                        subject = EnterSubject();
                        manager.GetCourseAverage(subject);
                        break;
                    case "11":
                        manager.SortByAverage();
                        manager.ShowStudentList();
                        break;
                    case "12":
                        Console.Clear();
                        isQuit = true;
                        break;
                    case "20":
                        manager.ShowStudentList();
                        break;
                    default:
                        Console.WriteLine("Are you sure?");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
