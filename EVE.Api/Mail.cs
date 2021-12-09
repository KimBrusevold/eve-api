using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EVE.Api
{
    public class Mail
    {
        public List<Recipient> Recipients { get; set; }

        [JsonPropertyName("mail_id")]
        public int? MailId { get; set; }

        public string Subject { get; set; }
    }

    public class Recipient
    {
        [JsonPropertyName("recipient_id")]
        public int recipientId { get; set; }
        [JsonPropertyName("recipient_type")]
        public string recipientType { get; set; }
    }
}
