using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF inválido.")]
    public string CPF { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Email inválido.")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Nome inválido.")]
    public string Nome { get; set; }
}