namespace LensLogic.Model
{
    [Flags]
    public enum SpecialEvent
    {
        DayToDay = 1,
        Birthday = 2,
        Wedding = 4,
        NewYearsEve = 8,
        Christmas = 16,
        Festival = 32
    }
}
