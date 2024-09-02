using KST.UnizaSchedule.Api;

namespace RozvrhUniza
{
    public static class TeacherMerger
    {
        public static IEnumerable<ScheduleContent> MergeMultipleTeachers(this IEnumerable<ScheduleContent> collection)
        {
            return collection
                .GroupBy(
                    x => (x.BlockNumber, x.CourseName, x.Day, x.Group, x.LessonType, x.RoomName, x.SubjectShortcut))
                .Select(x => new ScheduleContent
                {
                    TeacherName = String.Join(", ", x.Select(c => c.TeacherName).OrderBy(t => t)),
                    BlockNumber = x.Key.BlockNumber,
                    CourseName = x.Key.CourseName,
                    Day = x.Key.Day,
                    Group = x.Key.Group,
                    RoomName = x.Key.RoomName,
                    SubjectShortcut = x.Key.SubjectShortcut,
                    LessonType = x.Key.LessonType
                });
        }
    }
}
