namespace Exam.Common
{
    #region

    using System;
    using System.Text;

    using Exam.Common.Contracts;

    #endregion

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz           !?.";

        private readonly Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public string RandomString(int minLength = 5, int maxLength = 50)
        {
            var result = new StringBuilder();
            var length = this.random.Next(minLength, maxLength);

            for (var i = 0; i < length; i++)
            {
                result.Append(Letters[this.random.Next(Letters.Length)]);
            }
            return result.ToString();
        }

        public bool RandomBool()
        {
            var result = this.random.Next(2);
            if (result == 1)
            {
                return true;
            }

            return false;
        }

        public DateTime RandomDate(bool fature = true)
        {
            var multiplier = 1;

            var resultDate = DateTime.Now;
            if (fature == false)
            {
                multiplier = -1;
            }

            resultDate = resultDate.AddDays(multiplier * this.random.Next(356)).AddHours(multiplier * this.random.Next(24)).AddMinutes(multiplier * this.random.Next(59));

            return resultDate;

        }

        public int RandomNumber(int max)
        {
            return this.random.Next(max);
        }
    }
}