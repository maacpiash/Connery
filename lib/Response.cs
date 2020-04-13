using System.Collections.Generic;

namespace Connery.Lib
{
    public class Response
    {
        public string Prediction { get; set; }
        public Dictionary<string, float> Probablity { get; set; }

        public static string[] labels = new string[]
        {
            "fresh_apple",
            "fresh_banana",
            "fresh_mango",
            "fresh_orange",
            "rotten_apple",
            "rotten_banana",
            "rotten_mango",
            "rotten_orange"
        };

        public Response(ModelOutput modelOutput)
        {
            this.Prediction = modelOutput.Prediction;
            this.Probablity = new Dictionary<string, float>();
            for (int i = 0; i < 8; i++)
            {
                Probablity.Add(labels[i], modelOutput.Score[i]);
            }
        }
    }
}
