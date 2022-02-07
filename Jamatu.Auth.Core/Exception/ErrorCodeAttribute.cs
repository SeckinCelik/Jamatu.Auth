using System;

namespace Jamatu.Auth.Core.Exception
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ErrorCodeAttribute : Attribute
    {
        public ErrorCodeAttribute(short code, string title)
        {
            Code = code;
            Title = title;
        }

        public short Code { get; set; }

        public string Title { get; set; }
    }
}
