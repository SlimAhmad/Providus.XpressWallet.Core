using KellermanSoftware.CompareNetObjects;
using Moq;
using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team;
using RESTFulSense.Exceptions;
using System.Data;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;


namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {

        private readonly Mock<IXpressWalletBroker> xPressWalletBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly ITeamService teamService;

        public TeamServiceTests()
        {
            xPressWalletBrokerMock = new Mock<IXpressWalletBroker>();
            dateTimeBrokerMock = new Mock<IDateTimeBroker>();
            compareLogic = new CompareLogic();

            teamService = new TeamService(
                xPressWalletBrokerMock.Object,
                dateTimeBroker: dateTimeBrokerMock.Object);
        }


        private Expression<Func<ExternalInviteTeamMembersRequest, bool>> SameExternalInviteTeamMembersRequestAs(
             ExternalInviteTeamMembersRequest expectedExternalInviteTeamMembersRequest)
        {
            return actualExternalInviteTeamMembersRequest =>
                this.compareLogic.Compare(
                    expectedExternalInviteTeamMembersRequest,
                    actualExternalInviteTeamMembersRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalResendInvitationRequest, bool>> SameExternalResendInvitationRequestAs(
             ExternalResendInvitationRequest expectedExternalResendInvitationRequest)
        {
            return actualExternalResendInvitationRequest =>
                this.compareLogic.Compare(
                    expectedExternalResendInvitationRequest,
                    actualExternalResendInvitationRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalAcceptInvitationRequest, bool>> SameExternalAcceptInvitationRequestAs(
            ExternalAcceptInvitationRequest expectedExternalAcceptInvitationRequest)
        {
            return actualExternalAcceptInvitationRequest =>
                this.compareLogic.Compare(
                    expectedExternalAcceptInvitationRequest,
                    actualExternalAcceptInvitationRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalSwitchMerchantRequest, bool>> SameExternalSwitchMerchantRequestAs(
            ExternalSwitchMerchantRequest expectedExternalSwitchMerchantRequest)
        {
            return actualExternalSwitchMerchantRequest =>
                this.compareLogic.Compare(
                    expectedExternalSwitchMerchantRequest,
                    actualExternalSwitchMerchantRequest)
                        .AreEqual;
        }

        private Expression<Func<ExternalUpdateMemberInformationRequest, bool>> SameExternalUpdateMemberInformationRequestAs(
          ExternalUpdateMemberInformationRequest expectedExternalUpdateMemberInformationRequest)
        {
            return actualExternalUpdateMemberInformationRequest =>
                this.compareLogic.Compare(
                    expectedExternalUpdateMemberInformationRequest,
                    actualExternalUpdateMemberInformationRequest)
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

        private static List<string> CreateRandomStringList() =>
          new Filler<List<string>>().Create();

        private static bool GetRandomBoolean() =>
            Randomizer<bool>.Create();

        private static Dictionary<string, int> CreateRandomDictionary() =>
            new Filler<Dictionary<string, int>>().Create();


        #region InviteTeamMembersRequest 

        private static dynamic CreateRandomInviteTeamMembersRequestProperties()
        {
            return new
            {

                RoleId = GetRandomString(),
                Email = GetRandomString(),
                ApprovalLimit = GetRandomNumber(),

            };
        }




        #endregion

        #region InviteTeamMembersResponse 

        private static dynamic CreateRandomInviteTeamMembersResponseProperties()
        {
            return new
            {
                
                 Status = GetRandomBoolean(),
                 Message = GetRandomString(),
    
            };
        }


        #endregion

        #region ResendInvitationRequest 

        private static dynamic CreateRandomResendInvitationRequestProperties()
        {
            return new
            {

                Email = GetRandomString(),

            };
        }




        #endregion

        #region ResendInvitationResponse 

        private static dynamic CreateRandomResendInvitationResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region AcceptInvitationRequest 

        private static dynamic CreateRandomAcceptInvitationRequestProperties()
        {
            return new
            {
                 InvitationCode = GetRandomString(),
                 FirstName = GetRandomString(),
                 LastName = GetRandomString(),
                 PhoneNumber = GetRandomString(),
                 Password = GetRandomString(),
            };

        }


        #endregion

        #region AcceptInvitationResponse 

        private static dynamic CreateRandomAcceptInvitationResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region SwitchMerchantRequest 

        private static dynamic CreateRandomSwitchMerchantRequestProperties()
        {
            return new
            {
                MerchantId = GetRandomString(),

            };
        }




        #endregion

        #region SwitchMerchantResponse 

        private static dynamic CreateRandomSwitchMerchantResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

        #region MerchantListResponse 

        private static dynamic CreateRandomMerchantListResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomMerchantListResponseData(),

            };
        } 

        private static List<dynamic> GetRandomMerchantListResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomString(),
                Role = GetRandomString(),
                Name = GetRandomString(),



            }).ToList<dynamic>();

        }

        #endregion

        #region AllInvitationsResponse 

        private static dynamic CreateRandomAllInvitationsResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomAllInvitationsResponseData(),

            };
        }

        private static List<dynamic> GetRandomAllInvitationsResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {

                Id = GetRandomString(),
                Email = GetRandomString(),
                Role = GetRandomString(),
                Accepted = GetRandomBoolean(),
                CreatedAt = GetRandomDate(),
                UpdatedAt = GetRandomDate(),


            }).ToList<dynamic>();

        }

        #endregion

        #region TeamMembersResponse 

        private static dynamic CreateRandomTeamMembersResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Data = GetRandomTeamMembersResponseData(),

            };
        }

        private static List<dynamic> GetRandomTeamMembersResponseData()
        {

            return Enumerable.Range(0, GetRandomNumber()).Select(
            item => new
            {
                Role = GetRandomString(),
                Id = GetRandomString(),
                Email = GetRandomString(),
                LastName = GetRandomString(),
                FirstName = GetRandomString(),
                ApprovalLimit = GetRandomNumber(),



            }).ToList<dynamic>();

        }

        #endregion

        #region UpdateMemberInformationRequest 

        private static dynamic CreateRandomUpdateMemberInformationRequestProperties()
        {
            return new
            {

                ApprovalLimit = GetRandomNumber(),
                RoleId = GetRandomString(),
            };
        }




        #endregion

        #region UpdateMemberInformationResponse 

        private static dynamic CreateRandomUpdateMemberInformationResponseProperties()
        {
            return new
            {

                Status = GetRandomBoolean(),
                Message = GetRandomString(),

            };
        }


        #endregion

       

        public static TheoryData<HttpResponseException> UnauthorizedExceptions()
        {
            return new TheoryData<HttpResponseException>
            {
                new HttpResponseUnauthorizedException(),
                new HttpResponseForbiddenException()
            };
        }



    }
}
