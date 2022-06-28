using AtakDomainHotelBackend.Core.Entity;
using FluentValidation;

namespace AtakDomainHotelBackend.API.Validation
{
    public class HotelValidation: AbstractValidator<Hotel>
    {
        public HotelValidation()
        {
            //The hotel URL must be valid (please come up with a good definition of "valid").

            RuleFor(hotel=>hotel.uri).Must(ValidateUri).WithMessage("Lütfen Geçerli Bir Url Giriniz");

            //Hotel ratings are given as a number from 0 to 5 stars. There may be no negative numbers.
            RuleFor(hotel => hotel.stars).GreaterThan(0).LessThanOrEqualTo(5);
        }

        private bool ValidateUri(string uri)
        {
            
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
