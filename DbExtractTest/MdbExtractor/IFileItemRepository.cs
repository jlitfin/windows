using System;
using System.Collections.Generic;

namespace MdbExtractor
{
    public interface IFileItemRepository : IDisposable
    {
        IFileItem AddOrUpdate(int id, string source);

        List<string> ParseToTokens(string source);
    }

    
}
