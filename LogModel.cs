using System.ComponentModel.DataAnnotations;

namespace LogsUI
{
    public class LogModel
    {
        [Required]
        public int Id { get; set; }

        public DateTime? Time { get; set; }

        [Required]
        public bool IsChecked { get; set; }
    }
}
