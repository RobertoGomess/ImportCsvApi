using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ImportCsv.app.resource.mysql.repositories;

namespace ImportCsv.app.commands
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
            var sucess = true;
            var models = _mapper.Map<IEnumerable<M>>(list);
            try{
                _repository.Create(models);
                _repository.Commit();
            }catch{
                sucess = false;
            }
            return sucess;
        }
    }
}