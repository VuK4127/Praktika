using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Praktiaka2.Models;

namespace Praktiaka2.Services
{
    public class DataService
    {
        // Шлях до нашого JSON-файлу з питаннями
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "questions.json");

        // Метод для зчитування списку питань
        public List<Question> GetQuestions()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Question>(); // Повертаємо порожній список, якщо файлу немає
                }

                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Question>>(json) ?? new List<Question>();
            }
            catch (Exception)
            {
                return new List<Question>();
            }
        }
    }
}