namespace RosariumBackEnd.Service.Interfaces
{
    public interface ICustomHttpUtils
    {
        void SetUrl(string url);
        Task<T> GetAsync<T>(string authToken = null);
        Task<string> PostAsync(object requestBody, string authToken = null);
        Task<string> PutAsync(object requestBody, string authToken = null);
        Task<string> DeleteAsync(string authToken = null);
    }
}
