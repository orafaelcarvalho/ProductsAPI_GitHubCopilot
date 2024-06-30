// criar a classe BaseEntity com propriedade Id que será gerada pelo banco de dados
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI_GitHubCopilot.Domain.Entities
{
    public class BaseEntity
    {
        // criar DataAnnotations para definir que a propriedade Id
        [Key]
        // criar data annotations para definir que a propriedade Id é gerada pelo banco de dados
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }    
}