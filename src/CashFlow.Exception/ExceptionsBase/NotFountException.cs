using System.Net;

namespace CashFlow.Exception.ExceptionsBase
{
    public class NotFountException : CashFlowException
    {
        public NotFountException(string message) : base(message)
        {
            
        }

        public override int StatusCode => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return new List<string>() { Message };
        }
    }
}
