namespace Infomedia.Server.Models.RequestDto
{
    public class TransactionInputDto
    {
        public int bpid { get; set; }
        public string pt { get; set; }
        public string mx { get; set; }
        public int mnc { get; set; }
        public int mcc { get; set; }
        public decimal amount { get; set; }
        public string itemDescription { get; set; }
        public string u { get; set; }
        public string p { get; set; }
        public string pin { get; set; }

        public TransactionInputDto(string msisdn, string pin)
        {
            bpid = 91000000;
            pt = "Your pass-through";
            mx = msisdn;
            mnc = 99;
            mcc = 234;
            amount = 1;
            itemDescription = "100 Coins";
            u = "username";
            p = "password";
            pin = pin;
        }
    }
}
