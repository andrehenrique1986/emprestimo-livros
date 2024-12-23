namespace EmprestimoLivros.API.Models
{

    public class Cliente
    {
       
        public int Id { get; set; }
        
        public string Nome { get; set; }
       
        public string CPF { get; set; }
       
        public string Endereco { get; set; }
       
        public string Cidade { get; set; }
        
        public string Bairro { get; set; }
    }
}
