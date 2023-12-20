using HrApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HrApp.MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PersonelController : Controller
    {
        AppUser user = new AppUser() { Id = "1", Name = "Name1", Surname = "Surname1", Email = "Email1", Address = "Address1", BirthPlace = "BirthPlace1", BirthYear = DateTime.Now, Department = "Department1", UserName = "name1.surname1", StartDate = DateTime.Now, };
        public PersonelController(IPersonelService personelService, IMapper mapper)
        {
            _personelService = personelService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var personelDtos=await _personelService.GetAll(true);
            var personelViewModel= _mapper.Map<List<PersonelViewModel>>(personelDtos.Context);
            ViewBag.Personel = personelViewModel;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonel(PersonelViewModel pvm)
        {
            var data= _mapper.Map<PersonelDto>(pvm);
            if (ModelState.IsValid)
            {
                var result= await _personelService.InsertAsync(data);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Personel/Index");

                }
                ViewBag.Error = result.Message;
            }
            return RedirectToAction("Personel/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonelViewModel pvm)
        {
            
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<PersonelDto>(pvm);
                var result = await _personelService.UpdateAsync(data);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Personel/Index");
                }

                ViewBag.Error = result.Message;
            }

            return RedirectToAction("Personel/Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data = await _personelService.GetAsync(true, x => x.Id == id);

            await _personelService.DeleteAsync(data.Context);
            return RedirectToAction("Personel/Index");
        }

        public async Task<IActionResult> GetPersonel(int id)
        {
            var data = await _personelService.GetAsync(true, x => x.Id == id);
            var pvm = _mapper.Map<PersonelViewModel>(data.Context);

            return PartialView("_PersonelPartialView", pvm);
        }
    }
}
