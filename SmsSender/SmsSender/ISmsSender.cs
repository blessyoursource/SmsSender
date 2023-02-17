using System;
using System.Collections.Generic;
using System.Text;
using SMS4B;

namespace SmsSender.SmsSender
{
    interface ISmsSender
    {
        long phone { get; set; }
        string text { get; set; }
        void send();
    }
}
