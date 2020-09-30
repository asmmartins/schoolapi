namespace School.Application.UseCases.CapturarEventoSensor
{
    public class CapturarEventoSensorRequest
    {
        public long Timestamp { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }
    }
}