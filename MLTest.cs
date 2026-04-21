using System;
using student_predication;

namespace MLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ML Engine...");
            var engine = new MLEngine();
            
            Console.WriteLine("Training model...");
            engine.TrainModel();
            Console.WriteLine("Model Trained Successfully!");

            float[] testMarks = { 45f, 55f, 30f, 85f };
            foreach (var marks in testMarks)
            {
                var prediction = engine.Predict(marks);
                string result = prediction.Prediction ? "PASS" : "FAIL";
                Console.WriteLine($"Marks: {marks} => Prediction: {result} (Probability: {prediction.Probability:P1})");
            }
        }
    }
}
