using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Praktiaka2.Models;

namespace Praktiaka2.Services
{
    public class DataService
    {
        
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "questions.json");

        
        public List<Question> GetQuestions()
        {
            try
            {
                if (!File.Exists(_filePath))
                {
                    return new List<Question>(); 
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