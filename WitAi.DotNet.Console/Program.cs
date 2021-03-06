﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WitAi.DotNet.Api;
using WitAi.DotNet.Api.Models.Domain;
using WitAi.DotNet.Api.Models.Request;
using WitAi.DotNet.Api.Models.Response;

namespace WitAi.DotNet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                WitAiApi witApi = new WitAiApi();
                string serverAccessToken = "{YOUR_ACCESS_TOKEN_HERE}";

                CreateWitAppResponse cAppResponse = await witApi.CreateApp(new CreateWitAppRequest(serverAccessToken) { AppName = "refactoring_test", LanguageCode = "it", IsPrivate = true });

                if (!cAppResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] App created");

                UpdateWitAppResponse updateAppResponse = await witApi.UpdateApp(new UpdateWitAppRequest(cAppResponse.AccessToken, cAppResponse.AppId, "app-modified") { LanguageCode = "en" });

                if (!updateAppResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] App updated");

                AddWitEntityResponse aweResponse = await witApi.AddEntity(new AddWitEntityRequest(cAppResponse.AccessToken) { EntityName = "user_name", Description = "The name of the user that is texting with the bot" });
                
                if (!aweResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] Entity added");

                GetWitEntityResponse entityResponse = await witApi.GetEntity(new GetWitEntityRequest(cAppResponse.AccessToken) { EntityNameOrId = "user_name" });

                if (!entityResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] Entity read");

                GetWitEntitiesResponse entitiesResponse = await witApi.GetEntities(new GetWitEntitiesRequest(cAppResponse.AccessToken));

                if (!entitiesResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] Entities read");

                TrainWitAppResponse trainingResponse = await witApi.Train(new TrainWitAppRequest(cAppResponse.AccessToken)
                {
                    Samples = new List<WitTrainingSample>
                    {
                        new WitTrainingSample
                        {
                            Text = "Il mio nome è Jack",
                            Entities = new List<WitSampleEntity>
                            {
                                new WitSampleEntity("user_name", "Jack", "Il mio nome è Jack".IndexOf("Jack"), "Il mio nome è Jack".IndexOf("Jack") + "Jack".Length)
                            }
                        }
                    }
                });

                if (!trainingResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] App trained");

                System.Console.WriteLine(" *** Waiting about 20 seconds for app changes to take effect ...");
                Thread.Sleep(20000);

                ParseWitMessageResponse parseResponse = await witApi.ParseMessage(new ParseWitMessageRequest(cAppResponse.AccessToken)
                {
                    Message = "Il mio nome è Roy",
                    Verbose = true
                });

                if (!parseResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] Message parsed");

                DeleteWitEntityResponse deleteEntityResponse = await witApi.DeleteEntity(new DeleteWitEntityRequest(cAppResponse.AccessToken) { EntityNameOrId = "user_name" });

                if (!deleteEntityResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] Entity deleted");

                DeleteWitAppResponse deleteAppResponse = await witApi.DeleteApp(new DeleteWitAppRequest(cAppResponse.AccessToken) { AppId = cAppResponse.AppId });

                if (!deleteAppResponse.IsSuccessful)
                    return;

                System.Console.WriteLine("[OK] App deleted");

            }).GetAwaiter().GetResult();

            System.Console.WriteLine();
            System.Console.WriteLine("Press ENTER to finish");

            System.Console.ReadLine();
        }
    }
}