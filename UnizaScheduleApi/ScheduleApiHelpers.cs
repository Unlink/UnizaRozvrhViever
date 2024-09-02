using System;
using System.Web;
using KST.UnizaSchedule.Api.Enums;
using KST.UnizaSchedule.Api.ScheduleRequests;

namespace KST.UnizaSchedule.Api
{
	internal static class ScheduleApiHelpers
	{
		public static string BuildQuery(ScheduleRequest scheduleRequest)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);

			switch (scheduleRequest)
			{
				case GroupScheduleRequest groupScheduleRequest:
					query["m"] = "2";
					query["id"] = groupScheduleRequest.GroupNumber;

					break;
				case RoomScheduleRequest roomScheduleRequest:
					query["m"] = "3";
					query["id"] = roomScheduleRequest.RoomId.ToString();

					break;
				case SubjectScheduleRequest subjectScheduleRequest:
					query["m"] = "4";
					query["id"] = $"{subjectScheduleRequest.SubjectNumber},{(int) subjectScheduleRequest.Faculty},{(int) subjectScheduleRequest.StudyForm},{subjectScheduleRequest.YearOfStudy}";

					break;
				case TeacherScheduleRequest teacherScheduleRequest:
					query["m"] = "1";
					query["id"] = teacherScheduleRequest.PersonalNumber;

					break;
				default:
					throw new ArgumentOutOfRangeException(scheduleRequest.GetType().Name);
			}

			query["r"] = scheduleRequest.ScheduleYear.ToString();

			switch (scheduleRequest.ScheduleSemester)
			{
				case Semester.Summer:
					query["s"] = "L";
					break;
				case Semester.Winter:
					query["s"] = "Z";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return query.ToString();
		}

		public static Semester GetSemester(DateTime date)
		{
			if (date.Month >= 9 || date.Month <= 2)
				return Semester.Winter;
			else
				return Semester.Summer;
		}

		public static int GetStudyYear(DateTime date)
		{
			if (date.Month < 9)
				return date.Year - 1;
			else
				return date.Year;
		}

		public static UnizaFaculty GetSubjectFaculty(string subjectNumber)
			=> (UnizaFaculty) (subjectNumber[0] - '0');

		public static UnizaStudyForm GetSubjectForm(string subjectNumber)
			=> subjectNumber[1] == 'B' ? UnizaStudyForm.BachalorStudy : UnizaStudyForm.MasterStudy;

		public static int GetSubjectYear(string subjectNumber)
			=> subjectNumber[3] - '0';
	}
}
