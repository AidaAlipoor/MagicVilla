using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.ViewModels;
using MagicVilla_Web.Services.VillaNumberService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;

        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
        {
            _villaNumberService = villaNumberService;
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
    }
}
