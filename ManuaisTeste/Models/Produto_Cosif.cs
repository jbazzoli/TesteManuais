using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManuaisTeste.Models
{
    public class Produto_Cosif
    {


        public Produto_Cosif()
        {
            this.Movimento_Manual = new HashSet<Movimento_Manual>();
        }

        [ForeignKey("Produto"), Column(Order = 1)]
        public string COD_PRODUTOID { get; set; }
        [Key, Column(Order = 0)]
        [Index("COD_COSIF", 1, IsUnique = true)]
        public string COD_COSIF { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
        public virtual Produto Produto{ get; set; }
        public ICollection<Movimento_Manual> Movimento_Manual { get; set; }
    }
}