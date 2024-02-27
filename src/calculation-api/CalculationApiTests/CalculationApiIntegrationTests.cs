using System.Net;
using CalculationApi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculationApiTests;

[TestFixture]
public class CalculationApiIntegrationTests
{
    private WebApplicationFactory<Program> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [TearDown]
    public void TearDown()
    {
        _factory.Dispose();
    }

    [Test]
    public async Task GivenCalculateEndpoint_WhenProperExpressionDefaultSeparator_ReturnsCorrectResult(
        [ValueSource(nameof(ProperExpressionsDefaultSeparator))] (string expression, string expectedResult) testData)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        string escapedExpression = Uri.EscapeDataString(testData.expression);

        // Act
        HttpResponseMessage response = await client.GetAsync($"/calculations?expression={escapedExpression}");

        // Assert
        response.EnsureSuccessStatusCode();
        
        string result = await response.Content.ReadAsStringAsync();
        
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EqualTo(testData.expectedResult));
        });
    }

    [Test]
    public async Task GivenCalculateEndpoint_WhenProperExpressionComaSeparator_ReturnsCorrectResult(
        [ValueSource(nameof(ProperExpressionsComaSeparator))] (string expression, string expectedResult) testData)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        string escapedExpression = Uri.EscapeDataString(testData.expression);
        string escapedSeparator = Uri.EscapeDataString(",");

        // Act
        HttpResponseMessage response = await client.GetAsync($"/calculations?expression={escapedExpression}&decimal-symbol={escapedSeparator}");

        // Assert
        response.EnsureSuccessStatusCode();
        
        string result = await response.Content.ReadAsStringAsync();
        
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EqualTo(testData.expectedResult));
        });
    }

    [Test]
    public async Task GivenCalculateEndpoint_WhenDirtyExpressionDefaultSeparator_ReturnsCorrectResultAsIfWhereCleanExpression(
        [ValueSource(nameof(DirtyExpressionsDefaultSeparator))] (string expression, string expectedResult) testData)
    {
        // Arrange
        HttpClient client = _factory.CreateClient();
        string escapedExpression = Uri.EscapeDataString(testData.expression);

        // Act
        HttpResponseMessage response = await client.GetAsync($"/calculations?expression={escapedExpression}");

        // Assert
        response.EnsureSuccessStatusCode();
        
        string result = await response.Content.ReadAsStringAsync();
        
        Assert.Multiple(() =>
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.EqualTo(testData.expectedResult));
        });
    }

    private static readonly object[] ProperExpressionsDefaultSeparator =
    [
        ("5*10", "50"),
        ("000005*00010", "50"),
        ("5/10", "0.5"),
        ("5/10.00000", "0.5"),
        ("5+10", "15"),
        ("5-10", "-5"),
        ("10-5", "5"),
        ("5*10/5-5", "5"),
        ("5.25*2", "10.5"),
        ("2+3+4+5+6+7+8+9", "44"),
        ("100-2-3-4-5-6-7-8", "65"),
        ("1*2*3*4*5*6*7*81*2*3*4*5*6*7*8", "16460236800"),
        ("100*10/2*2/2*2/2/20/10/2/2/2*2/2/2", "0.00244140625"),
        ("20+300-5*2/2+6/2-12+30-5*2/2+6/2-1-300", "-39"),
        ("5005/10*5+4-3*2/2-11/10*5+4-3*2/2-1", "92.88"),
        ("5*5*5/5*2*2/2/2/25*5*5/5*2*2/2/2/2", "0.000015625"),
        ("30078-10+4*2/2*3-1+530-10+4*2/2*3-1+5", "29518.333333333333333333333334"),
    ];
    private static readonly object[] ProperExpressionsComaSeparator =
    [
        ("5*10", "50"),
        ("000005*00010", "50"),
        ("5/10", "0,5"),
        ("5/10,00000", "0,5"),
        ("5+10", "15"),
        ("5-10", "-5"),
        ("10-5", "5"),
        ("5*10/5-5", "5"),
        ("5,25*2", "10,5"),
        ("2+3+4+5+6+7+8+9", "44"),
        ("100-2-3-4-5-6-7-8", "65"),
        ("1*2*3*4*5*6*7*81*2*3*4*5*6*7*8", "16460236800"),
        ("100*10/2*2/2*2/2/20/10/2/2/2*2/2/2", "0,00244140625"),
        ("20+300-5*2/2+6/2-12+30-5*2/2+6/2-1-300", "-39"),
        ("5005/10*5+4-3*2/2-11/10*5+4-3*2/2-1", "92,88"),
        ("5*5*5/5*2*2/2/2/25*5*5/5*2*2/2/2/2", "0,000015625"),
        ("30078-10+4*2/2*3-1+530-10+4*2/2*3-1+5", "29518,333333333333333333333334"),
    ];
    private static readonly object[] DirtyExpressionsDefaultSeparator =
    [
        ("5    *10", "50"),
        ("00000aasd     5*00010", "50"),
        ("5/1  asdf0", "0.5"),
        ("5/10.000  asdaf00", "0.5"),
        ("5asaasas     +10", "15"),
        ("5asdf -10", "-5"),
        ("10-wwww5", "5"),
        ("5*  10/5    -5", "5"),
        ("5.25sdaf *2", "10.5"),
        ("2+3+4+5+ass as asdsss  d6+7+8+9", "44"),
        ("100-2-3               -4-5-6sdfasf           a-7-8", "65"),
        ("1*2*3*4*   5*6*7*81*2asdfa d          *3*4*5*6*7*8", "16460236800"),
        ("100*10/2*sa aasa sxx x x 2/2*2/2/20/10/2/2/2*2/2/2", "0.00244140625"),
        ("20+300-a ss aa d 5*2/2+6/2-12+30-5*asdfa  a 2/2+6/2-1-300", "-39"),
        ("5005/10*5+4 ss-3*2/2asdfa as as-11/10*5+4-3*2/2-1", "92.88"),
        ("5*5*5/5*2*2/2/as ad a f2ag/25*5*5/5*2*2/2/2/2", "0.000015625"),
        ("""
         30
         078
         -asdfasd10 + 4*2
          
          
          as
          as
          s
          d
          
          
          /2*3-1+53               
                     
                            
                               sdaf
                                a a
                                0-10+4*2/2*3-1+5
         """, "29518.333333333333333333333334"),
    ];
}
