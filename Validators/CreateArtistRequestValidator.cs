using FluentValidation;
using MusicRoom.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRoom.Validators
{
    public class CreateArtistRequestValidator : AbstractValidator<CreateArtistRequest>
    {
        public CreateArtistRequestValidator()
        {
            RuleFor(x => x.ArtistName)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9 ]*$");

            RuleFor(x => x.AlbumName)
                .NotEmpty()
                .NotNull()
                .Matches("^[a-zA-Z0-9 ]*$");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan("0");

            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .NotNull();
        }
    }
}
