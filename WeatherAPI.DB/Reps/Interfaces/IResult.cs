namespace WeatherAPI.DB.Reps.Interfaces
{
    public interface IResult<out T>
    {
        T Return { get; }
        string? Message { get; }
    }

    public interface IResultBool: IResult<bool> { }
}
