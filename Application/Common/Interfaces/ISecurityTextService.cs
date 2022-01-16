using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISecurityTextService
    {
        public string Crypt(string text);

        public string Decrypt(string text);
    }
}
