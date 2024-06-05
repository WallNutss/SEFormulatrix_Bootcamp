namespace Calculator.Test.Another;
using Calculator.Prog;

public class Tests
{
    private Calculator _calculator;
    [SetUp]
    public void Setup(){
        _calculator = new Calculator();
    }

    [Test]
    public void Add_ReturnCorrectValue_UsingTest()
    {
        Assert.Pass();
    }

}