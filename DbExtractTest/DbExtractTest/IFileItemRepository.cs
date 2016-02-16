using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DbExtractTest
{
    public interface IFileItemRepository : IDisposable
    {
        IFileItem AddOrUpdate(int id, string source);

        List<string> ParseToTokens(string source);
    }

    
}
