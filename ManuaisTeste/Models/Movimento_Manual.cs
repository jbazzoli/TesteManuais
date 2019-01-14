using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManuaisTeste.Models
{
    public class Movimento_Manual
    {
        
        [Display(Name ="Mês")]        
        [Key, Column(Order = 0)]
        public int DAT_MES { get; set; }

        [Display(Name = "Ano")]
        [Key, Column(Order = 1)]
        public int DAT_ANO { get; set; }

        [Display(Name = "NR Lançamento")]
        [Key, Column(Order = 2)]
        public int NUM_LANCAMENTO { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("COD_PRODUTO"),Column(Order = 3)]
        public string COD_PRODUTOID{ get; set; }

        [Display(Name = "Cosif")]
        [ForeignKey("COD_COSIF"), Column(Order = 4)]
        public string COD_COSIFID { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string DES_DESCRICAO { get; set; }

        [Required]
        [Display(Name = "Data Da Movimentação")]
        public DateTime DAT_MOVIMENTO { get; set; }

        [Required]
        [Display(Name = "Codigo do Usuario")]
        public string COD_USUARIO { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public int VAL_VALOR { get; set; }

        public virtual Produto_Cosif COD_PRODUTO { get; set; }

        public virtual Produto_Cosif COD_COSIF { get; set; }

    }
}