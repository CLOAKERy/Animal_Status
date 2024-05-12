using AutoMapper;
using Animal_Status;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Status.Controllers
{
    public class ChartController : Controller
    {
        private readonly IMapper mapper;

        IWeightAndHeightService weightAndHeightService;

        public ChartController(IMapper mapper, IWeightAndHeightService weightAndHeightService)
        {
            this.mapper = mapper;
            this.weightAndHeightService = weightAndHeightService;
        }

        public async Task<ActionResult> CreateChart(int petId)
        {
            IEnumerable<WeightAndHeightDTO> WeightAndHeightDtos = await weightAndHeightService.GetAllSortedAsync(petId);
            IEnumerable<WeightAndHeightViewModel> model;
            model = mapper.Map<IEnumerable<WeightAndHeightDTO>, IEnumerable<WeightAndHeightViewModel>>(WeightAndHeightDtos);

            var labels = model.Select(m => m.MeasurementDate.ToString("yyyy-MM-dd")).ToArray();
            var weights = model.Select(m => m.Weight).ToArray();
            var heights = model.Select(m => m.Height).ToArray();

            ViewBag.Labels = labels;
            ViewBag.Weights = weights;
            ViewBag.Heights = heights;

            return View();

            
        }
    }
}
