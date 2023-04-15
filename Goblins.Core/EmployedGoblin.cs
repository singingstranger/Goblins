namespace Goblins.Core
{
    public record EmployedGoblin
    {
        public Goblin Goblin { get; init; } = new();
        public string Job { get; set; } = string.Empty;
    }
}
