using ModelosConsultaMedica.Data;

namespace ModelosConsultaMedica.Models
{
    public class Atendente : ApplicationUser
    {
        public string Nome { get; set; } = null!;
    }
}
