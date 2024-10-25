using LanchesIO.API.src.Models;
using FluentValidation;

namespace LanchesIO.API.src.Validations
{
    public class IngredienteValidation : AbstractValidator<Ingrediente>
    {
        public IngredienteValidation()
        {
            RuleFor(i => i.Nome)
                .NotEmpty().WithMessage("O nome do ingrediente é obrigatório.")
                .Length(2, 100).WithMessage("O nome do ingrediente deve ter entre 2 e 100 caracteres.");

            RuleFor(i => i.Valor)
                .GreaterThan(0).WithMessage("O valor do ingrediente deve ser maior que zero.");
        }
    }
}
