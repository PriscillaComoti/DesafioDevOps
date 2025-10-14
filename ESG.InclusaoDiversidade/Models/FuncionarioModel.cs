using System;
namespace ESG.InclusaoDiversidade.Models
{
	public class FuncionarioModel
	{
        public int FuncionarioID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string? Deficiencia { get; set; }
        public string Cargo { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public int EquipeID { get; set; }
        public EquipeModel? Equipe { get; set; }
        public ICollection<ParticipacaoTreinamentoModel> Participacoes { get; set; } = new List<ParticipacaoTreinamentoModel>();


    }
}

