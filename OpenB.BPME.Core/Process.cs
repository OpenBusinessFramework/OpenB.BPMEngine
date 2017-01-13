using System;
using System.Collections.Generic;

namespace OpenB.BPM.Core
{

        public class Process
        {
            private ExecutionState executionState;

            public ProcessDefinition ProcessDefinition { get; private set; }
            public ProcessState CurrentState { get; internal set; }
            public ProcessDefinition StartingDefinition { get; set; }
            public IList<ProcessStateChange> StateChanges { get; private set; }

            public Process(ProcessDefinition startingDefinition)
            {
                if (startingDefinition == null)
                    throw new ArgumentNullException(nameof(startingDefinition));
                StartingDefinition = startingDefinition;
            }

            public void Start()
            {
                CurrentState = new ProcessState(ProcessDefinition.StartingState);
                StateChanges = new List<ProcessStateChange>();
            }

            public void Execute()
            {
                //ProcessState lastState = CurrentState;

                //foreach (StateTransistionDefinition transition in CurrentState.ProcessStateDefinition.Transitions)
                //{
                //    var transitionResult = transition.Execute();
                //    if (transitionResult.Success)
                //    {
                //        var eventExecutionResult = CurrentState.ProcessStateDefinition.ExecuteEvents();
                //        if (eventExecutionResult.Success)
                //        {
                //            CurrentState = new ProcessState(transition.ResultingStateDefinition);
                //            executionState = ExecutionState.StateChanged;
                //        }
                //    }
                //}

                //if (lastState != CurrentState)
                //{
                //    this.executionState = ExecutionState.NoTransitionsPossible;
                //}
            }
        }
}