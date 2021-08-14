using System;
namespace DiunsaSCM.Utils
{
    public class ServiceResult<T>
    {
        public ResponseCode ResponseCode { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }

        public ServiceResult(ResponseCode responseCode, string error, T result)
        {
            ResponseCode = responseCode;
            Error = error;
            Data = result;
        }

        public static ServiceResult<T> ErrorResult(string error) {
            return new ServiceResult<T>(ResponseCode.Error, error, default(T));
        }

        public static ServiceResult<T> SuccessResult(T entity) {
            return new ServiceResult<T>(ResponseCode.Success, string.Empty, entity);
        }

    }
}
