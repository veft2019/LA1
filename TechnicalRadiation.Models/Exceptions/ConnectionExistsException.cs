using System;

namespace TechnicalRadiation.Models.Exceptions
{
    public class ConnectionExistsException : Exception
    {
        public ConnectionExistsException(string message) : base(message) {}
    }
}