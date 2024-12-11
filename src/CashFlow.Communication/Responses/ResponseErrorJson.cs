namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public ResponseErrorJson(List<string> errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        
        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessage = new List<string> { errorMessage };
        }

        public List<string> ErrorMessage { get; set; }
    }
}
