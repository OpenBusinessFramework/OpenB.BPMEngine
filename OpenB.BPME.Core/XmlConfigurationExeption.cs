using System;
using System.Runtime.Serialization;

namespace OpenB.BPM.Core
{
    [Serializable]
    internal class XmlConfigurationException : Exception
    {
        public XmlConfigurationException()
        {
        }

        public XmlConfigurationException(string message) : base(message)
        {
        }

        public XmlConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XmlConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}