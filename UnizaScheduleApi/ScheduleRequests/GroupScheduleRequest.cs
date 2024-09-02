using System;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api.ScheduleRequests
{
	public class GroupScheduleRequest : ScheduleRequest
	{
		public GroupScheduleRequest(string groupNumber)
		{
			this.GroupNumber = groupNumber;
		}

		public GroupScheduleRequest(string groupNumber, DateTime date)
			: base(date)
		{
			this.GroupNumber = groupNumber;
		}

		public GroupScheduleRequest(string groupNumber, int scheduleYear, Semester scheduleSemester)
			: base(scheduleYear, scheduleSemester)
		{
			this.GroupNumber = groupNumber;
		}

		public string GroupNumber { get; }
	}
}
