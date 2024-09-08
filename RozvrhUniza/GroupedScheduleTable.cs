using System.Collections;
using KST.UnizaSchedule.Api;
using KST.UnizaSchedule.Api.Enums;
using KST.UnizaSchedule.Table;

namespace RozvrhUniza
{
    public class GroupedScheduleTable : IEnumerable<GroupedScheduleCell>
    {
        private readonly GroupedScheduleCell[,] _items;

        public GroupedScheduleTable(ScheduleTable schedule)
        {
            _items = new GroupedScheduleCell[ScheduleTable.DayCount, ScheduleTable.BlockCount];
            for (var i = 0; i < ScheduleTable.DayCount; i++)
            {
                var dayMax = 1;
                if (schedule.Any(x => x.Day == (DayOfWeek)(i + 1)))
                {
                    dayMax = schedule.Where(x => x.Day == (DayOfWeek)(i + 1)).Max(x => x.Count);
                }

                for (var j = 0; j < ScheduleTable.BlockCount; j++)
                {
                    _items[i, j] = new GroupedScheduleCell(
                        (DayOfWeek)(i + 1), 
                        j + ScheduleTable.FirstBlockHour,
                        dayMax);
                }
            }

            for (var y = 0; y < ScheduleTable.DayCount; y++)
            {
                var yy = (DayOfWeek)(y + 1);
                for (var x = 0; x < ScheduleTable.BlockCount; x++)
                {
                    var xx = x + ScheduleTable.FirstBlockHour;

                    foreach (var item in schedule[yy, xx])
                    {
                        if (x > 0 && schedule[yy, xx - 1].Any(i => i.Equals(item)))
                        {
                            continue;
                        }

                        var blockDuration = 1;
                        var blockIndex = _items[y, x].FindEmptyPosition();
                        for (var j = x+1; j < ScheduleTable.BlockCount; j++)
                        {
                            if (!schedule[yy, j + ScheduleTable.FirstBlockHour].Any(i => i.Equals(item))) break;

                            //Empty block
                            _items[y, j].Assign(blockIndex, new GroupedScheduleItem(item, 0));
                            blockDuration++;
                        }

                        _items[y, x].Assign(blockIndex, new GroupedScheduleItem(item, blockDuration));
                    }
                }
            }
        }

        public GroupedScheduleCell this[DayOfWeek day, int hour]
            => this._items[(int)(day - 1), hour - ScheduleTable.FirstBlockHour];

        public IEnumerator<GroupedScheduleCell> GetEnumerator()
        {

            for (var y = 0; y < ScheduleTable.DayCount; y++)
            for (var x = 0; x < ScheduleTable.BlockCount; x++)
                if (this._items[y, x].Any())
                    yield return this._items[y, x];
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

    }

    public class GroupedScheduleCell : IReadOnlyList<GroupedScheduleItem?>
    {
        private readonly GroupedScheduleItem?[] _items;

        public GroupedScheduleCell(DayOfWeek day, int hour, int itemsCount)
        {
            this.Day = day;
            this.Hour = hour;
            this._items = new GroupedScheduleItem[itemsCount];
        }

        public DayOfWeek Day { get; }
        public int Hour { get; }

        public IEnumerator<GroupedScheduleItem> GetEnumerator()
            => this._items.Cast<GroupedScheduleItem>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this._items.GetEnumerator();

        public int Count
            => this._items.Length;

        public GroupedScheduleItem? this[int index]
            => this._items[index];

        public override string ToString()
        {
            return $"{this.Day}, at {this.Hour}:00 ({nameof(this.Count)} = {this.Count})";
        }

        public int FindEmptyPosition()
        {
            return _items.Select((i, index) => (i, index)).SkipWhile(x => x.i != null).Select(x => x.index).First();
        }

        public void Assign(int index, GroupedScheduleItem item)
        {
            if (_items[index] is not null) throw new ArgumentException("Index already occupied");
            _items[index] = item;
        }
    }

    public record GroupedScheduleItem(LessonType LessonType, string TeacherName, string RoomName, string Group, string Subject,
        int Duration)
    {
        public GroupedScheduleItem(ScheduleItem item, int blockDuration) : this(item.LessonType, item.TeacherName, item.RoomName, item.Group, item.Subject, blockDuration)
        {
        }
    }

    public static class GroupedScheduleTableExt
    {
        public static GroupedScheduleTable GroupSameBlocks(this ScheduleTable table)
        {
            return new GroupedScheduleTable(table);
        }
    }
}