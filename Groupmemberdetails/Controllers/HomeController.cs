using Groupmemberdetails.Models;
using Microsoft.AspNetCore.Mvc;

namespace Groupmemberdetails.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var member = DetailsRepository.GetDetails();
            return View(member);
        }

        public IActionResult Edit(int? index)
        {
            var member = DetailsRepository.GetDetailsByIndex(index.HasValue? index.Value:0);
            return View(member);
        }


        [HttpPost]
        public IActionResult Edit(Details details)
        {
            DetailsRepository.UpdateDetails(details.IndexNo, details);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? index)
        {
            DetailsRepository.DeleteMemberByIndex(index.HasValue? index.Value:0);
            return RedirectToAction(nameof(index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Details details)
        {
            DetailsRepository.AddMember(details);
            return RedirectToAction(nameof(Index));
        }
    }
}
