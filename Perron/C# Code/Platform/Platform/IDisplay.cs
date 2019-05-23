using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    interface IDisplay
    {
        bool Connected { get;}
        void Connect();

        void Disconnect();

        void Send(string info);
    }
}
