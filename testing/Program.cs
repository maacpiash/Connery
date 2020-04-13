using System;
using System.Collections.Generic;
using Connery.Lib;
using System.Linq;

namespace Connery.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var images = ModelInput.LoadImagesFromDirectory(Paths.testImagesRelativePath, false);
            Console.WriteLine("Actual label\tPredicted Label\tScore");
            foreach (var image in images)
            {
                var prediction = ConsumeModel.Predict(image, Paths.modelPath);
                Console.WriteLine($"{image.Label}\t{prediction.Prediction}\t{prediction.Score.Max()}");
            }
        }
    }
}
