using System;
using System.IO;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;

// dotnet add package Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction --version 2.0.0

namespace test2
{
    class Program
    {
        static string endpoint = "https://gmalccustvision-prediction.cognitiveservices.azure.com/";
        // Add your training & prediction key from the settings page of the portal
        static string predictionKey = "e2e46cbbc27c48a28d69005afd6b144b";

        static Guid project_id = Guid.Parse("9879cc9e-81d3-4d1d-90a1-c9dbd80e6bf5");

        static string model = "groceries";
        static MemoryStream image_data;
        static void Main(string[] args)
        {
            CustomVisionPredictionClient predictionApi = new CustomVisionPredictionClient(new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.ApiKeyServiceClientCredentials(predictionKey))
            {
                Endpoint = endpoint
            };

            String image_file = "fruit.jpg";
            image_data = new MemoryStream(File.ReadAllBytes(image_file));
            var result = predictionApi.ClassifyImage(project_id, model, image_data);

            // Loop over each prediction and write out the results
            foreach (var prediction in result.Predictions)
            {
                if (prediction.Probability > 0.5)
                {
                    Console.WriteLine($"\t{prediction.TagName}: {prediction.Probability:P1}");
                }
            }

        }
    }
}
