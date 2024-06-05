namespace Calculator.Test;
using Calculator.Prog;

public class Tests
{
    public Calculator calculator;
    public Person person;
    [SetUp]
    public void Setup()
    {
        calculator = new Calculator();
        person = new Person();
    }

    // This is not so automatic
    [Test]
    public void Add_ReturnCorrectValue()
    {
        // Expectation
        int a = 2;
        int b = 4;
        int expectation = 6; 
        // Result
        int result = calculator.Add(a,b);

        // Assert
        Assert.AreEqual(expectation, result);
    }

    // This is like good, more simple
    [TestCase(1,2,3)]
    [TestCase(4,5,9)]
    [TestCase(-1,10,9)]
    [TestCase(10,-12,-2)]
    [TestCase(11,2,13)]
    public void Add_ReturnCorrectValue_UsingTestCase(int a, int b, int expectation){
        int result = calculator.Add(a,b);
        Assert.AreEqual(expectation,result);
    }

    [TestCase(5,120)]
    [TestCase(2,2)]
    [TestCase(10,3628800)]
    [TestCase(7,5040)]
    public void Factorial_ReturnCorrectValue_UsingTestCase(int a, int expectation){
        int result = calculator.Factorial(a);
        Assert.AreEqual(expectation,result);
    }

    [TestCase("Juni","inuj")]
    [TestCase("Tono","onot")]
    [TestCase("masakan","nakasam")]
    [TestCase("","")]
    public void Reverse_ReturnReveseWord_UsingTestCase(string a, string expectation){
        string result = calculator.Reverse(a);
        Assert.AreEqual(expectation,result);
    }    

    [Test]
    public void GetFullName_WhenCalledWithValidPerson_ReturnNameAndID(){
        // Arrange
        var personA = new Person(){UserName="PageUp",UserID=123444};
        // Action
        var result = person.GetPersonIdentifier(personA);
        // Assert
        Assert.AreEqual("PageUp123444",result);
    }

    [Test]
    public void GetFullName_WhenCalledWithInValidPerson_ReturnNull(){
        // Arrange
        // var personA = null;
        // Action
        var result = person.GetPersonIdentifier(null);
        // Assert
        Assert.IsNull(null,result);
    }
}