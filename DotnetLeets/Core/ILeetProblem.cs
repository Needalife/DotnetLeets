namespace DotnetLeets.Core
{
    internal interface ILeetProblem
    {
        string Name { get; }
        List<string> Tag { get; }
        void Run();
    }
}
