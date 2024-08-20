﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Domain.Providers.Kavenegar.Entities.Requests
{
    public class SimpleSendDto
    {
        public string Receptor { get; set; }
        public string Message { get; set; }
        public string Sender { get; set; }
        public long Date { get; set; }
        public string @Type { get; set; }
        public long LocalId { get; set; }
        public short Hide { get; set; }



    }
}
