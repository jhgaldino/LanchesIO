
using FluentValidation;
using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Validations
{
    public class LancheValidation : AbstractValidator<Lanche>
    {
        public LancheValidation()
        {
            RuleFor(l => l.Nome)
                .NotEmpty().WithMessage("O nome do lanche é obrigatório.")
                .Length(2, 100).WithMessage("O nome do lanche deve ter entre 2 e 100 caracteres.");

            RuleFor(l => l.Valor)
                .GreaterThan(0).WithMessage("O valor do lanche deve ser maior que zero.");
            
            RuleFor(l => l.Ingredientes)
                .Must(ingredientes => ingredientes.Count >= 2)
                .WithMessage("O lanche deve ter pelo menos 2 ingredientes.");
        }
    }
}
