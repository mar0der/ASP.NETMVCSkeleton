namespace Exam.Models.Models
{
    #region

    using System;
    using System.ComponentModel.DataAnnotations;

    #endregion

    public class Event
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

    }
}