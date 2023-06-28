using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp
{
    public class OperationResult
    {
        public ResultState State { get; protected set; }
        public Exception? Exception { get; protected set; }

        public OperationResult()
        {
            State = ResultState.Success;
            Exception = null;
        }

        public OperationResult(Exception exception)
        {
            State = ResultState.Failure;
            Exception = exception;
        }

        public bool IsSucceeded => State == ResultState.Success;
        public bool IsFailed => State == ResultState.Failure;

        public OperationResult Succeed()
        {
            return new OperationResult();
        }

        public OperationResult Fail(Exception exception)
        {
            return new OperationResult(exception);
        }

        public TResult Evaluate<TResult>(Func<TResult> succeed, Func<Exception, TResult> fail)
        {
            return IsSucceeded ? succeed() : fail(Exception);
        }
        public TResult Evaluate<TResult>(Func<TResult> succeed, Func<Exception, object, TResult> fail, object? failData)
        {
            return IsSucceeded ? succeed() : fail(Exception, failData);
        }

        public enum ResultState
        {
            Success,
            Failure
        }
    }
}

namespace BoardApp
{
    public class OperationResult<T> : OperationResult
    {
        public T? Value { get; protected set; }

        public OperationResult() : base()
        {
        }
        public OperationResult(T value) : base()
        {
            Value = value;
        }
        public OperationResult Succeed(T value)
        {
            return new OperationResult<T>(value);
        }

        public OperationResult(Exception exception) : base(exception)
        {
            Value = default;
        }

        public TResult Evaluate<TResult>(Func<T, TResult> succeed, Func<Exception, TResult> fail)
        {
            return IsSucceeded ? succeed(Value) : fail(Exception);
        }

        public TResult Evaluate<TResult>(Func<T, TResult> succeed, Func<Exception, object, TResult> fail, object failData)
        {
            return IsSucceeded ? succeed(Value) : fail(Exception, failData);
        }
    }
}
