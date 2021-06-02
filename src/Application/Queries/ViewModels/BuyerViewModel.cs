namespace Application.Queries.ViewModels
{
    public record BuyerViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public string Email { get; init; }
    }
}
