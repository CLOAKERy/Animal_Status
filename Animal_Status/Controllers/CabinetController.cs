﻿using BLL.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Animal_Status.Models;
using System.Collections.Generic;

namespace Animal_Status.Controllers
{
    public class CabinetController : Controller
    {
        private readonly IMapper mapper;

        IPetService petService;
        IAnimalTypeService animalTypeService;
        IVaccinationService vaccinationService;

        public CabinetController(IPetService petService, IMapper mapper, IAnimalTypeService animalTypeService, IVaccinationService vaccinationService)
        {
            this.mapper = mapper;
            this.petService = petService;
            this.animalTypeService = animalTypeService;
            this.vaccinationService = vaccinationService;
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
            PetViewModel petCreate = new()
            {
                AnimalTypes = mapper.Map<IEnumerable<AnimalTypeDTO>, IEnumerable<AnimalTypeViewModel>>(animalTypeDtos)

            };
            return View(petCreate);
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


    }
}
