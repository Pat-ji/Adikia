using System;

namespace API.Dtos.Entities
{
    public class SessionDto : BaseEntityDto
    {
        public int GameId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int GameStage { get; set; }

        public virtual GameDto Game { get; set; }
    }
}
