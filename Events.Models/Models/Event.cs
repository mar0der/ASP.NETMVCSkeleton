namespace Events.Models.Models
{
    #region

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class Event
    {
        [Key]
        public int Id { get; set; }
    }
}