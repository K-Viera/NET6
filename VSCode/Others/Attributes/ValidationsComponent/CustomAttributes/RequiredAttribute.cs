using System;
namespace ValidationsComponent.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Parameter|AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute:System.Attribute
    {
        public string ErrorMessage { get; set; }

        public RequiredAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}