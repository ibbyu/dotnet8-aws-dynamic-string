using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using DynamicString.Core;

namespace DynamicString.AWS
{
    public class ParameterStore : IParameterStore
    {
        private readonly AmazonSimpleSystemsManagementClient _client;
        private readonly string _propertyName;

        public ParameterStore(string propertyName)
        {
            _client = new AmazonSimpleSystemsManagementClient();
            _propertyName = propertyName;
        }

        public async Task<string> GetDynamicStringAsync()
        {
            var request = new GetParameterRequest
            {
                Name = _propertyName,
                WithDecryption = false,
            };

            try
            {
                var response = await _client.GetParameterAsync(request);
                return response.Parameter.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving parameter: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
