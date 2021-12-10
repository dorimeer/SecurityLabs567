using System;
using System.Collections.Generic;
using SecuritySobolDori.Labs567.BLL.Interfaces;

namespace SecuritySobolDori.Labs567.BLL.Mappers
{
    public abstract class GenericMapper<TData, TDto> : IMapper<TData, TDto>
    {
        public abstract TData Map(TDto dtoEntity);
        public abstract TDto Map(TData dataEntity);

        public IEnumerable<TData> Map(IEnumerable<TDto> entities, Action<TData> callback = null)
        {
            var mappingResult = new List<TData>();
            foreach (var entity in entities)
            {
                var mappedEntity = Map(entity);
                if (mappedEntity != null)
                {
                    callback?.Invoke(mappedEntity);
                    mappingResult.Add(mappedEntity);
                }
            }

            return mappingResult;
        }

        public IEnumerable<TDto> Map(IEnumerable<TData> entities, Action<TDto> callback = null)
        {
            var mappingResult = new List<TDto>();
            foreach (var entity in entities)
            {
                var mappedEntity = Map(entity);
                if (mappedEntity != null)
                {
                    callback?.Invoke(mappedEntity);
                    mappingResult.Add(mappedEntity);
                }
            }

            return mappingResult;
        }
    }
}