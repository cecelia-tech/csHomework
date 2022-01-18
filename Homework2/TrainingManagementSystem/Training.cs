using System;
using TrainingManagementSystem.PracticalLessons;

namespace TrainingManagementSystem.Trainings
{
    public class Training
    {
        private const int ARRAY_SIZE = 10;
        public int Index { get; private set; } = 0;
        public string Description { get; set; }
        public Training[] lecturesAndPracticalLessons;

        public Training(string description)
        {
            Description = description;
            lecturesAndPracticalLessons = new Training[ARRAY_SIZE];
        }

        public void Add(Training lesson)
        {
            lecturesAndPracticalLessons[Index] = lesson;
            Index++;
        }

        public bool IsPractical()
        {
            for (int i = 0; i < Index; i++)
            {
                if (!(lecturesAndPracticalLessons[i] is PracticalLesson))
                {
                    return false;
                }
            }
            return true;
        }

        public Training Clone()
        {
            Training clonedTraining = (Training)this.MemberwiseClone();

            clonedTraining.lecturesAndPracticalLessons = new Training[ARRAY_SIZE];
            Array.Copy(this.lecturesAndPracticalLessons, clonedTraining.lecturesAndPracticalLessons, Index);

            return clonedTraining;
        }
    }
}
