using System.Threading.Tasks;
using System.Web.Mvc;
using Task_Repository_Assignment.Models;
using Task_Repository_Assignment.Repository;

namespace Task_Repository_Assignment.Controllers
{
    public class ContactsController : Controller
    {
        private IContactRepository repository = new ContactRepository();

        // GET: Contacts
        public async Task<ActionResult> Index()
        {
            var contacts = await repository.GetAllAsync();
            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        public async Task<ActionResult> Delete(long id)
        {
            await repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

       
    }
}
