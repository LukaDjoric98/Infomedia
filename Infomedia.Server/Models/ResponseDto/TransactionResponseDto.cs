namespace Infomedia.Server.Models.ResponseDto
{
    public class TransactionResponseDto
    {
        public string status {  get; set; }
        public string description {  get; set; }
        public int bpid { get; set; }
        public string mx {  get; set; }
        public string txid {  get; set; }
        public int mcc {  get; set; }
        public int mnc { get; set; }
        public ConfigurationDto conf { get; set; }
    }

    public class ConfigurationDto
    {
        public string status { get; set; }
        public string description { get; set; }
        public string? portedMcc { get; set; }
        public string? portedMnc { get; set; }
    }
}
