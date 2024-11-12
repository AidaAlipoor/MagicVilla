using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos.VillaDtos;
using MagicVilla_Web.Models.Dtos.VillaNumberDtos;
using MagicVilla_Web.Models.ViewModels.villaNumberViewModels;
using MagicVilla_Web.Models.ViewModels.VillaViewModels;
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


        [HttpGet]
        public async Task<IActionResult> UpdateVillaNumber(int id)
        {
            var villaNumberUpdateViewModel = new VillaNumberUpdateViewModel();

            var response = await _villaNumberService.GetAsync<APIResponse>(id);

            if(response != null && response.IsSuccess) 
            {
                var model = JsonConvert.DeserializeObject<VillaNumberViewModel>(response.Result.ToString());

                villaNumberUpdateViewModel.VillaNumber = _mapper.Map<VillaNumDto>(model);
            }

            var villas = await _villaService
                   .GetAllAsync<APIResponse>();

            if (villas != null && villas.IsSuccess)
            {
                villaNumberUpdateViewModel.VillaList = JsonConvert
                    .DeserializeObject<List<VillaViewModel>>
                    (Convert.ToString(villas.Result))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
                return View(villaNumberUpdateViewModel);
            }

           return NotFound();   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateViewModel dto)
        {
            var response = await _villaNumberService.UpdateAsync<APIResponse>(dto.VillaNumber);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(IndexVillaNumber));

            else if (response.ErrorMessage.Any())
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

        [HttpGet]
        public async Task<IActionResult> DeleteVillaNumber(int id)
        {
            var villaNumberDeleteViewModel = new VillaNumberDeleteViewModel();

            var response = await _villaNumberService.GetAsync<APIResponse>(id);

            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaNumberViewModel>(response.Result.ToString());

                villaNumberDeleteViewModel.VillaNumber = _mapper.Map<VillaNumDto>(model);
            }

            var villas = await _villaService
                   .GetAllAsync<APIResponse>();

            if (villas != null && villas.IsSuccess)
            {
                villaNumberDeleteViewModel.VillaList = JsonConvert
                    .DeserializeObject<List<VillaViewModel>>
                    (Convert.ToString(villas.Result))
                    .Select(v => new SelectListItem
                    {
                        Text = v.Name,
                        Value = v.Id.ToString()
                    });
                return View(villaNumberDeleteViewModel);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteViewModel viewModel)
        {
            var response = await _villaNumberService.DeleteAsync<APIResponse>(viewModel.VillaNumber.Id);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(IndexVillaNumber));

            else if (response.ErrorMessage.Any())
                ModelState.AddModelError("Error message", response.ErrorMessage.FirstOrDefault());

            return View();
        }
    }
}
