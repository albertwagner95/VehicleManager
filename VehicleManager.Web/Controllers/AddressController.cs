using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels.AddressVm;
using static VehicleManager.Application.ViewModels.AddressVm.NewAddressVm;

namespace VehicleManager.Web.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addresService;
        public AddressController(IAddressService addressService)
        {
            _addresService = addressService;
        }
        public IActionResult Index()
        {
            var listVoivedoship = _addresService.GetAllVoivedoships();
            ViewBag.ListVoivodoship = new SelectList(listVoivedoship, "Voivodoship");
            return View();
        }

        [HttpGet]
        public IActionResult AddAddress()
        {
            // var userId = _userManager.GetUserId(User);
            //var listVoivedoship = _addresService.GetAllVoivedoships();
            //ViewBag.ListVoivodoship = listVoivedoship;

            var model = new NewAddressVm();

            model.VoivodeshipsVm = _addresService.GetAllVoivedoships();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAddress(NewAddressVm model)
        {

            model.VoivodeshipsVm = _addresService.GetAllVoivedoships();

            if (ModelState.IsValid)
            {
                //var listVoivedoship = _addresService.GetAllVoivedoships();
                //ViewBag.ListVoivodoship = listVoivedoship;

                return View(model);
            }
            return View(model);

        }

        [AllowAnonymous]
        [HttpGet("api/Voivedoship/{voivedoshipId}")]
        public IEnumerable<DistrictVm> GetDistricts(string voivedoshipId)
        {
            var a = _addresService.GetDistrictsByVoivedoship(voivedoshipId);
            return a.AsEnumerable();
        }

        [AllowAnonymous]
        [HttpGet("api/community/{districtId}")]
        public IEnumerable<CommunityVm> GetCommunities(string districtId)
        {
            var result = _addresService.GetCommunitiesByDistricId(districtId);
            return result.AsEnumerable();
        }
        [AllowAnonymous]
        [HttpGet("api/city/{communityId}")]
        public IEnumerable<CityVm> GetCities(string communityId)
        {
            var result = _addresService.GetCitiesByCommunityId(communityId);
            return result.AsEnumerable();
        }
        [AllowAnonymous]
        [HttpGet("api/citytype/{cityId}")]
        public CityTypeVm GetCityType(string cityId)
        {
            var result = _addresService.GetCityType(cityId);
            return result;
        }
    }
}
