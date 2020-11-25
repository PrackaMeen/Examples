namespace EventHub._2_1.Writer.Mappers
{
    using Microsoft.Azure.EventHubs;
    using Newtonsoft.Json;
    using System.Text;

    public static class EventDataMapper
    {
        public static EventData MapToEventData<T>(T data) where T: class
        {
            var serializedData = EventDataMapper.SerializeToUTF8(data);
            var binaryData = EventDataMapper.GetBinaryFromUTF8(serializedData);

            return new EventData(binaryData);
        }

        private static byte[] GetBinaryFromUTF8(string serializedData)
        {
            return Encoding.UTF8.GetBytes(serializedData);
        }

        private static string SerializeToUTF8<T>(T data) where T : class
        {
            var result = JsonConvert.SerializeObject(data);

            return result;
        }
    }
}
