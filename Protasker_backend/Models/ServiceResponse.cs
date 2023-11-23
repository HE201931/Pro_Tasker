
namespace Protasker_backend
{
    /// <summary>
    /// Wrapper utilisé pour répondre de façon générique aux différentes requêtes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public T? Data { get;set; }
        public bool Success { get;set; } = true;
        public string Message { get;set; } = string.Empty;
    }
}