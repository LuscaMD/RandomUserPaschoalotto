using RandomUserGeneratorPaschoalotto.Domain.Entities;

namespace RandomUserGeneratorPaschoalotto.Application.Interfaces
{
    public interface IRandomUserGeneratorService
    {
        Task<List<User>> GetRandomUserAsync(int count);
    }
}
