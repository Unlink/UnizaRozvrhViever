using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KST.UnizaSchedule.Api;

namespace KST.UnizaSchedule.Table
{
	public class ScheduleCell : IReadOnlyList<ScheduleItem>
	{
		private static readonly ScheduleItem[] EmptyItems = new ScheduleItem[0];

		private readonly ScheduleItem[] aItems;

		public ScheduleCell(DayOfWeek day, int hour)
		{
			this.Day = day;
			this.Hour = hour;
			this.aItems = EmptyItems;
		}

		public ScheduleCell(DayOfWeek day, int hour, List<ScheduleContent> scheduleContents)
			: this(day, hour)
		{
			this.aItems = scheduleContents.Select(x => new ScheduleItem(x)).ToArray();
		}

		public DayOfWeek Day { get; }
		public int Hour { get; }
		public IEnumerator<ScheduleItem> GetEnumerator()
			=> this.aItems.Cast<ScheduleItem>().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> this.aItems.GetEnumerator();

		public int Count
			=> this.aItems.Length;

		public ScheduleItem this[int index]
			=> this.aItems[index];

		public override string ToString()
		{
			return $"{this.Day}, at {this.Hour}:00 ({nameof(this.Count)} = {this.Count})";
		}
	}
}
