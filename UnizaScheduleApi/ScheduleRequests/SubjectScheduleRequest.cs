using System;
using KST.UnizaSchedule.Api.Enums;

namespace KST.UnizaSchedule.Api.ScheduleRequests
{
	public class SubjectScheduleRequest : ScheduleRequest
	{
		public SubjectScheduleRequest(UnizaFaculty faculty, UnizaStudyForm studyForm, int yearOfStudy, string subjectNumber)
		{
			this.Faculty = faculty;
			this.StudyForm = studyForm;
			this.YearOfStudy = yearOfStudy;
			this.SubjectNumber = subjectNumber;
		}

		public SubjectScheduleRequest(UnizaFaculty faculty, UnizaStudyForm studyForm, int yearOfStudy, string subjectNumber, DateTime date)
			: base(date)
		{
			this.Faculty = faculty;
			this.StudyForm = studyForm;
			this.YearOfStudy = yearOfStudy;
			this.SubjectNumber = subjectNumber;
		}

		public SubjectScheduleRequest(string subjectNumber, int scheduleYear, Semester scheduleSemester)
			: base(scheduleYear, scheduleSemester)
		{
			this.Faculty = ScheduleApiHelpers.GetSubjectFaculty(subjectNumber);
			this.StudyForm = ScheduleApiHelpers.GetSubjectForm(subjectNumber);
			this.YearOfStudy = ScheduleApiHelpers.GetSubjectYear(subjectNumber);
			this.SubjectNumber = subjectNumber;
		}

		public SubjectScheduleRequest(string subjectNumber)
		{
			this.Faculty = ScheduleApiHelpers.GetSubjectFaculty(subjectNumber);
			this.StudyForm = ScheduleApiHelpers.GetSubjectForm(subjectNumber);
			this.YearOfStudy = ScheduleApiHelpers.GetSubjectYear(subjectNumber);
			this.SubjectNumber = subjectNumber;
		}

		public SubjectScheduleRequest(string subjectNumber, DateTime date)
			: base(date)
		{
			this.Faculty = ScheduleApiHelpers.GetSubjectFaculty(subjectNumber);
			this.StudyForm = ScheduleApiHelpers.GetSubjectForm(subjectNumber);
			this.YearOfStudy = ScheduleApiHelpers.GetSubjectYear(subjectNumber);
			this.SubjectNumber = subjectNumber;
		}

		public SubjectScheduleRequest(UnizaFaculty faculty, UnizaStudyForm studyForm, int yearOfStudy, string subjectNumber, int scheduleYear, Semester scheduleSemester)
			: base(scheduleYear, scheduleSemester)
		{
			this.Faculty = faculty;
			this.StudyForm = studyForm;
			this.YearOfStudy = yearOfStudy;
			this.SubjectNumber = subjectNumber;
		}

		public UnizaFaculty Faculty { get; }
		public UnizaStudyForm StudyForm { get; }
		public int YearOfStudy { get; }
		public string SubjectNumber { get; }
	}
}
