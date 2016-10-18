namespace OpenB.BPME.Core.Events
{
    public class SendMailEvent : BaseAction<SendMailEventInput>, IEventAction
    {
        public SendMailEvent(SendMailEventInput input) : base(input)
        {

        }

        protected override void Execute()
        {

        }
    }

    internal interface IEventAction
    {
    }

    public abstract class BaseAction<T> where T : IActionInput
    {
        public BaseAction(T input)
        {
            Input = input;
        }

        protected T Input { get; private set; }

        protected abstract void Execute();
    }

    public class SendMailEventInput : IActionInput
    {
        public string SourceEmailAddress { get; set; }
        public string DestinationEmailAddress { get; set; }
        public string MessageBody { get; set; }
    }

    public interface IActionInput
    {
    }
}
