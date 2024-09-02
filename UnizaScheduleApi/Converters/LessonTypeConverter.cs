using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api.Converters
{
	internal class LessonTypeConverter : JsonConverter<LessonType>
	{
		public override LessonType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch (reader.GetString())
			{
				case "L":
					return LessonType.Laboratory;
				case "P":
					return LessonType.Lecture;
				case "C":
					return LessonType.Excercise;
				case "":
					return LessonType.Blocked;
				case var unknown:
					throw new ArgumentException($"Unexpected lesson type '{unknown}'");
			}
		}

		public override void Write(Utf8JsonWriter writer, LessonType value, JsonSerializerOptions options)
		{
			switch (value)
			{
				case LessonType.Laboratory:
					writer.WriteStringValue("L");
					break;
				case LessonType.Lecture:
					writer.WriteStringValue("P");
					break;
				case LessonType.Excercise:
					writer.WriteStringValue("C");
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(value), value, null);
			}
		}
	}
}