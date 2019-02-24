using System;

namespace APIBrumadinho.Helpers
{
    public interface IResult<out T>
    {
        bool Succeeded { get; }

        T Value { get; }

        ResultInfo Info { get; }
    }

    public readonly struct Result<T> : IResult<T>, IEquatable<Result<T>>
    {
        public bool Succeeded { get; }

        public T Value { get; }

        public ResultInfo Info { get; }

        internal Result(bool success, T value, ResultInfo info)
        {
            Succeeded = success;
            Value = value;
            Info = info;
        }

        internal Result(bool success, ResultInfo info)
            : this(success, default, info)
        {
        }

        internal Result(bool success, T value)
            : this(success, value, default)
        {
        }

        public static bool operator ==(Result<T> left, Result<T> right) =>
            Equals(left, right);

        public static bool operator !=(Result<T> left, Result<T> right) =>
            !Equals(left, right);

        public override bool Equals(object obj) =>
             (obj is Result<T> result) && Equals(result);

        public override int GetHashCode() => (Succeeded, Value, Info).GetHashCode();

        public bool Equals(Result<T> other)
        {
            var type = other.Value?.GetType();
            return (type == Value?.GetType()) && (Succeeded == other.Succeeded) && (Info == other.Info);
        }
    }

    public static class Result
    {
        public static IResult<T> Success<T>(T resValue) =>
            new Result<T>(true, resValue, new ResultInfo("No erros detected."));

        public static IResult<T> Success<T>(string successMsg, T resValue) =>
            new Result<T>(true, resValue, new ResultInfo(successMsg));

        public static IResult<T> Fail<T>(Exception exc) =>
            new Result<T>(false, default, new ResultInfo(exc));

        public static IResult<T> Fail<T>(string errMsg) =>
            new Result<T>(false, default, new ResultInfo(errMsg));

        public static IResult<T> Fail<T>(string errMsg, T resValue) =>
            new Result<T>(false, resValue, new ResultInfo(errMsg));

        public static IResult<T> Fail<T>(Exception ex, T resValue) =>
            new Result<T>(false, resValue, new ResultInfo(ex));

        public static IResult<T> Fail<T>(ResultInfo info, T resValue) =>
            new Result<T>(false, resValue, info);
    }
}
