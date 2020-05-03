using AutoMapper;
using ImportCsv.Api.Exceptions;
using ImportCsv.Api.Resources.Mysql.Repositories;
using System;
using System.Collections.Generic;

namespace ImportCsv.Api.Domains
{
    public abstract class SaveCsvAbstract <C,M> : ISaveCsvAbstract<C>
    {
        private readonly IBaseRepository<M> _repository;
        private readonly IMapper _mapper;

        protected SaveCsvAbstract(IBaseRepository<M> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Execute(IEnumerable<C> list)
        {
            var models = _mapper.Map<IEnumerable<M>>(list);

            try{
                _repository.DeleteAll();
                _repository.Create(models);
                _repository.Commit();
            }catch(Exception ex){
                throw new BusinessException("Error a save trying in data base.", ex);
            }
            return true;
        }
    }
}