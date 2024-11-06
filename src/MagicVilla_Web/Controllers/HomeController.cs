using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.ViewModels.VillaViewModels;
using MagicVilla_Web.Services.VillaNumberService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;

        private readonly IMapper _mapper;

        public HomeController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var villaViewModelList = new List<VillaViewModel>();

            var response = await _villaService.GetAllAsync<APIResponse>();

            if (response != null && response.IsSuccess)
            {
                villaViewModelList = JsonConvert.DeserializeObject<List<VillaViewModel>>(Convert.ToString(response.Result));
            }

            return View(villaViewModelList);
        }
    }
}