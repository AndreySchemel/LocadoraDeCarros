using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LocadoraDeCarros.Models;
using LocadoraDeCarros.ViewModels;

namespace LocadoraDeCarros.Controllers
{
    public class ClienteController : Controller
    {
        private ApplicationDbContext _context;

        public ClienteController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var clientes = _context.Clientes.Include(c => c.Carro).ToList();
            if (User.IsInRole("CanManage"))
                return View(clientes);
            return View("ReadOnlyIndex", clientes);

        }

        public ActionResult Details(int id)
        {
            var cliente = _context.Clientes.Include(c => c.Carro).SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [Authorize(Roles = "CanManage")]
        public ActionResult New()
        {
            var carros = _context.Carros.ToList();
            var viewModel = new ClienteFormViewModel
            {
                Cliente = new Cliente(),
                Carros = carros
            };

            return View("ClienteForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManage")]
        public ActionResult Save(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClienteFormViewModel
                {
                    Cliente = cliente,
                    Carros = _context.Carros.ToList()
                };

                return View("ClienteForm", viewModel);
            }

            if (cliente.Id == 0)
            {
                // armazena o cliente em memória
                _context.Clientes.Add(cliente);
            }
            else
            {
                var clienteInDb = _context.Clientes.Single(c => c.Id == cliente.Id);

                clienteInDb.Nome = cliente.Nome;
                clienteInDb.CPF = cliente.CPF;
                clienteInDb.Email = cliente.Email;
                clienteInDb.RG = cliente.RG;
                clienteInDb.Telefone = cliente.Telefone;
                clienteInDb.CarroId = cliente.CarroId;
                clienteInDb.NumeroCNH = cliente.NumeroCNH;

            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "CanManage")]
        public ActionResult Edit(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            var viewModel = new ClienteFormViewModel
            {
                Cliente = cliente,
                Carros = _context.Carros.ToList()
            };

            return View("ClienteForm", viewModel);
        }

        [Authorize(Roles = "CanManage")]
        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
