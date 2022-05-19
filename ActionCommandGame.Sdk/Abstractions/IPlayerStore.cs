using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionCommandGame.Sdk.Abstractions
{
    public interface IPlayerStore
    {
        Task<int> GetTokenAsync();
        Task SaveTokenAsync(int playerId);
    }
}
