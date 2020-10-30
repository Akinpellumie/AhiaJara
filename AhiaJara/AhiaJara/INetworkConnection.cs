using System;
using System.Collections.Generic;
using System.Text;
namespace AhiaJara
{
    public interface INetworkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();
    }
}