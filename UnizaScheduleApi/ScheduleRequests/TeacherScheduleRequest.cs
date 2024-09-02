using System;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api.ScheduleRequests
{
	public class TeacherScheduleRequest : ScheduleRequest
	{
		public TeacherScheduleRequest(string personalNumber)
		{
			this.PersonalNumber = personalNumber;
		}

		public TeacherScheduleRequest(string personalNumber, DateTime date)
			: base(date)
		{
			this.PersonalNumber = personalNumber;
		}

		public TeacherScheduleRequest(string personalNumber, int scheduleYear, Semester scheduleSemester)
			: base(scheduleYear, scheduleSemester)
		{
			this.PersonalNumber = personalNumber;
		}

		public string PersonalNumber { get; }
	}
}
