using System.Text.RegularExpressions;
using CalculationApi.Exceptions;

namespace CalculationApi;

public partial class Calculator
{
    public static readonly Dictionary<char, Func<decimal, decimal, decimal>> Operations =
        new()
        {
            { '*', (x, y) => x * y },
            { '/', (x, y) => x / y },
            { '+', (x, y) => x + y },
            { '-', (x, y) => x - y }
        };

    private readonly string _expression;

    public Calculator(string expression)
    {
        _expression = ExpressionForbiddenCharsRegex()
            .Replace(expression, string.Empty);;
    }
    
    public decimal Calculate()
    {
        return Calculate(_expression);
    }
    
    public static decimal Calculate(string expression)
    {
        foreach (char operation in Operations.Keys)
        {
            int operationPosition = expression.IndexOf(operation);

            if (operationPosition < 0) continue;

            string parsingOperationLeftSide = expression[..operationPosition];
            string parsingOperationRightSide = expression[(operationPosition + 1)..];
            string expressionRemainingLeftSide = string.Empty;
            string expressionRemainingRightSide = string.Empty;
            string parsingOperationLeftValue = parsingOperationLeftSide;
            string parsingOperationRightValue = parsingOperationRightSide;

            if (ContainsOperation(parsingOperationLeftSide))
            {
                string leftSideSplitLastValueTemplate = LeftSideSplitLastValueTemplateRegex().Replace(
                    parsingOperationLeftSide,
                    "$1|$2");
                string[] leftSideSplitLastValue = leftSideSplitLastValueTemplate.Split('|');

                expressionRemainingLeftSide = leftSideSplitLastValue[0];
                parsingOperationLeftValue = leftSideSplitLastValue[1];
            }

            if (ContainsOperation(parsingOperationRightSide))
            {
                string rightSideSplitLastValueTemplate = RightSideSplitFirstValueTemplateRegex().Replace(
                    parsingOperationRightSide,
                    "$1|$2");
                string[] rightSideSplitLastValue = rightSideSplitLastValueTemplate.Split('|');

                parsingOperationRightValue = rightSideSplitLastValue[0];
                expressionRemainingRightSide = rightSideSplitLastValue[1];
            }

            decimal currentOperationLeftValue = decimal.Parse(parsingOperationLeftValue);
            decimal currentOperationRightValue = decimal.Parse(parsingOperationRightValue);

            decimal currentOperationResult =
                Operations[operation](currentOperationLeftValue, currentOperationRightValue);

            bool isItTheFinalResult = expressionRemainingLeftSide.Length + expressionRemainingRightSide.Length == 0;

            if (currentOperationResult < 0 && !isItTheFinalResult)
                throw new NegativeOperationResultException();

            return
                isItTheFinalResult
                    ? currentOperationResult
                    : Calculate($"{expressionRemainingLeftSide}{currentOperationResult}{expressionRemainingRightSide}");
        }

        throw new InvalidOperationException();
    }

    public static bool ContainsOperation(string expression)
    {
        return Operations.Keys.Any(expression.Contains);
    }

    [GeneratedRegex("^(.*[*/+-])([^*/+-]+)$")]
    public static partial Regex LeftSideSplitLastValueTemplateRegex();

    [GeneratedRegex("^([^*/+-]+)([*/+-].*)$")]
    public static partial Regex RightSideSplitFirstValueTemplateRegex();

    [GeneratedRegex("[^0-9.*/+-]")]
    private static partial Regex ExpressionForbiddenCharsRegex();
}
