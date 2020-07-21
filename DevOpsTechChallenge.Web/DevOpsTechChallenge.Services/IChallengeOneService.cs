namespace DevOpsTechChallenge.Services.ChallengeThree
{
    public interface IChallengeOneService
    {
        string GetTest(string apiUrl);
        void SetTest(string apiUrl, string testValue);
    }
}