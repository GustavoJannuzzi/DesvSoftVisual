using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WoofHub.Entidades
{
    [Table("Felinos")]
    public class Felino
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Peso { get; set; }
        public string Situacao { get; set; }
        public string Endereco { get; set; }

        [ForeignKey("Dono")]
        public int DonoId { get; set; }
        public virtual Cliente Dono { get; set; }
    }
}
