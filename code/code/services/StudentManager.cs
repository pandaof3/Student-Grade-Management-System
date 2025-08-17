using StudentGradeManager.Models;
using System;
namespace StudentGradeManager.Services
{
    public class StudentManager
    {
        private List<Student> students;
        public StudentManager()
        {
            students = [];
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
            //Console.WriteLine("Student not found");
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
            //if(matchingStudents.Count == 0)
            //{
            //    Console.WriteLine("Student not found!");
            //}
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
        }
        public void DeleteStudentById(string Id)
        {
            Student? stu = FindStudentById(Id);
            if (stu == null)
            {
                return;
            }
            students.Remove(stu);
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
        }
        public void AddStudentGrade(Student stu,string subject, decimal score)
        {
            if (stu.GetGrades().ContainsKey(subject))
            {
                Console.WriteLine("{0} already exists. If you want to modify the score, try " +
                    "ModifyStudentGrade()");
                return;
            }
            stu.SetGrade(subject, score);
        }
        public void ModifyStudentGrade(Student stu, string subject, decimal score)
        {
            if (!stu.GetGrades().ContainsKey(subject))
            {
                Console.WriteLine("subject not found. If you want to add score, try " +
                    "AddStudentGrade()");
            }
            stu.SetGrade(subject, score);
        }
        public decimal GetStudentAverage(Student stu)
        {
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
        //测试用
        public void ShowStudentList()
        {
            if (!students.Any())
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


