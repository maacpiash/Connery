using System;
using System.Collections.Generic;
using Connery.Lib;
using System.Linq;
using static System.Console;

namespace Connery.Testing
{
    class Program
    {
        static int[,] confusionMatrix;
        static Dictionary<string, int> labels;
        static int NumberOfImages;
        static int NumberOfLabels;

        static void Main(string[] args)
        {
            NumberOfLabels = Constants.Labels.Length;
            var images = ModelInput.LoadImagesFromDirectory(Constants.TestImagesRelativePath, false);
            WriteLine($"Total number of images for testing: {images.Count()}");
            confusionMatrix = new int[NumberOfLabels, NumberOfLabels];
            labels = new Dictionary<string, int>();
            foreach (var label in Constants.Labels)
            {
                labels.Add(label, Array.IndexOf(Constants.Labels, label));
            }
            NumberOfImages = 0;
            WriteLine("Actual label\tPredicted Label\tScore");
            foreach (var image in images)
            {
                var prediction = ConsumeModel.Predict(image, Constants.ModelPath);
                WriteLine($"{image.Label}\t{prediction.Prediction}\t{prediction.Score.Max()}");
                // Format: `confusionMatrix[predictedLabel, actualLabel]`
                confusionMatrix[labels[prediction.Prediction], labels[image.Label]]++;
                NumberOfImages++;
            }

            WriteLine($"Categorized {NumberOfImages} images in {NumberOfLabels} classes.");

            PrintConfusionMatrix();

            PrintPrecisionRecall();
        }

        static void PrintConfusionMatrix()
        {
            WriteLine("\n============================== Confusion Matrix ==============================\n");
            WriteLine("Predicted\tActual\nLabels\t\tLabels\n");
            WriteLine("\t\tfresh\tfresh\tfresh\tfresh\trotten\trotten\trotten\trotten");
            WriteLine("\t\tapple\tbanana\tmango\torange\tapple\tbanana\tmango\torange");

            for (int i = 0; i < NumberOfLabels; i++)
            {
                Write($"{Constants.Labels[i]}\t");
                for (int j = 0; j < NumberOfLabels; j++)
                    Write($"{confusionMatrix[i, j]}\t");
                WriteLine();
            }
        }

        static void PrintPrecisionRecall()
        {
            WriteLine("\n============================ Precision and Recall ============================\n");
            float[] precision = new float[NumberOfLabels];
            float[] recall = new float[NumberOfLabels];
            float[] sumOfRows = new float[NumberOfLabels];
            float[] sumOfColumns = new float[NumberOfLabels];

            for (int i = 0; i < NumberOfLabels; i++)
            {
                for (int j = 0; j < NumberOfLabels; j++)
                {
                    sumOfRows[i] += confusionMatrix[i, j];
                    sumOfColumns[j] += confusionMatrix[i, j];
                }
            }

            for (int i = 0; i < NumberOfLabels; i++)
            {
                precision[i] = confusionMatrix[i, i] / sumOfRows[i];
                recall[i] = confusionMatrix[i, i] / sumOfColumns[i];
            }

            WriteLine("Labels\t\tPrecision\tRecall");
            for (int i = 0; i < NumberOfLabels; i++)
            {
                Write($"{Constants.Labels[i]}\t{precision[i]:0.0000}\t\t{recall[i]:0.0000}\n");
            }
        }
    }
}
