using System.Collections.Generic;
using KST.UnizaSchedule.Api;

namespace KST.UnizaSchedule.Table
{
	public static class ScheduleTableExtensions
	{
		public static ScheduleTable ToTable(this IEnumerable<ScheduleContent> schedule)
			=> new ScheduleTable(schedule);
	}
}
