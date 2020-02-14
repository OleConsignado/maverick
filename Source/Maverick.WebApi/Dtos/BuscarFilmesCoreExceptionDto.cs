using System.Collections.Generic;

namespace Maverick.WebApi.Dtos
{
    public class BuscarFilmesCoreExceptionDto
    {
        public IEnumerable<BuscarFilmesCoreErrorDto> Errors { get; set; }
    }
}
