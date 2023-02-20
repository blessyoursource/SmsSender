using System;
using System.Collections.Generic;

#nullable disable

namespace SmsSender
{
    public partial class Sender
    {
        public int IdS { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
    }
}
