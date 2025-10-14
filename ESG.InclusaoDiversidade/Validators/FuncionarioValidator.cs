using System;
using ESG.InclusaoDiversidade.Models;
using FluentValidation;

namespace ESG.InclusaoDiversidade.Validators
{
    public class FuncionarioValidator : AbstractValidator<FuncionarioModel>
    {
        public FuncionarioValidator()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100);

            RuleFor(f => f.Genero)
                .NotEmpty().WithMessage("Gênero é obrigatório");

            RuleFor(f => f.Etnia)
                .NotEmpty().WithMessage("Etnia é obrigatória");

            RuleFor(f => f.Cargo)
                .NotEmpty().WithMessage("Cargo é obrigatório");

            RuleFor(f => f.Salario)
                .GreaterThan(0).WithMessage("Salário deve ser maior que zero");

            RuleFor(f => f.EquipeID)
                .GreaterThan(0).WithMessage("EquipeID deve ser válido");
        }
    }
}

