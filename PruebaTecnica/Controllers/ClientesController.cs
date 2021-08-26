using Newtonsoft.Json;
using PruebaTecnica.Helper;
using PruebaTecnica.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IConnectionWebApi _connectionWebApi;

        public ClientesController()
        {
            _connectionWebApi = new ConnectionToWebService();
        }

        // GET: Clientes
        public async Task<ActionResult> Index()
        {
            var data = await _connectionWebApi.HttpGetAll<Cliente>("Clientes/GetCustomers", "get").ConfigureAwait(false);
            return View(data);
        }

        // GET: Clientes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Cliente>("Clientes/GetCustomerById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: Clientes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            cliente.IdEstado = 1;
            await _connectionWebApi.HttpPost<Cliente>("Clientes/AddCustomer", cliente, "Post").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Cliente>("Clientes/GetCustomerById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Cliente cliente)
        {
            cliente.IdEstado = 1;
            await _connectionWebApi.HttpPost<Cliente>("Clientes/UpdateCustomer/" + id, cliente, "Put").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var result = await _connectionWebApi.HttpGetBy<Cliente>("Clientes/GetCustomerById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Cliente cliente, int id = 0)
        {
            await _connectionWebApi.HttpPost<Cliente>("Clientes/RemoveCustomer/" + id, new object(), "Delete").ConfigureAwait(false);
            return RedirectToAction("Index");

        }
    }
}
