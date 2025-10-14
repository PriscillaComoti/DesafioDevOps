using System;
using ESG.InclusaoDiversidade.Models;
using FluentValidation;

namespace ESG.InclusaoDiversidade.Validators
{
    public class TreinamentoValidator : AbstractValidator<TreinamentoModel>
    {
        public TreinamentoValidator()
        {
            RuleFor(t => t.Titulo)
                .NotEmpty().WithMessage("Título é obrigatório")
                .MaximumLength(200);

            RuleFor(t => t.Descricao)
                .NotEmpty().WithMessage("Descrição é obrigatória");

            RuleFor(t => t.Tipo)
                .NotEmpty().WithMessage("Tipo é obrigatório (ex: assédio, diversidade etc)");
        }
    }
}

