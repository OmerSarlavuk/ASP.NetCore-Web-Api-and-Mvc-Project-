namespace AHL.UI.Areas.Admin.HttpApiServices
{
    public interface IHttpApiService
    {
        Task<T> GetData<T>(string endPoint, string token = null);
        Task<T> PostData<T>(string endPoint, string jsonData);
        Task<T> DeleteData<T>(string endPoint, string token = null);
        Task<T> PutData<T>(string endPoint, string jsonData);

    }
}
