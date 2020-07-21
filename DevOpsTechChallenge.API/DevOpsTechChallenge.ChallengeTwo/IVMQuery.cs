namespace DevOpsTechChallenge.ChallengeTwo
{
    public interface IVMQuery
    {
        string Get(string vmName, string filter = null);
    }
}