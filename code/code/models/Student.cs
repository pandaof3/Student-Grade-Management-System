using System;
using Newtonsoft.Json;
namespace StudentGradeManager.Models
{
    public class Student:IComparable<Student>
    {
        [JsonProperty]
        private string id;
        [JsonProperty]
        private string name;
        [JsonProperty]
        private Dictionary<string, decimal> grades;
        public Student(string id,string name)
        {
            this.id = id;
            this.name = name;
            this.grades = new Dictionary<string, decimal>();
        }

        public string? GetId()
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
        public Dictionary<string, decimal> GetGrades()
        {
            return grades;
        }
        public void SetGrade(string subject, decimal score)
        {
            grades[subject] = score;
        }
        public decimal CalcAverage()
        {
            if (grades.Count == 0)
            {
                Console.Write("No grade data");
                return 0;
            }
            decimal sum = 0;
            foreach(var score in grades.Values)
            {
                sum += score;
            }
            return sum / grades.Count;
        }
        public int CompareTo(Student? other)
        {
            if (this == other) return 0;
            if (other == null) return -1;
            return other.CalcAverage().CompareTo(this.CalcAverage());
        }
        public void ShowMe()
        {
            Console.Write("{0}\t{1}\t", id, name);
            foreach(var score in grades)
            {
                Console.Write(score.Key +  ": " + score.Value+"\t");
            }
            Console.Write("\n");
            return;
        }
    }
}