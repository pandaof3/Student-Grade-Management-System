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
            manager.AddStudentGrade("001", "math", 90);
            manager.AddStudentGrade("001", "english", 85);
            manager.AddStudentGrade("002", "math", 90);
            manager.AddStudentGrade("002", "english", 80);
            manager.AddStudentGrade("003", "math", 100);
            manager.AddStudentGrade("003", "english", 90);
            manager.ShowStudentList();
            manager.ModifyStudentGrade("001", "english", 90);
            manager.SortByAverage();
            manager.ShowStudentList();
            manager.GetCourseAverage("math");
        }
    }
}
