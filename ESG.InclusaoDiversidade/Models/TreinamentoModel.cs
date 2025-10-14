using System;
namespace ESG.InclusaoDiversidade.Models
{
	public class TreinamentoModel
	{
		public int TreinamentoID { get; set; }
		public string Titulo { get; set; } = string.Empty;
        public string? Descricao { get; set; }
		public string Tipo { get; set; } = string.Empty;
        public ICollection<ParticipacaoTreinamentoModel> Participacoes { get; set; } = new List<ParticipacaoTreinamentoModel>();

    }
}

