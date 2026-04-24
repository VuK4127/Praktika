using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Praktiaka2.Models;

namespace Praktiaka2.Services
{
    public class DataService
    {
        public List<Question> GetQuestions()
        {
            // Найнадійніший шлях до файлу в папці Data
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "questions.json");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не знайдено за шляхом: {path}");
            }

            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Question>>(jsonString) ?? new List<Question>();
        }
    }
}