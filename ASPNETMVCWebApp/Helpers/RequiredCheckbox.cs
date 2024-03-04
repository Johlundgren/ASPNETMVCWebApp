using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCWebApp.Helpers;

public class RequiredCheckbox : ValidationAttribute
{
    public override bool IsValid(object? value) => value is bool b && b;
    
}
