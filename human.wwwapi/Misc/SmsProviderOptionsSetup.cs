using Microsoft.Extensions.Options;

namespace human.wwwapi.Misc
{
    public class SmsProviderOptionsSetup : IConfigureOptions<SmsProviderOptions>
    {
        public const string SectionName = "SmsProvider";
        private readonly IConfiguration _configuration;

        public SmsProviderOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(SmsProviderOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
