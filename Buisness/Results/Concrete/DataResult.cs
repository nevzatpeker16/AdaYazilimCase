using Core.Utilities.Results.Abstract;

namespace Buisness.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
       public DataResult(T data,bool success,string message) : base(success, message)
        {
            Data = data;

        }
        public DataResult(T data,bool success) : base(success)
        {
            Data = data;
        }
        //Bu şekilde Success ve Message yi gönderecek kodu yazmadık.
        //Mesaj yazmadan da direk sadece data gönderimi ve success durumu..
        public T Data { get; }
    }
}
