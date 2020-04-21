using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImportCsv.app.resource.mysql.models
{
    public class ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime ModifieldDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}