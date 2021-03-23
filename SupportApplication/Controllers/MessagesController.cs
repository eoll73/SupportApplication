using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportApplication.Models;
using SupportApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApplication.Controllers
{
    public class MessagesController : Controller
    {
        private readonly MessagesRepository messagesRepository;

        public MessagesController(MessagesRepository messagesRepository)
        {
            this.messagesRepository = messagesRepository;
        }

        // GET: MessagesController
        public ActionResult Index()
        {
            var model = messagesRepository.GetAllMessages();

            return View(model);
        }

        // GET: MessagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MessagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Messages message)
        {
            try
            {
                messagesRepository.Add(message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessagesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = messagesRepository.Get(id);

            return View(model);
        }

        // POST: MessagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Messages messages)
        {
            try
            {
                messagesRepository.Update(messages);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessagesController/Delete/5
        public ActionResult Delete(int id)
        {
            messagesRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: MessagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
