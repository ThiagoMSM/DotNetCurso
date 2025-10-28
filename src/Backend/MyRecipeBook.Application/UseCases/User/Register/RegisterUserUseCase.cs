using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.Usecases.User.Register;

public class RegisterUserUseCase
{
    //business logic, valida a request
    // 
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson req)
    {
        ValidateUserReq(req);

        return new ResponseRegisteredUserJson
        {
            Name = req.Name
        };
    }

    private void ValidateUserReq(RequestRegisterUserJson req)
    {
        //dotnet add package FluentValidation.AspNetCore
        var validator = new RegisterUserValidator(); // instancia o zod basicamente
        var result = validator.Validate(req); //valida o req
        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(err => err.ErrorMessage);
            throw new Exception();
        }
    }
}
