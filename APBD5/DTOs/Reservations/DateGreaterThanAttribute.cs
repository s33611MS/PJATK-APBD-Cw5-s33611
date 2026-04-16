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
        DateTime earlierDate = (DateTime)value;

        DateTime laterDate = (DateTime)validationContext.ObjectType.GetProperty(DateToCompare).GetValue(validationContext.ObjectInstance);

        if (laterDate > earlierDate)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("EndTime is before StartTime");
    }
}