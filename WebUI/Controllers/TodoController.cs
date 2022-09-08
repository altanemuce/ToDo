using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class TodoController : Controller
    {
        ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _todoService.GetAll();
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult GetAll(Todo todo)
        {
            var result = _todoService.Update(todo);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult AddTodo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTodo(Todo todo)
        {
            var result = _todoService.Add(todo);
            return RedirectToAction("GetAll");

        }

        public IActionResult Delete(int id)
        {
            var result = _todoService.GetById(id);
            _todoService.Delete(result.Data);
            return RedirectToAction("GetAll");
        }
    }
}
