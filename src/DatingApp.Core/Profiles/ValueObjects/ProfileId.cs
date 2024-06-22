using DatingApp.Core.Common.ValueObjects;

namespace DatingApp.Core.Profiles.ValueObjects;

public sealed class ProfileId : BaseValueObject
{
  public Guid Value { get; }

  public ProfileId(Guid value)
  {
    if (value == Guid.Empty)
    {
      throw new ArgumentException($"{nameof(ProfileId)} cannot be empty", nameof(value));
    }

    Value = value;
  }

  public static ProfileId New() => new(Guid.NewGuid());

  protected override IEnumerable<object> GetAtomicValues()
  {
    yield return Value;
  }
}
