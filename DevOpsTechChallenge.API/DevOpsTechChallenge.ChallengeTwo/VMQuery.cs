using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevOpsTechChallenge.ChallengeTwo
{
    public class VMQuery : IVMQuery
    {
        public string Get(string vmName, string filter, string clientId, string clientSecret, string tenantId)
        {
            var azure = Azure
            .Configure()
            .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
            .Authenticate(GetCredentials(clientId, clientSecret, tenantId))
            .WithDefaultSubscription();

            var vm = azure.VirtualMachines.GetByResourceGroup("jfh_testvm_rg", vmName);
            var result = vm.RunPowerShellScript(new List<string> {
                @"$Json = Invoke-RestMethod -Headers @{""Metadata""=""true""} -Method GET -Uri http://169.254.169.254/metadata/instance?api-version=2019-06-01 | ConvertTo-Json -Depth 50
                  $Json = $Json -replace '\s+', ''
                  $Json"
            }, new List<RunCommandInputParameter>()); ;
            var json = result.Value.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o.Message)).Message;
            var jToken = JToken.Parse(json);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                return jToken.SelectToken(filter.Replace("/", ".")).Value<string>();
            }

            return jToken.ToString(Formatting.Indented);
        }

        private AzureCredentials GetCredentials(string clientId, string clientSecret, string tenantId)
        {
            return SdkContext.AzureCredentialsFactory.FromServicePrincipal(clientId, clientSecret, tenantId, AzureEnvironment.AzureGlobalCloud);
        }
    }
}
