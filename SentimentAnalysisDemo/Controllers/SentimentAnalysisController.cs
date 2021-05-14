
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SentimentAnalysisDemoML.Model;

namespace SentimentAnalysisDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentimentAnalysis : Controller
    { 
 

        [HttpGet]
        public JsonResult  AnalyzeFeedback(string feedback)
        {
            try
            {
                ModelInput _data = new();

                _data.Col0 = feedback;

                var predictionResult = ConsumeModel.Predict(_data);

                return Json(new
                {

                    Prediction = predictionResult.Prediction,
                    Score = predictionResult.Score,
                    Message = predictionResult.Prediction == "0"?"We are sorry for inconvience":"That's Great! Thank you for feedback"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                  
                    Error="Unable to Consume Model"
                });
            }

        }
    }
}
