using Microsoft.AspNetCore.Mvc;
using NetWitchSaga.BusinessLogic;
using NetWitchSaga.Models;

namespace NetWitchSaga.Controllers
{
    public class WitchSagaController : Controller
    {
        private readonly VillagerLogic villager;
        private readonly DeathRateLogic deathRateLogic;
        public WitchSagaController(VillagerLogic villager, DeathRateLogic deathRateLogic)
        {
            this.villager = villager;
            this.deathRateLogic = deathRateLogic;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateNumber(int year)
        {
            try
            {
                int result = deathRateLogic.CalculateVillagersKilled(year);

                ViewBag.NumberResult = $"On the {year} year she kills {result} villagers";
            }
            catch (Exception ex)
            {
                ViewBag.NumberResult = ex.Message;
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult CalculateAverage(int age1, int yearOfDeath1, int age2, int yearOfDeath2)
        {
            try
            {
                Villager villager1 = new Villager
                {
                    Age = age1,
                    YearOfDeath = yearOfDeath1,
                };

                Villager villager2 = new Villager
                {
                    Age = age2,
                    YearOfDeath = yearOfDeath2,
                };

                double averageKilled = villager.CalculateAverageKilled(villager1, villager2);

                if (averageKilled == -1)
                {
                    ViewBag.AverageResult = "Invalid input data. The witch's curse remains.";
                }
                else
                {
                    ViewBag.AverageResult = $"The average number of people killed in the birth years is: {averageKilled}";
                }
            }
            catch (ArgumentException ex)
            {
                ViewBag.AverageResult = ex.Message;
            }

            return View("Index");
        }
    }
}
