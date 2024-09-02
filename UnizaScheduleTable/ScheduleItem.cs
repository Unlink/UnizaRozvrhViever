using KST.UnizaSchedule.Api;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Table
{
    public record ScheduleItem(LessonType LessonType, string TeacherName, string RoomName, string Group)
    {
        public ScheduleItem(ScheduleContent scheduleContent) : this(scheduleContent.LessonType, scheduleContent.TeacherName, scheduleContent.RoomName, scheduleContent.Group)
        {
        }
    }
}
