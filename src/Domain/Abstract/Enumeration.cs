namespace Domain.Abstract
{
    public abstract class Enumeration
    {
        public ushort Id { get; }
        public string Name { get; }

        public Enumeration(ushort id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }
}