namespace DotnetLeets.Core
{
    internal interface ILeetProblem
    {
        string Name { get; }
        List<string> Tags { get; }
        void Run();
    }
}
