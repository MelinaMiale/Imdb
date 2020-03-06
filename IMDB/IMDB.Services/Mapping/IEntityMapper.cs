using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Services.Mapping
{
    public interface IEntityMapper<TModel, TDto>
    {
        // where TModel : EntityModels.
        //  where TDto : EntityDto

        TDto ToDto(TModel source, TDto destination);

        TModel ToModel(TDto source, TModel destination);
    }
}
