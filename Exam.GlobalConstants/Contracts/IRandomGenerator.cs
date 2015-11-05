namespace Exam.Common.Contracts
{
    using System;

    public interface IRandomGenerator
    {
        string RandomString(int minLength = 5, int maxLength = 50);

        bool RandomBool();

        DateTime RandomDate(bool fature = true);

        int RandomNumber(int max);
    }
}