using LocadoraDeCarros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeCarros.Controllers
{
    public class CarroController : Controller
    {

        private ApplicationDbContext _context;

        public CarroController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Carro
        public ActionResult Index()
        {

            var carros = _context.Carros.ToList();
            return View(carros);
        }

        public ActionResult Details(int id)
        {
            var carro = _context.Carros.SingleOrDefault(c => c.Id == id);
            if (carro == null)
            {
                return HttpNotFound();
            }

            return View(carro);
        }

        [Authorize(Roles = "CanManage")]
        public ActionResult New()
        {
            var carro = new Carro();

            return View("CarroForm", carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManage")]
        public ActionResult Save(Carro carro)
        {

            if (!ModelState.IsValid)
            {
                return View("CarroForm", carro);
            }

            if (carro.Id == 0)
            {
                // armazena o carro em memória
                _context.Carros.Add(carro);
            }
            else
            {
                var carroInDb = _context.Carros.Single(c => c.Id == carro.Id);

                carroInDb.Cor = carro.Cor;
                carroInDb.Marca = carro.Marca;
                carroInDb.Modelo = carro.Modelo;
                carroInDb.Placa = carro.Placa;
                carroInDb.ValorLocacao = carro.ValorLocacao;


            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanManage")]
        public ActionResult Edit(int id)
        {
            var carro = _context.Carros.SingleOrDefault(c => c.Id == id);

            if (carro == null)
                return HttpNotFound();


            return View("CarroForm", carro);
        }

        [Authorize(Roles = "CanManage")]
        public ActionResult Delete(int id)
        {
            var carro = _context.Carros.SingleOrDefault(c => c.Id == id);

            if (carro == null)
                return HttpNotFound();

            _context.Carros.Remove(carro);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }

    }
}
