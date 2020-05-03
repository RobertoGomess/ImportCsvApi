namespace ImportCsv.Api.Resources.Mysql.Models
{
    public class Price : ModelBase
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public float AmountPrice {get; set;}
    }
}