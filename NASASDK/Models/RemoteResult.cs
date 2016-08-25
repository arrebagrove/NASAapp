namespace NASASDK.Models
{
    public class RemoteResult : IRemoteResult
    {
        public RemoteResult(bool isSuccess, object data = null, string errorMessage = null)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.ErrorMessage = errorMessage;
        }

        public object Data { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool IsSuccess { get; private set; }
    }

    public interface IRemoteResult
    {
        bool IsSuccess { get; }
        object Data { get; }
        string ErrorMessage { get; }
    }
}
