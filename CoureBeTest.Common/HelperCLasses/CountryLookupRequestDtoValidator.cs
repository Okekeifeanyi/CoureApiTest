using FluentValidation;
using CoureBeTest.API.DTOs;

public class CountryLookupRequestDtoValidator : AbstractValidator<CountryLookupRequestDto>
{
    public CountryLookupRequestDtoValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{10,15}$").WithMessage("Phone number must be 10-15 digits.");
    }
}
