using System.Web.Mvc;

namespace DarzinTest.Controllers
{
	public class ProductsViewController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}