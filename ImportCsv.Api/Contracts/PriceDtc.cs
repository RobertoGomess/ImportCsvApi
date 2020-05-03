using FluentValidation.Attributes;
using ImportCsv.Api.src.Validators;

namespace ImportCsv.Api.Contracts
{
    [Validator(typeof(PriceDtcValidator))]
    public class PriceDtc
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public float AmountPrice {get; set;}
    }
}