
namespace GerenciamentoImobiliario.Application.DTOs.Response
{
    public class InquilinoResponse 
    {
        public string CPF { get; set; }
        public string Nome { get; set; }

        public InquilinoResponse(string nome, string cpf)
        {
           this.CPF = cpf;
           this.Nome = nome;
        }
    }


}
