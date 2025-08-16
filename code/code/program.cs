using System;
using StudentGradeManager.Services;

namespace StudentGradeManager.Test
{
    public class Test
    {
        static void Main()
        {
            StudentManager manager = new StudentManager();
            manager.AddStudent("24039100388", "zky");
            manager.AddStudent("24069100067", "txh");
            manager.ModifyStudentId("24039100067", "24039100000");
            manager.ModifyStudentName("24039100388", "ZKY");
            manager.DeleteStudentById("24039100388");
        }
    }
}
