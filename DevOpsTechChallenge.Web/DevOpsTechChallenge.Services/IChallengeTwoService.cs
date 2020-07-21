namespace DevOpsTechChallenge.Services.ChallengeThree
{
    public interface IChallengeTwoService
    {
        string Get(string vmName, string filter, string apiUrl);
    }
}