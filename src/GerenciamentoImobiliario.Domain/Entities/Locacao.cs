
using GerenciamentoImobiliario.Enums;
using GerenciamentoImobiliario.Exceptio;

namespace GerenciamentoImobiliario.Domain.Entities
{
    public class Locacao
    {
        public Guid Id { get; set; }
        public Guid ImovelId { get; set; }
        public Imovel Imovel { get; set; }
        public Guid InquilinoId { get; set; }
        public Inquilino Inquilino { get; set; }
        public Guid CorretorId { get; set; }
        public Corretor Corretor { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlugadoAte { get; set; }
        public StatusLocacao StatusLocacao { get; set; }

        public Locacao(Imovel imovel, Inquilino inquilino, Corretor corretor, DateTime alugadoAte)
        {
            this.CriadoEm = DateTime.Now;
            this.Inquilino = inquilino;
            this.Corretor = corretor;
            this.Imovel = imovel;
            this.AlugadoAte = alugadoAte;
            this.StatusLocacao = StatusLocacao.EmAndamento;
            this.ValidateInformation();
        }


        private void ValidateInformation()
        {
            if (this.Imovel is null || this.Inquilino is null || this.Corretor is null || this.AlugadoAte == DateTime.MinValue)
                throw new EntityException("Valide as Informacoes das entidades fornecidas");

            if (this.Imovel.IsDisponivel == false)
                throw new EntityException("Imovel informado esta ocupado");

            if (this.AlugadoAte <= DateTime.Now || this.AlugadoAte > DateTime.Now + TimeSpan.FromDays(30))
                throw new EntityException("Data de locacao esta invalida");
        }

    }
}
