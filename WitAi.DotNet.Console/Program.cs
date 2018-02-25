using System.Collections.Generic;
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
                string accessToken = "{YOUR_ACCESS_TOKEN_HERE}";

                CreateWitAppResponse cAppResponse = await witApi.CreateApp(new CreateWitAppRequest(accessToken) { AppName = "apiTest", LanguageCode = "it", IsPrivate = true });

                if (!cAppResponse.IsSuccessful)
                    return;

                AddWitEntityResponse aweResponse = await witApi.AddEntity(new AddWitEntityRequest(cAppResponse.AccessToken) { EntityName = "user_name", Description = "The name of the user that is texting with the bot" });
                aweResponse = await witApi.AddEntity(new AddWitEntityRequest(cAppResponse.AccessToken) { EntityName = "get_name", Description = "Intent to get name" });

                if (!aweResponse.IsSuccessful)
                    return;

                TrainWitAppResponse twaResponse = await witApi.Train(new TrainWitAppRequest(cAppResponse.AccessToken)
                {
                    Samples = new List<WitTrainingSample>
                    {
                        new WitTrainingSample
                        {
                            Text = "Il mio nome è Jack",
                            Entities = new List<WitSampleEntity>
                            {
                                new WitSampleEntity("intent", "specify_name"),
                                new WitSampleEntity("user_name", "Jack", "Il mio nome è Jack".IndexOf("Jack"), "Il mio nome è Jack".IndexOf("Jack") + "Jack".Length)
                            }
                        }
                    }
                });

                //DeleteWitAppResponse dAppResponse = await witApi.DeleteApp(new DeleteWitAppRequest(cAppResponse.AccessToken) { AppId = cAppResponse.AppId });
            }).GetAwaiter().GetResult();
        }
    }
}
