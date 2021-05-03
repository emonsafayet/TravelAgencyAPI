using MIS.BusinessService.CommonService;
using MIS.BusinessService.Map.ClientBusinessMap;
using MIS.Data.ClientModel;
using MIS.Data.Repositories;
using MIS.Data.SysModels;
using MIS.Dto.BusinessDTO;
using MIS.Dto.SysManage;
using MIS.Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MIS.BusinessService.BusinessService
{
    public class MasterSettingService : GenerateCodeService
    {
        ClientBusinessEntities clientContext = new ClientBusinessEntities();
        SysManageEntities systemContext = new SysManageEntities();

        public Exception Error = new Exception();

        //POST Company Profile
        public CompanyProfile saveUpdateCompanyProfile(CompanyProfileDTO companyProfile)
        {
            try
            { 

                //MAP
                var  newItem = new CompanyProfileMap().map(companyProfile);

                if (newItem.CompanyName == null || newItem.CompanyName == "") throw new Exception("Company name is empty.");

                //Delete Previous Data               
                systemContext.Database.ExecuteSqlCommand("TRUNCATE TABLE CompanyProfile");

                newItem.CreatedOn = DateTime.Now;

                if (companyProfile.CompanyLogo != null) UploadCompanyLogo(companyProfile.CompanyLogo);

                return new SysManageGenericRepository<CompanyProfile>().Insert(newItem);
                
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public bool UploadCompanyLogo(string BaseString)
        {
            try
            {
                System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/File/image/" ));

                string Path = HttpContext.Current.Server.MapPath("~/File/image/");


                if (File.Exists(Path))
                {
                    byte[] byteArry = File.ReadAllBytes(Path);
                    File.WriteAllBytes(Path + "Logo.jpg", byteArry);
                }

                string base64 = BaseString.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64);


                File.WriteAllBytes(Path + "Logo.jpg", bytes);

                return true;
            }
            catch (Exception ex)
            {
                Error = ex;
                return false;
            }
        }

        // GET ProductService

        public CompanyProfile getCompanyProfileList()
        {
            try
            {
                return new SysManageGenericRepository<CompanyProfile>().GetAll().FirstOrDefault();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //Post ProductService

        public ProductService saveUpdateTravelProduct(ProductService productService)
        {
            try
            {
                if (productService.ServiceName == null || productService.ServiceName == "") throw new Exception("Product service name is empty.");

                if (productService != null && productService.ID > 0)
                {
                    productService.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<ProductService>().Update(productService, r => r.ID == productService.ID);
                }
                else
                {
                    productService.ServiceCode = GenerateAutoCode("PS", DateTime.Now.ToString());
                    productService.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<ProductService>().Insert(productService);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // GET ProductService

        public List<ProductService> getTravelProductServiceList()
        {
            try
            {
                return new BusinessManageGenericRepository<ProductService>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // POST COUNTRY 
        public Country saveUpdateCountry(Country country)
        {
            try
            {
                if (country.CountryName == null || country.CountryName == "") throw new Exception("Product service name is empty.");

                if (country != null && country.ID > 0)
                {
                    country.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Country>().Update(country, r => r.ID == country.ID);
                }
                else
                {
                    country.CountryCode = GenerateAutoCode("CO", DateTime.Now.ToString());
                    country.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<Country>().Insert(country);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // GET COUNTRY 
        public List<Country> GetCountryList()
        {
            try
            {
                return new BusinessManageGenericRepository<Country>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        // POST DESTINATION 
        public Destination saveUpdateDestination(Destination destination)
        {
            try
            {
                if (destination.DestinationName == null || destination.DestinationName == "") throw new Exception("Destination name is empty.");

                if (destination != null && destination.ID > 0)
                {
                    destination.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Destination>().Update(destination, r => r.ID == destination.ID);
                }
                else
                {
                    destination.DestinationCode = GenerateAutoCode("DES", DateTime.Now.ToString());
                    destination.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<Destination>().Insert(destination);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // GET DESTINATION 
        public List<DestinationDto> GetDestinationList()
        {
            try
            {
                 return new BusinessManageGenericRepository<DestinationDto>().FindUsingSP("getDestinationDetails").ToList() ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //public List<DestinationDto> GetDestinationList()
        //{
        //    try
        //    {
        //        return new BusinessManageGenericRepository<DestinationDto>().FindUsingSP("getDestinationDetails").OrderByDescending(u => u.ID).ToList();
        //    }
        //    catch (Exception ex) { Error = ex; return null; }
        //}

        // POST saveUpdateProvider 
        public Provider saveUpdateProvider(Provider provider)
        {
            try
            {
                if (provider.ProviderName == null || provider.ProviderName == "") throw new Exception("provider name is empty.");
                if (provider.OpeningBalance == null) provider.OpeningBalance = 0;

                if (provider != null && provider.ID > 0)
                {
                    provider.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Provider>().Update(provider, r => r.ID == provider.ID);
                }
                else
                {
                    provider.ProviderCode = GenerateAutoCode("PRV", DateTime.Now.ToString());
                   
                    provider.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<Provider>().Insert(provider);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET PROVIDER LIST 

        public List<Provider> getProviderList()
        {
            try
            {
                return new BusinessManageGenericRepository<Provider>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // POST Airline 
        public TravelAirline saveUpdateAirline(TravelAirline airline)
        {
            try
            {
                if (airline.AirlinesName == null || airline.AirlinesName == "") throw new Exception("Airline name is empty.");
                if (airline.OpeningBalance == null) airline.OpeningBalance = 0;

                if (airline != null && airline.ID > 0)
                {
                    airline.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<TravelAirline>().Update(airline, r => r.ID == airline.ID);
                }
                else
                {
                    airline.AirlinesCode = GenerateAutoCode("TA", DateTime.Now.ToString());

                    airline.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<TravelAirline>().Insert(airline);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET Airline LIST 

        public List<TravelAirline> getAirlineList()
        {
            try
            {
                return new BusinessManageGenericRepository<TravelAirline>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // POST Customer Type 
        public CustomerType saveUpdateCustomerType(CustomerType customerType)
        {
            try
            {
                if (customerType.TypeName == null || customerType.TypeName == "") throw new Exception("Customer Type name is empty."); 

                if (customerType != null && customerType.ID > 0)
                {
                    customerType.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<CustomerType>().Update(customerType, r => r.ID == customerType.ID);
                }
                else
                {
                    customerType.TypeCode = GenerateAutoCode("CT",DateTime.Now.ToString());

                    customerType.CreatedOn = DateTime.Now; 
                    return new BusinessManageGenericRepository<CustomerType>().Insert(customerType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET  Customer Type  LIST 

        public List<CustomerType> getCustomerTypeList()
        {
            try
            {
                return new BusinessManageGenericRepository<CustomerType>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        // POST Payment Type         
        public PaymentType saveUpdatePaymentType(PaymentType paymentType)
        {
            try
            {
                if (paymentType.PaymentTypeName == null || paymentType.PaymentTypeName == "") throw new Exception("Payment Type name is empty.");

                if (paymentType != null && paymentType.ID > 0)
                {
                    paymentType.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<PaymentType>().Update(paymentType, r => r.ID == paymentType.ID);
                }
                else
                {
                    paymentType.PaymentTypeCode = GenerateAutoCode("PT", DateTime.Now.ToString());

                    paymentType.CreatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<PaymentType>().Insert(paymentType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET  Payment Type  LIST 
        public List<PaymentType> getPaymentTypeList()
        {
            try
            {
                return new BusinessManageGenericRepository<PaymentType>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        // POST Currency      
        public Currency saveUpdateCurrency(Currency currency)
        {
            try
            {
                if (currency.CurrencyName == null || currency.CurrencyName == "") throw new Exception("Currency is empty.");

                if (currency != null && currency.ID > 0)
                {
                    currency.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Currency>().Update(currency, r => r.ID == currency.ID);
                }
                else
                {   
                    currency.CreatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Currency>().Insert(currency);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Currency
        public List<Currency> getCurrencyList()
        {
            try
            {
                return new BusinessManageGenericRepository<Currency>().GetAll().OrderByDescending(u => u.ID).ToList(); ;
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        // POST Currency Rate     
        public CurrencyConversationHistory saveUpdateCurrencyRate(CurrencyConversationHistory currencyConversationHistory)
        {
            try
            {
                if (currencyConversationHistory.Currency == null || currencyConversationHistory.Currency == "") throw new Exception("Currency is empty.");
                
                //Update
                if (currencyConversationHistory != null && currencyConversationHistory.ID > 0)
                {
                    currencyConversationHistory.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<CurrencyConversationHistory>().Update(currencyConversationHistory, r => r.ID == currencyConversationHistory.ID);
                }
                //Insert
                else
                {
                    //InActive Previous Rate By Currency             
                    clientContext.Database.ExecuteSqlCommand("UPDATE CurrencyConversationHistory SET isActive=0 WHERE Currency='" + currencyConversationHistory.Currency + "' ");
                    currencyConversationHistory.CurrencyRateCode = GenerateAutoCode("CUR", DateTime.Now.ToString());
                    currencyConversationHistory.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<CurrencyConversationHistory>().Insert(currencyConversationHistory);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Currency Conversation Rate List       
        public List<CurrencyConversationHistory> GETCurrencyRateLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<CurrencyConversationHistory>().GetAll().OrderBy(o=>o.Order).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // POST Customer      
        public Customer saveUpdateCustomer(CustomerDto customerDto)
        {
            try
            {
                if (customerDto.CustomerName == null || customerDto.CustomerName == "") throw new Exception("customer is empty.");

                //MAP
                Customer newItem = new CustomerMap().map(customerDto);

                if (newItem == null)
                {
                    Error = new Exception("Failed to map Customer Model. Please try again");
                    return null;
                }

                if (customerDto != null && customerDto.ID > 0)
                {
                    Customer ExistingCustomerrMapObj = new BusinessManageGenericRepository<Customer>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                    newItem.CreatedOn = ExistingCustomerrMapObj.CreatedOn;

                    newItem.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Customer>().Update(newItem, r => r.ID == newItem.ID);
                     
                }
                else
                {


                    newItem.CustomerCode = GenerateAutoCode("CUS", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<Customer>().Insert(newItem);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET Customer List For Drop Down
        public List<CustomerDto> getDropDownCustomerList()
        {
            try
            {
                return new BusinessManageGenericRepository<CustomerDto>().FindUsingSP("getCustomerList").OrderBy(i => i.CustomerName).ToList();

            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Customer
        public List<CustomerDto> getCustomerList()
        {
            try
            { 
                return new BusinessManageGenericRepository<CustomerDto>().FindUsingSP("getCustomerList").OrderByDescending(i=>i.ID).ToList();

            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST Package
        public PackageMaster savePackage(PackageMasterDTO packageMasterNew)
        {
            try
            {
                PackageMaster newPackMaster=new PackageMaster();
                PackageMaster newItem = new PackageMaster();


                //MAP
                newItem = new PackageMasterMap().map(packageMasterNew);
                newItem.PackageName = packageMasterNew.PackageName;
                newItem.Summary = packageMasterNew.Summary;

                newItem.NoOfDay = packageMasterNew.NoOfDay;
                newItem.NoOfNight = packageMasterNew.NoOfNight;
                newItem.TotalPackagePrice = packageMasterNew.TotalPackagePrice;
                newItem.isActive = packageMasterNew.isActive;

                //save on package Details Table
                JSONSerialize serialize = new JSONSerialize();
                List<PackageDetailDTO> reqItems = serialize.ObjectToJSONText<PackageDetailDTO>(packageMasterNew.packageDetails);
                if (reqItems == null) throw new Exception("Data is empty.");

                if (packageMasterNew.PackageCode==null)
                {
                    //INSERT
                    newItem.PackageCode = GenerateAutoCode("PACK", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    newItem.UpdatedOn = null;


                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map package Model. Please try again");
                        return null;
                    }

                    newPackMaster = new BusinessManageGenericRepository<PackageMaster>().Insert(newItem);

                    //Master VALIDATION
                    if (newPackMaster == null) return null; 

                    foreach (PackageDetailDTO item in reqItems)
                    {

                        item.PackageCode = newPackMaster.PackageCode;
                        item.EventName = item.EventName;
                        item.EventDetails = item.EventDetails;
                        item.EventPrice = item.EventPrice;
                        item.Remarks = item.Remarks;

                        PackageDetail packageDetails = new PackageDetailMap().map(item);

                        //Details VALIDATION
                        if (packageDetails == null) return null;

                        packageDetails = new BusinessManageGenericRepository<PackageDetail>().Insert(packageDetails);
                    }
                }
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    newPackMaster = new BusinessManageGenericRepository<PackageMaster>().Update(newItem,i=>i.ID==newItem.ID);
                     
                     //DELETE EXISTING DETAILS
                     
                     var ExistingDetailsListObj=new BusinessManageGenericRepository<PackageDetail>().Find(i=>i.PackageCode==newItem.PackageCode);  
                  
                     foreach (PackageDetail item in ExistingDetailsListObj)
                     { 
                        new BusinessManageGenericRepository<PackageDetail>().Delete(l => l.ID == item.ID); 
                     } 

                    // Update Details List                  

                    foreach (PackageDetailDTO item in reqItems)
                     {
                  
                         item.PackageCode = newPackMaster.PackageCode;
                         item.EventName = item.EventName;
                         item.EventDetails = item.EventDetails;
                         item.EventPrice = item.EventPrice;
                         item.Remarks = item.Remarks;
                  
                         PackageDetail packageDetails = new PackageDetailMap().map(item);
                  
                         //Details VALIDATION
                         if (packageDetails == null) return null;
                  
                         packageDetails = new BusinessManageGenericRepository<PackageDetail>().Insert(packageDetails);
                     }


                }
                return newPackMaster;
            }

            catch (Exception ex) { Error = ex; return null; }

        }

        //Get TourPackage Details packCode
        public List<PackageDetail> getPackageDetailsByIDList(string packCode)
        {
            try
            {
                return new BusinessManageGenericRepository<PackageDetail>().Find(l=>l.PackageCode== packCode).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Package
        public List<PackageMasterDTO> getPackageDetailsList()
        {
            try
            {
                List<PackageMasterDTO> data = new List<PackageMasterDTO>();

                List<PackageMaster> packageMasterList= new BusinessManageGenericRepository<PackageMaster>().GetAll().OrderByDescending(u => u.ID).ToList();

                foreach( var item in packageMasterList)
                {
                    PackageMasterDTO dataItem = new PackageMasterDTO();

                    dataItem = new PackageMasterMap().DtoMap(item);

                    dataItem.PackageDetailList = new BusinessManageGenericRepository<PackageDetail>().Find(e=>e.PackageCode == dataItem.PackageCode).ToList();

                    data.Add(dataItem);
                }

                return data;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Card
        public List<CardMaster> getcardList()
        {
            try
            {
                return new BusinessManageGenericRepository<CardMaster>().GetAll().OrderByDescending(c=>c.ID).ToList();

            }  
            
            catch (Exception ex) { Error = ex; return null; }
        }


        // POST Card      
        public CardMaster saveUpdateCardMaster(CardMaster cardMaster)
        {
            try
            {
                if (cardMaster.CardName == null || cardMaster.CardName == "") throw new Exception("Card Name is empty.");

                if (cardMaster != null && cardMaster.ID > 0)
                {
                    cardMaster.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<CardMaster>().Update(cardMaster, r => r.ID == cardMaster.ID);
                }
                else
                {
                    cardMaster.CreatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<CardMaster>().Insert(cardMaster);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET CARD TYPE
        public List<CardType> getCardTypeList()
        {
            try
            {
                return new BusinessManageGenericRepository<CardType>().GetAll().OrderByDescending(c => c.ID).ToList();

            }

            catch (Exception ex) { Error = ex; return null; }
        }

        // POST CARD  TYPE     
        public CardType saveUpdateCardTYPEMaster(CardType cardType)
        {
            try
            {
                if (cardType.CardTypeName == null || cardType.CardTypeName == "") throw new Exception("Card Type Name is empty.");

                if (cardType != null && cardType.ID > 0)
                {
                    cardType.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<CardType>().Update(cardType, r => r.ID == cardType.ID);
                }
                else
                {
                    cardType.CreatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<CardType>().Insert(cardType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

         //GET CITY BY COUNTRY CODE
        public List<City> getCityByCountryCodeList(string countryCode)
        {
            try
            {
                return new BusinessManageGenericRepository<City>().Find(c=>c.CountryCode == countryCode).ToList();

            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET CITY
        public List<City> getCityList()
        {
            try
            {
                return new BusinessManageGenericRepository<City>().GetAll().OrderByDescending(c => c.ID).ToList();

            }

            catch (Exception ex) { Error = ex; return null; }
        }

        // POST City 
        public City saveUpdateCity(City city)
        {
            try
            {
                if (city.CityName == null || city.CityName == "") throw new Exception("City Name is empty.");

                if (city != null && city.ID > 0)
                {
                    city.UpdatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<City>().Update(city, r => r.ID == city.ID);
                }
                else
                {
                    city.CreatedOn = DateTime.Now;
                    return new BusinessManageGenericRepository<City>().Insert(city);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST Hotel Type
        public HotelType SaveUpdateHotelType(HotelType hotelType)
        {
            try
            {
                if (hotelType != null && hotelType.ID > 0)
                {
                    hotelType.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<HotelType>().Update(hotelType, r => r.ID == hotelType.ID);
                }
                else
                {
                    hotelType.HotelTypeCode = GenerateAutoCode("HTP", DateTime.Now.ToString());
                    hotelType.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<HotelType>().Insert(hotelType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Hotel Type Lists
        public List<HotelType> GetHotelTypeList()
        {
            try
            {
                return new BusinessManageGenericRepository<HotelType>().GetAll().ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST Room Type
        public RoomType SaveUpdateRoomtype(RoomType roomType)
        {
            try
            {
                if (roomType != null && roomType.ID > 0)
                {
                    roomType.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<RoomType>().Update(roomType, r => r.ID == roomType.ID);
                }
                else
                {
                    roomType.RoomTypeCode = GenerateAutoCode("RMT", DateTime.Now.ToString());
                    roomType.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<RoomType>().Insert(roomType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Room Type Lists
        public List<RoomType> GetRoomTypeList()
        {
            try
            {
                return new BusinessManageGenericRepository<RoomType>().GetAll().ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Seat Type Lists
        public List<SeatType> GetSeatTypeLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<SeatType>().GetAll().ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //POST Seat Type
        public SeatType SaveUpdateSeatType(SeatType seatType)
        {
            try
            {
                if (seatType != null && seatType.ID > 0)
                {
                    seatType.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<SeatType>().Update(seatType, r => r.ID == seatType.ID);
                }
                else
                {
                    seatType.SeatTypeCode = GenerateAutoCode("SeatType", DateTime.Now.ToString());
                    seatType.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<SeatType>().Insert(seatType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Post topUpType
        public TopUpType SaveUpdateTopUpType(TopUpType topUpType)
        {
            try
            {
                if (topUpType.TopUpTypeName == null || topUpType.TopUpTypeName == "") throw new Exception("Top up Type Name name is empty.");

                if (topUpType != null && topUpType.ID > 0)
                {
                    topUpType.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<TopUpType>().Update(topUpType, r => r.ID == topUpType.ID);
                }
                else
                {
                    topUpType.TopUpTypeCode = GenerateAutoCode("TopUpType", DateTime.Now.ToString());
                    topUpType.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<TopUpType>().Insert(topUpType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET BANK Lists
        public List<Bank> GetBankList()
        {
            try
            {
                return new BusinessManageGenericRepository<Bank>().GetAll().ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

    }
}
