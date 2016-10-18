namespace OpenB.BMP.TaskEngine.Triggers
{

    public interface ITask
    {
        bool IsApplicable { get; }

        void Run();
    }
}
