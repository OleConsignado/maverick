using Otc.ComponentModel.DataAnnotations;

namespace Maverick.TmdbAdapter
{
    public class TmdbAdapterConfiguration
    {
        [Required]
        public string TmdbApiUrlBase { get; set; }
        [Required]
        public string TmdbApiKey { get; set; }
        public int TempoDeCacheDaPesquisaEmSegundos { get; set; } = 20;
    }
}
