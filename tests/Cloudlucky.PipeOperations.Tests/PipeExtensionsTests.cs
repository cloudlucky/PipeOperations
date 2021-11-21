namespace Cloudlucky.PipeOperations.Tests;

public class PipeExtensionsTests
{
    [Fact]
    public void Test_pipe_with_only_one_input()
    {
        var result = 5.Pipe(Add2);

        Assert.Equal(7, result);
    }

    [Fact]
    public void Test_pipe_with_one_input_and_one_param()
    {
        var result = 5.Pipe(Add, 3);

        Assert.Equal(8, result);
    }

    [Fact]
    public void Test_pipe_with_one_input_and_two_params()
    {
        var result = 5.Pipe(Add, 3, 4);

        Assert.Equal(12, result);
    }

    [Fact]
    public void Test_pipe_chaining()
    {
        var result = 5
            .Pipe(Add2)
            .Pipe(Add, 3)
            .Pipe(Add, 4, 5);

        Assert.Equal(19, result);
    }

    private static int Add2(int input)
        => input + 2;

    private static int Add(int input, int valueToAdd)
        => input + valueToAdd;

    private static int Add(int input, int valueToAdd, int valueToAdd2)
        => input + valueToAdd + valueToAdd2;
}
