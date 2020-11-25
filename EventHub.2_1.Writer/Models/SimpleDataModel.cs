namespace EventHub._2_1.Writer.Models
{
    using EventHub._2_1.Writer.Models.Abstractions;

    public class SimpleDataModel : EventDataSerializer
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
