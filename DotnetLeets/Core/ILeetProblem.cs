namespace DotnetLeets.Core
{
    internal interface ILeetProblem
    {
        string Name { get; }
        void Run();
    }
}
