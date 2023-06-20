namespace EleicaoDigital.Application.Models.InputModel
{
    public record LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
