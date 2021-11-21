namespace Cloudlucky.PipeOperations.Tests;

public class PipeAsyncExtensionsTests
{
    [Fact]
    public async Task Test_pipe_async_with_only_one_input()
    {
        var result = await Task.FromResult(5).PipeAsync(Add2Async);

        Assert.Equal(7, result);
    }

    [Fact]
    public async Task Test_pipe_async_with_only_one_input_and_cancellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5).PipeAsync(Add2Async, cancellationTokenSource.Token);

        Assert.Equal(7, result);
    }

    [Fact]
    public async Task Test_pipe_async_task_with_only_one_input()
    {
        var result = await Task.FromResult(5).PipeAsync(Add2Task);

        Assert.Equal(7, result);
    }

    [Fact]
    public async Task Test_pipe_async_task_with_only_one_input_and_cancellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5).PipeAsync(Add2Task, cancellationTokenSource.Token);

        Assert.Equal(7, result);
    }

    [Fact]
    public async Task Test_pipe_async_with_one_input_and_one_param()
    {
        var result = await Task.FromResult(5).PipeAsync(AddAsync, 3);

        Assert.Equal(8, result);
    }

    [Fact]
    public async Task Test_pipe_async_with_one_input_and_one_param_cancellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5).PipeAsync(AddAsync, 3, cancellationTokenSource.Token);

        Assert.Equal(8, result);
    }

    [Fact]
    public async Task Test_pipe_async_task_with_one_input_and_one_param()
    {
        var result = await Task.FromResult(5).PipeAsync(AddTask, 3);

        Assert.Equal(8, result);
    }

    [Fact]
    public async Task Test_pipe_async_task_with_one_input_and_one_param_with_cancellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5).PipeAsync(AddTask, 3, cancellationTokenSource.Token);

        Assert.Equal(8, result);
    }

    [Fact]
    public async Task Test_pipe_async_with_one_input_and_two_params()
    {
        var result = await Task.FromResult(5).PipeAsync(AddAsync, 3, 4);

        Assert.Equal(12, result);
    }

    [Fact]
    public async Task Test_pipe_async_with_one_input_and_two_params_with_canellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5).PipeAsync(AddAsync, 3, 4, cancellationTokenSource.Token);

        Assert.Equal(12, result);
    }

    [Fact]
    public async Task Test_pipe_async_task_with_one_input_and_two_params()
    {
        var result = await Task.FromResult(5).PipeAsync(AddTask, 3, 4);

        Assert.Equal(12, result);
    }

    [Fact]
    public async Task Test_pipe_async_task_with_one_input_and_two_params_with_canellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5).PipeAsync(AddTask, 3, 4, cancellationTokenSource.Token);

        Assert.Equal(12, result);
    }

    [Fact]
    public async Task Test_pipe_async_chaining()
    {
        var result = await Task.FromResult(5)
            .PipeAsync(Add2Async)
            .PipeAsync(AddAsync, 3)
            .PipeAsync(AddAsync, 4, 5);

        Assert.Equal(19, result);
    }

    [Fact]
    public async Task Test_pipe_async_chaining_with_canellation_token()
    {
        var cancellationTokenSource = new CancellationTokenSource();
        var result = await Task.FromResult(5)
            .PipeAsync(Add2Async, cancellationTokenSource.Token)
            .PipeAsync(AddAsync, 3, cancellationTokenSource.Token)
            .PipeAsync(AddAsync, 4, 5, cancellationTokenSource.Token);

        Assert.Equal(19, result);
    }

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
