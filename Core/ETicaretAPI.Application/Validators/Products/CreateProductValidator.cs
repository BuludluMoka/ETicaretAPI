﻿using FluentValidation;
using OnionArchitecture.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<CreateProductDto> 
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Məhsul adını boş keçmeyin.")
                .MaximumLength(150)
                .MinimumLength(4)
                    .WithMessage("Məhsul adını 4 ilə 150 hərf arasında girin.");

            RuleFor(p => p.Stock)
                .NotEmpty() 
                .NotNull()
                    .WithMessage("Stok məlumatını boş keçmeyin.")
                .Must(s => s >= 0)
                    .WithMessage("Stok məlumatı neqatif ola bilməz ");

            RuleFor(p => p.Price)
             .NotEmpty()
             .NotNull()
                 .WithMessage("Qiyməti boş keçmeyin.")
             .Must(s => s >= 0)
                 .WithMessage("Qiymət neqatif ola bilməz ");


        }
    }
}
