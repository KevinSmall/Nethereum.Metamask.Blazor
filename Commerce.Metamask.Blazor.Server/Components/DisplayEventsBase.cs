using Microsoft.AspNetCore.Components;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Commerce.Metamask.Blazor.Server.Models;

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

        private Web3 _web3;

        //[Inject]
        //public HttpClient Client { get; set; }

        protected override void OnInitialized()
        {
            //_web3 = new Web3(Settings.BlockchainUrl);
            //ClearEventLogs();
            //StartBlock = Settings.BlockNumberValidAtAppStartup;
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
                //var wbs = new WalletBuyerService(_web3, Settings.WalletBuyerAddress);

                //// Check PO number exists for the buyer source system id (which is retrieved from the buyer wallet)
                //var poMainAddress = await wbs.PoMainQueryAsync();
                //var poms = new PoMainService(_web3, poMainAddress);
                //var buyerSysId = await wbs.SystemIdQueryAsync();
                //var buyerSysIdAsString = ConversionUtils.ConvertBytes32ArrayToString(buyerSysId);
                //var buyerPoNumberAsBytes = ConversionUtils.ConvertStringToBytes32Array(BuyerPoNumber);
                //var po = await poms.GetPoByBuyerPoNumberQueryAsync(buyerSysId, buyerPoNumberAsBytes);

                //if (po != null && po.Po != null && po.Po.EthPurchaseOrderNumber != 0)
                //{
                //    // PO exists, get events that have happened since app startup    
                //    ulong currentBlockNum = (ulong)(await _web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;

                //    // Main event reading
                //    Stopwatch stopWatch = new Stopwatch();
                //    stopWatch.Start();
                //    var logs = await GetEventLogsForPoAsync(StartBlock, currentBlockNum, po.Po.EthPurchaseOrderNumber);
                //    stopWatch.Stop();
                //    TimeSpan ts = stopWatch.Elapsed;

                //    if (logs.Length == 0)
                //    {
                //        EventLog01 = "No logs found";
                //    }
                //    else
                //    {
                //        if (logs.Length >= 1)
                //        {
                //            EventLog01 = FormatLog(logs[0]);
                //        }
                //        if (logs.Length >= 2)
                //        {
                //            EventLog02 = FormatLog(logs[1]);
                //        }
                //        if (logs.Length >= 3)
                //        {
                //            EventLog03 = FormatLog(logs[2]);
                //        }
                //        if (logs.Length >= 4)
                //        {
                //            EventLog04 = FormatLog(logs[3]);
                //        }
                //        if (logs.Length >= 5)
                //        {
                //            EventLog05 = FormatLog(logs[4]);
                //        }
                //        if (logs.Length >= 6)
                //        {
                //            EventLog06 = FormatLog(logs[5]);
                //        }
                //        if (logs.Length >= 7)
                //        {
                //            EventLog06 = "more events not shown (adjust start block to see subset)";
                //        }
                //    }
                //    AdditionalMessage = $"Read blocks {StartBlock} to {currentBlockNum} and found {logs.Length} events in {ts.TotalSeconds} seconds";
                //}
                //else
                //{
                //    AdditionalMessage = $"Buyer PO {BuyerPoNumber} does not exist";
                //}
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

        //public async Task<EventLogModel[]> GetEventLogsForPoAsync(ulong startBlock, ulong endBlock, ulong poNumber)
        //{
        //    /*
        //        01 PurchaseRaisedOkLog
        //        02 PurchaseCancelRequestedOkLog
        //        03 PurchaseUpdatedWithSalesOrderOkLog
        //        04 PurchasePaymentMadeOkLog
        //        05 PurchasePaymentFailedLog
        //        06 PurchaseRefundMadeOkLog
        //        07 PurchaseRefundFailedLog
        //        08 SalesOrderCancelFailedLog
        //        09 SalesOrderNotApprovedLog
        //        10 SalesOrderInvoiceFaultLog
        //     */

        //    var filter01 = new FilterInputBuilder<PurchaseRaisedOkLogEventDTO>()
        //        .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //        .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs01 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter01);

        //    var filter02 = new FilterInputBuilder<PurchaseCancelRequestedOkLogEventDTO>()
        //        .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //        .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs02 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter02);

        //    var filter03 = new FilterInputBuilder<PurchaseUpdatedWithSalesOrderOkLogEventDTO>()
        //        .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //        .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs03 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter03);

        //    var filter04 = new FilterInputBuilder<PurchasePaymentMadeOkLogEventDTO>()
        //        .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //        .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs04 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter04);

        //    var filter05 = new FilterInputBuilder<PurchasePaymentFailedLogEventDTO>()
        //        .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //        .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs05 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter05);

        //    var filter06 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
        //        .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //        .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs06 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter06);

        //    var filter07 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
        //      .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //      .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs07 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter07);

        //    var filter08 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
        //      .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //      .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs08 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter08);

        //    var filter09 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
        //      .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //      .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs09 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter09);

        //    var filter10 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
        //      .AddTopic(e => e.EthPurchaseOrderNumber, poNumber)
        //      .Build(contractAddress: Settings.WalletBuyerAddress, new BlockRange(startBlock, endBlock));
        //    var filterLogs10 = await _web3.Eth.Filters.GetLogs.SendRequestAsync(filter10);

        //    // Merge the logs, converting them to EventLogModels
        //    var elmAll = new List<EventLogModel>();

        //    foreach (var item in filterLogs01)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchaseRaisedOkLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchaseRaisedOkLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs02)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchaseCancelRequestedOkLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchaseCancelRequestedOkLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs03)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchaseUpdatedWithSalesOrderOkLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchaseUpdatedWithSalesOrderOkLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs04)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchasePaymentMadeOkLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchasePaymentMadeOkLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs05)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchasePaymentFailedLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchasePaymentFailedLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs06)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchaseRefundMadeOkLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchaseRefundMadeOkLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs07)
        //    {
        //        var decodedLog = item.DecodeEvent<PurchaseRefundFailedLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("PurchaseRefundFailedLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs08)
        //    {
        //        var decodedLog = item.DecodeEvent<SalesOrderCancelFailedLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("SalesOrderCancelFailedLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs09)
        //    {
        //        var decodedLog = item.DecodeEvent<SalesOrderNotApprovedLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("SalesOrderNotApprovedLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    foreach (var item in filterLogs10)
        //    {
        //        var decodedLog = item.DecodeEvent<SalesOrderInvoiceFaultLogEventDTO>();
        //        if (decodedLog != null)
        //        {
        //            var elm = await BuildEventLogModelAsync("SalesOrderInvoiceFaultLog", poNumber, decodedLog.Log, decodedLog.Event.Po);
        //            if (elm != null) elmAll.Add(elm);
        //        }
        //    }

        //    return elmAll.ToArray();
        //}

        ///// <summary>
        ///// Build an event log model
        ///// </summary>
        ///// <param name="poNumber">Use 0 to take all POs, or specify an ethPO number to filter by</param>
        ///// <returns>an event log model, or null if record should be filtered out</returns>
        //private async Task<EventLogModel> BuildEventLogModelAsync(string eventName, ulong poNumber, FilterLog filterLog, Po po)
        //{
        //    if (poNumber == 0 || poNumber == po.EthPurchaseOrderNumber)
        //    {
        //        var timestamp = await GetBlockTimeStampAsync(filterLog.BlockNumber);
        //        return new EventLogModel
        //        {
        //            BlockNumber = filterLog.BlockNumber,
        //            TransactionHash = filterLog.TransactionHash,
        //            TransactionIndex = filterLog.TransactionIndex,
        //            LogIndex = filterLog.LogIndex,
        //            Timestamp = timestamp,
        //            BlockDate = timestamp.ToString("yyyy-MM-dd"),
        //            BlockTime = timestamp.ToString("HH:mm:ss"),
        //            EventName = eventName
        //            //Po = _mapper.Map<PoModel>(po)
        //        };
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //private async Task<DateTime> GetBlockTimeStampAsync(HexBigInteger blockNumber)
        //{
        //    var block = await _web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(blockNumber));
        //    var time = (int)block.Timestamp.Value;
        //    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //    var date = epoch.AddSeconds(time);
        //    return date;
        //}
    }
}
