using RosariumBackEnd.Entities.Entities;
using RosariumBackEnd.Service.Interfaces;
using RosariumBackEnd.Service.Utils;
using System.Globalization;

namespace RosariumBackEnd.Schedule.Implementation
{
    public class LiturgiaDiaria
    {
        private readonly ICustomHttpUtils _customHttpUtils;
        private readonly IEvangelhoService _evangelhoService;
        private readonly ILiturgiaService _liturgiaService;
        private readonly string url = "https://liturgiadiaria.site/";
        private readonly ObjectMapper _objectMapper;

        public LiturgiaDiaria(ICustomHttpUtils customHttpUtils, IEvangelhoService evangelhoService, ILiturgiaService liturgiaService, ObjectMapper ObjectMapper)
        {
            _customHttpUtils = customHttpUtils;
            _customHttpUtils.SetUrl(url);
            _evangelhoService = evangelhoService;
            _liturgiaService = liturgiaService;
            _objectMapper = ObjectMapper;
        }

        public async Task InitLiturgiaDiariaAsync()
        {
            try
            {
                var liturgiaDto = await _customHttpUtils.GetAsync<LiturgiaDto>();

                Liturgia liturgia = ObjectMapper.Map<LiturgiaDto, Liturgia>(
                                                                            liturgiaDto,
                                                                            (output, input) =>
                                                                                                {
                                                                                                    // Converter a string Data para DateTime usando o formato específico
                                                                                                    if (DateTime.TryParseExact(input.Data, new[] { "dd/MM/yyyy", "d/MM/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                                                                                                    {
                                                                                                        output.Data = data;
                                                                                                    }

                                                                                                });
                if (liturgia != null)
                {
                    var teste = await _liturgiaService.AddLiturgia(liturgia);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }


}









