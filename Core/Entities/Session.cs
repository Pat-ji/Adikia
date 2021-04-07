using System;

namespace Core.Entities
{
    public class Session : BaseEntity
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public virtual User User { get; set; }
    }
}
