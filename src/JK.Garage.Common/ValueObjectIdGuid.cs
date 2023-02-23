namespace JK.Garage.Common;

public abstract class ValueObjectIdGuid : ValueObject
{
    protected ValueObjectIdGuid()
    {
        this.Value = Guid.NewGuid();
    }

    protected ValueObjectIdGuid(Guid id)
    {
        this.Value = id;
    }

    public Guid Value { get; protected set; }

    public static implicit operator Guid(ValueObjectIdGuid valueObjectId)
    {
        return valueObjectId.Value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
