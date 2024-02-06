using Infomedia.Server.Models.RequestDto;
using Infomedia.Server.Models.ResponseDto;
using Infomedia.Server.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Infomedia.Server.Services.Implementations
{
    public class Queries : BaseService, IQueries
    {
        private readonly HttpClient _httpClient;
        public Queries(IConfiguration configuration, HttpClient httpClient) : base(configuration) 
        {
            _httpClient = httpClient;
        }


        public async Task<PurchaseResponseDto> PurchaseTransactionAsync(PurchaseInputDto inputDto)
        {
            // Createing HttpClient
            var httpClient = new HttpClient();

            // Adding CacheControl and ApiKey as defined in documentation
            httpClient.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");

            httpClient.DefaultRequestHeaders.Add("X-Infomedia-Api-Key", ApiKey);

            var uri = "https://api.infomedia.co.uk/dcbsb/SendBillWithPin";

            // Creating object that we are sending to api
            var postObj = new TransactionInputDto(inputDto.MSISDN, inputDto.PIN);
            var jsonPostObj = JsonConvert.SerializeObject(postObj);
            HttpResponseMessage response;
            using (var content = new StringContent(jsonPostObj, Encoding.UTF8, "application/json"))
            {
                // Sending Object
                response = await httpClient.PostAsync(uri, content);

                // Reading response and initializing it to new object
                string responseBody = await response.Content.ReadAsStringAsync();
                var transactionResponse = JsonConvert.DeserializeObject<TransactionResponseDto>(responseBody);
                

                // Inserting the transaction into the database
                InsertTransaction(transactionResponse!);

                // If everything was a success we will return status true and transaction ID
                if (transactionResponse!.status.Equals("Success"))
                {
                    if (transactionResponse.conf.status.Equals("Success"))
                    {
                        return new PurchaseResponseDto { status = true, txid = transactionResponse.txid };
                    }
                }
                // In case something went wrong we return status false and transaction ID
                return new PurchaseResponseDto { status = false, txid = transactionResponse!.txid };
            }
        }

        public async Task SendNotificationAsync(PurchaseResponseDto inputDto)
        {
            // Declaring out notification endpoint and inserting the data as provided in the task
            string notificationUri = $"https://www.infomedia.co.uk/?txid={inputDto.txid}&status={(inputDto.status ? 1 : 0)}";

            HttpResponseMessage notificationResponse = await _httpClient.GetAsync(notificationUri);

            // First we check if the response is Unsuccessful and we return string
            if(!notificationResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Error forwarding to notification endpoint: " + notificationResponse.ReasonPhrase);
            } 
            else
            {
                Console.WriteLine("Success forwarding to notification endpoint!");
            }
        }

        private void InsertTransaction(TransactionResponseDto transactionResponse)
        {
            // Creating connection to database
            using (var conn = Connection)
            {
                conn.Open();
                // Creating query to insert new row into table Transactions
                string insertQuery = @"INSERT INTO [dbo].[Transactions] (
	                                                [ThirdPartyID]
	                                                ,[MSISDN]
	                                                ,[TransactionDate]
	                                                ,[Status]
	                                                )
                                                VALUES (
	                                                @ThirdPartyID
	                                                ,@MSISDN
	                                                ,@TransactionDate
	                                                ,@Status
	                                                )";

                // Making/Executing SQL command and populating the data
                using (var command = new SqlCommand(insertQuery, conn))
                {
                    command.Parameters.AddWithValue("@ThirdPartyID", transactionResponse.txid);
                    command.Parameters.AddWithValue("@MSISDN", transactionResponse.mx);
                    command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Status", transactionResponse.conf.description);
                    
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
