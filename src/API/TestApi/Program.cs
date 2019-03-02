using System;
using System.Threading.Tasks;

namespace TestApi
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            var api = APIBrumadinho.API.EscavadorApi.Current;
            api.Init(string.Empty, string.Empty, APIBrumadinho.Logger.LogLevel.All);
            var result = await api.AuthAsync();
            await api.GetCreditsAsync();
            await api.SearchPeopleAsync(2);
            //await api.SearchAsync(APIBrumadinho.API.Enumerators.EscavadorEntity.Patentes, "microcontrolador", 2);
            Console.ReadKey();
        }
    }
}
