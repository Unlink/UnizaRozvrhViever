using System;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api.ScheduleRequests
{
	public class RoomScheduleRequest : ScheduleRequest
	{
		public RoomScheduleRequest(int roomId)
		{
			this.RoomId = roomId;
		}

		public RoomScheduleRequest(int roomId, DateTime date)
			: base(date)
		{
			this.RoomId = roomId;
		}

		public RoomScheduleRequest(int roomId, int scheduleYear, Semester scheduleSemester)
			: base(scheduleYear, scheduleSemester)
		{
			this.RoomId = roomId;
		}

		public int RoomId { get; }
	}
}
