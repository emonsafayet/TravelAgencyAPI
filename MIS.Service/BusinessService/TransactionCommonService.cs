using MIS.BusinessService.CommonService;
using MIS.BusinessService.Map.TransactionMap;
using MIS.Data.ClientModel;
using MIS.Data.Repositories;
using MIS.Dto.BusinessDTO;
using MIS.Dto.TransactionDTO;
using MIS.Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BusinessService.BusinessService
{
    public class TransactionCommonService : GenerateCodeService
    {
        public Exception Error = new Exception();
        //Post topUp

        public TopUp SaveUpdateTopUp(TopUp topUp)
        {
            try
            {
                if (topUp.ProviderID == null || topUp.ProviderID == "") throw new Exception("Top up service name is empty.");

                if (topUp != null && topUp.ID > 0)
                {
                    topUp.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<TopUp>().Update(topUp, r => r.ID == topUp.ID);
                }
                else
                {
                    topUp.TopUpCode = GenerateAutoCode("TopUp", DateTime.Now.ToString());
                    topUp.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<TopUp>().Insert(topUp);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        // GET topUp LIST

        public List<TopUpDTO> GetTopUpList()
        {
            try
            {
                return new BusinessManageGenericRepository<TopUpDTO>().FindUsingSP("getTopUpList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        // GET topUp TYPE  LIST

        public List<TopUpType> GetTopUpTypeList()
        {
            try
            {
                return new BusinessManageGenericRepository<TopUpType>().GetAll().OrderByDescending(o => o.ID).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        // GET ONLINE REGISTATION LIST

        public List<OnlineRegistationListDto> GetOnlineRegisationList()
        {
            try
            {
                return new BusinessManageGenericRepository<OnlineRegistationListDto>().FindUsingSP("getOnlineRegistationList");
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST  ONLINE REGISTATION 

        public OnlineRegMaster SaveUpdateOnlineRegisation(OnlineRegistationDTO dto)
        {

            try
            {
                OnlineRegMaster newItem = new OnlineRegMaster();
                //MAP
                newItem = new OnlineRegMasterMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();

                List<OnlineRegDetail> reqItems = serialize.ObjectToJSONText<OnlineRegDetail>(dto.OnlineRegistrationDetail);

                //INSERT 
                if (dto.TransactionCode == null)
                {
                    newItem.TransactionCode = GenerateAutoCode("REG", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;

                    newItem.UpdatedOn = null;
                    newItem.UpdatedBy = null;

                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map Registration Master. Please try again");
                        return null;
                    }
                    newItem = new BusinessManageGenericRepository<OnlineRegMaster>().Insert(newItem);
                    //Master VALIDATION
                    if (newItem == null) return null;

                    // Online Registration Details
                    foreach (OnlineRegDetail item in reqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<OnlineRegDetail>().Insert(item);
                    }
                }
                //UPDATE
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    OnlineRegMaster ExistingOnlineRegMasterMapObj = new BusinessManageGenericRepository<OnlineRegMaster>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                    newItem.CreatedOn = ExistingOnlineRegMasterMapObj.CreatedOn;

                    newItem = new BusinessManageGenericRepository<OnlineRegMaster>().Update(newItem, i => i.ID == newItem.ID);



                    //Delete existing Details Data if this will not include on Updating Data
                    List<OnlineRegDetail> existingDetailsList = new BusinessManageGenericRepository<OnlineRegDetail>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newList = (from num in existingDetailsList
                                   select num.OnlineRegDetailID).Except(reqItems.Select(y => y.OnlineRegDetailID)).ToList();
                    foreach (var item in newList)
                    {
                        new BusinessManageGenericRepository<OnlineRegDetail>().Delete(i => i.OnlineRegDetailID == item);
                    }



                    //var QS = (from std in AllStudents
                    //          select std.Name).Except(Class6Students.Select(y => y.Name)).ToList();

                    // Update Online Registration Details
                    foreach (OnlineRegDetail item in reqItems)
                    {
                        OnlineRegDetail ExistingOnlineRegDetailpObj = new BusinessManageGenericRepository<OnlineRegDetail>().Find(i => i.OnlineRegDetailID == item.OnlineRegDetailID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingOnlineRegDetailpObj != null)
                        {
                            item.CreatedOn = ExistingOnlineRegDetailpObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<OnlineRegDetail>().Update(item, i => i.OnlineRegDetailID == item.OnlineRegDetailID);
                        }

                        //Insert New Item on Update Mode
                        if (item.OnlineRegDetailID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<OnlineRegDetail>().Insert(item);
                        }

                    }
                }
                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        // GET ONLINE REGISTATION Details

        public List<OnlineRegDetail> getOnlineRegistrationDetailsByTransactionCode(string transactionCode)
        {
            try
            {
                return new BusinessManageGenericRepository<OnlineRegDetail>().Find(i => i.TransactionCode == transactionCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET Company Drop Down List
        public List<CompanyDTO> GETCompanyLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<CompanyDTO>().FindUsingSP("getCorporateCustomer");
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Sales Staff Drop Down List
        public List<SalesStaffListDto> GETSalesStaffLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<SalesStaffListDto>().FindUsingSP("getSalesStaffList");
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Active Currency Conversation Rate List
        public List<CurrencyConversationHistory> GETActiveCurrencyRateLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<CurrencyConversationHistory>().Find(p => p.isActive == true).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET VISA TYPE LIST
        public List<VisaType> GETVisaTypeLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<VisaType>().GetAll().ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST VISA REGISTATION 
        public VisaType SaveUpdateVisaType(VisaType visaType)
        {
            try
            {
                if (visaType != null && visaType.ID > 0)
                {
                    visaType.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<VisaType>().Update(visaType, r => r.ID == visaType.ID);
                }
                else
                {
                    visaType.VisaTypeCode = GenerateAutoCode("VisaType", DateTime.Now.ToString());
                    visaType.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<VisaType>().Insert(visaType);
                }
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET VISA REGISTATION LIST
        public List<VisaRegistrationList> GETVisaRegistationLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<VisaRegistrationList>().FindUsingSP("getVisaRegistationList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST VISA REGISTATION 
        public VisaMaster SaveUpdateVisaRegisation(VisaRegistationDTO dto)
        {
            try
            {
                VisaMaster newItem = new VisaMaster();
                //MAP
                newItem = new VisaRegistrationMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();

                List<VisaDetail> reqItems = serialize.ObjectToJSONText<VisaDetail>(dto.visaDetails);

                //INSERT 
                if (dto.TransactionCode == null)
                {
                    newItem.TransactionCode = GenerateAutoCode("Visa", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    newItem.CreatedBy = dto.CreatedBy;
                    newItem.UpdatedOn = null;
                    newItem.UpdatedBy = null;

                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map Visa Master. Please try again");
                        return null;
                    }
                    newItem = new BusinessManageGenericRepository<VisaMaster>().Insert(newItem);
                    //Master VALIDATION
                    if (newItem == null) return null;

                    // Airticket Registration Details
                    foreach (VisaDetail item in reqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<VisaDetail>().Insert(item);
                    }

                }
                //UPDATE
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    VisaDetail ExistingMasterMapObj = new BusinessManageGenericRepository<VisaDetail>().Find(i => i.DetailID == newItem.ID).FirstOrDefault();
                    newItem.CreatedOn = ExistingMasterMapObj.CreatedOn;

                    newItem = new BusinessManageGenericRepository<VisaMaster>().Update(newItem, i => i.ID == newItem.ID);



                    //Delete existing Details Data if this will not include on Updating Data
                    List<VisaDetail> existingDetailsList = new BusinessManageGenericRepository<VisaDetail>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newList = (from num in existingDetailsList
                                   select num.DetailID).Except(reqItems.Select(y => y.DetailID)).ToList();
                    foreach (var item in newList)
                    {
                        new BusinessManageGenericRepository<VisaDetail>().Delete(i => i.DetailID == item);
                    }

                    // Update Online Registration Details
                    foreach (VisaDetail item in reqItems)
                    {
                        VisaDetail ExistingVisaRegDetailpObj = new BusinessManageGenericRepository<VisaDetail>().Find(i => i.DetailID == item.DetailID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingVisaRegDetailpObj != null)
                        {
                            item.CreatedOn = ExistingVisaRegDetailpObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<VisaDetail>().Update(item, i => i.DetailID == item.DetailID);
                        }

                        //Insert New Item on Update Mode
                        if (item.DetailID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<VisaDetail>().Insert(item);
                        }

                    }
                }
                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET  VISA REGISTATION  Details By TransactionCode
        public List<VisaDetail> getVisaRegDetailsByTransactionCode(string transactionCode)
        {
            try
            {
                return new BusinessManageGenericRepository<VisaDetail>().Find(i => i.TransactionCode == transactionCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET AIR TICKET REGISTRATION 
        public List<AirTicketListDTO> GetAirTickeLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<AirTicketListDTO>().FindUsingSP("GetAirTicketRegistrationList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST AIR TICKET Forwaring REGISTRATION 
        public AirTicketMaster UpdateForwardAirTicketRegistration(AirTicketRegMasterDTO dto)
        {
            try
            {
                AirTicketMaster newItem = new AirTicketMaster();
                //MAP
                newItem = new AirTicketMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();

                List<AirTicketDetail> reqItems = serialize.ObjectToJSONText<AirTicketDetail>(dto.AirticketDetails);


                //MASTER UPDATE

                AirTicketMaster ExistingAirticketRegMasterMapObj = new BusinessManageGenericRepository<AirTicketMaster>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                ExistingAirticketRegMasterMapObj.UpdatedOn = DateTime.Now;
                ExistingAirticketRegMasterMapObj.NetPayableAmt = dto.NetPayableAmt;
                newItem = new BusinessManageGenericRepository<AirTicketMaster>().Update(ExistingAirticketRegMasterMapObj, i => i.ID == newItem.ID);

                // Update Forwarding Info Airticket Registration Details
                foreach (AirTicketDetail item in reqItems)
                {
                    AirTicketDetail ExistingAirticketRegDetailpObj = new BusinessManageGenericRepository<AirTicketDetail>().Find(i => i.DetailID == item.DetailID).FirstOrDefault();

                    //Update Existing Data
                    if (ExistingAirticketRegDetailpObj != null)
                    {
                        if (item.ChangePenalty != 0) item.IsForward = true;
                        item.CreatedOn = ExistingAirticketRegDetailpObj.CreatedOn;
                        item.UpdatedOn = DateTime.Now;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<AirTicketDetail>().Update(item, i => i.DetailID == item.DetailID);
                    }

                }

                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }

        }

        //POST AIR TICKET Cancellation REGISTRATION 
        public AirTicketMaster UpdateCancellingAirTicketRegistration(AirTicketRegMasterDTO dto)
        {
            try
            {
                AirTicketMaster newItem = new AirTicketMaster();
                //MAP
                newItem = new AirTicketMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();

                List<AirTicketDetail> reqItems = serialize.ObjectToJSONText<AirTicketDetail>(dto.AirticketDetails);


                //MASTER UPDATE

                AirTicketMaster ExistingAirticketRegMasterMapObj = new BusinessManageGenericRepository<AirTicketMaster>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                ExistingAirticketRegMasterMapObj.UpdatedOn = DateTime.Now;
                ExistingAirticketRegMasterMapObj.NetPayableAmt = dto.NetPayableAmt;
                newItem = new BusinessManageGenericRepository<AirTicketMaster>().Update(ExistingAirticketRegMasterMapObj, i => i.ID == newItem.ID);

                // Update Forwarding Info Airticket Registration Details
                foreach (AirTicketDetail item in reqItems)
                {
                    AirTicketDetail ExistingAirticketRegDetailpObj = new BusinessManageGenericRepository<AirTicketDetail>().Find(i => i.DetailID == item.DetailID).FirstOrDefault();

                    //Update Existing Data
                    if (ExistingAirticketRegDetailpObj != null)
                    {
                        if (item.CancellationCharge != 0) item.IsCancel = true;
                        item.CreatedOn = ExistingAirticketRegDetailpObj.CreatedOn;
                        item.UpdatedOn = DateTime.Now;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<AirTicketDetail>().Update(item, i => i.DetailID == item.DetailID);
                    }

                }

                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }

        }
        //POST AIR TICKET REGISTRATION 
        public AirTicketMaster SaveUpdateAirTicketRegisation(AirTicketRegMasterDTO dto)
        {

            try
            {
                AirTicketMaster newItem = new AirTicketMaster();
                //MAP
                newItem = new AirTicketMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();

                List<AirTicketDetail> reqItems = serialize.ObjectToJSONText<AirTicketDetail>(dto.AirticketDetails);

                //INSERT 
                if (dto.TransactionCode == null)
                {
                    newItem.TransactionCode = GenerateAutoCode("Air", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    newItem.CreatedBy = dto.CreatedBy;
                    newItem.UpdatedOn = null;
                    newItem.UpdatedBy = null;

                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map Air Ticket Registration Master. Please try again");
                        return null;
                    }
                    //Validation Details
                    if (reqItems == null)
                    {
                        Error = new Exception("Failed to map Airticket Registration Details. Please try again");
                        return null;
                    }
                    //Master Insertation
                    newItem = new BusinessManageGenericRepository<AirTicketMaster>().Insert(newItem);

                    //Master Validation
                    if (newItem == null) return null;

                    // Airticket Registration Details               

                    foreach (AirTicketDetail item in reqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        try
                        {
                            var details = new BusinessManageGenericRepository<AirTicketDetail>().Insert(item);
                        }
                        catch (Exception ex)
                        {
                            new BusinessManageGenericRepository<AirTicketMaster>().Delete(i => i.TransactionCode == newItem.TransactionCode);
                            throw ex;
                        }

                    }
                }
                //Update
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    AirTicketMaster ExistingAirticketRegMasterMapObj = new BusinessManageGenericRepository<AirTicketMaster>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                    newItem.CreatedOn = ExistingAirticketRegMasterMapObj.CreatedOn;

                    newItem = new BusinessManageGenericRepository<AirTicketMaster>().Update(newItem, i => i.ID == newItem.ID);



                    //Delete existing Details Data if this will not include on Updating Data
                    List<AirTicketDetail> existingDetailsList = new BusinessManageGenericRepository<AirTicketDetail>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newList = (from num in existingDetailsList
                                   select num.DetailID).Except(reqItems.Select(y => y.DetailID)).ToList();
                    foreach (var item in newList)
                    {
                        new BusinessManageGenericRepository<AirTicketDetail>().Delete(i => i.DetailID == item);
                    }

                    // Update Airticket Registration Details
                    foreach (AirTicketDetail item in reqItems)
                    {
                        AirTicketDetail ExistingAirticketRegDetailpObj = new BusinessManageGenericRepository<AirTicketDetail>().Find(i => i.DetailID == item.DetailID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingAirticketRegDetailpObj != null)
                        {
                            item.CreatedOn = ExistingAirticketRegDetailpObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<AirTicketDetail>().Update(item, i => i.DetailID == item.DetailID);
                        }

                        //Insert New Item on Update Mode
                        if (item.DetailID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<AirTicketDetail>().Insert(item);
                        }

                    }
                }
                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }

        }
        // GET Airticket   Details By Transaction

        public List<AirTicketDetail> getAirTicketDetailsByTransactionCode(string transactionCode)
        {
            try
            {
                return new BusinessManageGenericRepository<AirTicketDetail>().Find(i => i.TransactionCode == transactionCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET HotelBooking Lists
        public List<HotelBookingDTO> GetHotelBookinLIST()
        {
            try
            {
                return new BusinessManageGenericRepository<HotelBookingDTO>().FindUsingSP("getHotelBookingList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //POST HotelBooking
        public HotelBookMaster SaveUpdateHotelBooking(HotelBookingDTO dto)
        {
            try
            {
                HotelBookMaster newItem = new HotelBookMaster();
                //MAP
                newItem = new HotelBookingMasterMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();

                List<HotelBookDetail> reqItems = serialize.ObjectToJSONText<HotelBookDetail>(dto.HotelBookingDetail);

                //INSERT 
                if (dto.TransactionCode == null)
                {
                    newItem.TransactionCode = GenerateAutoCode("HTB", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    newItem.CreatedBy = dto.CreatedBy;
                    newItem.UpdatedOn = null;
                    newItem.UpdatedBy = null;

                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map Hotel Booking Master. Please try again");
                        return null;
                    }
                    newItem = new BusinessManageGenericRepository<HotelBookMaster>().Insert(newItem);
                    //Master VALIDATION
                    if (newItem == null) return null;

                    // Airticket Registration Details
                    foreach (HotelBookDetail item in reqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<HotelBookDetail>().Insert(item);
                    }

                }
                //UPDATE
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    HotelBookMaster ExistingHotelBookingMasterMapObj = new BusinessManageGenericRepository<HotelBookMaster>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                    newItem.CreatedOn = ExistingHotelBookingMasterMapObj.CreatedOn;

                    newItem = new BusinessManageGenericRepository<HotelBookMaster>().Update(newItem, i => i.ID == newItem.ID);



                    //Delete existing Details Data if this will not include on Updating Data
                    List<HotelBookDetail> existingDetailsList = new BusinessManageGenericRepository<HotelBookDetail>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newList = (from num in existingDetailsList
                                   select num.DetailID).Except(reqItems.Select(y => y.DetailID)).ToList();
                    foreach (var item in newList)
                    {
                        new BusinessManageGenericRepository<HotelBookDetail>().Delete(i => i.DetailID == item);
                    }

                    // Update Online Registration Details
                    foreach (HotelBookDetail item in reqItems)
                    {
                        HotelBookDetail ExistingHotelBookingDetailpObj = new BusinessManageGenericRepository<HotelBookDetail>().Find(i => i.DetailID == item.DetailID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingHotelBookingDetailpObj != null)
                        {
                            item.CreatedOn = ExistingHotelBookingDetailpObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<HotelBookDetail>().Update(item, i => i.DetailID == item.DetailID);
                        }

                        //Insert New Item on Update Mode
                        if (item.DetailID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<HotelBookDetail>().Insert(item);
                        }

                    }
                }
                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        //GET HotelBooking Details By TransactionCode
        public List<HotelBookDetail> getHotelDetailsByTransactionCode(string transactionCode)
        {
            try
            {
                return new BusinessManageGenericRepository<HotelBookDetail>().Find(i => i.TransactionCode == transactionCode);
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        //POST Holiday Tour Package
        public HolidayPackageMaster saveUpdateHolidayPackageTour(HolidayPackageTourMasterDTO holidayPackageTourMasterNew)
        {
            try
            {
                HolidayPackageMaster newItem = new HolidayPackageMaster();

                //MAP
                newItem = new HolidayPackageTourMasterMap().map(holidayPackageTourMasterNew);

                //save on holiday package Details Table
                JSONSerialize serialize = new JSONSerialize();
                List<HolidayPackageTourDetailDTO> reqItems = serialize.ObjectToJSONText<HolidayPackageTourDetailDTO>(holidayPackageTourMasterNew.HolidayPackageDetail);
                if (reqItems == null) throw new Exception("Data is empty.");

                if (holidayPackageTourMasterNew.HOPCode == null)
                {
                    //INSERT
                    newItem.HOPCode = GenerateAutoCode("HOP", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    newItem.UpdatedOn = null;


                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map package Model. Please try again");
                        return null;
                    }

                    newItem = new BusinessManageGenericRepository<HolidayPackageMaster>().Insert(newItem);

                    //Master VALIDATION
                    if (newItem == null) return null;

                    foreach (HolidayPackageTourDetailDTO item in reqItems)
                    {

                        item.HOPCode = newItem.HOPCode;
                        item.ID = 0;
                        HolidayPackageDetail holidayPackageDetail = new HolidayPackageTourDetailMap().map(item);

                        //Details VALIDATION
                        if (holidayPackageDetail == null) return null;

                        holidayPackageDetail = new BusinessManageGenericRepository<HolidayPackageDetail>().Insert(holidayPackageDetail);
                    }
                }
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    newItem = new BusinessManageGenericRepository<HolidayPackageMaster>().Update(newItem, i => i.ID == newItem.ID);

                    //DELETE EXISTING DETAILS

                    var ExistingDetailsListObj = new BusinessManageGenericRepository<HolidayPackageDetail>().Find(i => i.HOPCode == newItem.HOPCode);

                    foreach (HolidayPackageDetail item in ExistingDetailsListObj)
                    {
                        new BusinessManageGenericRepository<HolidayPackageDetail>().Delete(l => l.ID == item.ID);
                    }

                    // Update Details List                  

                    foreach (HolidayPackageTourDetailDTO item in reqItems)
                    {

                        item.HOPCode = newItem.HOPCode;
                        item.ID = 0;
                        HolidayPackageDetail holidayPackageDetail = new HolidayPackageTourDetailMap().map(item);

                        //Details VALIDATION
                        if (holidayPackageDetail == null) return null;

                        holidayPackageDetail = new BusinessManageGenericRepository<HolidayPackageDetail>().Insert(holidayPackageDetail);
                    }


                }
                return newItem;
            }

            catch (Exception ex) { Error = ex; return null; }

        }

        //GET Holiday Tour Package List
        public List<HolidayPackageTourInfoDTO> getholidayPackageTourList()
        {
            try
            {
                return new BusinessManageGenericRepository<HolidayPackageTourInfoDTO>().FindUsingSP("getHolidayPackageTourList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Holiday Package Details By HOPCode
        public List<HolidayPackageDetail> getHolidayPackageDetailByHOPCodeList(string hopCode)
        {
            try
            {
                return new BusinessManageGenericRepository<HolidayPackageDetail>().Find(l => l.HOPCode == hopCode).ToList();


            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST Advance Payment
        public ClientAdvancePayment saveUpdateAdvancePayment(ClientAdvancePayment clientAdvancePayment)
        {
            try
            {

                if (clientAdvancePayment != null && clientAdvancePayment.ID > 0)
                {
                    clientAdvancePayment.UpdatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<ClientAdvancePayment>().Update(clientAdvancePayment, r => r.ID == clientAdvancePayment.ID);
                }
                else
                {
                    clientAdvancePayment.AdvanceCode = GenerateAutoCode("Adv", DateTime.Now.ToString());
                    clientAdvancePayment.CreatedOn = DateTime.Now;

                    return new BusinessManageGenericRepository<ClientAdvancePayment>().Insert(clientAdvancePayment);
                }
            }

            catch (Exception ex) { Error = ex; return null; }

        }

        //GET Advance Payment List
        public List<AdvancePaymentDTO> getAdvancePaymentList()
        {
            try
            {
                return new BusinessManageGenericRepository<AdvancePaymentDTO>().FindUsingSP("getAdvancePaymentList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET  Money Receipt Service List By Customer Code
        public List<ServiceDetailByCustomerCodeDTO> getServiceListByCustomerCode(string customerCode)
        {
            try
            {
                return new BusinessManageGenericRepository<ServiceDetailByCustomerCodeDTO>().FindUsingSP("getServiceDetailByCustomerCode @customerCode", new SqlParameter("@customerCode", customerCode)).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //Post Money Receipt  
        public MRMaster saveUpdateMoenyReceipt(MoneyReceiptDTO mmoneyReceiptDTOnew)
        {
            try
            {
                MRMaster newItem = new MRMaster();

                //MAP
                newItem = new MRMasterMap().map(mmoneyReceiptDTOnew);


                //MAP  on Money Receipt invoice/service Details Table
                JSONSerialize serialize = new JSONSerialize();
                List<MRInvoiceDetailDTO> reqItems = serialize.ObjectToJSONText<MRInvoiceDetailDTO>(mmoneyReceiptDTOnew.InvoiceDetail);

                //MAP Money Receipt on  Payment Details Table
                serialize = new JSONSerialize();
                List<MRPaymentDetailsDTO> reqPaymentDetail = serialize.ObjectToJSONText<MRPaymentDetailsDTO>(mmoneyReceiptDTOnew.PaymentDetail);


                if (reqItems == null && reqPaymentDetail == null) throw new Exception("Data is empty.");

                if (mmoneyReceiptDTOnew.ReceiptCode == null)
                {
                    //INSERT
                    newItem.ReceiptCode = GenerateAutoCode("MR", DateTime.Now.ToString());


                    newItem.CreatedOn = DateTime.Now;
                    newItem.UpdatedOn = null;


                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map package Model. Please try again");
                        return null;
                    }

                    newItem = new BusinessManageGenericRepository<MRMaster>().Insert(newItem);

                    //Master VALIDATION
                    if (newItem == null) return null;

                    // Money Receipt invoice / service Details Table
                    foreach (MRInvoiceDetailDTO item in reqItems)
                    {

                        item.ReceiptCode = newItem.ReceiptCode;
                        item.InvoiceID = item.InvoiceID;  //GenerateAutoCode("INV", DateTime.Now.ToString()); 
                        MRInvoiceDetail mrInvoiceDetail = new MRInvoiceDetailMap().map(item);

                        // Money Receipt invoice/service VALIDATION
                        if (mrInvoiceDetail == null) return null;
                        mrInvoiceDetail = new BusinessManageGenericRepository<MRInvoiceDetail>().Insert(mrInvoiceDetail);
                    }

                    // Money Receipt Payment Details Table
                    foreach (MRPaymentDetailsDTO item in reqPaymentDetail)
                    {
                        item.ReceiptCode = newItem.ReceiptCode;
                        MRPaymentDetails mrPaymentDetail = new MrPaymentDetailMap().map(item);

                        //Money Receipt Payment Details VALIDATION
                        if (mrPaymentDetail == null) return null;
                        mrPaymentDetail = new BusinessManageGenericRepository<MRPaymentDetails>().Insert(mrPaymentDetail);
                    }
                }

                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    newItem = new BusinessManageGenericRepository<MRMaster>().Update(newItem, i => i.ID == newItem.ID);

                    //DELETE EXISTING DETAILS

                    var ExistingMRInvoiceDetailObj = new BusinessManageGenericRepository<MRInvoiceDetail>().Find(i => i.ReceiptCode == newItem.ReceiptCode);
                    foreach (MRInvoiceDetail item in ExistingMRInvoiceDetailObj)
                    {
                        new BusinessManageGenericRepository<MRInvoiceDetail>().Delete(l => l.ID == item.ID);
                    }

                    var ExistingMRPaymentDetailObj = new BusinessManageGenericRepository<MRPaymentDetails>().Find(i => i.ReceiptCode == newItem.ReceiptCode);
                    foreach (MRPaymentDetails item in ExistingMRPaymentDetailObj)
                    {
                        new BusinessManageGenericRepository<MRPaymentDetails>().Delete(l => l.ID == item.ID);
                    }

                    // Update Invoice Details List  
                    foreach (MRInvoiceDetailDTO item in reqItems)
                    {

                        item.ReceiptCode = newItem.ReceiptCode;
                        item.InvoiceID = item.InvoiceID; //GenerateAutoCode("INV", DateTime.Now.ToString());

                        item.ID = 0;
                        MRInvoiceDetail mrInvoiceDetail = new MRInvoiceDetailMap().map(item);

                        //Money Receipt invoice/service  VALIDATION
                        if (mrInvoiceDetail == null) return null;

                        mrInvoiceDetail = new BusinessManageGenericRepository<MRInvoiceDetail>().Insert(mrInvoiceDetail);
                    }

                    // Update Payment Details List      
                    foreach (MRPaymentDetailsDTO item in reqPaymentDetail)
                    {

                        item.ReceiptCode = newItem.ReceiptCode;
                        item.ID = 0;
                        MRPaymentDetails mrPaymentDetail = new MrPaymentDetailMap().map(item);

                        //MONEY RECEIOT PAYMENT VALIDATION
                        if (mrPaymentDetail == null) return null;

                        mrPaymentDetail = new BusinessManageGenericRepository<MRPaymentDetails>().Insert(mrPaymentDetail);
                    }


                }
                return newItem;
            }

            catch (Exception ex) { Error = ex; return null; }

        }

        public List<MoneyReceiptDTO> getMoneyReceiptList(string fromDate, string toDate)
        {
            try
            {
                return new BusinessManageGenericRepository<MoneyReceiptDTO>().FindUsingSP("getMRList @fromDate,@toDate ",
                                                            new SqlParameter("@fromDate", fromDate),
                                                                     new SqlParameter("@toDate", toDate)).ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Money Receipt
        public object getMoneyReceiptInvoiceAndPaymentDetailsDetail(string receiptCode, string customerCode)
        {
            try
            {
                List<MRPaymentDetails> MRPaymentDetail = new BusinessManageGenericRepository<MRPaymentDetails>().Find(l => l.ReceiptCode == receiptCode).ToList();
                List<ServiceDetailByCustomerCodeDTO> MRInvoiceDetail = new BusinessManageGenericRepository<ServiceDetailByCustomerCodeDTO>().FindUsingSP("getEditServiceDetailByReceiptCode @ReceiptCode,@CustomerCode ",
                                                              new SqlParameter("@ReceiptCode", receiptCode),
                                                                       new SqlParameter("@CustomerCode", customerCode)).ToList();


                return new { MRPaymentDetail, MRInvoiceDetail };

            }
            catch (Exception ex) { Error = ex; return null; }
        }
        //GET Customer Advance Amount 
        public List<CustomerAdvanceAmountDto> GetCustomerAdvanceAmount(string CustomerCode)
        {
            try
            {
                List<CustomerAdvanceAmountDto> list = new BusinessManageGenericRepository<CustomerAdvanceAmountDto>().FindUsingSP("getCustomerAdvanceAmount @CustomerCode",
                                    new SqlParameter("@CustomerCode", CustomerCode)).ToList();
                return list;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public List<MrCustomerDTO> getMRcustomerList()
        {
            try
            {
                List<MrCustomerDTO> customer = new BusinessManageGenericRepository<MrCustomerDTO>().FindUsingSP("getMRCustomerList").ToList();
                return customer;

            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Advance Payment List Only Cheque AND Not Cheque Clear Data
        public List<AdvancePaymentClearanceDTO> getAdvancePaymentNotClearanceList()
        {
            try
            {
                return new BusinessManageGenericRepository<AdvancePaymentClearanceDTO>().FindUsingSP("getAdvancePaymentNotClearanceList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public ClientAdvancePayment updateadvanceClearance(ClientAdvancePayment dto)
        {
            try
            {
                return new BusinessManageGenericRepository<ClientAdvancePayment>().Update(dto, r => r.ID == dto.ID);
            }
            catch (Exception ex) { Error = ex; return null; }
        }


        //GET Group Tour Registration List
        public List<GroupTourListDto> getGroupTourList()
        {
            try
            {
                return new BusinessManageGenericRepository<GroupTourListDto>().FindUsingSP("getGroupTourList").ToList();
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        public GroupTourMaster saveUpdateGroupTour(GrouptourMasterDTO dto)
        {
            try
            {
                GroupTourMaster newItem = new GroupTourMaster();
                //MAP
                newItem = new GroupTourMasterMap().map(dto);

                JSONSerialize serialize = new JSONSerialize();
                List<GroupTourCustomer> cusReqItems = serialize.ObjectToJSONText<GroupTourCustomer>(dto.customers);
                List<GroupTourMember> memreqItems = serialize.ObjectToJSONText<GroupTourMember>(dto.participants);
                List<GroupTourDetails> reqItems = serialize.ObjectToJSONText<GroupTourDetails>(dto.eventDetails);


                //INSERT 
                if (dto.TransactionCode == null)
                {
                    newItem.TransactionCode = GenerateAutoCode("GRP", DateTime.Now.ToString());
                    newItem.CreatedOn = DateTime.Now;
                    newItem.CreatedBy = dto.CreatedBy;
                    newItem.UpdatedOn = null;
                    newItem.UpdatedBy = null;

                    if (newItem == null)
                    {
                        Error = new Exception("Failed to map Group Tour Master. Please try again");
                        return null;
                    }
                    newItem = new BusinessManageGenericRepository<GroupTourMaster>().Insert(newItem);
                    //Master VALIDATION
                    if (newItem == null) return null;

                    #region Insert Into Customer Details
                    // GroupTour Customer Details
                    foreach (GroupTourCustomer item in cusReqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<GroupTourCustomer>().Insert(item);
                    }
                    #endregion Insert Into Customer Details

                    #region Insert Into Participant Details
                    // GroupTour Participant Details
                    foreach (GroupTourMember item in memreqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<GroupTourMember>().Insert(item);
                    }
                    #endregion Insert Into Participant Details


                    #region Insert Into GroupTour Event Details
                    // GroupTour Event Details
                    foreach (GroupTourDetails item in reqItems)
                    {
                        item.TransactionCode = newItem.TransactionCode;
                        item.CreatedOn = DateTime.Now;
                        item.CreatedBy = newItem.CreatedBy;

                        item.UpdatedOn = null;
                        item.UpdatedBy = null;

                        if (item == null) return null;
                        var details = new BusinessManageGenericRepository<GroupTourDetails>().Insert(item);
                    }
                    #endregion Insert Into  GroupTour Event Details
                }
                //UPDATE
                else
                {
                    //MASTER UPDATE
                    newItem.UpdatedOn = DateTime.Now;
                    GroupTourMaster ExistingMasterMapObj = new BusinessManageGenericRepository<GroupTourMaster>().Find(i => i.ID == newItem.ID).FirstOrDefault();
                    newItem.CreatedOn = ExistingMasterMapObj.CreatedOn;

                    newItem = new BusinessManageGenericRepository<GroupTourMaster>().Update(newItem, i => i.ID == newItem.ID);


                    #region Customer Update
                    //Delete existing customer Details Data if this will not include on Updating Data
                    List<GroupTourCustomer> existingCustomerList = new BusinessManageGenericRepository<GroupTourCustomer>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newList = (from num in existingCustomerList
                                   select num.ID).Except(reqItems.Select(y => y.ID)).ToList();
                    foreach (var item in newList)
                    {
                        new BusinessManageGenericRepository<GroupTourCustomer>().Delete(i => i.ID == item);
                    }

                    // Update Group Customer Details
                    foreach (GroupTourCustomer item in cusReqItems)
                    {
                        GroupTourCustomer ExistingGroupTourCustomerObj = new BusinessManageGenericRepository<GroupTourCustomer>().Find(i => i.ID == item.ID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingGroupTourCustomerObj != null)
                        {
                            item.CreatedOn = ExistingGroupTourCustomerObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<GroupTourCustomer>().Update(item, i => i.ID == item.ID);
                        }

                        //Insert New Item on Update Mode
                        if (item.ID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<GroupTourCustomer>().Insert(item);
                        }

                    }
                    #endregion customer update

                    #region Participant Update
                    //Delete existing participant Details Data if this will not include on Updating Data
                    List<GroupTourMember> existingParticipantList = new BusinessManageGenericRepository<GroupTourMember>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newparticipantList = (from num in existingParticipantList
                                              select num.ID).Except(reqItems.Select(y => y.ID)).ToList();
                    foreach (var item in newparticipantList)
                    {
                        new BusinessManageGenericRepository<GroupTourMember>().Delete(i => i.ID == item);
                    }
                    // Update Group participant Details
                    foreach (GroupTourMember item in memreqItems)
                    {
                        GroupTourMember ExistingGroupTourParticipantObj = new BusinessManageGenericRepository<GroupTourMember>().Find(i => i.ID == item.ID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingGroupTourParticipantObj != null)
                        {
                            item.CreatedOn = ExistingGroupTourParticipantObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<GroupTourMember>().Update(item, i => i.ID == item.ID);
                        }

                        //Insert New Item on Update Mode
                        if (item.ID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<GroupTourMember>().Insert(item);
                        }

                    }
                    #endregion Participant Update

                    #region Grouptour Details
                    //Delete existing Event Details Data if this will not include on Updating Data
                    List<GroupTourDetails> existingDetailsList = new BusinessManageGenericRepository<GroupTourDetails>().Find(i => i.TransactionCode == dto.TransactionCode);
                    //Query Syntax
                    var newDetailsList = (from num in existingDetailsList
                                          select num.ID).Except(reqItems.Select(y => y.ID)).ToList();
                    foreach (var item in newDetailsList)
                    {
                        new BusinessManageGenericRepository<GroupTourDetails>().Delete(i => i.ID == item);
                    }

                    // Update Group Details
                    foreach (GroupTourDetails item in reqItems)
                    {
                        GroupTourDetails ExistingGroupTourDetailsObj = new BusinessManageGenericRepository<GroupTourDetails>().Find(i => i.ID == item.ID).FirstOrDefault();

                        //Update Existing Data
                        if (ExistingGroupTourDetailsObj != null)
                        {
                            item.CreatedOn = ExistingGroupTourDetailsObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<GroupTourDetails>().Update(item, i => i.ID == item.ID);
                        }

                        //Insert New Item on Update Mode
                        if (item.ID == 0)
                        {
                            item.TransactionCode = newItem.TransactionCode;
                            item.CreatedOn = DateTime.Now;
                            item.CreatedBy = newItem.CreatedBy;
                            new BusinessManageGenericRepository<GroupTourDetails>().Insert(item);
                        }

                    }
                    #endregion Grouptour Details
                }
                return newItem;
            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //GET Group Tour Registration Details by Transaction Code
        public object GetGroupTourDetailsbyTransactionCode(string transactionCode)
        {
            try
            {
                List<GroupTourCustomer> groupTourCustomer = new BusinessManageGenericRepository<GroupTourCustomer>().GetAll().Where(i => i.TransactionCode == transactionCode).ToList();
                List<GroupTourMember> groupTourMember = new BusinessManageGenericRepository<GroupTourMember>().GetAll().Where(i => i.TransactionCode == transactionCode).ToList();
                List<GroupTourDetails> groupTourDetails = new BusinessManageGenericRepository<GroupTourDetails>().GetAll().Where(i => i.TransactionCode == transactionCode).ToList();

                return new { groupTourCustomer, groupTourMember, groupTourDetails };

            }
            catch (Exception ex) { Error = ex; return null; }
        }

        //POST Group Tour Master Cancellation   
        public string updateGroupTourCancellation(GrouptourMasterDTO dto)
        {
            try
            {
                GroupTourMaster newItem = new GroupTourMaster();


                JSONSerialize serialize = new JSONSerialize();

                List<GroupTourDetails> reqItems = serialize.ObjectToJSONText<GroupTourDetails>(dto.eventDetails);
                var transactionCode = reqItems[0].TransactionCode;

                //Group Tour Master Update

                GroupTourMaster ExistingGroupTourMasterMasterMapObj = new BusinessManageGenericRepository<GroupTourMaster>().Find(i => i.TransactionCode == transactionCode).FirstOrDefault();
                ExistingGroupTourMasterMasterMapObj.UpdatedOn = DateTime.Now;
                ExistingGroupTourMasterMasterMapObj.UpdatedBy = dto.UpdatedBy;

                newItem = new BusinessManageGenericRepository<GroupTourMaster>().Update(ExistingGroupTourMasterMasterMapObj, i => i.TransactionCode == transactionCode);

                // Update Forwarding Info Airticket Registration Details
                try
                {
                    foreach (GroupTourDetails item in reqItems)
                    {
                        GroupTourDetails ExistingDetailpObj = new BusinessManageGenericRepository<GroupTourDetails>().Find(i => i.ID == item.ID).FirstOrDefault();

                        //Update GroupTour Details Existing Data
                        if (ExistingDetailpObj != null)
                        {
                            if (item.CancelationCharge != 0) item.IsCancel = true;
                            item.CreatedOn = ExistingDetailpObj.CreatedOn;
                            item.UpdatedOn = DateTime.Now;
                            item.UpdatedBy = dto.UpdatedBy;

                            if (item == null) return null;
                            var details = new BusinessManageGenericRepository<GroupTourDetails>().Update(item, i => i.ID == item.ID);
                        }

                    }


                    //Update Group Customer NetPayable Amount

                    var updateCustomerDetails = new BusinessManageGenericRepository<GroupTourListDto>().FindOneUsingSP("UpdateGroupTourCustomerDetails @TransactionCode,@updatedBy",
                                                     new SqlParameter("@TransactionCode", transactionCode),
                                                                      new SqlParameter("@updatedBy", ExistingGroupTourMasterMasterMapObj.UpdatedBy));
                }
                catch (Exception ex) { Error = ex; return null; }

                return "'" + transactionCode + "' ,Successfully Cancel, ";
            }
            catch (Exception ex) { Error = ex; return "Faild to Update Cancel, "; }

        }


    }
}
