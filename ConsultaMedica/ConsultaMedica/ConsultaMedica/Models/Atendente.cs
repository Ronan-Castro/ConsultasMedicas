using ConsultaMedica.Data;

namespace ConsultaMedica.Models
{
    public class Atendente : ApplicationUser
    {
        public string Nome { get; set; } = null!;
    }
}
