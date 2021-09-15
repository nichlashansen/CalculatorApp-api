using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_api.Controllers
{
    [Route("api/{Controller}")]
    public class Calculate : Controller
    {
        private CalculateMethods _calculateMethods;

        public Calculate()
        {
            _calculateMethods = new CalculateMethods();
        }

        [HttpGet]
        public double CalculateInput(double a, double b, string option)
        {
            return option switch
            {
                "add"=>_calculateMethods.Add(a,b),
                "minus"=>_calculateMethods.Minus(a,b),
                "divide"=>_calculateMethods.Divide(a,b),
                "multiply"=>_calculateMethods.Multiply(a,b),
                _=> 0

            };
        }
        
    }
}