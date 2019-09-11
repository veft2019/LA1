using System;

namespace TechnicalRadiation.Models.Exceptions
{
    public class ContentNotFoundException : Exception
    {
        public ContentNotFoundException(string message) : base(message) {}
    }
}