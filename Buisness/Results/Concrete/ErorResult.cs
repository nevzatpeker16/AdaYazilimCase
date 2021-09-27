namespace Buisness.Results.Concrete
{
    public class ErorResult : Result
    {
        public ErorResult(string message) : base(false, message)
        {
        }
        public ErorResult() : base(false)
        {

        }
    }
    //Sabit base den false gelir.
}
