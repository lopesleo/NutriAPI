using NutrIA.Models;

namespace NutrIA.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Nutricionista nutricionista);
    }
}
