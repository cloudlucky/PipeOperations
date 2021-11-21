namespace Cloudlucky.PipeOperations.Tests;

public class PipeExtensionsMixTests
{
    [Fact]
    public async Task Test_pipe_and_pipe_async()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await 5
            .Pipe(Add2)
            .Pipe(Add, 3)
            .Pipe(Add, 4, 5)
            .PipeAsync(Add2Async)
            .PipeAsync(AddAsync, 3)
            .PipeAsync(AddAsync, 4, 5)
            .PipeAsync(Add2Async, cancellationTokenSource.Token)
            .PipeAsync(AddAsync, 3, cancellationTokenSource.Token)
            .PipeAsync(AddAsync, 4, 5, cancellationTokenSource.Token);

        Assert.Equal(47, result);
    }

    private static int Add2(int input)
        => input + 2;

    private static int Add(int input, int valueToAdd)
        => input + valueToAdd;

    private static int Add(int input, int valueToAdd, int valueToAdd2)
        => input + valueToAdd + valueToAdd2;

    private static Task<int> Add2Async(int input)
        => Task.FromResult(input + 2);

    private static Task<int> Add2Async(int input, CancellationToken cancellationToken)
        => Task.FromResult(input + 2);

    private static async Task<int> Add2Task(Task<int> input)
        => await input + 2;

    private static async Task<int> Add2Task(Task<int> input, CancellationToken cancellationToken)
        => await input + 2;

    private static Task<int> AddAsync(int input, int valueToAdd)
        => Task.FromResult(input + valueToAdd);

    private static Task<int> AddAsync(int input, int valueToAdd, CancellationToken cancellationToken)
        => Task.FromResult(input + valueToAdd);

    private static async Task<int> AddTask(Task<int> input, int valueToAdd)
        => await input + valueToAdd;

    private static async Task<int> AddTask(Task<int> input, int valueToAdd, CancellationToken cancellationToken)
        => await input + valueToAdd;

    private static Task<int> AddAsync(int input, int valueToAdd, int valueToAdd2)
        => Task.FromResult(input + valueToAdd + valueToAdd2);

    private static Task<int> AddAsync(int input, int valueToAdd, int valueToAdd2, CancellationToken cancellationToken)
        => Task.FromResult(input + valueToAdd + valueToAdd2);

    private static async Task<int> AddTask(Task<int> input, int valueToAdd, int valueToAdd2)
        => await input + valueToAdd + valueToAdd2;

    private static async Task<int> AddTask(Task<int> input, int valueToAdd, int valueToAdd2, CancellationToken cancellationToken)
        => await input + valueToAdd + valueToAdd2;
}
