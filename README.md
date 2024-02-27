# Calculation API

This Calculation API can deal with any set of multiplications (`*`), divisions (`/`), sums (`+`) and subtractions (`-`). It does not support brackets, only numebers, a dinamic decimal separator (defaults to `.`) and the previously mentioned operators. As the `-` charecter is used as subtration operator, the onlyt negative number allowed in the calculations is the final operation, wich is the result of the calculation.

## Precision

The precision of the calculation is the supported precision for `decimal` type in .Net runtime, witch is a `float` type that can go as far as 29 significant digits. For that reason, the Calculation API formats up to 29 decimal digits in its results wothout any rounding, nor truncation, neither leading zeros nor trailing zeros.

## Swagger

The Calculation API relies on the Swagger documentation to be available at `https://localhost:5184/swagger/index.html` once the Calculation API is running.

### GET /calculations

The `/calculations` endpoint requires the `expression` query parameter to be set. The expression is a string that represents the calculation to be performed. Additionally, the `decimal-symbol` query parameter can be set to a character to be used as decimal separator.

Only the API deals with custom decimal symbols. The [`Calculator`](./src/calculation-api/CalculationApi/Calculator.cs) class exposes a constructor to receive unsafe expressions and the recursive `public static Calculate(string expression)` method to perform the expression parsing and its calculations.

## Calculator

The `Calculator` class has basic operations dictionary (`Dictionary<char, Func<decimal, decimal, decimal>> Operations`) tho provide an seamless way to perform a mathematic operation given an `char` operator and two `decimal` numbers. It is publicly exposed to be covered by the unit tests.

The `Calculator` class constructor removes any forbidden characters from the `expression` parameter. Than, the `Calculate()` method is called to perform the expression parsing and its calculations.

The `Calculate()` method relies on the recursive `public static Calculate(string expression)` method to perform the expression parsing and its calculations. It performs the following workflow:

1. Iterates over the `Operations` dictionary keys.
2. If the given expression doesn't contain the current key, it ignores the current key and continues to the next key.
3. If the given expression contains the current key, it slices the expression into a left side and a right side, operation key wize.
4. If the side has an operator, it is considerd as a partial expression to be parsed further. So it cuts the current operation operands, do the calculations, replaces the current operation int the given expression with its result, concatenates the left and right partial expressions, if any, and recursivelly calls the `Calculate(string expression)` method.
5. If the calculation ends with no partial expressions left, the result is considered as the final result.

## Top-level Statements

The Calculation API droped the usage of top-level statements to provide better integration testing. The top-level statements do not exposes the `Program` class as public.

## Testing

NUnit was used for both integration and unit testing.

The integration tests covered the `GET /calculations` endpoint, with and without custom decimal symbol.

The unit tests covered the basic `Operations` dictionary, the `ContainsOperation`, both left and right regular expressions to evaluate and extract values and partial expressions from sliced expressions, the `Calculate(string expression)` method with success and not supported negative operations.
