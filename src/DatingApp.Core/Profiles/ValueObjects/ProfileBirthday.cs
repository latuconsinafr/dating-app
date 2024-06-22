using DatingApp.Core.Common.ValueObjects;

namespace DatingApp.Core.Profiles.ValueObjects;

public sealed class ProfileBirthday(int month, int day, int year) : BaseValueObject
{
  public int Month { get; private set; } = month;
  public int Day { get; private set; } = day;
  public int Year { get; private set; } = year;

  public ProfileBirthday() : this(0, 0, 0) { }

  public void ChangeDate(int month, int day, int year)
  {
    Month = month;
    Day = day;
    Year = year;
  }

  protected override IEnumerable<object> GetAtomicValues()
  {
    yield return Month;
    yield return Day;
    yield return Year;
  }
}
