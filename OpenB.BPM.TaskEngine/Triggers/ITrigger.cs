﻿namespace OpenB.BPM.TaskEngine.Triggers
{
    public interface ITrigger
    {
        bool IsApplicable { get; }
        void Initialize();
        void RunTask();
    }
}