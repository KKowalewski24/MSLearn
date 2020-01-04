using System;

namespace ScheduleWebApi.Models
{
    public class ScheduleItem
    {
        /*----------------------- PROPERTIES REGION ----------------------*/
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        /*------------------------ METHODS REGION ------------------------*/
        public ScheduleItem()
        {
        }

        public ScheduleItem(long id, string name, bool isComplete)
        {
            Id = id;
            Name = name;
            IsComplete = isComplete;
        }

        protected bool Equals(ScheduleItem other)
        {
            return Id == other.Id && Name == other.Name && IsComplete == other.IsComplete;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ScheduleItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, IsComplete);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}," +
                   $" {nameof(IsComplete)}: {IsComplete}";
        }
    }
}