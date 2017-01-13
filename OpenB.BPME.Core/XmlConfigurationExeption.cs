using System;
using System.Runtime.Serialization;

namespace OpenB.DSL.Test
{

    [Serializable]
    internal class XmlConfigurationExeption : Exception
    {
        public XmlConfigurationExeption()
        {
        }

        public XmlConfigurationExeption(string message) : base(message)
        {
        }

        public XmlConfigurationExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XmlConfigurationExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}