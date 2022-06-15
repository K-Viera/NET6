using System;
namespace ValidationsComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthAttribute : System.Attribute
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public string ErrorMessage { get; set; }

        public StringLengthAttribute(int minimumLength, int maximumLength, string errorMessage)
        {
            MinimumLength = minimumLength;
            MaximumLength = maximumLength;
            ErrorMessage = errorMessage;
        }
    }
}