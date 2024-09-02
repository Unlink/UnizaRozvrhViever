using System;
using System.Text.Json.Serialization;
using KST.UnizaSchedule.Api.Converters;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api
{
	public class ScheduleContent
	{
		[JsonPropertyName("dw")]
		public DayOfWeek Day { get; set; }

		[JsonPropertyName("b")]
		public int BlockNumber { get; set; }

		[JsonPropertyName("tu")]
		[JsonConverter(typeof(LessonTypeConverter))]
		public LessonType LessonType { get; set; }

		[JsonPropertyName("u")]
		public string TeacherName { get; set; }

		[JsonPropertyName("r")]
		public string RoomName { get; set; }

		[JsonPropertyName("k")]
		public string SubjectShortcut { get; set; }

		[JsonPropertyName("s")]
		public string CourseName { get; set; }

		[JsonPropertyName("g")]
		public string Group { get; set; }

		public override bool Equals(object obj)
		{
			if (obj is ScheduleContent other)
				return this.Day == other.Day
				       && this.BlockNumber == other.BlockNumber
				       && this.LessonType == other.LessonType
				       && this.TeacherName == other.TeacherName
				       && this.RoomName == other.RoomName
				       && this.SubjectShortcut == other.SubjectShortcut
				       && this.CourseName == other.CourseName
				       && this.Group == other.Group;
			return false;
		}

		public override int GetHashCode()
			=> HashCode.Combine(this.Day, this.BlockNumber, this.LessonType, this.TeacherName, this.RoomName, this.SubjectShortcut, this.CourseName, this.Group);
	}
}