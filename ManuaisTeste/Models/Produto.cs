using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManuaisTeste.Models
{
    public class Produto
    {
        public Produto()
        {
            this.Produto_Cosif = new HashSet<Produto_Cosif>();
        }

        [Key]
        [Index("COD_PRODUTO", 1, IsUnique = true)]
        public string COD_PRODUTO { get; set; }
        public string DES_PRODUTO { get; set; }
        public string STA_STATUS { get; set; }
       
        public ICollection<Produto_Cosif> Produto_Cosif { get; set; }
    }
}