namespace DatingApp.Core.Aggregates.Profiles.ValueObjects;

public sealed class Birthday(int month, int day, int year) : ValueObject
{
  public int Month { get; private set; } = month;
  public int Day { get; private set; } = day;
  public int Year { get; private set; } = year;

  public Birthday() : this(0, 0, 0) { }

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
