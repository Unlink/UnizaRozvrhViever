using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using KST.UnizaSchedule.Api.ScheduleRequests;

namespace KST.UnizaSchedule.Api
{
	public static class ScheduleApi
	{
		private const string URL = "https://nic.uniza.sk/webservices/";
		
		public static async Task<IEnumerable<ScheduleContent>> GetUnizaScheduleContentAsync(ScheduleRequest scheduleRequest)
		{
			using var httpClient = new HttpClient();

			var url = new UriBuilder(URL);
			url.Path += "getUnizaScheduleContent.php";
			url.Query = ScheduleApiHelpers.BuildQuery(scheduleRequest);

			var response = await httpClient.GetAsync(url.Uri);
			var responseObject = await JsonSerializer.DeserializeAsync<ScheduleContentResponse>(await response.Content.ReadAsStreamAsync());

			if (responseObject.Report != null)
				throw new InvalidOperationException($"Error getting the schedule: {responseObject.Report}");

			return responseObject
				.ScheduleContent
				.OrderBy(x => x.Day)
				.ThenBy(x => x.BlockNumber)
				.Distinct();
		}
	}
}
