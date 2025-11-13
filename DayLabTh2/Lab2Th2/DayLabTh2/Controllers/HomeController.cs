using Microsoft.AspNetCore.Mvc;
using DayLabTh2.Models;  

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var students = new List<Student>
        {
            new Student { Id = 101, FullName = "Hồ Văn Nam", Dob = new DateTime(2001,1,1), Class = "CNTT", Gender = "Nam", Phone = "0123456789", Email = "namhv@gmail.com" },
            new Student { Id = 102, FullName = "Nguyễn Thị Minh Tú", Dob = new DateTime(2002,5,12), Class = "KT", Gender = "Nữ", Phone = "0987654321", Email = "tu.ntm@gmail.com" },
            new Student { Id = 103, FullName = "Trần Hoàng Hoàng", Dob = new DateTime(2001,8,20), Class = "CNTT", Gender = "Nam", Phone = "0912345678", Email = "hoangth@gmail.com" },
            new Student { Id = 104, FullName = "Phạm Xuân Mai", Dob = new DateTime(2003,3,15), Class = "Điện tử", Gender = "Nữ", Phone = "0909090909", Email = "mai.px@gmail.com" },
        };

        return View(students);
    }
}