using JLD.RiverLane.Models;
using System;

namespace JLD.RiverLane.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class MessageAttribute : Attribute
    {
        /// <summary>
        /// Creates a new MessageAttribute with the message
        /// </summary>
        /// <param name="glyphicon"></param>
        public MessageAttribute(string message)
        {
            Check.NotNullOrEmpty(message, nameof(message));
            Message = message;
        }

        public string Message { get; private set; }
    }
}