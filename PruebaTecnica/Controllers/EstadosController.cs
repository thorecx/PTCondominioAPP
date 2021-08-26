using Newtonsoft.Json;
using PruebaTecnica.Helper;
using PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class EstadosController : Controller
    {
        private readonly IConnectionWebApi _connectionWebApi;

        public EstadosController()
        {
            _connectionWebApi = new ConnectionToWebService();
        }
        // GET: Estados
        public async Task<ActionResult> Index()
        {
            var data = await _connectionWebApi.HttpGetAll<Estado>("Estadoes/GetAllStatus", "get").ConfigureAwait(false);

            return View(data);
        }

        // GET: Estadoes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Estado>("Estadoes/GetStatusById/" + id, "get").ConfigureAwait(false);
            return View();
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: Clientes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Estado estado)
        {
            estado.IdEstado = 1;
            await _connectionWebApi.HttpPost<Estado>("Estadoes/AddStatus", estado, "Post").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Estado>("Estadoes/GetStatusById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Estado estado)
        {
            estado.IdEstado = 1;
            await _connectionWebApi.HttpPost<Estado>("Estadoes/UpdateStatus/" + id, estado, "Put").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var result = await _connectionWebApi.HttpGetBy<Estado>("Estadoes/GetStatusById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Estado estado, int id = 0)
        {
            await _connectionWebApi.HttpPost<Estado>("Estadoes/RemoveStatus/" + id, new object(), "Delete").ConfigureAwait(false);
            return RedirectToAction("Index");

        }
    }
}
