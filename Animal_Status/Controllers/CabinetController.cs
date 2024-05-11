using BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Animal_Status.Models;
using System.Collections.Generic;
using BLL.BusinessModel;

namespace Animal_Status.Controllers
{
    public class CabinetController : Controller
    {
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostingEnvironment;
        IPetService petService;
        IAnimalTypeService animalTypeService;
        IVaccinationService vaccinationService;
        IPetVaccinationService petVaccinationService;
        IDietService dietService;
        IExerciseService exerciseService;
        ISleepAndRestService sleepAndRestService;
        IStressLevelService stressLevelService;
        IBehaviorService behaviorService;
        IVeterinaryRecordService veterinaryRecordService;
        IWeightAndHeightService weightAndHeightService;

        public CabinetController(IPetService petService, IMapper mapper, IAnimalTypeService animalTypeService, 
            IVaccinationService vaccinationService, IWebHostEnvironment hostingEnvironment,
            IPetVaccinationService petVaccinationService, IDietService dietService, IExerciseService exerciseService,
            ISleepAndRestService sleepAndRestService, IStressLevelService stressLevelService, IBehaviorService behaviorService,
            IVeterinaryRecordService veterinaryRecordService, IWeightAndHeightService weightAndHeightService)
        {
            this.mapper = mapper;
            this.petService = petService;
            this.animalTypeService = animalTypeService;
            this.vaccinationService = vaccinationService;
            this.hostingEnvironment = hostingEnvironment;
            this.petVaccinationService = petVaccinationService;
            this.dietService = dietService;
            this.exerciseService = exerciseService;
            this.sleepAndRestService = sleepAndRestService;
            this.stressLevelService = stressLevelService;
            this.behaviorService = behaviorService;
            this.veterinaryRecordService = veterinaryRecordService;
            this.weightAndHeightService = weightAndHeightService;
        }
        public async Task<ActionResult> Pets()
        {
            IEnumerable<PetDTO> petsDtos = await petService.GetAllPetsWithTypesAsync();
            PetIndexViewModel model = new();
            model.petViewModel = mapper.Map<IEnumerable<PetDTO>, IEnumerable<PetViewModel>>(petsDtos);
            return View("Pets", model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            IEnumerable <AnimalTypeDTO> animalTypeDtos = await animalTypeService.GetAllAnimalTypesAsync();
            PetViewModel typeCreate = new()
            {
                AnimalTypes = mapper.Map<IEnumerable<AnimalTypeDTO>, IEnumerable<AnimalTypeViewModel>>(animalTypeDtos)

            };
            return View(typeCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PetViewModel model, IFormFile imageFile)
        {
            WorkingWithImg img = new();
            string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            string imagePath = await img.ProcessImage(imageFile, uploadFolder);
            PetDTO petCreate = mapper.Map <PetViewModel, PetDTO> (model);
            petCreate.OwnerId = Convert.ToInt32(User.Identity.Name);
            petCreate.Picture = imagePath;
            await petService.AddPet(petCreate);
            return RedirectToAction("Pets", "Cabinet");
        }

        [HttpGet]
        public async Task<ActionResult> Redact(int petId)
        {
            IEnumerable<AnimalTypeDTO> animalTypeDtos = await animalTypeService.GetAllAnimalTypesAsync();
            PetDTO petDTO = await petService.GetPetById(petId);
            PetViewModel model = mapper.Map<PetDTO, PetViewModel>(petDTO);
            model.AnimalTypes = mapper.Map<IEnumerable<AnimalTypeDTO>, IEnumerable<AnimalTypeViewModel>>(animalTypeDtos);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Redact(PetViewModel model, int petId, int ownerId, 
            string picture, IFormFile imageFile)
        {
            string imagePath = picture;
            if(imageFile != null)
            {
                WorkingWithImg img = new();
                string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                imagePath = await img.ProcessImage(imageFile, uploadFolder);
            }
            
            model.OwnerId = ownerId;
            model.Picture = imagePath;
            PetDTO petRedact = mapper.Map<PetViewModel, PetDTO>(model);
            
            await petService.UpdatePet(petRedact);
            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> Details(int animalId)
        {
            PetDTO petDto = await petService.GetPetDetailsAsync(animalId);
            PetViewModel model = mapper.Map<PetDTO, PetViewModel>(petDto);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> AddVaccine(int animalId)
        {
            IEnumerable <VaccinationDTO> vaccinationDto = await vaccinationService.GetAllVaccinationsAsync();
            VaccinationViewModelIndex model = new();
            model.vaccinationViewModels = mapper.Map<IEnumerable<VaccinationDTO>, IEnumerable<VaccinationViewModel>>(vaccinationDto);
            model.animalId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddVaccine(VaccinationViewModelIndex model, int petId)
        {
            PetVaccinationDTO petVaccinationDTO = new()
            {
                PetId = petId,
                VaccinationId = model.vaccineId
            };
            await petVaccinationService.AddPetVaccination(petVaccinationDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId});
        }

        
        public async Task<ActionResult> DeleteVaccine(int vaccineId, int petId)
        {
            
            await petVaccinationService.RemovePetVaccination(vaccineId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddDiet(int animalId)
        {
            DietViewModel model = new();
            model.PetId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddDiet(DietViewModel model, int petId)
        {
            DietDTO dietDTO = new()
            {
                PetId = petId,
                Description = model.Description,
                DietDate = model.DietDate
            };
            await dietService.AddDiet(dietDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteDiet(int dietId, int petId)
        {

            await dietService.RemoveDiet(dietId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddExercise(int animalId)
        {
            ExerciseViewModel model = new();
            model.PetId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddExercise(ExerciseViewModel model, int petId)
        {
            ExerciseDTO exerciseDTO = new()
            {
                PetId = petId,
                Description = model.Description,
                ActivityDate = model.ActivityDate
            };
            await exerciseService.AddExercise(exerciseDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteExercise(int exerciseId, int petId)
        {

            await exerciseService.RemoveExercise(exerciseId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddSleepAndRest(int animalId)
        {
            SleepAndRestViewModel model = new();
            model.PetId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddSleepAndRest(SleepAndRestViewModel model, int petId)
        {
            SleepAndRestDTO sleepAndRestDTO = new()
            {
                PetId = petId,
                Description = model.Description,
                RestDate = model.RestDate
            };
            await sleepAndRestService.AddSleepAndRest(sleepAndRestDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteSleepAndRest(int sleepAndRestId, int petId)
        {

            await sleepAndRestService.RemoveSleepAndRest(sleepAndRestId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddStressLevel(int animalId)
        {
            StressLevelViewModel model = new();
            model.PetId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddStressLevel(StressLevelViewModel model, int petId)
        {
            StressLevelDTO stressLevelDTO = new()
            {
                PetId = petId,
                Description = model.Description,
                StressDate = model.StressDate
            };
            await stressLevelService.AddStressLevel(stressLevelDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteStressLevel(int stressLevelId, int petId)
        {

            await stressLevelService.RemoveStressLevel(stressLevelId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddBehavior(int animalId)
        {
            BehaviorViewModel model = new();
            model.PetId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddBehavior(BehaviorViewModel model, int petId)
        {
            BehaviorDTO behaviorDTO = new()
            {
                PetId = petId,
                Description = model.Description,
                BehaviorDate = model.BehaviorDate
            };
            await behaviorService.AddBehavior(behaviorDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteBehavior(int behaviorId, int petId)
        {

            await behaviorService.RemoveBehavior(behaviorId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddVeterinaryRecord(int animalId)
        {
            VeterinaryRecordViewModel model = new();
            model.PetId = animalId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddVeterinaryRecord(VeterinaryRecordViewModel model, int petId)
        {
            VeterinaryRecordDTO veterinaryRecordDTO = new()
            {
                PetId = petId,
                Description = model.Description,
                VisitDate = model.VisitDate,
                Recommendations = model.Recommendations,
                Veterinarian = model.Veterinarian
            };
            await veterinaryRecordService.AddVeterinaryRecord(veterinaryRecordDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteVeterinaryRecord(int veterinaryRecordId, int petId)
        {

            await veterinaryRecordService.RemoveVeterinaryRecord(veterinaryRecordId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        [HttpGet]
        public async Task<ActionResult> AddWeightAndHeight(int petId)
        {
            WeightAndHeightViewModel model = new();
            model.PetId = petId;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddWeightAndHeight(WeightAndHeightViewModel model, int petId)
        {
            WeightAndHeightDTO weightAndHeightDTO = new()
            {
                PetId = petId,
                MeasurementDate = model.MeasurementDate,
                Weight = model.Weight,
                Height = model.Height,

            };
            await weightAndHeightService.AddWeightAndHeight(weightAndHeightDTO);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }

        public async Task<ActionResult> DeleteWeightAndHeight(int measurementId, int petId)
        {

            await weightAndHeightService.RemoveWeightAndHeight(measurementId);

            return RedirectToAction("Details", "Cabinet", new { animalId = petId });
        }
    }
}
