using System;
using ESG.InclusaoDiversidade.Models;
using FluentValidation;

namespace ESG.InclusaoDiversidade.Validators
{
    public class CandidatoValidator : AbstractValidator<BancoTalentosModel>
    {
        public CandidatoValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100);

            RuleFor(c => c.Genero)
                .NotEmpty().WithMessage("Gênero é obrigatório");

            RuleFor(c => c.Etnia)
                .NotEmpty().WithMessage("Etnia é obrigatória");

            RuleFor(c => c.Deficiencia)
                .NotNull().WithMessage("Deficiência deve ser informada (sim/não)");

            RuleFor(c => c.CargoPretendido)
                .NotEmpty().WithMessage("Cargo pretendido é obrigatório");

            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Status do candidato é obrigatório");
        }
    }
}

