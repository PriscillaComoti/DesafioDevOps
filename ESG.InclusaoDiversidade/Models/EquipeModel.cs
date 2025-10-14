using System;
namespace ESG.InclusaoDiversidade.Models
{
	public class EquipeModel
	{
		public int EquipeID { get; set; }
		public string NomeEquipe { get; set; } = string.Empty;
        public ICollection<FuncionarioModel> Funcionarios { get; set; } = new List<FuncionarioModel>();

    }
}

