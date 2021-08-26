using PruebaTecnica.Helper;
using PruebaTecnica.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaTecnica.Controllers
{
    public class ResidencialesController : Controller
    {
        private readonly IConnectionWebApi _connectionWebApi;

        public ResidencialesController()
        {
            _connectionWebApi = new ConnectionToWebService();
        }
        // GET: Residenciales
        public async Task<ActionResult> Index()
        {
            var data = await _connectionWebApi.HttpGetAll<Residenciale>("Residenciales/GetAllResidentials", "get").ConfigureAwait(false);
            return View(data);
        }

        // GET: Residenciales/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Residenciale>("Residenciales/GetResidentialById/" + id, "get").ConfigureAwait(false);
            return View();
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Create()
        {
            return View();
        }
        // POST: Clientes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Residenciale residencial)
        {
            residencial.IdEstado = 1;
            await _connectionWebApi.HttpPost<Residenciale>("Residenciales/AddResidential", residencial, "Post").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _connectionWebApi.HttpGetBy<Residenciale>("Residenciales/GetResidentialById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Residenciale residenciale)
        {
            residenciale.IdEstado = 1;
            await _connectionWebApi.HttpPost<Residenciale>("Residenciales/UpdateResidential/" + id, residenciale, "Put").ConfigureAwait(false);
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var result = await _connectionWebApi.HttpGetBy<Residenciale>("Residenciales/GetResidentialById/" + id, "get").ConfigureAwait(false);
            return View(result);
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Residenciale residenciale, int id = 0)
        {
            await _connectionWebApi.HttpPost<Residenciale>("Residenciales/RemoveResidential/" + id, new object(), "Delete").ConfigureAwait(false);
            return RedirectToAction("Index");

        }
    }
}
