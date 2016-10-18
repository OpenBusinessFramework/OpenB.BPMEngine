using System;
using System.Collections.Generic;

namespace OpenB.BPME.Core
{
    public abstract class BaseTrigger
    {
        public ProcessDefinition ProcessDefinition { get; }
        public IList<IEventListener> EventListeners { get; private set; } 

        public void Fire()
        {
            foreach(var listener in EventListeners)
            {
                listener.Trigger();
            }
        }

        protected abstract void FireInternal();
    }

    public interface IEventListener
    {
        void Trigger();
    }

    public class TimerBasedTrigger : BaseTrigger, IProcessStartTrigger
    {
        protected override void FireInternal()
        {
            throw new NotImplementedException();
        }
    }

    public class ModelStateChangeTrigger : BaseTrigger, IProcessStartTrigger
    {
        protected override void FireInternal()
        {
            throw new NotImplementedException();
        }
    }

    public class ManualTrigger : BaseTrigger, IProcessStartTrigger
    {
        protected override void FireInternal()
        {
            throw new NotImplementedException();
        }
    }

    public interface IProcessStartTrigger
    {
        ProcessDefinition ProcessDefinition { get; }
    }

    public class StateTransistion
    {
        public StateTransistion(ProcessStateDefinition destinationState, IEnumerable<ICondition> conditions)
        {
            if (conditions == null)
                throw new ArgumentNullException(nameof(conditions));
            if (destinationState == null)
                throw new ArgumentNullException(nameof(destinationState));
        }
    }

    public class ProcessDefinition
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ProcessStateDefinition StartingState { get; private set; }

        public ProcessDefinition(string key, string name, string description, ProcessStateDefinition startingState)
        {            
            if (startingState == null)
                throw new ArgumentNullException(nameof(startingState));

            Key = key;
            Name = name;
            Description = description;
            StartingState = startingState;
        }
    }

    public class ProcessStateDefinition
    {
        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<Transistion> Transistions { get; private set; }

        public ProcessStateDefinition(string key, string name, string description, IEnumerable<Transistion> transistions)
        {
            if (transistions == null)
                throw new ArgumentNullException(nameof(transistions));

            Transistions = transistions;
            Description = description;
            Name = name;
            Key = key;
        }
    }

    public interface ICondition
    {
    }
}
