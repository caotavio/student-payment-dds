using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}

//We return a command result because it is not every case that we will return the same command that went in,
//e.g -> when we receive a command that has a passwork the command that we will send to the screen obviously
//won't contain the user's password, only the username and Id.