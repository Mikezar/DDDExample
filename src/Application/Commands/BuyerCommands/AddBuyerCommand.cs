using MediatR;

namespace Application.Commands.BuyerCommands
{
    public class AddBuyerCommand : IRequest<bool>
    {
        public string Name { get; }
        public string Email { get; }

        public AddBuyerCommand(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
