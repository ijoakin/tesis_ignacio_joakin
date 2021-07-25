using chapter2.ML.Objects;
using chapter2.ML.Base;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace chapter2.ML
{
    public class Trainer : BaseML
    {
        public void Train(string trainningFileName) 
        {
            if (!File.Exists(trainningFileName))
            {
                Console.WriteLine("el archivo no exite");
            }

            var trainningDataView = MlContext.Data.LoadFromTextFile<RestaurantFeedback>(trainningFileName);

            var dataSplit = MlContext.Data.TrainTestSplit(trainningDataView, testFraction: 0.2);

            var dataProcessPipeline = MlContext.Transforms.Text.FeaturizeText(
               outputColumnName: "Features",
               inputColumnName: nameof(RestaurantFeedback.Text));

            var sdcaRegressionTrainer = MlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: nameof(RestaurantFeedback.Label),
                featureColumnName: "Features");
            var trainingPipeline = dataProcessPipeline.Append(sdcaRegressionTrainer);

            ITransformer trainedModel = trainingPipeline.Fit(dataSplit.TrainSet);
            MlContext.Model.Save(trainedModel, dataSplit.TrainSet.Schema, ModelPath);

            var testSetTransform = trainedModel.Transform(dataSplit.TestSet);

            var modelMetrics = MlContext.BinaryClassification.Evaluate(
                data: testSetTransform,
                labelColumnName: nameof(RestaurantFeedback.Label),
                scoreColumnName: nameof(RestaurantPrediction.Score));

            Console.WriteLine($"Area Under Curve: {modelMetrics.AreaUnderRocCurve:P2}{Environment.NewLine}" +
                              $"Area Under Precision Recall Curve: {modelMetrics.AreaUnderPrecisionRecallCurve:P2}{Environment.NewLine}" +
                              $"Accuracy: {modelMetrics.Accuracy:P2}{Environment.NewLine}" +
                              $"F1Score: {modelMetrics.F1Score:P2}{Environment.NewLine}" +
                              $"Positive Recall: {modelMetrics.PositiveRecall:#.##}{Environment.NewLine}" +
                              $"Negative Recall: {modelMetrics.NegativeRecall:#.##}{Environment.NewLine}");

        }
    }
}
