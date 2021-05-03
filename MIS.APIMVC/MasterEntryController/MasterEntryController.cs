using MIS.BusinessService.BusinessService;
using MIS.BusinessService.Map.ClientBusinessMap;
using MIS.Data.ClientModel;
using MIS.Data.SysModels;
using MIS.Dto.BusinessDTO;
using MIS.Dto.SysManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MIS.APIMVC.MasterEntryController
{
    public class MasterEntryController : ApiController
    {
        public MasterSettingService masterSettingService = new MasterSettingService();

        //POST Company Profile 
        [HttpPost]
        [Route("~/api/client/business/company/profile/save/update")]
        public HttpResponseMessage saveUpdateCompanyProfile(CompanyProfileDTO companyProfile)
        {
            try
            { 

                return MISResponse.Return(masterSettingService.saveUpdateCompanyProfile(companyProfile), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET  Company Profile
        [HttpGet]
        [Route("~/api/client/business/company/profile/list")]
        public HttpResponseMessage getCompanyProfileList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCompanyProfileList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST Travel Product Service
        [HttpPost]
        [Route("~/api/client/business/travel/product/service/save/update")]
        public HttpResponseMessage saveUpdateTravelProduct(ProductService productService)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateTravelProduct(productService), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        //GET Travel Product Service
        [HttpGet]
        [Route("~/api/client/business/travel/product/service/list")]
        public HttpResponseMessage getTravelProductServiceList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getTravelProductServiceList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }        

        //POST COUNTRY
        [HttpPost]
        [Route("~/api/client/business/travel/country/save/update")]
        public HttpResponseMessage saveUpdateCountry(Country country)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCountry(country), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Country LIST
        [HttpGet]
        [Route("~/api/client/business/travel/country/list")]
        public HttpResponseMessage GetCountryList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.GetCountryList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //POST DESTINATION
        [HttpPost]
        [Route("~/api/client/business/travel/Destination/save/update")]
        public HttpResponseMessage SaveUpdateDestination(Destination destination)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateDestination(destination), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET DESTINATION LIST
        [HttpGet]
        [Route("~/api/client/business/travel/destination/list")]
        public HttpResponseMessage GetDestinationList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.GetDestinationList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST PROVIDER
        [HttpPost]
        [Route("~/api/client/business/travel/Provider/save/update")]
        public HttpResponseMessage SaveUpdateProvider(Provider provider)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateProvider(provider), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET PORVIDER LIST
        [HttpGet]
        [Route("~/api/client/business/travel/provider/list")]
        public HttpResponseMessage getProviderList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getProviderList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //POST AIRLINE
        [HttpPost]
        [Route("~/api/client/business/travel/Airline/save/update")]
        public HttpResponseMessage saveUpdateProvider(TravelAirline airline)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateAirline(airline), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET AIRLINE LIST
        [HttpGet]
        [Route("~/api/client/business/travel/Airline/list")]
        public HttpResponseMessage getAirlineList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getAirlineList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //POST CUSTOMER TYPE
        [HttpPost]
        [Route("~/api/client/business/travel/customer/type/save/update")]
        public HttpResponseMessage saveUpdateCustomerType(CustomerType customerType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCustomerType(customerType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET CUSTOMER TYPE LIST
        [HttpGet]
        [Route("~/api/client/business/travel/customer/type/list")]
        public HttpResponseMessage getCustomerTypeList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCustomerTypeList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //POST Payment TYPE
        [HttpPost]
        [Route("~/api/client/business/travel/payment/type/save/update")]
        public HttpResponseMessage saveUpdatePaymentType(PaymentType paymentType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdatePaymentType(paymentType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET Payment TYPE LIST
        [HttpGet]
        [Route("~/api/client/business/travel/payment/type/list")]
        public HttpResponseMessage getPaymentTypeList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getPaymentTypeList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        //POST Currency
        [HttpPost]
        [Route("~/api/client/business/travel/currency/save/update")]
        public HttpResponseMessage saveUpdateCurrency(Currency currency)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCurrency(currency), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET Currency LIST
        [HttpGet]
        [Route("~/api/client/business/travel/currency/list")]
        public HttpResponseMessage getCurrencyList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCurrencyList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST Currency Rate

        [HttpPost]
        [Route("~/api/client/business/travel/currency/rate/save/update")]
        public HttpResponseMessage saveUpdateCurrencyRate(CurrencyConversationHistory currencyConversationHistory)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCurrencyRate(currencyConversationHistory), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Currency Rate List
        [HttpGet]
        [Route("~/api/client/business/travel/Currency/Rate/list")]
        public HttpResponseMessage GETCurrencyRateLIST()
        {
            try
            {
                return MISResponse.Return(masterSettingService.GETCurrencyRateLIST(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST Customer
        [HttpPost]
        [Route("~/api/client/business/travel/customer/save/update")]
        public HttpResponseMessage saveUpdateCustomer(CustomerDto customerDto)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCustomer(customerDto), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        //GET Customer LIST
        [HttpGet]
        [Route("~/api/client/business/travel/customer/dropDown/list")]
        public HttpResponseMessage getDropDownCustomerList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getDropDownCustomerList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET Customer LIST
        [HttpGet]
        [Route("~/api/client/business/travel/customer/list")]
        public HttpResponseMessage getcustomerList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCustomerList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        } 


        //GET package Details By PackCode
        [HttpGet]
        [Route("~/api/client/business/travel/package/details/list/package/code/{packageCode}")]
        public HttpResponseMessage getPackageDetailsByIDList(string packageCode)
        {
            try
            {
                return MISResponse.Return(masterSettingService.getPackageDetailsByIDList(packageCode), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //POST package
        [HttpPost]
        [Route("~/api/client/business/travel/package/save")]
        public HttpResponseMessage savePackage([FromBody] PackageMasterDTO packageMasterDto)
        {
            // return ResponseMiddleware.Return(service.saveChemistSpecialRate(Discount), service.Error, Request);
            try
            {
                return MISResponse.Return(masterSettingService.savePackage(packageMasterDto), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //GET Package LIST
        [HttpGet]
        [Route("~/api/client/business/travel/package/list")]
        public HttpResponseMessage getPackageList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getPackageDetailsList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST CardInfo
        [HttpPost]
        [Route("~/api/client/business/travel/card/info/save/update")]
        public HttpResponseMessage saveUpdateCard(CardMaster cardMaster)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCardMaster(cardMaster), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET CardInfo LIST
        [HttpGet]
        [Route("~/api/client/business/travel/card/info/list")]
        public HttpResponseMessage getcardList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getcardList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST Card TYPE Info
        [HttpPost]
        [Route("~/api/client/business/travel/card/type/info/save/update")]
        public HttpResponseMessage saveUpdateCardTYPEMaster(CardType cardType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCardTYPEMaster(cardType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET Card TYPE Info LIST
        [HttpGet]
        [Route("~/api/client/business/travel/card/type/info/list")]
        public HttpResponseMessage getCardTypeList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCardTypeList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //POST CITY
        [HttpPost]
        [Route("~/api/client/business/travel/city/save/update")]
        public HttpResponseMessage saveUpdateCity(City city)
        {
            try
            {
                return MISResponse.Return(masterSettingService.saveUpdateCity(city), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //GET CITY LIST
        [HttpGet]
        [Route("~/api/client/business/travel/city/info/list")]
        public HttpResponseMessage getCityList()
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCityList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET CITY LIST BY COUNTRY CODE
        [HttpGet]
        [Route("~/api/client/business/travel/city/info/list/by/country/code/{countryCode}")]
        public HttpResponseMessage getCityByCountryCodeList(string countryCode)
        {
            try
            {
                return MISResponse.Return(masterSettingService.getCityByCountryCodeList(countryCode), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET Seat Type
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/Seat/Type/list")]
        public HttpResponseMessage GETSeatTypeLIST()
        {

            try
            {
                return MISResponse.Return(masterSettingService.GetSeatTypeLIST(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //POST Seat Type
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/Seat/Type/save/update")]
        public HttpResponseMessage SaveUpdateSeatType(SeatType seatType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.SaveUpdateSeatType(seatType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET Room Type
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/hotel/Room/Type/list")]
        public HttpResponseMessage GETHotelRoomTypeLIST()
        {

            try
            {
                return MISResponse.Return(masterSettingService.GetRoomTypeList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //POST Room Type
        [HttpPost]
        [Route("~/api/client/business/travel/transactionSeat/hotel/Room/type/save/update")]
        public HttpResponseMessage SaveUpdateHotelRoomType(RoomType roomType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.SaveUpdateRoomtype(roomType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET hotel Type
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/hotel/type/list")]
        public HttpResponseMessage GETHotelLIST()
        {

            try
            {
                return MISResponse.Return(masterSettingService.GetHotelTypeList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //POST hotel Type
        [HttpPost]
        [Route("~/api/client/business/travel/transactionSeat/hotel/type/save/update")]
        public HttpResponseMessage SaveUpdateHotelType(HotelType hotelType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.SaveUpdateHotelType(hotelType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //POST TopUp Type
        [HttpPost]
        [Route("~/api/client/business/travel/transaction/topUp/Type/save/update")]
        public HttpResponseMessage saveUpdateToUpType(TopUpType topUpType)
        {
            try
            {
                return MISResponse.Return(masterSettingService.SaveUpdateTopUpType(topUpType), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //GET BANK
        [HttpGet]
        [Route("~/api/client/business/travel/transaction/bank/list")]
        public HttpResponseMessage GetBankList()
        {

            try
            {
                return MISResponse.Return(masterSettingService.GetBankList(), masterSettingService.Error, Request);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
