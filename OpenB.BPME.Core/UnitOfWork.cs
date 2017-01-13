using System;

namespace OpenB.BPM.Core
{
    internal class UnitOfWork
    {
        internal void AddAction(IEvent item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            throw new NotImplementedException();
        }

        internal void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}