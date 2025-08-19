using System;
using StudentGradeManager.Models;
using StudentGradeManager.Services;
using Newtonsoft.Json;

namespace StudentGradeManager.DataAccess
{
    public class DataAccesser
    {
        private const string DefaultFileName = "grades.json";
        private string _filePath = DefaultFileName;
        public List<Student> LoadFromFile(string? filePath = null)
        {
            if (filePath != null)
            {
                _filePath = filePath;
            }
            filePath ??= DefaultFileName;
            if(!File.Exists(filePath))
            {
                return new List<Student>();
            }

            try
            {
                string json = File.ReadAllText(filePath);
                List<Student> student = JsonConvert.DeserializeObject<List<Student>>(json)
                    ?? new List<Student>();
                if (student.Count == 0)
                {
                    return student;
                }
                else
                {
                    if (student.ElementAt(0).GetId() == null)
                    {
                        return new List<Student>();
                    }
                    else
                    {
                        return student;
                    }
                }
            }
            catch
            {
                return new List<Student>();
            }
        }
        public void SaveToFile(List<Student> students, string? filePath = null)
        {
            filePath ??= DefaultFileName;
            //var settings = new JsonSerializerSettings
            //{
            //    Formatting = Formatting.Indented,
            //    NullValueHandling = NullValueHandling.Ignore,
            //};

            string json = JsonConvert.SerializeObject(students);
            string tempPath = Path.GetTempFileName();
            File.WriteAllText(tempPath, json);
            File.Move(tempPath, filePath, overwrite: true);
            Console.WriteLine("data saved");
        }
    }
}
