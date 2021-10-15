using Abernathy.history.Service.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Extensions
{
    public class Configuration
    {



        private static IEnumerable<Note> GenerateSeedData()
        {
            return new[]
            {
                new Note
                {
                    PatientId = 1,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Cholesterol\n" +
                              "Dizziness\n" +
                              "Relapse\n" +
                              "Reaction\n" +
                              "Antibodies\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 2,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Cholesterol\n" +
                              "Dizziness\n" +
                              "Relapse\n" +
                              "Reaction\n" +
                              "Antibodies\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 3,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Cholesterol\n" +
                              "Dizziness\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 4,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Cholesterol\n" +
                              "Dizziness\n" +
                              "Relapse\n" +
                              "Reaction\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 5,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Cholesterol\n" +
                              "Dizziness\n" +
                              "Relapse\n" +
                              "Reaction\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 6,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Cholesterol\n" +
                              "Dizziness\n" +
                              "Relapse\n" +
                              "Reaction\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 7,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 8,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n" +
                              "Abnormal\n" +
                              "Reaction\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 9,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 10,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 11,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                },
                new Note
                {
                    PatientId = 12,
                    Title = "Test",
                    Content = "Weight\n" +
                              "Smoker\n",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                }
            };
        }
    }
}
