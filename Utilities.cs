builder.Services.AddSingleton<ProblemDetailsFactory, AdminClientProblemDetailsFactory>();


                return Error.Custom(
                    type: (int)CustomErrorType.BadRequest,
                    code: "Null.Value",
                    description: "Cannot insert null value");




public static class CustomErrorType
{
    public const ErrorType BadRequest = (ErrorType)400;
    public const ErrorType InternalServerError = (ErrorType)500;
    public const ErrorType NotFound = (ErrorType)404;
}





//Commands
public interface ICommand : IRequest<IErrorOr> {}

public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>> {}



public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IErrorOr> where TCommand : ICommand {}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>> 
    where TCommand : ICommand<TResponse>
{}



//Query
public interface IQuery : IRequest<IErrorOr>
{

}

public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>>
{
}


public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, IErrorOr> where TQuery : ICommand
{
}

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, ErrorOr<TResponse>> 
    where TQuery : IQuery<TResponse>
{
}



//DI


        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddAutoMapper(typeof(AdminClientMapper));
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
