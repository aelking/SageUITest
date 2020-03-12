using System;

namespace SageUITest.Model
{
    public class Objective
    {
        public Objective(string name,
                         string description,
                         string measure,
                         string strategicGoal,
                         string contributes,
                         DateTime startDate,
                         DateTime endDate,
                         DateTime nextReviewDate,
                         int weight,
                         string isRequiredForBonus,
                         string isPrivate)
        {
            Name = name;
            Description = description;
            Measure = measure;
            StrategicGoal = strategicGoal;
            Contributes = contributes;
            StartDate = startDate;
            EndDate = endDate;
            NextReviewDate = nextReviewDate;
            Weight = weight;
            IsRequiredForBonus = isRequiredForBonus;
            IsPrivate = isPrivate;
        }

        public string Name { get; }
        public string Description { get; }
        public string Measure { get; }

        public string StrategicGoal { get; }
        public string Contributes { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public DateTime NextReviewDate { get; }
        public int Weight { get; }
        public string IsRequiredForBonus { get; }
        public string IsPrivate { get; }
    }
}
