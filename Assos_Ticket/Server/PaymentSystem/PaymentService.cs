using Assos_Ticket.Server.Context;
using Assos_Ticket.Server.Security;
using Assos_Ticket.Server.Services.ForAuth;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;
using NUnit.Framework;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;
using Assos_Ticket.Shared;

namespace Assos_Ticket.Server.PaymentSystem
{
    public class PaymentService :  IPaymentService
    {
        private readonly IAuthService _authService;
        private readonly DataContext _dataContext;
        public PaymentService(IAuthService authService,DataContext dataContext)
        {
            _authService = authService;
            _dataContext = dataContext;
        }

        public  string Cancel_Refund()
        {
            var userId = _authService.GetUserId();
            var user = _dataContext.Users.FirstOrDefault(x => x.Id == userId);
            var vipCar = _dataContext.RezerveVipCars.FirstOrDefault(x => x.UserId == userId);
            var car = _dataContext.VipCars.FirstOrDefault(x => x.CarId == vipCar.VipCarId);
            var withDeposit = vipCar.TotalPrice + vipCar.Deposit;
            Options options = new Options();
            options.ApiKey = Keys.apiKey; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = Keys.secretKey; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = Keys.baseUrl;
            CreateCancelRequest request = new CreateCancelRequest();
            request.ConversationId =vipCar.ConversationId;
            request.Locale = Locale.TR.ToString();
            request.PaymentId = vipCar.PaymentId;
            request.Ip = GetIp();

            Cancel cancel = Cancel.Create(request, options);
            return null;
        }

        public ServiceResponse<string> Should_Create_Payment()
        {
            var userId = _authService.GetUserId();
            var user = _dataContext.Users.FirstOrDefault(x=>x.Id == userId);
            var vipCar =  _dataContext.RezerveVipCars.FirstOrDefault(x => x.UserId == userId);
            var car = _dataContext.VipCars.FirstOrDefault(x => x.CarId == vipCar.VipCarId);
            var withDeposit = vipCar.TotalPrice + vipCar.Deposit;


            Options options = new Options();
            options.ApiKey = Keys.apiKey; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = Keys.secretKey; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = Keys.baseUrl;
            //vipCar.TotalPrice.ToString()
            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = vipCar.ConversationId.ToString();
            request.Price = vipCar.TotalPrice.ToString();
            request.PaidPrice = withDeposit.ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = vipCar.RezerveVipCarId.ToString();
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "John Doe";
            paymentCard.CardNumber = "5890040000000016";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = user.Id.ToString();
            buyer.Name = "John";
            buyer.Surname = "Doe";
            buyer.GsmNumber = "+905350000000";
            buyer.Email = user.Email.ToString();
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2015-10-05    12:43:35";
            buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            buyer.Ip = "85.34.78.112";
            buyer.City = "Istanbul";
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Jane Doe";
            shippingAddress.City = "Istanbul";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            


            BasketItem thirdBasketItem = new BasketItem();
            thirdBasketItem.Id = vipCar.RezerveVipCarId.ToString();
            thirdBasketItem.Name = car.Model;
            thirdBasketItem.Category1 = car.Brand;
            thirdBasketItem.Category2 = "Usb / Cable";
            thirdBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            thirdBasketItem.Price = vipCar.TotalPrice.ToString();
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Payment payment = Payment.Create(request, options);

            PrintResponse<Payment>(payment);

            //Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual(vipCar.ConversationId.ToString(), payment.ConversationId);
            Assert.IsNotNull(payment.SystemTime);
            //Assert.IsNull(payment.ErrorCode);
            //Assert.IsNull(payment.ErrorMessage);
            //Assert.IsNull(payment.ErrorGroup);

            if (payment.ErrorMessage != null)
            {
                return new ServiceResponse<string>
                {
                    Message = payment.ErrorMessage,
                    Success = false,
                };
            }
            return new ServiceResponse<string>
            {
                Message = "Your Process is succes",
                Success = true,
            };
        }


        private string GetIp()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = host.AddressList[0]; //ilk IP adresi
            var IpAddress = ipAddress.ToString();
            return IpAddress;
        }

        protected void PrintResponse<T>(T resource)
        {
            TraceListener consoleListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleListener);
            Trace.WriteLine(JsonConvert.SerializeObject(resource, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
