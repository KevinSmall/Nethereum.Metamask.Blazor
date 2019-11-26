using Commerce.Buyer.Lib.Contracts.WalletBuyer.ContractDefinition;
using Commerce.Buyer.Lib.Models;
using Common.Logging;
using Nethereum.Contracts;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Buyer.Lib.Services
{
    public class EventLogs : IEventLogs
    {
        private IWallet _wallet;
        private IPurchaseOrder _purchaseOrder;
        private ILog _log;
        private IFieldMapper _mapper;

        public EventLogs(IWallet wallet, IPurchaseOrder purchaseOrder, IFieldMapper mapper, ILog log)
        {
            _wallet = wallet;
            _purchaseOrder = purchaseOrder;
            _mapper = mapper;
            _log = log;
        }

        public async Task<EventLogModel[]> GetEventLogsForPoAsync(string buyerPoNumber, ulong startBlock = 0, ulong endBlock = 0)
        {
            EventLogModel[] elms = new EventLogModel[] { };
            var po = await _purchaseOrder.GetPoAsync(buyerPoNumber);
            if (po == null || (po != null && po.EthPurchaseOrderNumber == 0))
            {
                return elms;
            }
            else
            {
                return await GetEventLogsForPoAsync(po.EthPurchaseOrderNumber, startBlock, endBlock);
            }
        }

        public async Task<EventLogModel[]> GetEventLogsForPoAsync(ulong ethPoNumber, ulong startBlock = 0, ulong endBlock = 0)
        {
            /*
                01 PurchaseRaisedOkLog
                02 PurchaseCancelRequestedOkLog
                03 PurchaseUpdatedWithSalesOrderOkLog
                04 PurchasePaymentMadeOkLog
                05 PurchasePaymentFailedLog
                06 PurchaseRefundMadeOkLog
                07 PurchaseRefundFailedLog
                08 SalesOrderCancelFailedLog
                09 SalesOrderNotApprovedLog
                10 SalesOrderInvoiceFaultLog
            */

            if (endBlock == 0)
            {
                endBlock = (ulong)(await _wallet.Web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
            }
            var address = _wallet.Info.WalletBuyerAddress;
            var range = new BlockRange(startBlock, endBlock);
            var web3 = _wallet.Web3;

            var filter01 = new FilterInputBuilder<PurchaseRaisedOkLogEventDTO>()
                 .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
                 .Build(address, range);
            var filterLogs01 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter01);

            var filter02 = new FilterInputBuilder<PurchaseCancelRequestedOkLogEventDTO>()
                .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
                .Build(address, range);
            var filterLogs02 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter02);

            var filter03 = new FilterInputBuilder<PurchaseUpdatedWithSalesOrderOkLogEventDTO>()
                .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
                .Build(address, range);
            var filterLogs03 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter03);

            var filter04 = new FilterInputBuilder<PurchasePaymentMadeOkLogEventDTO>()
                .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
                .Build(address, range);
            var filterLogs04 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter04);

            var filter05 = new FilterInputBuilder<PurchasePaymentFailedLogEventDTO>()
                .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
                .Build(address, range);
            var filterLogs05 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter05);

            var filter06 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
                .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
                .Build(address, range);
            var filterLogs06 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter06);

            var filter07 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
              .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
              .Build(address, range);
            var filterLogs07 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter07);

            var filter08 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
              .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
              .Build(address, range);
            var filterLogs08 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter08);

            var filter09 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
              .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
              .Build(address, range);
            var filterLogs09 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter09);

            var filter10 = new FilterInputBuilder<PurchaseRefundMadeOkLogEventDTO>()
              .AddTopic(e => e.EthPurchaseOrderNumber, ethPoNumber)
              .Build(address, range);
            var filterLogs10 = await web3.Eth.Filters.GetLogs.SendRequestAsync(filter10);

            // Merge the logs, converting them to EventLogModels
            var elmAll = new List<EventLogModel>();

            foreach (var item in filterLogs01)
            {
                var decodedLog = item.DecodeEvent<PurchaseRaisedOkLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchaseRaisedOkLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs02)
            {
                var decodedLog = item.DecodeEvent<PurchaseCancelRequestedOkLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchaseCancelRequestedOkLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs03)
            {
                var decodedLog = item.DecodeEvent<PurchaseUpdatedWithSalesOrderOkLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchaseUpdatedWithSalesOrderOkLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs04)
            {
                var decodedLog = item.DecodeEvent<PurchasePaymentMadeOkLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchasePaymentMadeOkLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs05)
            {
                var decodedLog = item.DecodeEvent<PurchasePaymentFailedLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchasePaymentFailedLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs06)
            {
                var decodedLog = item.DecodeEvent<PurchaseRefundMadeOkLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchaseRefundMadeOkLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs07)
            {
                var decodedLog = item.DecodeEvent<PurchaseRefundFailedLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("PurchaseRefundFailedLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs08)
            {
                var decodedLog = item.DecodeEvent<SalesOrderCancelFailedLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("SalesOrderCancelFailedLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs09)
            {
                var decodedLog = item.DecodeEvent<SalesOrderNotApprovedLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("SalesOrderNotApprovedLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            foreach (var item in filterLogs10)
            {
                var decodedLog = item.DecodeEvent<SalesOrderInvoiceFaultLogEventDTO>();
                if (decodedLog != null)
                {
                    var elm = await BuildEventLogModelAsync("SalesOrderInvoiceFaultLog", decodedLog.Log, decodedLog.Event.Po);
                    if (elm != null) elmAll.Add(elm);
                }
            }

            return elmAll.ToArray();
        }

        public async Task<EventLogModel[]> GetEventLogsForAllPosAsync(ulong startBlock, ulong endBlock)
        {
            // TODO could rewrite using Blockchain Processing instead
            /*
                01 PurchaseRaisedOkLog
                02 PurchaseCancelRequestedOkLog
                03 PurchaseUpdatedWithSalesOrderOkLog
                04 PurchasePaymentMadeOkLog
                05 PurchasePaymentFailedLog
                06 PurchaseRefundMadeOkLog
                07 PurchaseRefundFailedLog
                08 SalesOrderCancelFailedLog
                09 SalesOrderNotApprovedLog
                10 SalesOrderInvoiceFaultLog
             */
            var address = _wallet.Info.WalletBuyerAddress;
            var startBlockP = new BlockParameter(startBlock);
            var endBlockP = new BlockParameter(endBlock);
            var web3 = _wallet.Web3;

            var eventHandler01 = web3.Eth.GetEvent<PurchaseRaisedOkLogEventDTO>(address);
            var filter01 = eventHandler01.CreateFilterInput(startBlockP, endBlockP);
            var logs01 = await eventHandler01.GetAllChanges(filter01);

            var eventHandler02 = web3.Eth.GetEvent<PurchaseCancelRequestedOkLogEventDTO>(address);
            var filter02 = eventHandler02.CreateFilterInput(startBlockP, endBlockP);
            var logs02 = await eventHandler02.GetAllChanges(filter02);

            var eventHandler03 = web3.Eth.GetEvent<PurchaseUpdatedWithSalesOrderOkLogEventDTO>(address);
            var filter03 = eventHandler03.CreateFilterInput(startBlockP, endBlockP);
            var logs03 = await eventHandler03.GetAllChanges(filter03);

            var eventHandler04 = web3.Eth.GetEvent<PurchasePaymentMadeOkLogEventDTO>(address);
            var filter04 = eventHandler04.CreateFilterInput(startBlockP, endBlockP);
            var logs04 = await eventHandler04.GetAllChanges(filter04);

            var eventHandler05 = web3.Eth.GetEvent<PurchasePaymentFailedLogEventDTO>(address);
            var filter05 = eventHandler05.CreateFilterInput(startBlockP, endBlockP);
            var logs05 = await eventHandler05.GetAllChanges(filter05);

            var eventHandler06 = web3.Eth.GetEvent<PurchaseRefundMadeOkLogEventDTO>(address);
            var filter06 = eventHandler06.CreateFilterInput(startBlockP, endBlockP);
            var logs06 = await eventHandler06.GetAllChanges(filter06);

            var eventHandler07 = web3.Eth.GetEvent<PurchaseRefundFailedLogEventDTO>(address);
            var filter07 = eventHandler07.CreateFilterInput(startBlockP, endBlockP);
            var logs07 = await eventHandler07.GetAllChanges(filter07);

            var eventHandler08 = web3.Eth.GetEvent<SalesOrderCancelFailedLogEventDTO>(address);
            var filter08 = eventHandler08.CreateFilterInput(startBlockP, endBlockP);
            var logs08 = await eventHandler08.GetAllChanges(filter08);

            var eventHandler09 = web3.Eth.GetEvent<SalesOrderNotApprovedLogEventDTO>(address);
            var filter09 = eventHandler09.CreateFilterInput(startBlockP, endBlockP);
            var logs09 = await eventHandler09.GetAllChanges(filter09);

            var eventHandler10 = web3.Eth.GetEvent<SalesOrderInvoiceFaultLogEventDTO>(address);
            var filter10 = eventHandler10.CreateFilterInput(startBlockP, endBlockP);
            var logs10 = await eventHandler10.GetAllChanges(filter10);

            // Merge the logs, converting them to EventLogModels
            var elmAll = new List<EventLogModel>();

            foreach (var item in logs01)
            {
                var elm = await BuildEventLogModelAsync("PurchaseRaisedOkLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs02)
            {
                var elm = await BuildEventLogModelAsync("PurchaseCancelRequestedOkLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs03)
            {
                var elm = await BuildEventLogModelAsync("PurchaseUpdatedWithSalesOrderOkLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs04)
            {
                var elm = await BuildEventLogModelAsync("PurchasePaymentMadeOkLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs05)
            {
                var elm = await BuildEventLogModelAsync("PurchasePaymentFailedLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs06)
            {
                var elm = await BuildEventLogModelAsync("PurchaseRefundMadeOkLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs07)
            {
                var elm = await BuildEventLogModelAsync("PurchaseRefundFailedLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs08)
            {
                var elm = await BuildEventLogModelAsync("SalesOrderCancelFailedLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs09)
            {
                var elm = await BuildEventLogModelAsync("SalesOrderNotApprovedLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            foreach (var item in logs10)
            {
                var elm = await BuildEventLogModelAsync("SalesOrderInvoiceFaultLog", item.Log, item.Event.Po);
                if (elm != null) elmAll.Add(elm);
            }

            return elmAll.ToArray();
        }

        private async Task<EventLogModel> BuildEventLogModelAsync(string eventName, FilterLog filterLog, Po po)
        {
            var timestamp = await GetBlockTimeStampAsync(filterLog.BlockNumber);
            return new EventLogModel
            {
                BlockNumber = filterLog.BlockNumber,
                TransactionHash = filterLog.TransactionHash,
                TransactionIndex = filterLog.TransactionIndex,
                LogIndex = filterLog.LogIndex,
                Timestamp = timestamp,
                BlockDate = timestamp.ToString("yyyy-MM-dd"),
                BlockTime = timestamp.ToString("HH:mm:ss"),
                EventName = eventName,
                Po = _mapper.MapFieldsPoToPoModel(po)
            };
        }

        private async Task<DateTime> GetBlockTimeStampAsync(HexBigInteger blockNumber)
        {
            var block = await _wallet.Web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new BlockParameter(blockNumber));
            var time = (int)block.Timestamp.Value;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var date = epoch.AddSeconds(time);
            return date;
        }

    }
}
