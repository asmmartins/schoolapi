using School.Domain.Shared;
using System.Collections.Generic;

namespace School.Domain.Sensores
{
    public class Tag : ValueObject
    {
        public string Country { get; private set; }
        public string Region { get; private set; }
        public string Sensor { get; private set; }

        protected Tag() { }

        protected override IEnumerable<object> GetEqualsProperties()
        {
            yield return Country;
            yield return Region;
            yield return Sensor;
        }

        public static Tag Create(string fullTag)
        {
            FullTagValidate(fullTag);

            var tags = fullTag?.Trim().Split('.');

            TagsValidate(tags);

            return new Tag() { Country = tags[0], Region = tags[1], Sensor = tags[2] };
        }

        private static void FullTagValidate(string fullTag)
        {
            if (string.IsNullOrWhiteSpace(fullTag))
            {
                throw new System.ArgumentException("A tag é obrigatória.");
            }
        }

        private static void TagsValidate(string[] tags)
        {
            if (tags.Length != 3)
            {
                throw new System.ArgumentException("A tag está incorreta.");
            }

        }
    }
}