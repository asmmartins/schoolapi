using School.Domain.Shared;
using System;

namespace School.Domain.Sensores
{
    public class EventoSensor : IAggregateRoot
    {
        public long Timestamp { get; private set; }
        public DateTimeOffset Datetime { get; set; }
        public Tag Tag { get; private set; }
        public string Value { get; set; }

        public string TagFull => $"{Tag.Country}.{Tag.Region}.{Tag.Sensor}";

        public static EventoSensor Create(long timestamp, Tag tag, string value)
        {
            Validate(timestamp, tag, value);

            return new EventoSensor() { Timestamp = timestamp, Datetime = DateTimeOffset.FromUnixTimeMilliseconds(timestamp), Tag = tag, Value = value.Trim() };
        }

        private static void Validate(long timestamp, Tag tag, string value)
        {
            TimestampValidate(timestamp);
            if (tag == null) throw new ArgumentException("A tag é obrigatória.");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("O valor do evento do sensor é obrigatório.");
        }

        private static void TimestampValidate(long timestamp)
        {
            if (timestamp < 0) new ArgumentException("O timestamp está incorreto.");
        }
    }
}