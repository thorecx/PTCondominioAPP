using PruebaTecnica.Helper;
using PruebaTecnica.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class CuotasController : Controller
    {
        private readonly IConnectionWebApi _connectionWebApi;

        public CuotasController()
        {
            _connectionWebApi = new ConnectionToWebService();
        }
        // GET: Cuotas
        public async Task<ActionResult> Index()
        {
            var data = await _connectionWebApi.HttpGetAll<Cuota>("Cuotas/GetAllFees", "get").ConfigureAwait(false);
            return View(data);
        }

        // GET: Cuotas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Cuota>("Cuotas/GetFeeById/" + id, "get").ConfigureAwait(false);
            return View();
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: Clientes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Cuota cuota)
        {
            cuota.IdEstado = 1;
            await _connectionWebApi.HttpPost<Cuota>("Cuotas/AddFee", cuota, "Post").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Cuota>("Cuotas/GetFeeById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Cuota cuota)
        {
            cuota.IdEstado = 1;
            await _connectionWebApi.HttpPost<Cuota>("Cuotas/UpdateFee/" + id, cuota , "Put").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var result = await _connectionWebApi.HttpGetBy<Cuota>("Cuotas/GetFeeById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Cuota cuota, int id = 0)
        {
            await _connectionWebApi.HttpPost<Cuota>("Cuotas/RemoveFee/" + id, new object(), "Delete").ConfigureAwait(false);
            return RedirectToAction("Index");

        }
    }
}
