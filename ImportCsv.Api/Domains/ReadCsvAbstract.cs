using CsvHelper;
using ImportCsv.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportCsv.Api.Domains
{
    public abstract class ReadCsvAbstract <C> : IReadCsvAbstract<C>
    {

        private readonly ISaveCsvAbstract<C> _saveCsvPrice;

        protected ReadCsvAbstract(ISaveCsvAbstract<C> csvPrice)
        {
            _saveCsvPrice = csvPrice;
        }

        public IEnumerable<C> Execute(){
            var rows = ReaderFileCsv();
#if DEBUG
            _saveCsvPrice.Execute(rows);
#else
            var moveFile = _saveCsvPrice.Execute(rows);
            if (moveFile){
                MoveFile();
            }
#endif
            return rows;
        }

        protected abstract string GetOriginFilePath();
        protected abstract string GetOriginFileName();
        protected abstract string GetDestinationPath();

        protected IEnumerable<C> ReaderFileCsv(){

            try
            {
                var originalFilePath = GetOriginFilePath();
                var originalFileName = GetOriginFileName();

                using var reader = new StreamReader($"{originalFilePath}{originalFileName}", Encoding.UTF8);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                return csv.GetRecords<C>()?.ToList() ?? new List<C>();
            }
            catch(Exception ex)
            {
                throw new BusinessException("Error a load file.", ex);
            }
        }

        private void MoveFile()
        {
            try
            {
                var originalPath = $"{GetOriginFilePath()}{GetOriginFileName()}";
                var destinationPath = $"{GetDestinationPath()}{GetOriginFileName()}";

                if (File.Exists(originalPath))
                {
                    if (File.Exists(destinationPath))
                    {
                        File.Delete(destinationPath);
                    }
                    else
                    {

                        File.Move(originalPath, destinationPath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error a file move.", ex);
            }
        }
    }
}