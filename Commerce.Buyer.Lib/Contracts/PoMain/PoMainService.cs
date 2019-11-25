using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Commerce.Buyer.Lib.Contracts.PoMain.ContractDefinition;

namespace Commerce.Buyer.Lib.Contracts.PoMain
{
    public partial class PoMainService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PoMainDeployment poMainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PoMainDeployment>().SendRequestAndWaitForReceiptAsync(poMainDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PoMainDeployment poMainDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PoMainDeployment>().SendRequestAsync(poMainDeployment);
        }

        public static async Task<PoMainService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PoMainDeployment poMainDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, poMainDeployment, cancellationTokenSource);
            return new PoMainService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PoMainService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ReportSalesOrderCancelFailureRequestAsync(ReportSalesOrderCancelFailureFunction reportSalesOrderCancelFailureFunction)
        {
             return ContractHandler.SendRequestAsync(reportSalesOrderCancelFailureFunction);
        }

        public Task<TransactionReceipt> ReportSalesOrderCancelFailureRequestAndWaitForReceiptAsync(ReportSalesOrderCancelFailureFunction reportSalesOrderCancelFailureFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reportSalesOrderCancelFailureFunction, cancellationToken);
        }

        public Task<string> ReportSalesOrderCancelFailureRequestAsync(ulong ethPoNumber)
        {
            var reportSalesOrderCancelFailureFunction = new ReportSalesOrderCancelFailureFunction();
                reportSalesOrderCancelFailureFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(reportSalesOrderCancelFailureFunction);
        }

        public Task<TransactionReceipt> ReportSalesOrderCancelFailureRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var reportSalesOrderCancelFailureFunction = new ReportSalesOrderCancelFailureFunction();
                reportSalesOrderCancelFailureFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reportSalesOrderCancelFailureFunction, cancellationToken);
        }

        public Task<string> CancelPurchaseOrderRequestAsync(CancelPurchaseOrderFunction cancelPurchaseOrderFunction)
        {
             return ContractHandler.SendRequestAsync(cancelPurchaseOrderFunction);
        }

        public Task<TransactionReceipt> CancelPurchaseOrderRequestAndWaitForReceiptAsync(CancelPurchaseOrderFunction cancelPurchaseOrderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelPurchaseOrderFunction, cancellationToken);
        }

        public Task<string> CancelPurchaseOrderRequestAsync(ulong ethPoNumber)
        {
            var cancelPurchaseOrderFunction = new CancelPurchaseOrderFunction();
                cancelPurchaseOrderFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(cancelPurchaseOrderFunction);
        }

        public Task<TransactionReceipt> CancelPurchaseOrderRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var cancelPurchaseOrderFunction = new CancelPurchaseOrderFunction();
                cancelPurchaseOrderFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelPurchaseOrderFunction, cancellationToken);
        }

        public Task<string> SwitchDebugOnRequestAsync(SwitchDebugOnFunction switchDebugOnFunction)
        {
             return ContractHandler.SendRequestAsync(switchDebugOnFunction);
        }

        public Task<string> SwitchDebugOnRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SwitchDebugOnFunction>();
        }

        public Task<TransactionReceipt> SwitchDebugOnRequestAndWaitForReceiptAsync(SwitchDebugOnFunction switchDebugOnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(switchDebugOnFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SwitchDebugOnRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SwitchDebugOnFunction>(null, cancellationToken);
        }

        public Task<string> WritePoToEventLogRequestAsync(WritePoToEventLogFunction writePoToEventLogFunction)
        {
             return ContractHandler.SendRequestAsync(writePoToEventLogFunction);
        }

        public Task<TransactionReceipt> WritePoToEventLogRequestAndWaitForReceiptAsync(WritePoToEventLogFunction writePoToEventLogFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(writePoToEventLogFunction, cancellationToken);
        }

        public Task<string> WritePoToEventLogRequestAsync(ulong ethPoNumber)
        {
            var writePoToEventLogFunction = new WritePoToEventLogFunction();
                writePoToEventLogFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(writePoToEventLogFunction);
        }

        public Task<TransactionReceipt> WritePoToEventLogRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var writePoToEventLogFunction = new WritePoToEventLogFunction();
                writePoToEventLogFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(writePoToEventLogFunction, cancellationToken);
        }

        public Task<string> ReportSalesOrderNotApprovedRequestAsync(ReportSalesOrderNotApprovedFunction reportSalesOrderNotApprovedFunction)
        {
             return ContractHandler.SendRequestAsync(reportSalesOrderNotApprovedFunction);
        }

        public Task<TransactionReceipt> ReportSalesOrderNotApprovedRequestAndWaitForReceiptAsync(ReportSalesOrderNotApprovedFunction reportSalesOrderNotApprovedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reportSalesOrderNotApprovedFunction, cancellationToken);
        }

        public Task<string> ReportSalesOrderNotApprovedRequestAsync(ulong ethPoNumber)
        {
            var reportSalesOrderNotApprovedFunction = new ReportSalesOrderNotApprovedFunction();
                reportSalesOrderNotApprovedFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(reportSalesOrderNotApprovedFunction);
        }

        public Task<TransactionReceipt> ReportSalesOrderNotApprovedRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var reportSalesOrderNotApprovedFunction = new ReportSalesOrderNotApprovedFunction();
                reportSalesOrderNotApprovedFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reportSalesOrderNotApprovedFunction, cancellationToken);
        }

        public Task<string> BusinessPartnerStorageQueryAsync(BusinessPartnerStorageFunction businessPartnerStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BusinessPartnerStorageFunction, string>(businessPartnerStorageFunction, blockParameter);
        }

        
        public Task<string> BusinessPartnerStorageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BusinessPartnerStorageFunction, string>(null, blockParameter);
        }

        public Task<GetSalesOrderNumberByEthPoNumberOutputDTO> GetSalesOrderNumberByEthPoNumberQueryAsync(GetSalesOrderNumberByEthPoNumberFunction getSalesOrderNumberByEthPoNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSalesOrderNumberByEthPoNumberFunction, GetSalesOrderNumberByEthPoNumberOutputDTO>(getSalesOrderNumberByEthPoNumberFunction, blockParameter);
        }

        public Task<GetSalesOrderNumberByEthPoNumberOutputDTO> GetSalesOrderNumberByEthPoNumberQueryAsync(ulong ethPoNumber, BlockParameter blockParameter = null)
        {
            var getSalesOrderNumberByEthPoNumberFunction = new GetSalesOrderNumberByEthPoNumberFunction();
                getSalesOrderNumberByEthPoNumberFunction.EthPoNumber = ethPoNumber;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetSalesOrderNumberByEthPoNumberFunction, GetSalesOrderNumberByEthPoNumberOutputDTO>(getSalesOrderNumberByEthPoNumberFunction, blockParameter);
        }

        public Task<string> PoStorageQueryAsync(PoStorageFunction poStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoStorageFunction, string>(poStorageFunction, blockParameter);
        }

        
        public Task<string> PoStorageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PoStorageFunction, string>(null, blockParameter);
        }

        public Task<ulong> GetLatestPoNumberQueryAsync(GetLatestPoNumberFunction getLatestPoNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLatestPoNumberFunction, ulong>(getLatestPoNumberFunction, blockParameter);
        }

        
        public Task<ulong> GetLatestPoNumberQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLatestPoNumberFunction, ulong>(null, blockParameter);
        }

        public Task<string> ConfigureRequestAsync(ConfigureFunction configureFunction)
        {
             return ContractHandler.SendRequestAsync(configureFunction);
        }

        public Task<TransactionReceipt> ConfigureRequestAndWaitForReceiptAsync(ConfigureFunction configureFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(configureFunction, cancellationToken);
        }

        public Task<string> ConfigureRequestAsync(string nameOfPoStorage, string nameOfProductStorage, string nameOfBusinessPartnerStorage, string nameOfFundingContract)
        {
            var configureFunction = new ConfigureFunction();
                configureFunction.NameOfPoStorage = nameOfPoStorage;
                configureFunction.NameOfProductStorage = nameOfProductStorage;
                configureFunction.NameOfBusinessPartnerStorage = nameOfBusinessPartnerStorage;
                configureFunction.NameOfFundingContract = nameOfFundingContract;
            
             return ContractHandler.SendRequestAsync(configureFunction);
        }

        public Task<TransactionReceipt> ConfigureRequestAndWaitForReceiptAsync(string nameOfPoStorage, string nameOfProductStorage, string nameOfBusinessPartnerStorage, string nameOfFundingContract, CancellationTokenSource cancellationToken = null)
        {
            var configureFunction = new ConfigureFunction();
                configureFunction.NameOfPoStorage = nameOfPoStorage;
                configureFunction.NameOfProductStorage = nameOfProductStorage;
                configureFunction.NameOfBusinessPartnerStorage = nameOfBusinessPartnerStorage;
                configureFunction.NameOfFundingContract = nameOfFundingContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(configureFunction, cancellationToken);
        }

        public Task<string> SetSalesOrderNumberByEthPoNumberRequestAsync(SetSalesOrderNumberByEthPoNumberFunction setSalesOrderNumberByEthPoNumberFunction)
        {
             return ContractHandler.SendRequestAsync(setSalesOrderNumberByEthPoNumberFunction);
        }

        public Task<TransactionReceipt> SetSalesOrderNumberByEthPoNumberRequestAndWaitForReceiptAsync(SetSalesOrderNumberByEthPoNumberFunction setSalesOrderNumberByEthPoNumberFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSalesOrderNumberByEthPoNumberFunction, cancellationToken);
        }

        public Task<string> SetSalesOrderNumberByEthPoNumberRequestAsync(ulong ethPoNumber, byte[] sellerSysId, byte[] sellerSalesOrderNumber)
        {
            var setSalesOrderNumberByEthPoNumberFunction = new SetSalesOrderNumberByEthPoNumberFunction();
                setSalesOrderNumberByEthPoNumberFunction.EthPoNumber = ethPoNumber;
                setSalesOrderNumberByEthPoNumberFunction.SellerSysId = sellerSysId;
                setSalesOrderNumberByEthPoNumberFunction.SellerSalesOrderNumber = sellerSalesOrderNumber;
            
             return ContractHandler.SendRequestAsync(setSalesOrderNumberByEthPoNumberFunction);
        }

        public Task<TransactionReceipt> SetSalesOrderNumberByEthPoNumberRequestAndWaitForReceiptAsync(ulong ethPoNumber, byte[] sellerSysId, byte[] sellerSalesOrderNumber, CancellationTokenSource cancellationToken = null)
        {
            var setSalesOrderNumberByEthPoNumberFunction = new SetSalesOrderNumberByEthPoNumberFunction();
                setSalesOrderNumberByEthPoNumberFunction.EthPoNumber = ethPoNumber;
                setSalesOrderNumberByEthPoNumberFunction.SellerSysId = sellerSysId;
                setSalesOrderNumberByEthPoNumberFunction.SellerSalesOrderNumber = sellerSalesOrderNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSalesOrderNumberByEthPoNumberFunction, cancellationToken);
        }

        public Task<string> CreatePurchaseOrderRequestAsync(CreatePurchaseOrderFunction createPurchaseOrderFunction)
        {
             return ContractHandler.SendRequestAsync(createPurchaseOrderFunction);
        }

        public Task<TransactionReceipt> CreatePurchaseOrderRequestAndWaitForReceiptAsync(CreatePurchaseOrderFunction createPurchaseOrderFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPurchaseOrderFunction, cancellationToken);
        }

        public Task<string> CreatePurchaseOrderRequestAsync(Po po)
        {
            var createPurchaseOrderFunction = new CreatePurchaseOrderFunction();
                createPurchaseOrderFunction.Po = po;
            
             return ContractHandler.SendRequestAsync(createPurchaseOrderFunction);
        }

        public Task<TransactionReceipt> CreatePurchaseOrderRequestAndWaitForReceiptAsync(Po po, CancellationTokenSource cancellationToken = null)
        {
            var createPurchaseOrderFunction = new CreatePurchaseOrderFunction();
                createPurchaseOrderFunction.Po = po;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createPurchaseOrderFunction, cancellationToken);
        }

        public Task<GetPoByEthPoNumberOutputDTO> GetPoByEthPoNumberQueryAsync(GetPoByEthPoNumberFunction getPoByEthPoNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPoByEthPoNumberFunction, GetPoByEthPoNumberOutputDTO>(getPoByEthPoNumberFunction, blockParameter);
        }

        public Task<GetPoByEthPoNumberOutputDTO> GetPoByEthPoNumberQueryAsync(ulong ethPoNumber, BlockParameter blockParameter = null)
        {
            var getPoByEthPoNumberFunction = new GetPoByEthPoNumberFunction();
                getPoByEthPoNumberFunction.EthPoNumber = ethPoNumber;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPoByEthPoNumberFunction, GetPoByEthPoNumberOutputDTO>(getPoByEthPoNumberFunction, blockParameter);
        }

        public Task<GetPoByBuyerPoNumberOutputDTO> GetPoByBuyerPoNumberQueryAsync(GetPoByBuyerPoNumberFunction getPoByBuyerPoNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPoByBuyerPoNumberFunction, GetPoByBuyerPoNumberOutputDTO>(getPoByBuyerPoNumberFunction, blockParameter);
        }

        public Task<GetPoByBuyerPoNumberOutputDTO> GetPoByBuyerPoNumberQueryAsync(byte[] buyerSystemId, byte[] buyerPoNumber, BlockParameter blockParameter = null)
        {
            var getPoByBuyerPoNumberFunction = new GetPoByBuyerPoNumberFunction();
                getPoByBuyerPoNumberFunction.BuyerSystemId = buyerSystemId;
                getPoByBuyerPoNumberFunction.BuyerPoNumber = buyerPoNumber;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPoByBuyerPoNumberFunction, GetPoByBuyerPoNumberOutputDTO>(getPoByBuyerPoNumberFunction, blockParameter);
        }

        public Task<string> FundingContractQueryAsync(FundingContractFunction fundingContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FundingContractFunction, string>(fundingContractFunction, blockParameter);
        }

        
        public Task<string> FundingContractQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FundingContractFunction, string>(null, blockParameter);
        }

        public Task<string> ProductStorageQueryAsync(ProductStorageFunction productStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProductStorageFunction, string>(productStorageFunction, blockParameter);
        }

        
        public Task<string> ProductStorageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProductStorageFunction, string>(null, blockParameter);
        }

        public Task<GetSalesOrderNumberByBuyerPoNumberOutputDTO> GetSalesOrderNumberByBuyerPoNumberQueryAsync(GetSalesOrderNumberByBuyerPoNumberFunction getSalesOrderNumberByBuyerPoNumberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSalesOrderNumberByBuyerPoNumberFunction, GetSalesOrderNumberByBuyerPoNumberOutputDTO>(getSalesOrderNumberByBuyerPoNumberFunction, blockParameter);
        }

        public Task<GetSalesOrderNumberByBuyerPoNumberOutputDTO> GetSalesOrderNumberByBuyerPoNumberQueryAsync(byte[] buyerSystemId, byte[] buyerPoNumber, BlockParameter blockParameter = null)
        {
            var getSalesOrderNumberByBuyerPoNumberFunction = new GetSalesOrderNumberByBuyerPoNumberFunction();
                getSalesOrderNumberByBuyerPoNumberFunction.BuyerSystemId = buyerSystemId;
                getSalesOrderNumberByBuyerPoNumberFunction.BuyerPoNumber = buyerPoNumber;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetSalesOrderNumberByBuyerPoNumberFunction, GetSalesOrderNumberByBuyerPoNumberOutputDTO>(getSalesOrderNumberByBuyerPoNumberFunction, blockParameter);
        }

        public Task<string> SwitchDebugOffRequestAsync(SwitchDebugOffFunction switchDebugOffFunction)
        {
             return ContractHandler.SendRequestAsync(switchDebugOffFunction);
        }

        public Task<string> SwitchDebugOffRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SwitchDebugOffFunction>();
        }

        public Task<TransactionReceipt> SwitchDebugOffRequestAndWaitForReceiptAsync(SwitchDebugOffFunction switchDebugOffFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(switchDebugOffFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SwitchDebugOffRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SwitchDebugOffFunction>(null, cancellationToken);
        }

        public Task<string> RefundPoToBuyerRequestAsync(RefundPoToBuyerFunction refundPoToBuyerFunction)
        {
             return ContractHandler.SendRequestAsync(refundPoToBuyerFunction);
        }

        public Task<TransactionReceipt> RefundPoToBuyerRequestAndWaitForReceiptAsync(RefundPoToBuyerFunction refundPoToBuyerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(refundPoToBuyerFunction, cancellationToken);
        }

        public Task<string> RefundPoToBuyerRequestAsync(ulong ethPoNumber)
        {
            var refundPoToBuyerFunction = new RefundPoToBuyerFunction();
                refundPoToBuyerFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(refundPoToBuyerFunction);
        }

        public Task<TransactionReceipt> RefundPoToBuyerRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var refundPoToBuyerFunction = new RefundPoToBuyerFunction();
                refundPoToBuyerFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(refundPoToBuyerFunction, cancellationToken);
        }

        public Task<string> ReleasePoFundsToSellerRequestAsync(ReleasePoFundsToSellerFunction releasePoFundsToSellerFunction)
        {
             return ContractHandler.SendRequestAsync(releasePoFundsToSellerFunction);
        }

        public Task<TransactionReceipt> ReleasePoFundsToSellerRequestAndWaitForReceiptAsync(ReleasePoFundsToSellerFunction releasePoFundsToSellerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(releasePoFundsToSellerFunction, cancellationToken);
        }

        public Task<string> ReleasePoFundsToSellerRequestAsync(ulong ethPoNumber)
        {
            var releasePoFundsToSellerFunction = new ReleasePoFundsToSellerFunction();
                releasePoFundsToSellerFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(releasePoFundsToSellerFunction);
        }

        public Task<TransactionReceipt> ReleasePoFundsToSellerRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var releasePoFundsToSellerFunction = new ReleasePoFundsToSellerFunction();
                releasePoFundsToSellerFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(releasePoFundsToSellerFunction, cancellationToken);
        }

        public Task<string> ReportSalesOrderInvoiceFaultRequestAsync(ReportSalesOrderInvoiceFaultFunction reportSalesOrderInvoiceFaultFunction)
        {
             return ContractHandler.SendRequestAsync(reportSalesOrderInvoiceFaultFunction);
        }

        public Task<TransactionReceipt> ReportSalesOrderInvoiceFaultRequestAndWaitForReceiptAsync(ReportSalesOrderInvoiceFaultFunction reportSalesOrderInvoiceFaultFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reportSalesOrderInvoiceFaultFunction, cancellationToken);
        }

        public Task<string> ReportSalesOrderInvoiceFaultRequestAsync(ulong ethPoNumber)
        {
            var reportSalesOrderInvoiceFaultFunction = new ReportSalesOrderInvoiceFaultFunction();
                reportSalesOrderInvoiceFaultFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAsync(reportSalesOrderInvoiceFaultFunction);
        }

        public Task<TransactionReceipt> ReportSalesOrderInvoiceFaultRequestAndWaitForReceiptAsync(ulong ethPoNumber, CancellationTokenSource cancellationToken = null)
        {
            var reportSalesOrderInvoiceFaultFunction = new ReportSalesOrderInvoiceFaultFunction();
                reportSalesOrderInvoiceFaultFunction.EthPoNumber = ethPoNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reportSalesOrderInvoiceFaultFunction, cancellationToken);
        }

        public Task<bool> IsDebugOnQueryAsync(IsDebugOnFunction isDebugOnFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsDebugOnFunction, bool>(isDebugOnFunction, blockParameter);
        }

        
        public Task<bool> IsDebugOnQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsDebugOnFunction, bool>(null, blockParameter);
        }

        public Task<string> AddressRegistryQueryAsync(AddressRegistryFunction addressRegistryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressRegistryFunction, string>(addressRegistryFunction, blockParameter);
        }

        
        public Task<string> AddressRegistryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressRegistryFunction, string>(null, blockParameter);
        }
    }
}
