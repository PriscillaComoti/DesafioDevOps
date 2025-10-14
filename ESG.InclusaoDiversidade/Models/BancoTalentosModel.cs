using System;
namespace ESG.InclusaoDiversidade.Models
{
	public class BancoTalentosModel
	{
		public int CandidatoID { get; set; }
		public string Nome { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string? Deficiencia { get; set; }
        public string CargoPretendido { get; set; } = string.Empty;
        public string Status { get; set; } = "Pendente";
    }
}

