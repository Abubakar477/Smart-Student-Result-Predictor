using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;

namespace student_predication
{
    public class MLEngine
    {
        private readonly MLContext _mlContext;
        private ITransformer? _model;
        private PredictionEngine<StudentData, StudentPrediction>? _predictionEngine;

        public MLEngine()
        {
            _mlContext = new MLContext(seed: 0);
        }

        public void TrainModel()
        {
            // Generate synthetic dataset
            var trainData = GenerateSyntheticData();
            var dataView = _mlContext.Data.LoadFromEnumerable(trainData);

            // Build pipeline
            var pipeline = _mlContext.Transforms.Concatenate("Features", "Marks")
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression());

            // Train model
            _model = pipeline.Fit(dataView);

            // Create prediction engine
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<StudentData, StudentPrediction>(_model);
        }

        public StudentPrediction Predict(float marks)
        {
            if (_predictionEngine == null)
            {
                throw new InvalidOperationException("Model must be trained before prediction.");
            }

            var input = new StudentData { Marks = marks };
            return _predictionEngine.Predict(input);
        }

        private List<StudentData> GenerateSyntheticData()
        {
            var dataset = new List<StudentData>();
            var random = new Random(0);

            for (int i = 0; i < 100; i++)
            {
                float marks = (float)(random.NextDouble() * 100);
                dataset.Add(new StudentData
                {
                    Marks = marks,
                    Passed = marks >= 50
                });
            }

            return dataset;
        }
    }
}
