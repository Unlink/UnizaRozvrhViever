using System.Text.Json.Serialization;

namespace KST.UnizaSchedule.Api
{
	internal class ScheduleContentResponse
	{
		[JsonPropertyName("report")]
		public string Report { get; set; }

		public ScheduleContent[] ScheduleContent { get; set; }
	}
}
