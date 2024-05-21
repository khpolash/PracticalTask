using System.ComponentModel.DataAnnotations;

namespace PracticalTask.Models.CustomValidations;

public class OneRequiredAttribute : ValidationAttribute
{
    private readonly string _otherPropertyName;

    public OneRequiredAttribute(string otherPropertyName)
    {
        _otherPropertyName = otherPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherProperty = validationContext.ObjectType.GetProperty(_otherPropertyName);
        if (otherProperty == null)
        {
            return new ValidationResult($"Unknown property: {_otherPropertyName}");
        }

        var otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

        if (value == null && otherValue == null)
        {
            return new ValidationResult("Either CorporateCustomerId or IndividualCustomerId must be provided.");
        }

        return ValidationResult.Success;
    }
}