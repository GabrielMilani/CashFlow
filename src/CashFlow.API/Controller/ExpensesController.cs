using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                var errorMessage = new ResponseErrorJson(ex.Message);

                return BadRequest(errorMessage);
            }
            catch
            {   
                var errorMessage = new ResponseErrorJson("Unknow error." );
                
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }
    }
}
