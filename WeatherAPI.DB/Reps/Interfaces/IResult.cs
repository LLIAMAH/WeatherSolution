namespace WeatherAPI.DB.Reps.Interfaces
{
    public interface IResult<out T>
    {
        T Returned { get; }
        string? Message { get; }
    }

    public interface IResultBool: IResult<bool> { }
}
