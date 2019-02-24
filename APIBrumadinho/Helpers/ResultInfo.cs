using System;

namespace APIBrumadinho.Helpers
{
    public readonly struct ResultInfo : IEquatable<ResultInfo>
    {
        public Exception Exception { get; }

        public string Message { get; }

        internal ResultInfo(Exception ex)
        {
            Exception = ex;
            Message = ex?.Message;
        }

        internal ResultInfo(string message)
        {
            Message = message;
            Exception = null;
        }

        public static bool operator ==(ResultInfo left, ResultInfo right) =>
            Equals(left, right);

        public static bool operator !=(ResultInfo left, ResultInfo right) =>
            !Equals(left, right);

        public bool Equals(ResultInfo other) =>
            (Exception, Message) == (other.Exception, other.Message);

        public override bool Equals(object obj) =>
            (obj is ResultInfo info) && Equals(info);

        public override int GetHashCode() =>
            (Exception, Message).GetHashCode();
    }
}
