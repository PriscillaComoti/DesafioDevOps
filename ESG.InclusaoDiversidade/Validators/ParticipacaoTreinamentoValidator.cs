using System;
using ESG.InclusaoDiversidade.Models;
using FluentValidation;

namespace ESG.InclusaoDiversidade.Validators
{
    public class ParticipacaoTreinamentoValidator : AbstractValidator<ParticipacaoTreinamentoModel>
    {
        public ParticipacaoTreinamentoValidator()
        {
            RuleFor(p => p.FuncionarioID)
                .GreaterThan(0).WithMessage("FuncionárioID inválido");

            RuleFor(p => p.TreinamentoID)
                .GreaterThan(0).WithMessage("TreinamentoID inválido");

            RuleFor(p => p.DataParticipacao)
                .NotEmpty().WithMessage("Data de participação é obrigatória")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("A data de participação não pode ser no futuro");

            RuleFor(p => p.Estrelas)
                .InclusiveBetween(1, 5).WithMessage("A nota de estrelas deve ser entre 1 e 5");
        }
    }
}

