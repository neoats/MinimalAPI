namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message = null) : base(data, true, message)
        {
        }

        public SuccessDataResult(T data) : this(data, null)
        {
        }

        public SuccessDataResult(string message) : this(default, message)
        {
        }

    }

}
