using System;
using StudentGradeManager.Models;
using StudentGradeManager.Services;

namespace StudentGradeManager.Test
{
    public class Test
    {
        static void Main()
        {
            StudentManager manager = new StudentManager();
            //new test
            manager.AddStudent("001", "aaa");
            manager.AddStudent("002", "bbb");
            manager.AddStudent("003", "ccc");
            Student? stu = manager.FindStudentById("001");
            if(stu == null)
            {
                Console.WriteLine("Student not found");
            }
            else
            {
                manager.AddStudentGrade(stu, "math", 90);
                manager.AddStudentGrade(stu, "english", 85);
            }
            stu = manager.FindStudentById("002");
            if (stu == null)
            {
                Console.WriteLine("Student not found");
            }
            else
            {
                manager.AddStudentGrade(stu, "math", 90);
                manager.AddStudentGrade(stu, "english", 80);
            }
            stu = manager.FindStudentById("003");
            if (stu == null)
            {
                Console.WriteLine("Student not found");
            }
            else
            {
                manager.AddStudentGrade(stu, "math", 100);
                manager.AddStudentGrade(stu, "english", 90);
            }
            manager.ShowStudentList();
            stu = manager.FindStudentById("001");
            if (stu == null)
            {
                Console.WriteLine("Student not found");
            }
            else
            {
                manager.ModifyStudentGrade(stu, "english", 90);
            }
            manager.SortByAverage();
            manager.ShowStudentList();
        }
    }
}
