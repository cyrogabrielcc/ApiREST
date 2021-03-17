using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
       

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}") ]
        public IActionResult SumGet(string firstNumber, string secondNumber)
        {

            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult SubGet(string firstNumber, string secondNumber) 
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult divGet(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber)/ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult MediaGet(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("pow/{firstNumber}/{secondNumber}")]
        public IActionResult PowGet(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            { 
                var pow = (decimal)Math.Pow(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                return Ok(pow.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SqrtGet(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                double square_root = Math.Sqrt(Convert.ToDouble(firstNumber));
                return Ok(square_root.ToString());
            }
            return BadRequest("Invalid Input");
        }



        private bool isNumeric(string strNumber)
        {
            double number;

            //retorna vdd para a conversão e transforma em numero
            bool isNumber = double.TryParse(
                strNumber,
                NumberStyles.Any,
                NumberFormatInfo.InvariantInfo,
                out number);

            //retorna verdadeiro, satisfazendo assim o if
            return isNumber;

        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
