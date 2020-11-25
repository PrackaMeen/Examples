namespace EventHub._2_1.Writer.Models.Abstractions
{
    using EventHub._2_1.Writer.Mappers;
    using Microsoft.Azure.EventHubs;

    public abstract class EventDataSerializer
    {
        public EventData ToEventData()
        {
            return EventDataMapper.MapToEventData(this);
        }
    }
}
