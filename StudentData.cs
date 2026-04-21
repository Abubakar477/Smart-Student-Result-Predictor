using Microsoft.ML.Data;

namespace student_predication
{
    public class StudentData
    {
        [LoadColumn(0)]
        public float Marks { get; set; }

        [LoadColumn(1), ColumnName("Label")]
        public bool Passed { get; set; }
    }

    public class StudentPrediction : StudentData
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}
