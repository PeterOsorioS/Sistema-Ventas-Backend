using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        public void Create();
        public void Authentication();
        public Task UpdatePassword();
        public Task Delete();
    }
}
