using System;
using TrainingManagementSystem.Lectures;
using TrainingManagementSystem.PracticalLessons;
using TrainingManagementSystem.Trainings;

namespace TrainingManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Training training1 = new Training("Training 1");
            Lecture lecture1 = new Lecture("Lecture 1", "Topic 1");
            PracticalLesson practicalLesson1 = new PracticalLesson("Practical lecture 1", "Task 1", "Solution 1");

            training1.Add(lecture1);
            training1.Add(practicalLesson1);

            Console.WriteLine("Inside of the array of training1");
            for (int i = 0; i < training1.Index; i++)
            {
                Console.WriteLine(training1.lecturesAndPracticalLessons[i].Description);
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Is training1 practical?");
            Console.WriteLine(training1.IsPractical());
            Console.WriteLine("-------------");

            Training training2 = new Training("training 2");

            training2.Add(practicalLesson1);

            Console.WriteLine("Inside of the array of training2");
            for (int i = 0; i < training2.Index; i++)
            {
                Console.WriteLine(training2.lecturesAndPracticalLessons[i].Description);
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Is training2 practical?");
            Console.WriteLine(training2.IsPractical());
            Console.WriteLine("-------------");

            Training training3 = training2.Clone();
            training3.Add(practicalLesson1);
            training3.Add(lecture1);
            training3.Description = "New description for training3";

            Console.WriteLine("Training3 cloned from training2, 2 elements added to the array");
            for (int i = 0; i < training3.Index; i++)
            {
                Console.WriteLine(training3.lecturesAndPracticalLessons[i].Description);
            }

            Console.WriteLine("---- Checking if training2 has changed ---------");
            for (int i = 0; i < training2.Index; i++)
            {
                Console.WriteLine(training2.lecturesAndPracticalLessons[i].Description);
            }
            Console.WriteLine("-------------");

            Console.WriteLine("Description for training2");
            Console.WriteLine(training2.Description);
            Console.WriteLine("-------------");

            Console.WriteLine("Description for training3");
            Console.WriteLine(training3.Description);
            Console.WriteLine("-------------");
        }
    }
}
