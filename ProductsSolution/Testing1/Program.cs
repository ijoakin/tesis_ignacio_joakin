using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Runtime;

namespace Testing1
{
    class Program
    {
        class FeedBackTrainingData
        {
            public string FeedBackText { get; set; }
            public bool isGood { get; set; }
        }

        static List<FeedBackTrainingData> trainingData = new List<FeedBackTrainingData>();
        static void LoadTrainingData()
        {
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is good", isGood = true });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is horrible", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is nice", isGood = true });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is very nice", isGood = true });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is very horrible", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is bad", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is terrible", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is any", isGood = true });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is posible wrong", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is terrible2", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is none", isGood = false });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is possible good", isGood = true });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is kind nice", isGood = true });
            trainingData.Add(new FeedBackTrainingData() { FeedBackText = "This is terrible3", isGood = false });
        }
        static void Main(string[] args)
        {
            //step1: Load training data
            LoadTrainingData();

            //step2: create ml context
            var mlcontext = new MLContext();
            //step3 convert our data on our data view
            IDataView dataView = mlcontext.Data.LoadFromEnumerable<FeedBackTrainingData>(trainingData);
            //step4 conert your data on a pipeline and define the works flows in it
            var pipeline = mlcontext.Transforms.Text.FeaturizeText("FeedBackText", "Features")
                .Append(mlcontext.BinaryClassification.Trainers.FastTree(numberOfLeaves: 50, numberOfTrees: 50));

            Console.WriteLine("Hello World!");
        }
    }
}
