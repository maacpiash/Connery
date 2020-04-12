using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Connery.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Connery.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> logger;

        public ImageController(ILogger<ImageController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public async Task<object> Post([FromBody]IFormFile image)
        {
            logger.LogInformation($"Request received at {new DateTime()}");
            try
            {
                var tempFilePath = Path.GetTempFileName();
                using (var ms = new FileStream(tempFilePath, FileMode.Create))
                {
                    await image.CopyToAsync(ms);
                }
                var prediction = ConsumeModel.Predict(new ModelInput { ImageSource = tempFilePath, Label = "anything" });
                logger.LogInformation($"Predicted {prediction.Prediction} with a probablity of {prediction.Score.Max()}");
                return prediction;
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return e;
            }
        }
    }
}
