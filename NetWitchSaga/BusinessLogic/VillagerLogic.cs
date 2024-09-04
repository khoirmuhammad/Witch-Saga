using NetWitchSaga.Models;

namespace NetWitchSaga.BusinessLogic
{
    public class VillagerLogic
    {
        private readonly DeathRateLogic deathRate;

        public VillagerLogic(DeathRateLogic deathRate)
        {
            this.deathRate = deathRate;
        }

        private int CalculateBirthYear(Villager villager)
        {
            return villager.YearOfDeath - villager.Age;
        }

        public double CalculateAverageKilled(Villager villager1, Villager villager2)
        {
            int birthYear1 = this.CalculateBirthYear(villager1);
            int birthYear2 = this.CalculateBirthYear(villager2);

            if (birthYear1 < 1 || birthYear2 < 1) 
                return -1; // Invalid birth years

            int killedInYear1 = deathRate.CalculateVillagersKilled(birthYear1);
            int killedInYear2 = deathRate.CalculateVillagersKilled(birthYear2);

            if (killedInYear1 == -1 || killedInYear2 == -1) 
                return -1; // Invalid year of birth

            return (killedInYear1 + killedInYear2) / 2.0;
        }
    }
}
