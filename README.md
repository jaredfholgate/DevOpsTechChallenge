# DevOps Tech Challenge

## Overview

The three challenges use the following technologies;

1. GitHub for source control.
2. Azure DevOps Service for Continuous Integration and Continuous Delivery
3. Azure as the platform
4. Terraform to define the infrastructure
5. C# for the code
6. ASP.NET Core for the example apps
7. Azure App Service for Web Tier and API Tier
8. Azure SQL Service for Data Tier
9. Nuke.Build for CI build definitions
10. Azure DevOps YAML CD pipeline definitions

## Where to Find Everything

At a high level the relevant urls are;

1. Source Control: https://github.com/jaredfholgate/DevOpsTechChallenge
2. CI Build Definitions: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.Web/build/Build.cs and https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/build/Build.cs
3. CD Pipeline Definition: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/azure-pipelines.yml
4. 3 Tier Infrastruction definition: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/Infrastructure/dotc.tf
5. Pipeline results: https://jaredfholgate.visualstudio.com/DevOpsTechChallenge/_build?definitionId=5
6. Live application API: https://jfh-dotc-api-as.azurewebsites.net/
7. Live application Web: https://jfh-dotc-web-as.azurewebsites.net/

## Challenge 1

This challenge was completed using a Terraform defintion for the 3 Tier Infrastructure. The 3 Tiers are;

1. Data: Azure SQL Service
2. API: Azure App Service
3. UI: Azure App Service

- The terraform defintion is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/Infrastructure/dotc.tf
- The Azure DevOps Pipeline that runs the Terraform apply is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/azure-pipelines.yml
- An example deployment where the infrastructure was created from scratch can be seen here: https://dev.azure.com/jaredfholgate/DevOpsTechChallenge/_build/results?buildId=213&view=logs&j=e5483be5-0b17-5c84-5a14-2851645699f7&t=42261f82-5dc6-542f-bc35-95201887d32f
- A live user interface to test is here: https://jfh-dotc-web-as.azurewebsites.net/

## Challenge 2

This challenge was completed using PowerShell run remotely via C#. A VM is provisioned using Terraform for the purpose of testing.

- The C# code and PowerShell can be seen here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/DevOpsTechChallenge.ChallengeTwo/VMQuery.cs
- Some integration tests are here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/DevOpsTechChallenge.ChallengeTwo.IntnTests/VMQueryTests.cs
- The VM Terraform is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/Infrastructure/testvm.tf
- A live user interface to test is here: https://jfh-dotc-web-as.azurewebsites.net/

## Challenge 3

This challenge was completed using C#. I used JSON.NET, a well known Nuget package, to assist with parsing and finding the value defined by the key.

- The unit tests are here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/DevOpsTechChallenge.ChallengeThree.UnitTests/ParserTest.cs
- The implementation is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/DevOpsTechChallenge.ChallengeThree/Parser.cs
- A live user interface to test is here: https://jfh-dotc-web-as.azurewebsites.net/

## Notes and Improvements

I limited the amount of time I spent on this, so couldn't achieve what I would for a fully production ready implementation. There are a number of improvements I would make to improve the solution, including but not limited to;

1. Add an Application Gateway and WAF into the infrastructure design.
2. Use a Hub and Spoke network design to enhance security.
3. Implement robust monitoring and alerting, including cost alerts / quotas.
4. Use a managed account to connect to SQL Server.
5. Use Azure Key Vault for secrets.
6. Add test environments and / or deployment slots.
7. Approvals for production deployments if required.
8. Branch polices in the GitHub repo for Pull Request enforcement.
9. Static analysis for security (e.g. VeraCode), quality (e.g. SonarQube) and credential leaks.
10. Make the User Interface a lot prettier and use a client library like React.
11. Implement Authentication and Authorisation for the UI and API (OAuth).
12. Better unit and integration test coverage for a production work load. Using SQL Lite or similar and self hosting to test at API layer.
13. Consider the scale of the PaaS services based on predicted work load.
14. SIEM implementation and dynamic security scanning or penetration testing.
15. Better live documentation of the solution.
16. Polices such as enforced tagging, restrictions on public ip addresses.
17. Robust IAM, Multi Factor and PIM with AzureAD.
18. Proper url and SSL certs for the Web and API apps.
19. Regular checks for infrastructure integrity with Terraform.
20. Better error handling and messages, especially in the API layer.
21. Swagger, versioning and self documenting (HATEOAS) in the API.
