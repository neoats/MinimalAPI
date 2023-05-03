using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message = null) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : this(data, null)
        {
        }

        public ErrorDataResult(string message) : this(default, message)
        {
        }

    }
}
