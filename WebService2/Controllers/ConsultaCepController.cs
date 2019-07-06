using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebService2.Models;

namespace WebService.Controllers
{
    public class ConsultaCepController : Controller
    {
        private readonly Context _context;
        public ConsultaCepController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsultaCep.ToListAsync());
        }

        public IActionResult ConsultaCep()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultaCep(string cep)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/" + cep + "/json/");
            ConsultaCep cidade = JsonConvert.DeserializeObject<ConsultaCep>(json);

            _context.Add(cidade);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}