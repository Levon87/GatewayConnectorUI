using System.ComponentModel.DataAnnotations;

namespace LogsUI.Models
{
    public class Logmodel
    {
        public class LogModel
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public DateTime Time { get; set; }

            [Required]
            public bool IsChecked { get; set; }
        }
    }
}
