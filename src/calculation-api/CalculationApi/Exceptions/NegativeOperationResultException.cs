namespace CalculationApi.Exceptions;

public class NegativeOperationResultException : BadHttpRequestException
{
    private const string ExceptionMessage = "Negative values are not supported.";

    public NegativeOperationResultException() : base(ExceptionMessage) { }
}
