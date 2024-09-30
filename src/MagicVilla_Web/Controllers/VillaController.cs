using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos.VillaDtos;
using MagicVilla_Web.Models.ViewModels;
using MagicVilla_Web.Services.VillaNumberService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;

        private readonly IMapper _mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> IndexVilla()
        {
            var villaViewModelList = new List<VillaViewModel>();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaViewModelList = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result));
            }

            return View(villaViewModelList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<APIResponse>(dto);

                if (response != null && response.IsSuccess)
                    return RedirectToAction(nameof(IndexVilla));
            }
            return View(dto);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);

            var model = JsonConvert.DeserializeObject<VillaViewModel>(response.Result.ToString());

            return View(_mapper.Map<VillaUpdateDto>(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(dto);

                if (response != null && response.IsSuccess)
                    return RedirectToAction(nameof(IndexVilla));
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);

            var model = JsonConvert.DeserializeObject<VillaViewModel>(response.Result.ToString());

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaViewModel viewModel)
        {
            var response = await _villaService.DeleteAsync<APIResponse>(viewModel.Id);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(IndexVilla));

            return View();
        }
    }
}
