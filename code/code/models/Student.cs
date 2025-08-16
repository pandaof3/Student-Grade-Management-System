using System;
namespace StudentGradeManager.Models
{
    public class Student
    {
        private string id;
        private string name;
        private 
        public Student(string id,string name)
        {
            this.id = id;
            this.name = name;
        }

        public string GetId()
        {
            return this.id;
        }
        public string GetName()
        {
            return this.name;
        }

        public void SetId(string id)
        {
            this.id = id;
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public bool MatchesId(string id)
        {
            return this.id.Equals(id);
        }
    }
}