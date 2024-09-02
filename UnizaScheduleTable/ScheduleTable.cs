using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KST.UnizaSchedule.Api;

namespace KST.UnizaSchedule.Table
{
	public class ScheduleTable : IEnumerable<ScheduleCell>
	{
		public const int DayCount = 5;
		public const int BlockCount = 13;
		public const int FirstBlockHour = 7;
		public const int LastBlockHour = FirstBlockHour + BlockCount - 1;

		private readonly ScheduleCell[,] aItems;

		public ScheduleTable(IEnumerable<ScheduleContent> schedule)
		{
			var items = new List<ScheduleContent>[DayCount, BlockCount];

			foreach (var content in schedule)
			{
				var x = content.BlockNumber - 1;
				var y = (int) content.Day - 1;

				items[y, x] ??= new List<ScheduleContent>();
				items[y, x].Add(content);
			}

			this.aItems = new ScheduleCell[DayCount, BlockCount];

			for (var y = 0; y < DayCount; y++)
			{
				for (var x = 0; x < BlockCount; x++)
				{
					if (items[y, x] == null)
						this.aItems[y, x] = new ScheduleCell((DayOfWeek) (y + 1), x + FirstBlockHour);
					else
						this.aItems[y, x] = new ScheduleCell((DayOfWeek) (y + 1), x + FirstBlockHour, items[y, x]);
				}
			}
		}

		public ScheduleCell this[DayOfWeek day, int hour]
			=> this.aItems[(int) (day - 1), hour - FirstBlockHour];

		public IEnumerator<ScheduleCell> GetEnumerator()
		{

			for (var y = 0; y < DayCount; y++)
				for (var x = 0; x < BlockCount; x++)
					if (this.aItems[y, x].Any())
						yield return this.aItems[y, x];
		}

		IEnumerator IEnumerable.GetEnumerator()
			=> this.GetEnumerator();

    }
}
