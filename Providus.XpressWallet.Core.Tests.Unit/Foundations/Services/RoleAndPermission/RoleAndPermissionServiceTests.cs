using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using RESTFulSense.Exceptions;
using System.Net;
using System.Xml.Linq;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.RoleAndPermission
{
    public partial class RoleAndPermissionServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IRoleAndPermissionService roleAndPermissionService;

        public RoleAndPermissionServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            roleAndPermissionService = new RoleAndPermissionService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalUpdateRoleRequest, bool>> SameExternalUpdateRoleRequestAs(
             ExternalUpdateRoleRequest expectedExternalUpdateRoleRequest)
        {
            return actualExternalUpdateRoleRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateRoleRequest,
                    actualExternalUpdateRoleRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalCreateRoleRequest, bool>> SameExternalCreateRoleRequestAs(
               ExternalCreateRoleRequest expectedExternalCreateRoleRequest)
        {
            return actualExternalCreateRoleRequest =>
                this.compareLogic.Compare(
                    expectedExternalCreateRoleRequest,
                    actualExternalCreateRoleRequest)
                        .AreEqual;
        }

        private static DateTime GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static string GetRandomString() =>
           new MnemonicString().GetValue();

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string[] CreateRandomStringArray() =>
            new Filler<string[]>().Create();

        private static List<string> GetRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region UpdateRoleRequest 

        private static dynamic CreateRandomUpdateRoleRequestProperties()
        {
            return new
            {

                Name = GetRandomString(),
                Permissions = GetRandomStringList(),

            };
        }



        #endregion

        #region UpdateRoleResponse 

        private static dynamic CreateRandomUpdateRoleResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
                 Data = GetRandomUpdateRoleResponseData(),
    
            };
        }
        private static dynamic GetRandomUpdateRoleResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Name = GetRandomString(),
                Permissions = GetRandomStringList(),



            };
        }


        #endregion

        #region CreateRoleRequest 

        private static dynamic CreateRandomCreateRoleRequestProperties()
        {
            return new
            {

                Name = GetRandomString(),
                Permissions = GetRandomStringList(),

            };
        }



        #endregion

        #region CreateRoleResponse 

        private static dynamic CreateRandomCreateRoleResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),
                Data = GetRandomCreateRoleResponseData(),

            };
        }
        private static dynamic GetRandomCreateRoleResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Name = GetRandomString(),
                Permissions = GetRandomStringList(),



            };
        }


        #endregion

        #region AllRolesResponse 

        private static dynamic CreateRandomAllRoleResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),
                Data = GetRandomAllRoleResponseData(),

            };
        }
        private static dynamic GetRandomAllRoleResponseData()
        {
            return new
            {

                Id = GetRandomString(),
                Name = GetRandomString(),
                Permissions = GetRandomStringList(),



            };
        }


        #endregion

        #region AllPermissionsResponse 

        private static dynamic CreateRandomAllPermissionsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomAllPermissionsResponseData(),

            };
        }
      
        private static List<dynamic> GetRandomAllPermissionsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Name = GetRandomString(),
                Description = GetRandomString(),


            }).ToList<dynamic>();

        }

        #endregion


        public static TheoryData UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
