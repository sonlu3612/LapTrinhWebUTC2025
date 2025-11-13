// File: Components/LeftMenuViewComponent.cs
using DayLabTh2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DayLabTh2.Components
{
    public class LeftMenuViewComponent : ViewComponent
    {
        private readonly List<MenuItem> _menuItems;

        public LeftMenuViewComponent()
        {
            _menuItems = new List<MenuItem>
            {
                new() { Id = 1, Name = "Dashboard",      Link = "/",                     Icon = "fas fa-fw fa-tachometer-alt" },
                new() { Id = 2, Name = "Branches",       Link = "/Branches",             Icon = "fas fa-fw fa-code-branch" },
                new() { Id = 3, Name = "Students",       Link = "/Students",             Icon = "fas fa-fw fa-users" },
                new() { Id = 4, Name = "Courses",        Link = "/Courses",              Icon = "fas fa-fw fa-book" },
                new() { Id = 5, Name = "Classes",        Link = "/Classes",              Icon = "fas fa-fw fa-chalkboard-teacher" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View(_menuItems));
        }
    }
}