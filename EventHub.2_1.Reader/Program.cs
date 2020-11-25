namespace EventHub._2_1.Reader
{
    using Microsoft.Azure.EventHubs;
    using Microsoft.Azure.EventHubs.Processor;
    using System;
    using System.Threading.Tasks;

    class Program
    {
        private const string EVENT_HUB_NAME = "poc";
        private const string SHARED_ACCESS_KEY_NAME = "Listener";
        private const string SHARED_ACCESS_KEY = "ydZBxAVtEafVMoGWlId7tTWVjxFYeNpiamJDvIR8AC8=";

        private const string STORAGE_CONTAINER_NAME = "eventhub";
        private const string STORAGE_ACCOUNT_NAME = "examplehubstorage";
        private const string STORAGE_ACCOUNT_KEY = "j3aPsdNtnYTMhjcdxJh8VQyws+hRTkmneUm6tS5hU/kNcmjeo4bRMyJI+Z8sceKsw14BNp92PECoukSBkYjr3Q==";

        private static readonly string StorageConnectionString = $"DefaultEndpointsProtocol=https;AccountName={STORAGE_ACCOUNT_NAME};AccountKey={STORAGE_ACCOUNT_KEY};EndpointSuffix=core.windows.net";
        static async Task Main(string[] args)
        {
            await MainAsync();
        }

        private async static Task MainAsync()
        {
            Console.WriteLine("Registering EventProcessor...");
            var eventHubConnectionString = $"Endpoint=sb://event-hub-examples.servicebus.windows.net/;SharedAccessKeyName={SHARED_ACCESS_KEY_NAME};SharedAccessKey={SHARED_ACCESS_KEY}";
            var eventProcessorHost = new EventProcessorHost(
                EVENT_HUB_NAME,
                PartitionReceiver.DefaultConsumerGroupName,
                eventHubConnectionString,
                StorageConnectionString,
                STORAGE_CONTAINER_NAME);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>();

            Console.WriteLine("Receiving. Press ENTER to stop worker.");
            Console.ReadLine();

            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }
    }
}
