using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Connery.Lib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Connery.WebApi
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
        public async Task<object> Post([FromForm]IFormFile image)
        {
            logger.LogInformation($"Request received at {DateTime.Now}");
            try
            {
                var tempFilePath = Path.GetTempFileName();
                using (var ms = new FileStream(tempFilePath, FileMode.Create))
                {
                    await image.CopyToAsync(ms);
                }
                ModelInput input = new ModelInput { ImageSource = tempFilePath };
                ModelOutput output = ConsumeModel.Predict(input, "MLModel.zip");
                logger.LogInformation($"Predicted {output.Prediction} with a probablity of {output.Score.Max()}");
                return new Response(output);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return e;
            }
        }
    }
}
