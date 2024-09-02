using System;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api.ScheduleRequests
{
	public abstract class ScheduleRequest
	{
		internal ScheduleRequest()
			: this(DateTime.Now)
		{
		}

		internal ScheduleRequest(DateTime date)
			: this(ScheduleApiHelpers.GetStudyYear(date), ScheduleApiHelpers.GetSemester(date))
		{
		}

		internal ScheduleRequest(int scheduleYear, Semester scheduleSemester)
		{
			this.ScheduleYear = scheduleYear;
			this.ScheduleSemester = scheduleSemester;
		}

		public int ScheduleYear { get; }
		public Semester ScheduleSemester { get; }
	}
}
