using System;

namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public ResponseErrorJson(string errorMessages)
    {
        ErrorMessages = [ errorMessages ];   
    }
    public ResponseErrorJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;   
    }
    public List<string> ErrorMessages { get; set; }
}
