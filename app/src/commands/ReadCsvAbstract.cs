using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using CsvHelper;
using App.src.resource.mysql.repositories;

namespace App.src.commands
{
    public abstract class ReadCsvAbstract <C,M> : IReadCsvAbstract<C>
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<M> _repository;

        private readonly ISaveCsvAbstract<C> _saveCsvPrice;

        protected ReadCsvAbstract(IMapper mapper, IBaseRepository<M> repository, ISaveCsvAbstract<C> csvPrice)
        {
            _mapper = mapper;
            _repository = repository;
            _saveCsvPrice = csvPrice;
        }

        public IEnumerable<C> Execute(){
            var rows = ReaderFileCsv();
            var sucess = _saveCsvPrice.Execute(rows);
            if(sucess){
                MoveFile();
            }
            return rows;
        }

        protected abstract string GetOriginFilePath();
        protected abstract string GetOriginFileName();
        protected abstract string GetDestinationPath();

        protected IEnumerable<C> ReaderFileCsv(){
            var originalFilePath = GetOriginFilePath();
            var originalFileName = GetOriginFileName();

            using var reader = new StreamReader($"{originalFilePath}{originalFileName}", Encoding.UTF8);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csv.GetRecords<C>()?.ToList() ?? new List<C>();
        }

        private void MoveFile()
        {
            var originalPath = $"{GetOriginFilePath()}{GetOriginFileName()}";
            var destinationPath = $"{GetDestinationPath()}{GetOriginFileName()}";
            
            if(File.Exists(originalPath))
            {
                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                File.Move(originalPath, destinationPath);
            }
        }
    }
}