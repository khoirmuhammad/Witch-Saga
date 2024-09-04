namespace NetWitchSaga.BusinessLogic
{
    public class DeathRateLogic
    {
        /// <summary>
        /// a pattern is based on the sum of the Fibonacci numbers up to a certain point.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public int CalculateVillagersKilled(int year)
        {
            if (year < 1) return -1;
            if (year == 1) return 1;

            // Initialize the Fibonacci sequence
            int[] fibonacci = new int[year];
            fibonacci[0] = 1; // F(1)
            fibonacci[1] = 1; // F(2)

            // Generate Fibonacci sequence up to the year
            for (int index = 2; index < year; index++)
            {
                int prevOne = index - 1;
                int prevTwo = index - 2;
                fibonacci[index] = fibonacci[prevOne] + fibonacci[prevTwo];
            }

            // Calculate the cumulative sum of Fibonacci numbers
            int result = fibonacci.Sum();

            return result;

        }
    }
}
