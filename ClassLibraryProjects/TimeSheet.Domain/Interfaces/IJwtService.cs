using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Domain.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(string email);
    }
}
