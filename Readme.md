# Dotnet 8 - AWS Dynamic String

This project is an ASP.NET Core Web Application running as an AWS Lambda function. It dynamically fetches a string from AWS Systems Manager Parameter Store and displays it on a Razor page. The entire infrastructure is provisioned using Terraform.

## Overview
- Runtime: .NET 8
- AWS Service: Lambda (ASP.NET Core Web API with Razor Pages)
- Configuration Store: AWS Systems Manager Parameter Store
- Infrastructure as Code: Terraform
- Build Tools: Amazon.Lambda.Tools

Getting Started:
1. Ensure `.NET 8 SDK`, `Terraform` & `dotnet Amazon.Lambda.Tools` have been installed on your system.
2. Build the artifact:
    - On Windows: `windows-build.bat`
    - On Linux/macOS: `unix-build.sh`
3. Change directories `cd ./terraform`
4. Init Terraform: `terraform init`
5. Deploy using `terraform apply`


## Why ASP.NET Core & AWS Lambda
- ASP.NET Core is a high-performance, cross-platform, cloud-ready and modular web framework that is actively maintained by Microsoft
- Serverless: Lambda allows us to run our ASP.NET Core app without managing servers.
- Cost Efficiency: You pay only for compute time
- Scalability: Lambda auto-scales with demand.


## Using .NET 8
- Leverages the latest performance improvements and features.
- Ensures long-term support and compatibility.

## Dynamic String via AWS Parameter Store
- Centralized configuration: Parameter Store acts as a single source of truth for configuration data.
- Security: Supports encryption via KMS.
- Flexibility: Configuration parameters can be updated without the need to redeploy the application

## Terraform for Infrastructure as Code (IaC)
- Repeatability: Terraform scripts enable consistent environment provisioning.
- Version Control: Infrastructure can be versioned alongside application code.
- Modularity: Easily extend or refactor infrastructure components.

## Build & Deployment Tools
- `Amazon.Lambda.Tools` simplifies packaging and deployment of Lambda functions directly from .NET CLI.

## Options
| Feature             | Options Considered                                    | Reason for Choice                                           |
| ------------------- | ----------------------------------------------------- | ----------------------------------------------------------- |
| Hosting Platform    | AWS Lambda, CDN + Lambda@Edge, EC2, ECS               | Lambda chosen for serverless, cost and scalability          |
| IaC Tool            | Terraform, CloudFormation, Pulumi                     | Terraform for cloud-agnostic, popular IaC tool              |
| Deployment Pipeline | Manual deploy, CI/CD (GitHub Actions, CodePipeline)   | Manual for simplicity; CI/CD can be added later             |
| Web Framework       | ASP.NET Core MVC, Razor Pages, Minimal APIs           | Razor Pages for simplicity in rendering UI                  |

## Architectural Considerations

### Pros
- Cost effective: Only pay per execution.
- Operational simplicity: No server maintenance.
- Dynamic configuration: Change parameters without redeploy.
- Scalable: Auto scales with request volume.
- Minimal Lambda Permissions:
    - `AWSLambdaBasicExecutionRole` for Log group, stream and event creation.
    - `AmazonSSMReadOnlyAccess` for Parameter Store read-only access.

### Cons
- Cold start latency: Lambda cold starts slow initial requests.
- Lambda have a hard limit of 15 minutes of excecution time
- Lambdas deployment size is limited to 250MB

## Improvements

### Performance & Latency
- Cold starts can be improved by implementing provisioned concurrency. This allows you to configure a number of pre-warm Lambda instances so that they're ready to process requests immediately.

### Deployment Pipeline
- Currently, builds and deployments are manual. This can be automated through the use of CI/CD pipeline (GitHub Actions, TeamCity, AWS CodePipeline)

### Infrastructure Extensibility
- The API Gateway has a default URL which is not very readable. Custom domains can be used by leveraging Route53 Records.
