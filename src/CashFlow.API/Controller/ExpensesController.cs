using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
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
            catch (ErrorOnValidationException ex)
            {
                var errorMessage = new ResponseErrorJson(ex.Errors);
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
