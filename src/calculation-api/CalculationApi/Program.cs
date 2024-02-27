using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace CalculationApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.MapGet(
                "/calculations", (
                    [FromQuery(Name = "expression")] string expression,
                    [FromQuery(Name = "decimal-symbol")] char decimalSymbol = '.') =>
                {
                    const char defaultSeparator = '.';
                    string calcExpression = expression;

                    if (!defaultSeparator.Equals(decimalSymbol))
                        calcExpression = calcExpression.Replace(decimalSymbol, defaultSeparator);

                    string result = new Calculator(calcExpression).Calculate()
                        .ToString("0.#############################", CultureInfo.InvariantCulture);

                    if (!defaultSeparator.Equals(decimalSymbol))
                        result = result.Replace(defaultSeparator, decimalSymbol);

                    return result;
                })
            .WithOpenApi();

        await app.RunAsync();
    }
}
