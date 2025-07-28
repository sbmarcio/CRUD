using CRUD.Application.Commands.CreateCliente;
using FluentValidation;

namespace CRUD.Application.Validators
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Documento)
                .NotEmpty().WithMessage("O documento é obrigatório.")
                .Matches(@"^\d{11}|\d{14}$").WithMessage("O documento deve ser um CPF (11 dígitos) ou CNPJ (14 dígitos).");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("E-mail inválido.")
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.TipoClienteId)
                .GreaterThan(0).WithMessage("Tipo de cliente inválido.");

            RuleFor(x => x.Telefone)
                .Matches(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$")
                .WithMessage("Telefone inválido.")
                .When(x => !string.IsNullOrWhiteSpace(x.Telefone));
        }
    }
}
