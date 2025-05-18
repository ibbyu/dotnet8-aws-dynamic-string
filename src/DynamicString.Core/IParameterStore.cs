namespace DynamicString.Core
{
    public interface IParameterStore
    {
        Task<string> GetDynamicStringAsync();
    }
}
