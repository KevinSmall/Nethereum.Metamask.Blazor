using Commerce.Buyer.Lib.Models;
using Commerce.Metamask.Blazor.Server.Models;
using Commerce.Metamask.Blazor.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Commerce.Metamask.Blazor.Server.Components
{
    public class DisplayEventsBase : ComponentBase
    {
        [Microsoft.AspNetCore.Components.Parameter]
        public SettingsModel Settings { get; set; }

        [Microsoft.AspNetCore.Components.Parameter]
        public string BuyerPoNumber { get; set; }

        public ulong StartBlock { get; set; }
        public string EventLog01 { get; set; }
        public string EventLog02 { get; set; }
        public string EventLog03 { get; set; }
        public string EventLog04 { get; set; }
        public string EventLog05 { get; set; }
        public string EventLog06 { get; set; }

        public string AdditionalMessage { get; set; }
        public bool IsBusy { get; private set; }

        [Inject]
        public IWalletBuyer WalletBuyer { get; set; }

        protected override void OnInitialized()
        {
            ClearEventLogs();
            StartBlock = 0;
            base.OnInitialized();
        }

        private void ClearEventLogs()
        {
            EventLog01 = string.Empty;
            EventLog02 = string.Empty;
            EventLog03 = string.Empty;
            EventLog04 = string.Empty;
            EventLog05 = string.Empty;
            EventLog06 = string.Empty;
        }

        protected async Task GetEvents()
        {
            IsBusy = true;
            ClearEventLogs();
            try
            {
                // Main event reading
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                var logs = await WalletBuyer.Lib.EventLogs.GetEventLogsForPoAsync(BuyerPoNumber);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                var currentblockHex = await WalletBuyer.Lib.Wallet.Web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                ulong currentBlock = (ulong)(currentblockHex.Value);

                if (logs.Length == 0)
                {
                    EventLog01 = "No logs found";
                }
                else
                {
                    if (logs.Length >= 1)
                    {
                        EventLog01 = FormatLog(logs[0]);
                    }
                    if (logs.Length >= 2)
                    {
                        EventLog02 = FormatLog(logs[1]);
                    }
                    if (logs.Length >= 3)
                    {
                        EventLog03 = FormatLog(logs[2]);
                    }
                    if (logs.Length >= 4)
                    {
                        EventLog04 = FormatLog(logs[3]);
                    }
                    if (logs.Length >= 5)
                    {
                        EventLog05 = FormatLog(logs[4]);
                    }
                    if (logs.Length >= 6)
                    {
                        EventLog06 = FormatLog(logs[5]);
                    }
                    if (logs.Length >= 7)
                    {
                        EventLog06 = "more events not shown (adjust start block to see subset)";
                    }
                }
                ulong blockCount = currentBlock - StartBlock;
                AdditionalMessage = $"Searched {blockCount} blocks from {StartBlock} to {currentBlock} and found {logs.Length} events in {ts.TotalSeconds} seconds";

            }
            catch (Exception ex)
            {
                AdditionalMessage = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private string FormatLog(EventLogModel log)
        {
            return $"{log.EventName} {log.BlockDate} {log.BlockTime} block: {log.BlockNumber}";
        }
    }
}
