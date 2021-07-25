using System;

using chapter2.ML;

namespace chapter2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            /*if (args.Length != 2)
            {
                Console.WriteLine($"Invalid arguments passed in, exiting.{Environment.NewLine}{Environment.NewLine}Usage:{Environment.NewLine}" +
                                  $"predict <sentence of text to predict against>{Environment.NewLine}" +
                                  $"or {Environment.NewLine}" +
                                  $"train <path to training data file>{Environment.NewLine}");

                return;
            }*/

            var testingValue = "predict";

            switch (testingValue)
            {
                case "predict":
                    new Predictor().Predict("Data\\sampledata.csv");
                    break;
                case "train":
                    new Trainer().Train("Data\\sampledata.csv");
                    break;
                default:
                    Console.WriteLine($"{args[0]} is an invalid option");
                    break;
            }
        }
    }
}
