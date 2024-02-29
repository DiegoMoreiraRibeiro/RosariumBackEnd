using Microsoft.Extensions.DependencyInjection;
using RosariumBackEnd.Entities.Entities;
using RosariumBackEnd.Infra.IoC;
using RosariumBackEnd.Schedule.Implementation;
using System.Text.Json;

string[] commandLineArgs = Environment.GetCommandLineArgs();
string jsonString = commandLineArgs[1].Replace("'", "\"");

Aplicacao aplicacao = JsonSerializer.Deserialize<Aplicacao>(jsonString);
Console.WriteLine($"Application: {aplicacao.application}");



// TODO: Buscar pelo config
Console.WriteLine($"Injeção de dependência: {aplicacao.application}");
var serviceProvider = InitIOC.InitIOC_Schedule<LiturgiaDiaria>(new ServiceCollection(), "Data Source=localhost;Initial Catalog=rosarium;Integrated Security=True;TrustServerCertificate=True;");

try
{
    switch (aplicacao.application)
    {
        case "liturgia_diaria":
            Console.WriteLine($"Init: {aplicacao.application}");
            var liturgiaDiariaService = serviceProvider.GetRequiredService<LiturgiaDiaria>();
            await liturgiaDiariaService.InitLiturgiaDiariaAsync();
            Console.WriteLine($"Concluído com sucesso!");
            break;
        default:
            Console.WriteLine("Nenhuma opção foi passada");
            break;
    }

}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
    throw ex;
}
