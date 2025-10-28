using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application;
                                    //herda o validador para o tipo <>
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator(){ // basicamente o zod
        RuleFor(User => User.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(User => User.Email).NotEmpty().EmailAddress();
        RuleFor(User => User.Password).NotEmpty().MinimumLength(6);
    }
}
