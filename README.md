# DevOps Tech Challenge

## Overview

The three challenges use the following technologies;

1. GitHub for source control.
2. Azure DevOps Serviuce for Continuous Integration and Continuous Delivery
3. Azure as the platform
4. ARM templates to define the platform
5. C# for the code
6. ASP.NET Core for the example apps
7. Azure App Service for Web Tier and API Tier
8. Azure CosmosDB for Data Tier

## Where to Find Everything

At a high level the relevant urls are;

1. Source Control: https://github.com/jaredfholgate/DevOpsTechChallenge
2. CI Build Definitions: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge/build/Build.cs
3. CD Pipeline Definition: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/azure-pipelines.yml
4. 3 Tier Infrastruction definition: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/Infrastructure/dotc.tf
5. Pipeline results: https://jaredfholgate.visualstudio.com/DevOpsTechChallenge/_build?definitionId=5
6. Live application API: https://jfh-dotc-api-as.azurewebsites.net/
7. Live application Web: https://jfh-dotc-web-as.azurewebsites.net/

## Challenge 1

This challenge was completed using a Terrform defintion for the 3 Tier Infrastructure. The 3 Tiers are;

1. Data: Azure SQL Service
2. API: Azure App Service
3. UI: Azure App Service

- The terraform defintion is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/Infrastructure/dotc.tf
- The Azure DevOps Pipeline that runs the Terraform apply is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/azure-pipelines.yml
- An example deployment where the infrastructure was created from scratch can be seen here: TBC
- A live user interface to test is here: https://jfh-dotc-web-as.azurewebsites.net/

## Challenge 2

This challenge was completed using PowerShell run remotely via C#. A VM is provisioned using Terraform for the purpose of testing.

- The C# code and PowerShell can be seen here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/DevOpsTechChallenge.ChallengeTwo/VMQuery.cs
- Some integration tests are here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge.API/DevOpsTechChallenge.ChallengeTwo.IntnTests/VMQueryTests.cs
- The VM Terraform is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/Infrastructure/testvm.tf
- A live user interface to test is here: https://jfh-dotc-web-as.azurewebsites.net/

## Challenge 3

This challenge was completed using C#. I used JSON.NET, a well known Nuget package, to assist with parsing and finding the value defined by the key.

- The unit tests are here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge/DevOpsTechChallenge.ChallengeThree.UnitTests/ParserTest.cs
- The implementation is here: https://github.com/jaredfholgate/DevOpsTechChallenge/blob/master/DevOpsTechChallenge/DevOpsTechChallenge.ChallengeThree/Parser.cs
- A live user interface to test is here: https://jfh-dotc-web-as.azurewebsites.net/

## Notes / Improvements

I limited the amount of time I spent on this, so couldn't achieve a fully production ready implementation. There are a number of improvements I would make to improve the solution;

1. Add an Application Gateway and WAF into the infrastructure design.
2. Use a Hub and Spoke network design.
3. Implement robust monitoring and alerting.
4. Use a managed account to connect to SQL Server.
5. Use Azure Key Vault for secrets.

