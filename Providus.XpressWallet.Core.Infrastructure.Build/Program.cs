﻿using System.Collections.Generic;
using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

namespace Providus.XpressWallet.Core.Infrastructure.Build
{




    internal class Program
    {
        private static void Main(string[] args)
        {
            var adoNetClient = new ADotNetClient();

            var githubPipeline = new GithubPipeline
            {
                Name = "Providus.XpressWallet.Core Build",

                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Jobs
                {
                    Build = new BuildJob
                    {
                        EnvironmentVariables = new Dictionary<string, string>
                        {
                            { "ApiKey", "${{ secrets.APIKEY }}" }
                        },

                        RunsOn = BuildMachines.WindowsLatest,

                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name = "Pulling Code"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Installing .NET",

                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    DotNetVersion = "7.0.201"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restoring Packages"
                            },

                            new DotNetBuildTask
                            {
                                Name = "Building Solution"
                            },

                            new TestTask
                            {
                                Name = "Running Tests"
                            }
                        }
                    }
                }
            };

            adoNetClient.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: "../../../../.github/workflows/dotnet.yml");

        }
    }
}