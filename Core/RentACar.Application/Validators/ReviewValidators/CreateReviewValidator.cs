using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.Features.Mediator.Commands.ReviewCommands;

namespace RentACar.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Müşteri Adı Boş Geçilemez.")
                                        .MinimumLength(5).WithMessage("Müşteri Adı En Az 5 Karakterden Oluşmalıdır.")
                                        .MaximumLength(50).WithMessage("Müşteri Adı En Fazla 50 Karakter İçermelidir.");

            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen Puan Değerini Boş Geçmeyiniz.")
                                                  .InclusiveBetween(0, 5).WithMessage("Puan Değeri 0 ile 5 Arasında Olmalıdır.");

            RuleFor(x =>x.Comment).NotEmpty().WithMessage("Yorum Boş Geçilemez.")
                                  .MinimumLength(50).WithMessage("Yorum En Az 50 Karakterden Oluşmalıdır.")
                                  .MaximumLength(500).WithMessage("Yorum En Fazla 500 Karakter İçermelidir.");

            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Müşteri Görseli Boş Geçilemez");
                                         
        }
    }
}
