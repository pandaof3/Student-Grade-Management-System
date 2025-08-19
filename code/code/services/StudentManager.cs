using StudentGradeManager.Models;
using StudentGradeManager.DataAccess;
using System;
namespace StudentGradeManager.Services
{
    public class StudentManager
    {
        private List<Student> students;
        private DataAccesser dataAccesser;
        private string? _filePath;
        public StudentManager()
        {
            students = [];
            dataAccesser = new DataAccesser();
        }
        public void LoadData(string? filePath)
        {
            students.Clear();
            if (filePath == "" || filePath==null)
            {
                students.AddRange(dataAccesser.LoadFromFile());
            }
            else
            {
                _filePath = filePath;
                students.AddRange(dataAccesser.LoadFromFile(filePath));
            }
        }
        public void SaveData()
        {
            dataAccesser.SaveToFile(students, _filePath);
        }
        public Student? FindStudentById(string id)
        {
            foreach(Student stu in students)
            {
                if (stu.GetId().Equals(id))
                {
                    return stu;
                }
            }
            Console.WriteLine("Student not found");
            return null;
        }

        public List<Student> FindStudentByName(string name)
        {
            List<Student> matchingStudents = new List<Student>();
            foreach(Student stu in students)
            {
                if (stu.GetName().Equals(name))
                {
                    matchingStudents.Add(stu);
                }
            }
            if (matchingStudents.Count == 0)
            {
                Console.WriteLine("Student not found!");
            }
            foreach(Student stu in matchingStudents)
            {
                stu.ShowMe();
            }
            return matchingStudents;
        } 
        public void AddStudent(string Id, string name)
        {
            if(FindStudentById(Id) != null)
            {
                Console.WriteLine("Duplicated student ID!");
                return;
            }
            Student stu = new Student(Id,name);
            students.Add(stu);
            SaveData();
        }
        public void DeleteStudentById(string Id)
        {
            Student? stu = FindStudentById(Id);
            if (stu == null)
            {
                return;
            }
            students.Remove(stu);
            SaveData();
        }
        public void ModifyStudentId(string oldId,string newId)
        {
            Student? stu = FindStudentById(oldId);
            if(stu == null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            stu.SetId(newId);
            SaveData();
        }

        public void ModifyStudentName(string Id,string newName)
        {
            Student? stu = FindStudentById(Id);
            if (stu == null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            stu.SetName(newName);
            SaveData();
        }
        public void AddStudentGrade(string Id,string subject, decimal score)
        {
            Student? stu = FindStudentById(Id);
            if (stu == null)
            {
                return;
            }
            if (stu.GetGrades().ContainsKey(subject))
            {
                Console.WriteLine("{0} already exists. If you want to modify the score, try " +
                    "ModifyStudentGrade()");
                return;
            }
            if (score >= 0 && score < 100)
            {
                stu.SetGrade(subject, score);
                SaveData();
            }
            else
            {
                Console.WriteLine("score must be between 0 and 100");
                return;
            }
        }
        public void ModifyStudentGrade(string Id, string subject, decimal score)
        {
            Student? stu = FindStudentById(Id);
            if (stu == null)
            {
                return;
            }
            if (!stu.GetGrades().ContainsKey(subject))
            {
                Console.WriteLine("subject not found. If you want to add score, try " +
                    "AddStudentGrade()");
                return;
            }
            if (score >= 0 && score <= 100)
            {
                stu.SetGrade(subject, score);
                SaveData();
            }
            else
            {
                Console.WriteLine("score must be between 0 and 100");
                return;
            }
        }
        public decimal GetStudentAverage(string Id)
        {
            Student? stu = FindStudentById(Id);
            if (stu == null)
            {
                return -1;
            }
            return stu.CalcAverage();
        }
        public decimal GetCourseAverage(string subject)
        {
            if(students.Count == 0)
            {
                Console.WriteLine("No student");
                return 0;
            }
            decimal sum = 0;
            int count = 0;
            decimal average=0;
            List<Student> errors = new List<Student>();
            foreach (Student stu in students)
            {
                if (stu.GetGrades().ContainsKey(subject))
                {
                    sum+=stu.GetGrades()[subject];
                    count++;
                }
                else
                {
                    errors.Add(stu);
                }
            }
            if(errors.Count > 0)
            {
                Console.WriteLine("Some students don't have a {0} score", subject);
                foreach(Student stu in errors)
                {
                    Console.WriteLine(stu.GetId());
                }
            }
            if (count != 0)
            {
                average = sum / count;
            }
            Console.WriteLine("As for students who have the score, the average is {0}",average);
            return average;
        }
        public void SortByAverage()
        {
            students.Sort();
        }
        public void ShowStudentList()
        {
            if (students.Count==0)
            {
                Console.WriteLine("No data");
            }
            foreach(Student student in students)
            {
                Console.Write(student.GetId() + "\t" + student.GetName() + "\t");
                foreach(var map in student.GetGrades())
                {
                    Console.Write(map.Key + ":" + map.Value+"\t");
                }
                Console.Write("Average "+student.CalcAverage().ToString()+"\n");
            }
        }
    }
}


