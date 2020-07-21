namespace DevOpsTechChallenge.ChallengeTwo
{
    public interface IVMQuery
    {
        string Get(string vmName, string filter, string clientId, string clientSecret, string tenantId);
    }
}