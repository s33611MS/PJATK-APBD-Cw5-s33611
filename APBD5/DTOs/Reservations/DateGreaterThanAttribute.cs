using System.ComponentModel.DataAnnotations;

namespace APBD5.DTOs.Reservations;

[AttributeUsage(AttributeTargets.Property)]
public class TimeGreaterThanAttribute : ValidationAttribute
{
    private string TimeToCompare { get; set; }
    
    public TimeGreaterThanAttribute(string timeToCompare)
    {
        TimeToCompare = timeToCompare;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        TimeOnly earlierTime = (TimeOnly)validationContext.ObjectType.GetProperty(TimeToCompare).GetValue(validationContext.ObjectInstance);

        TimeOnly laterTime = (TimeOnly)value;

        if (laterTime > earlierTime)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("EndTime is before StartTime");
    }
}