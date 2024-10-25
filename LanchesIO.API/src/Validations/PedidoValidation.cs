using FluentValidation;
using LanchesIO.API.src.Models;

namespace LanchesIO.API.src.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(p => p.Lanches)
                .NotEmpty().WithMessage("O pedido deve conter pelo menos um lanche.");

            RuleForEach(p => p.Lanches)
                .SetValidator(new LancheValidation());
        }
    }
}
