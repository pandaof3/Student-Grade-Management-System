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

        public List<Student>? FindStudentByName(string name)
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
        public void AddStudent(string Id, String name)
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
    }
}


