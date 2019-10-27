using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

//The two constructors are to facilitate if I want to call the class with e.g true + message or if I want to call it and compose it later.