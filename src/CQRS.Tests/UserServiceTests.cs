namespace CQRS.Tests;

public class UserServiceTests
{
    [Fact]
    public void IsUserEqualToOrNot()
    {
        var a = 1;

        Assert.Equal(1, a);
    }
    [Fact]
    public void IsMultWorkingCorrectly()
    {
        var a = 50;
        var b = 80;

        Assert.NotEqual(0, a * b);
    }
    [Fact]
    public void IsMultWorkingWrong()
    {
        var a = 50;
        var b = 80;

        Assert.Equal(0, a * b);
    }
}
