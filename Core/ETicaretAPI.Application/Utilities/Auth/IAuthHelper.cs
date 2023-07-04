using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Utilities.Auth
{
    public interface IAuthHelper
    {
        int GetUserId();
        string GetUsername();
        string GetEmail();


    }
}
