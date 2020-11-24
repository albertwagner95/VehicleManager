using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels.AddressVm;
using VehicleManager.Domain.Model;

namespace VehicleManager.Web.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _addresService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddressController(IAddressService addressService, UserManager<ApplicationUser> userManager)
        {
            _addresService = addressService;
            _userManager = userManager;
        }
        //[Route("Identity/Account/Manage/Address")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            var model = new NewAddressVm();
            model.AddressTypes = _addresService.GetAddressTypes();
            model.VoivodeshipsVm = _addresService.GetAllVoivedoships();
            model.ApplicationUserID = _userManager.GetUserId(User);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress(NewAddressVm model)
        {

            if (!ModelState.IsValid)
            {
                model.AddressTypes = _addresService.GetAddressTypes();
                model.VoivodeshipsVm = _addresService.GetAllVoivedoships();
                model.AddressTypes = _addresService.GetAddressTypes();
                model.ApplicationUserID = _userManager.GetUserId(User);
                return View(model);
            }
            model.AddressTypes = _addresService.GetAddressTypes();
            model.VoivodeshipsVm = _addresService.GetAllVoivedoships();
            model.AddressTypes = _addresService.GetAddressTypes();
            model.ApplicationUserID = _userManager.GetUserId(User);
            _addresService.AddNewAddress(model);
            return RedirectToAction("Index", "Address");
        }

        [AllowAnonymous]
        [HttpGet("api/Voivedoship/{voivedoshipId}")]
        public IEnumerable<DistrictVm> GetDistricts(string voivedoshipId)
        {

            var districts = _addresService.GetDistrictsByVoivedoship(voivedoshipId);
            return districts.AsEnumerable();
        }

        [AllowAnonymous]
        [HttpGet("api/community/{districtId}")]
        public IEnumerable<CommunityVm> GetCommunities(string districtId)
        {
            var communities = _addresService.GetCommunitiesByDistricId(districtId);
            return communities.AsEnumerable();
        }

        [AllowAnonymous]
        [HttpGet("api/city/{communityId}")]
        public IEnumerable<CityVm> GetCities(string communityId)
        {
            var cities = _addresService.GetCitiesByCommunityId(communityId);
            return cities.AsEnumerable();
        }

        [AllowAnonymous]
        [HttpGet("api/citytype/{cityId}")]
        public CityTypeVm GetCityType(string cityId)
        {
            var cityType = _addresService.GetCityType(cityId);
            return cityType;
        }
    }
}
