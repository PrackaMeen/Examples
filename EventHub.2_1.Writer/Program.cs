namespace EventHub._2_1.Writer
{
    using System.Threading.Tasks;
    using EventHub._2_1.Writer.Mappers;
    using EventHub._2_1.Writer.Models;
    using Microsoft.Azure.EventHubs;

    class Program
    {
        static EventHubClient _client;
        const string SHARED_ACCESS_KEY_NAME = "Writer";
        const string SHARED_ACCESS_KEY = "RCxff6rXWgEFbDp1xuA/P3WRGfNwY0fzI4uFmXkEWvQ=";
        const string EVENT_HUB_NAME = "poc";

        static async Task Main(string[] args)
        {
            var eventHubConnectionString = $"Endpoint=sb://event-hub-examples.servicebus.windows.net/;SharedAccessKeyName={SHARED_ACCESS_KEY_NAME};SharedAccessKey={SHARED_ACCESS_KEY};EntityPath={EVENT_HUB_NAME}";

            _client = EventHubClient.CreateFromConnectionString(eventHubConnectionString);
            var runtimeInformation = await _client.GetRuntimeInformationAsync();
            var partitionInformation = runtimeInformation.PartitionIds;

            var partitionSender = _client.CreatePartitionSender(partitionInformation[0]);

            var newEventData = new SimpleDataModel()
            {
                Age = 35,
                FirstName = "User",
                LastName = "Named"
            };

            await partitionSender.SendAsync(newEventData.ToEventData());

            var newEventData2 = new
            {
                Age = 15,
                FirstName = "Pracka",
                LastName = "Meen"
            };

            await _client.SendAsync(EventDataMapper.MapToEventData(newEventData2));
        }
    }
}