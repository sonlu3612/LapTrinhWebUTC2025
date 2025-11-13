// File: Models/MenuItem.cs
namespace DayLabTh2.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Link { get; set; } = "#";
        public string Icon { get; set; } = "fas fa-fw fa-tachometer-alt";
    }
}