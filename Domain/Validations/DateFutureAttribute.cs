using System.ComponentModel.DataAnnotations;

namespace Domain.Validations;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
public class DateFutureAttribute : ValidationAttribute
{
    private readonly Func<DateTime> _dateTimeNowProvider;

    public DateFutureAttribute(Func<DateTime> dateTimeNowProvider)
    {
        _dateTimeNowProvider = dateTimeNowProvider;
        ErrorMessage = "La fecha no puede ser una que ya pasó";
    }

    //agregamos valor por defecto al connstructor de arriba
    public DateFutureAttribute() : this(() => DateTime.Now) { }

    public override bool IsValid(object value)
    {
        bool isValid = false;
        if (value is DateTime dateTime)
        {
            isValid = dateTime > _dateTimeNowProvider();
        }

        return isValid;
    }
}
