using System.ComponentModel.DataAnnotations;

namespace APBD5.DTOs.Reservations;

[AttributeUsage(AttributeTargets.Property)]
public class DateGreaterThanAttribute : ValidationAttribute
{
    private string DateToCompare { get; set; }
    
    public DateGreaterThanAttribute(string dateToCompare)
    {
        DateToCompare = dateToCompare;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime earlierDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompare).GetValue(validationContext.ObjectInstance);

        DateTime laterDate = (DateTime)value;

        if (laterDate > earlierDate)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("EndTime is before StartTime");
    }
}