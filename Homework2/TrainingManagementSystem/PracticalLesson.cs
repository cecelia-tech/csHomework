using TrainingManagementSystem.Trainings;

namespace TrainingManagementSystem.PracticalLessons
{
    public class PracticalLesson : Training
    {
        public string Task { get; set; }
        public string Solution { get; set; }

        public PracticalLesson(string description, string task, string solution) :
                               base(description)
        {
            Task = task;
            Solution = solution;
        }
    }
}
