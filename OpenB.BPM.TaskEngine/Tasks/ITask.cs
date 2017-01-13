namespace OpenB.BPM.TaskEngine.Tasks
{

    public interface ITask
    {
        bool IsApplicable { get; }

        void Run();
    }
}
