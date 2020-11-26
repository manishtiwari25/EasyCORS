using EasyCORS.Models;
namespace EasyCORS.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IEasyCorsConfiguration
    {
        ValueTask<Dictionary<string, Configuration>> GetConfiguration();
    }
}
