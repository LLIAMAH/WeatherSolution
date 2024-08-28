using WeatherAPI.DB.Reps.Interfaces;

namespace WeatherAPI.DB.Reps
{
    public class Result<T> : IResult<T>
    {
        public T Return { get; }
        public string? Message { get; }

        public Result(T ret, string? message = null)
        {
            this.Return = ret;
            this.Message = message;
        }
    }

    public class ResultBool:Result<bool>, IResultBool
    {
        public ResultBool(bool ret, string? message = null) : base(ret, message) { }
    }
}
