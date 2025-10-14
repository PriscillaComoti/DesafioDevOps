using System;
namespace ESG.InclusaoDiversidade.Models
{
	public class ParticipacaoTreinamentoModel
	{
		public int ParticipacaoID { get; set; }
		public int FuncionarioID { get; set; }
		public FuncionarioModel? Funcionario { get; set; }
		public int TreinamentoID { get; set; }
		public TreinamentoModel? Treinamento { get; set; }
		public DateTime DataParticipacao { get; set; }
		public int Estrelas { get; set; }

    }
}

