using PruebaTecnica.Helper;
using PruebaTecnica.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class PagosController : Controller
    {
        private readonly IConnectionWebApi _connectionWebApi;

        public PagosController()
        {
            _connectionWebApi = new ConnectionToWebService();
        }
        // GET: Pagos
        public async Task<ActionResult> Index()
        {
            var data = await _connectionWebApi.HttpGetAll<Pago>("Pagoes/GetAllPayments", "get").ConfigureAwait(false);

            return View(data);
        }

        // GET: Pagoes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Pago>("Pagoes/GetPaymentById/" + id, "get").ConfigureAwait(false);
            return View();
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: Clientes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Pago pago)
        {
            pago.IdEstado = 1;
            await _connectionWebApi.HttpPost<Pago>("Pagoes/AddPayment", pago, "Post").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Pago>("Pagoes/GetPaymentById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Pago pago)
        {
            pago.IdEstado = 1;
            await _connectionWebApi.HttpPost<Pago>("Pagoes/UpdatePayment/" + id, pago, "Put").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var result = await _connectionWebApi.HttpGetBy<Pago>("Pagoes/GetPaymentById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Pago pago, int id = 0)
        {
            await _connectionWebApi.HttpPost<Pago>("Pagoes/RemovePayment/" + id, new object(), "Delete").ConfigureAwait(false);
            return RedirectToAction("Index");

        }
    }
}
