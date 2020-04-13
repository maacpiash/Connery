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
        public async Task<object> Post(IFormFile image)
        {
            logger.LogInformation($"Request received at {DateTime.Now}");
            if (image is null)
            {
                logger.LogInformation($"No image was found!");
                return BadRequest("No image was found. Request body must be form-data in { \"image\": <file> } format");
            }

            try
            {
                var tempFilePath = Path.GetTempFileName();
                using (var ms = new FileStream(tempFilePath, FileMode.Create))
                {
                    await image.CopyToAsync(ms);
                    logger.LogInformation($"{image.FileName} was saved to {tempFilePath}");
                }

                ModelInput input = new ModelInput { ImageSource = tempFilePath };
                ModelOutput output = ConsumeModel.Predict(input, "MLModel.zip");

                double probablity = output.Score.Max();
                if (probablity == 0) // The file was probably not an image at all.
                {
                    logger.LogInformation("Error with the file!");
                    return BadRequest("Error with the file!");
                }

                logger.LogInformation($"Predicted {output.Prediction} with a probablity of {probablity}.");
                return new Response(output);
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                return BadRequest(e);
            }
        }
    }
}
