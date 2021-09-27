﻿namespace Buisness.Results.Concrete
{
    public class ErorDataResult<T> : DataResult<T>
    {
        public ErorDataResult(T data,string message) : base(data, false,message)
        {
        }

        public ErorDataResult(T data) : base(data, false)
        {
        }
        public ErorDataResult(string message):base(default,false,message)
        {

        }
        public ErorDataResult():base(default,false)
        {

        }
    }
}
