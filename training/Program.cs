// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.ML;
using Connery.Lib;
using static Connery.Training.ModelBuilder;

namespace Connery.Training
{
    class Program
    {
        // Create MLContext to be shared across the model creation workflow objects 
        // Set a random seed for repeatable/deterministic results across multiple trainings.
        private static MLContext mlContext = new MLContext(seed: 1);

        static void Main(string[] args)
        {
            // Load Data
            IEnumerable<ModelInput> images = ModelInput.LoadImagesFromDirectory(Constants.AssetsRelativePath);
            IDataView trainingDataView = mlContext.Data.LoadFromEnumerable(images);

            // Build training pipeline
            IEstimator<ITransformer> trainingPipeline = BuildTrainingPipeline(mlContext);

            // Evaluate quality of Model
            Evaluate(mlContext, trainingDataView, trainingPipeline);

            // Train Model
            ITransformer mlModel = TrainModel(mlContext, trainingDataView, trainingPipeline);

            // Save model
            if (!Directory.Exists(Constants.WorkspaceRelativePath))
                Directory.CreateDirectory(Constants.WorkspaceRelativePath);
            SaveModel(mlContext, mlModel, Constants.ModelPath, trainingDataView.Schema);

            Console.WriteLine("Finished task. Press any key to exit.");
            Console.ReadKey();
        }

        // Change this code to create your own sample data
        #region CreateSingleDataSample
        // Method to load single row of dataset to try a single prediction
        private static ModelInput CreateSingleDataSample(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: '\t',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }
        #endregion
    }
}
