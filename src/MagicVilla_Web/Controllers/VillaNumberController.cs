using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.ViewModels;
using MagicVilla_Web.Services.VillaNumberService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;

        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService,
            IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _villaService = villaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> IndexVillaNumber()
        {
            var villaNumberViewModel = new List<VillaNumberViewModel>();

            var response = await _villaNumberService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaNumberViewModel = JsonConvert
                    .DeserializeObject<List<VillaNumberViewModel>>(Convert.ToString(response.Result));
            }

            return View(villaNumberViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVillaNumber()
        {
            var villaNumberCreateViewModel = new VillaNumberCreateViewModel();

            var villas = await _villaService
                .GetAllAsync<APIResponse>();

            if (villas != null && villas.IsSuccess)
            {
                villaNumberCreateViewModel.VillaList = JsonConvert
                    .DeserializeObject<List<VillaViewModel>>
                    (Convert.ToString(villas.Result))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
            }

            return View(villaNumberCreateViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateViewModel dto)
        {
            var response = await _villaNumberService.CreateAsync<APIResponse>(dto.VillaNumber);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(IndexVillaNumber));

            else if(response.ErrorMessage.Any())
                ModelState.AddModelError("Error message", response.ErrorMessage.FirstOrDefault());

            var villas = await _villaService
                    .GetAllAsync<APIResponse>();

            if (villas != null && villas.IsSuccess)
            {
                dto.VillaList = JsonConvert
                    .DeserializeObject<List<VillaViewModel>>
                    (Convert.ToString(villas.Result))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
            }

            return View(dto);
        }


        //[HttpGet]
        //public async Task<IActionResult> UpdateVilla(int villaId)
        //{
        //    var response = await _villaService.GetAsync<APIResponse>(villaId);

        //    var model = JsonConvert.DeserializeObject<VillaViewModel>(response.Result.ToString());

        //    return View(_mapper.Map<VillaUpdateDto>(model));
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UpdateVilla(VillaUpdateDto dto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _villaService.UpdateAsync<APIResponse>(dto);

        //        if (response != null && response.IsSuccess)
        //            return RedirectToAction(nameof(IndexVilla));
        //    }
        //    return View(dto);
        //}

        //[HttpGet]
        //public async Task<IActionResult> DeleteVilla(int villaId)
        //{
        //    var response = await _villaService.GetAsync<APIResponse>(villaId);

        //    var model = JsonConvert.DeserializeObject<VillaViewModel>(response.Result.ToString());

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteVilla(VillaViewModel viewModel)
        //{
        //    var response = await _villaService.DeleteAsync<APIResponse>(viewModel.Id);

        //    if (response != null && response.IsSuccess)
        //        return RedirectToAction(nameof(IndexVilla));

        //    return View();
        //}
    }
}
