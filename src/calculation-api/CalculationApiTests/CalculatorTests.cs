using System.Collections;
using CalculationApi;
using CalculationApi.Exceptions;

namespace CalculationApiTests;

[TestFixture]
public class CalculatorTests
{
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.ContainsOperationTestCases))]
    public bool ContainsOperationTest(string expression)
    {
        return Calculator.ContainsOperation(expression);
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.LeftSideSplitLastValueTemplateRegexWholeExpressionTestCases))]
    public string LeftSideSplitLastValueTemplateRegexWholeExpressionTest(string expression)
    {
        return Calculator.LeftSideSplitLastValueTemplateRegex().Replace(expression, "");
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.LeftSideSplitLastValueTemplateRegexRemainingExpressionTestCases))]
    public string LeftSideSplitLastValueTemplateRegexRemainingExpressionTest(string expression)
    {
        return Calculator.LeftSideSplitLastValueTemplateRegex().Replace(expression, "$1");
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.LeftSideSplitLastValueTemplateRegexRightValueTestCases))]
    public string LeftSideSplitLastValueTemplateRegexRightValueTest(string expression)
    {
        return Calculator.LeftSideSplitLastValueTemplateRegex().Replace(expression, "$2");
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.RightSideSplitFirstValueTemplateRegexWholeExpressionTestCases))]
    public string RightSideSplitLastValueTemplateRegexWholeExpressionTest(string expression)
    {
        return Calculator.RightSideSplitFirstValueTemplateRegex().Replace(expression, "");
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.RightSideSplitFirstValueTemplateRegexLeftValueTestCases))]
    public string RightSideSplitLastValueTemplateRegexLeftValueTest(string expression)
    {
        return Calculator.RightSideSplitFirstValueTemplateRegex().Replace(expression, "$1");
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.RightSideSplitFirstValueTemplateRegexRemainingExpressionTestCases))]
    public string RightSideSplitLastValueTemplateRegexRemainingExpressionTest(string expression)
    {
        return Calculator.RightSideSplitFirstValueTemplateRegex().Replace(expression, "$2");
    }
    
    [TestCaseSource(
        typeof(DataClass),
        nameof(DataClass.CalculationExpressionTestCases))]
    public decimal CalculationExpressionTest(string expression)
    {
        return Calculator.Calculate(expression);
    }
    
    [Test]
    public void CalculationExpressionWithNegativeOperationTest()
    {
        Assert.Throws<NegativeOperationResultException>(() => Calculator.Calculate("1*1-10-11+1"));
    }
}

file class DataClass
{
    public static IEnumerable ContainsOperationTestCases
    {
        get
        {
            yield return new TestCaseData("452*452").Returns(true);
            yield return new TestCaseData("452/452").Returns(true);
            yield return new TestCaseData("452+452").Returns(true);
            yield return new TestCaseData("452-452").Returns(true);
            yield return new TestCaseData("*452").Returns(true);
            yield return new TestCaseData("/452").Returns(true);
            yield return new TestCaseData("+452").Returns(true);
            yield return new TestCaseData("-452").Returns(true);
            yield return new TestCaseData("452*").Returns(true);
            yield return new TestCaseData("452/").Returns(true);
            yield return new TestCaseData("452+").Returns(true);
            yield return new TestCaseData("452-").Returns(true);
            yield return new TestCaseData("452").Returns(false);
            yield return new TestCaseData("45,2").Returns(false);
            yield return new TestCaseData("45.2").Returns(false);
            yield return new TestCaseData("45 2").Returns(false);
        }
    }

    public static IEnumerable LeftSideSplitLastValueTemplateRegexWholeExpressionTestCases
    {
        get
        {
            yield return new TestCaseData("125*48-").Returns("125*48-");
            yield return new TestCaseData("125/48*").Returns("125/48*");
            yield return new TestCaseData("125+48/").Returns("125+48/");
            yield return new TestCaseData("125-48+").Returns("125-48+");
            yield return new TestCaseData("-125*48").Returns("");
            yield return new TestCaseData("*125/48").Returns("");
            yield return new TestCaseData("/125+48").Returns("");
            yield return new TestCaseData("+125-48").Returns("");
            yield return new TestCaseData("125*48").Returns("");
            yield return new TestCaseData("125/48").Returns("");
            yield return new TestCaseData("125+48").Returns("");
            yield return new TestCaseData("125-48").Returns("");
            yield return new TestCaseData("-&t$*48").Returns("");
            yield return new TestCaseData("-&t$/48").Returns("");
            yield return new TestCaseData("-&t$+48").Returns("");
            yield return new TestCaseData("-&t$-48").Returns("");
        }
    }
    
    public static IEnumerable LeftSideSplitLastValueTemplateRegexRemainingExpressionTestCases
    {
        get
        {
            yield return new TestCaseData("125*48-").Returns("125*48-");
            yield return new TestCaseData("125/48*").Returns("125/48*");
            yield return new TestCaseData("125+48/").Returns("125+48/");
            yield return new TestCaseData("125-48+").Returns("125-48+");
            yield return new TestCaseData("-125*48").Returns("-125*");
            yield return new TestCaseData("*125/48").Returns("*125/");
            yield return new TestCaseData("/125+48").Returns("/125+");
            yield return new TestCaseData("+125-48").Returns("+125-");
            yield return new TestCaseData("125*48").Returns("125*");
            yield return new TestCaseData("125/48").Returns("125/");
            yield return new TestCaseData("125+48").Returns("125+");
            yield return new TestCaseData("125-48").Returns("125-");
            yield return new TestCaseData("-&t$*48").Returns("-&t$*");
            yield return new TestCaseData("-&t$/48").Returns("-&t$/");
            yield return new TestCaseData("-&t$+48").Returns("-&t$+");
            yield return new TestCaseData("-&t$-48").Returns("-&t$-");
        }
    }
    
    public static IEnumerable LeftSideSplitLastValueTemplateRegexRightValueTestCases
    {
        get
        {
            yield return new TestCaseData("125*48-").Returns("125*48-");
            yield return new TestCaseData("125/48*").Returns("125/48*");
            yield return new TestCaseData("125+48/").Returns("125+48/");
            yield return new TestCaseData("125-48+").Returns("125-48+");
            yield return new TestCaseData("-125*48").Returns("48");
            yield return new TestCaseData("*125/48").Returns("48");
            yield return new TestCaseData("/125+48").Returns("48");
            yield return new TestCaseData("+125-48").Returns("48");
            yield return new TestCaseData("125*48").Returns("48");
            yield return new TestCaseData("125/48").Returns("48");
            yield return new TestCaseData("125+48").Returns("48");
            yield return new TestCaseData("125-48").Returns("48");
            yield return new TestCaseData("-&t$/48").Returns("48");
            yield return new TestCaseData("-&t$+48").Returns("48");
            yield return new TestCaseData("-&t$-48").Returns("48");
            yield return new TestCaseData("-&t$*48").Returns("48");
        }
    }

    public static IEnumerable RightSideSplitFirstValueTemplateRegexWholeExpressionTestCases
    {
        get
        {
            yield return new TestCaseData("-125*48").Returns("-125*48");
            yield return new TestCaseData("*125/48").Returns("*125/48");
            yield return new TestCaseData("/125+48").Returns("/125+48");
            yield return new TestCaseData("+125-48").Returns("+125-48");
            yield return new TestCaseData("125*48-").Returns("");
            yield return new TestCaseData("125/48*").Returns("");
            yield return new TestCaseData("125+48/").Returns("");
            yield return new TestCaseData("125-48+").Returns("");
            yield return new TestCaseData("125*48").Returns("");
            yield return new TestCaseData("125/48").Returns("");
            yield return new TestCaseData("125+48").Returns("");
            yield return new TestCaseData("125-48").Returns("");
            yield return new TestCaseData("*48&t$-").Returns("*48&t$-");
            yield return new TestCaseData("/48&t$-").Returns("/48&t$-");
            yield return new TestCaseData("+48&t$-").Returns("+48&t$-");
            yield return new TestCaseData("-48&t$-").Returns("-48&t$-");
        }
    }
    
    public static IEnumerable RightSideSplitFirstValueTemplateRegexRemainingExpressionTestCases
    {
        get
        {
            yield return new TestCaseData("-125*48").Returns("-125*48");
            yield return new TestCaseData("*125/48").Returns("*125/48");
            yield return new TestCaseData("/125+48").Returns("/125+48");
            yield return new TestCaseData("+125-48").Returns("+125-48");
            yield return new TestCaseData("125*48-").Returns("*48-");
            yield return new TestCaseData("125/48*").Returns("/48*");
            yield return new TestCaseData("125+48/").Returns("+48/");
            yield return new TestCaseData("125-48+").Returns("-48+");
            yield return new TestCaseData("125*48").Returns("*48");
            yield return new TestCaseData("125/48").Returns("/48");
            yield return new TestCaseData("125+48").Returns("+48");
            yield return new TestCaseData("125-48").Returns("-48");
            yield return new TestCaseData("*t$&48-").Returns("*t$&48-");
            yield return new TestCaseData("/t$&48-").Returns("/t$&48-");
            yield return new TestCaseData("+t$&48-").Returns("+t$&48-");
            yield return new TestCaseData("-t$&48-").Returns("-t$&48-");
        }
    }
    
    public static IEnumerable RightSideSplitFirstValueTemplateRegexLeftValueTestCases
    {
        get
        {
            yield return new TestCaseData("-125*48").Returns("-125*48");
            yield return new TestCaseData("*125/48").Returns("*125/48");
            yield return new TestCaseData("/125+48").Returns("/125+48");
            yield return new TestCaseData("+125-48").Returns("+125-48");
            yield return new TestCaseData("125*48-").Returns("125");
            yield return new TestCaseData("125/48*").Returns("125");
            yield return new TestCaseData("125+48/").Returns("125");
            yield return new TestCaseData("125-48+").Returns("125");
            yield return new TestCaseData("125*48").Returns("125");
            yield return new TestCaseData("125/48").Returns("125");
            yield return new TestCaseData("125+48").Returns("125");
            yield return new TestCaseData("125-48").Returns("125");
            yield return new TestCaseData("*48&t$-").Returns("*48&t$-");
            yield return new TestCaseData("/48&t$-").Returns("/48&t$-");
            yield return new TestCaseData("+48&t$-").Returns("+48&t$-");
            yield return new TestCaseData("-48&t$-").Returns("-48&t$-");
        }
    }

    public static IEnumerable CalculationExpressionTestCases
    {
        get
        {
            yield return new TestCaseData("5*10").Returns(50m);
            yield return new TestCaseData("000005*00010").Returns(50m);
            yield return new TestCaseData("5/10").Returns(0.5m);
            yield return new TestCaseData("5/10.00000").Returns(0.5m);
            yield return new TestCaseData("5+10").Returns(15m);
            yield return new TestCaseData("5-10").Returns(-5m);
            yield return new TestCaseData("10-5").Returns(5m);
            yield return new TestCaseData("5*10/5-5").Returns(5m);
            yield return new TestCaseData("5.25*2").Returns(10.5m);
            yield return new TestCaseData("2+3+4+5+6+7+8+9").Returns(44m);
            yield return new TestCaseData("100-2-3-4-5-6-7-8").Returns(65m);
            yield return new TestCaseData("1*2*3*4*5*6*7*81*2*3*4*5*6*7*8").Returns(16460236800m);
            yield return new TestCaseData("100*10/2*2/2*2/2/20/10/2/2/2*2/2/2").Returns(0.00244140625m);
            yield return new TestCaseData("20+300-5*2/2+6/2-12+30-5*2/2+6/2-1-300").Returns(-39m);
            yield return new TestCaseData("5005/10*5+4-3*2/2-11/10*5+4-3*2/2-1").Returns(92.88m);
            yield return new TestCaseData("5*5*5/5*2*2/2/2/25*5*5/5*2*2/2/2/2").Returns(0.000015625m);
            yield return new TestCaseData("30078-10+4*2/2*3-1+530-10+4*2/2*3-1+5").Returns(29518.333333333333333333333334m);
        }
    }
}
