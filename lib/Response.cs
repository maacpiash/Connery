using System.Collections.Generic;

namespace Connery.Lib
{
    public class Response
    {
        public string Prediction { get; set; }
        public Dictionary<string, float> Probablity { get; set; }

        public Response(ModelOutput modelOutput)
        {
            this.Prediction = modelOutput.Prediction;
            this.Probablity = new Dictionary<string, float>();
            for (int i = 0; i < 8; i++)
            {
                Probablity.Add(Constants.Labels[i], modelOutput.Score[i]);
            }
        }
    }
}
