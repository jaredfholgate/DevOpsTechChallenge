namespace DevOpsTechChallenge.Repositories
{
    public interface ITestRepository
    {
        string GetTest();
        void SetTest(string testValue);
    }
}