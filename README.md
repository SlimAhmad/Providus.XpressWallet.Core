# Providus.XpressWallet.Core

![Providus.XpressWallet.Core](https://raw.githubusercontent.com/SlimAhmad/Providus.XpressWallet.Core/main/Providus.XpressWallet.Core/xpresswallet.png)


[![.NET](https://github.com/SlimAhmad/Providus.XpressWallet.Core/actions/workflows/dotnet.yml/badge.svg)](https://github.com/SlimAhmad/Providus.XpressWallet.Core/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Providus.XpressWallet.Core?logo=nuget)](https://www.nuget.org/packages/Providus.XpressWallet.Core)
![Nuget](https://img.shields.io/nuget/dt/Providus.XpressWallet.Core?color=blue&label=Downloads)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)


## Introduction
Providus.XpressWallet.Core is a Standard-Compliant .NET library built on top of Providus Banks XpressWallet API RESTful endpoints to enable software engineers to develop FinTech solutions in .NET.

## This library implements the following section
Please review the following documents:
- [Wallet]
- [Transfers]
- [Transactions]
- [Customers]

## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.


## How to use this library?
In order to use this library there are prerequisites that you must complete before you can write your first C#.NET program. These steps are as follows:

### Providus.XpressWallet Account
You must create an Providus.XpressWallet account with the following link:
[Click here](https://payment.xpress-wallet.com)

### Nuget Package 
Install the Providus.XpressWallet.Core library in your project.
Use the method best suited for your development preference listed at the Nuget Link above or below.

[![Nuget](https://img.shields.io/nuget/v/Providus.XpressWallet.Core?logo=nuget)](https://www.nuget.org/packages/Providus.XpressWallet.Core)

### API Keys
Once you've created a Providus.XpressWallet account. Now, go ahead and get your secret API key from the following link:
[Click here](https://payment.xpress-wallet.com/settings)

### Hello, World!
Once you've completed the aforementioned steps, let's write our very first program with Providus.XpressWallet.Core as follows:


### Wallet
This section outlines critical endpoints related to wallet management and operations. These encompass various wallet-related actions, such as querying wallet information,Wallet creation,debit,credit freeze and unfreeze wallet. 
This section implements the following:
- [Retrieve wallets]
- [Batch debit wallet customer wallets]
- [Batch Credit wallet customer wallets]
- [Customer Credit customer wallets]
- [Create wallet]
- [Debit wallet]
- [Credit wallet]
- [Customer wallet details]
- [Freeze and Unfreeze wallet]
- [Fund merchant sandbox wallet]



### Create Wallet
This allows merchants to create wallets for their users.


#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Wallet;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

                   var request = new CreateWallet
            {
                
                Request = new CreateWalletRequest
                {
                     Address = "<Address>",
                     Bvn = "<bvn>",
                     DateOfBirth = "dateofbirth",
                     Email = "<Email>",
                     FirstName = "<FirstName>",
                     LastName = "LastName",
                     Metadata = new CreateWalletRequest.MetadataResponse
                     {
                        AdditionalData = "null",
                        EvenMore = "null"
                     },
                     PhoneNumber = "<PhoneNumber>",
                     
                }
            };

            
            CreateWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.CreateWalletAsync(request);


          

          
        }
    }
}
```

### Credit Wallet
This allows merchants to credit wallets.


#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Wallet;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

            
            var request = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                     Metadata = new CreditWalletRequest.MetadataResponse
                     {
                         MoreData = "test",
                         SomeData = "test"
                     },
                     Amount = 100,
                     CustomerId = "e8a17512-0f30-4e82-a648-16540baf746e",
                     Reference = Guid.NewGuid().ToString()

                }
            };

           
            CreditWallet retrievedWalletModel =
              await this.xPressWalletClient.Wallet.CreditWalletAsync(request);


          

          
        }
    }
}
```


### Transfers
This section provides an overview of essential endpoints related to transfers and their management. These encompass various transfer-related operations, such as querying bank account details, wallet and customer transfer . 
This section implements the following:
- [Retrieve Bank account details]
- [Retrieve banks]
- [Customer bank transfer]
- [Customer to customer wallet transfer]
- [Merchant bank transfer]
- [Merchant batch bank transfer]


### Merchant Bank Transfer
This initiates a bank transfer by the merchant.


#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Charge;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

           
            
            var request = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = "<>",
                    AccountNumber = "<>",
                    Amount = 50,
                    Narration = "<>",
                    SortCode = "<>",
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = "<>"
                    }

                }
            };

           MerchantBankTransfer retrievedTransferModel =
              await this.xPressWalletClient.Transfers.MerchantBankTransferAsync(request);

          
        }
    }
}
```

### Retrieve bank account details
This retrieves a users bank account details for confirmation.


#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Charge;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            
            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

           
            string sortCode = "<>";
            string accountNumber = "<>";

            
            BankAccountDetails retrievedBankAccountModel =
              await this.xPressWalletClient.Transfers.RetrieveBankAccountDetailsAsync(sortCode,accountNumber);


          
        }
    }
}
```

### Transactions
This section details all transactional endpoints that are important for general transaction management and operations. Some of these operations include transaction queries, 
This section implements the following:
- [Approve transaction]
- [Retrieve batch transaction details]
- [Retrieve batch transactions]
- [Retrieve Customer transactions]
- [Decline pending transaction]
- [Download customer transaction]
- [Download merchant transaction]
- [Retrieve merchant transactions]
- [Pending transactions]
- [Reverse batch transactions]
- [Retrieve transaction details]



### Approve transaction
This initiates a transaction approval .

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Charge;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

            
            var request = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                     TransactionId = "<>"
                }
            };

       
            
            ApproveTransaction retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.ApproveTransactionAsync(request);

     

        }
    }
}
```

### Customer transactions
This initiates a transaction approval .

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Charge;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

            
            string customerId = "<>";
            string type = "<ALL,CREDIT,DEBIT>";
            int page = 1;
            int perPage = 3;

            
            CustomerTransactions retrievedTransactionModel =
              await this.xPressWalletClient.Transactions.RetrieveCustomerTransactionAsync(customerId,page,type,perPage);


     

        }
    }
}
```


### Customers
This section covers key related to customer management and operations. These encompass various customer-related functions, including querying customer details 
This section implements the following:
- [Retrieve customers]
- [Retrieve customer details]
- [Find customer by phone number]
- [Update customer profile]



### Customer details
This retrieves the customer's details.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Charge;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

           
               
            string customerId = "<>";

            
            CustomerDetails retrievedCustomerModel =
              await this.xPressWalletClient.Customers.RetrieveCustomerDetailsAsync(customerId);

         

     

        }
    }
}
```


### Retrieve all customer details
This retrieves all the merchant's customer's details.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.Providus.XpressWallet.Charge;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

           var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.xPressWalletClient = new Providus.XpressWalletClient(apiConfigurations);

           
             AllCustomers retrievedCustomerModel =
              await this.xPressWalletClient.Customers.RetrieveAllCustomersAsync();

        
     

        }
    }
}
```


### ProviPay
This section covers key related to bill payment management and operations. These encompass various bill-related functions, including querying available bills 
This section implements the following:
- [Retrieve bill categories]
- [Retrieve bills by category]
- [Retrieve fields]
- [Retrieve payment enquiry]
- [Validate customer]
- [Bill payment]



### Retrieve bill categories
This retrieves the bill categories.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

             var apiConfigurations = new ApiConfigurations
            {
              
                Password = "test",
                UserName = "test",
                ApiUrl = "<URL>"


            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);

            Categories retrievedBillPaymentModel =
              await this.xPressWalletClient.BillPayment.RetrieveCategoriesAsync();

         

     

        }
    }
}
```

### Bill payment
This charges the customer from a bank account provided for any given bill.
NOTE: First retrieve the keys for a given bill using the [Retrieve fields] each bill has different input keys to be passed.
NOTE: it does not support xPressWallet bank accounts you need to provide your settlement merchant account.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Providus.XpressWallet.Core;
using Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Categories;

namespace ExampleProvidus.XpressWalletNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

             var apiConfigurations = new ApiConfigurations
            {
              
                Password = "test",
                UserName = "test",
                ApiUrl = "<URL>"


            };

            this.xPressWalletClient = new XpressWalletClient(apiConfigurations);

              var request = new Payment
            {
                Request = new PaymentRequest
                {
                    BillId = "1086",
                    ChannelRef = Guid.NewGuid().ToString(),
                    CustomerAccountNo = "<BankAccountNumber>",
                    Inputs = new List<PaymentRequest.Input>
                    {
                       new PaymentRequest.Input
                       {
                           Value = "MTNVTU",
                           Key = "serviceType"
                       },
                        new PaymentRequest.Input
                       {
                           Value = "100",
                           Key = "amount"
                       },
                         new PaymentRequest.Input
                       {
                           Value = "070-----0",
                           Key = "phoneNumber"
                       },
                    },

                }
            };

            Payment retrievedCustomerModel =
            await this.xPressWalletClient.BillPayment.ChargePaymentAsync(request);

         

     

        }
    }
}
```

#### Exceptions

Providus.XpressWallet.Core may throw following exceptions:

| Exception Name | When it will be thrown |
| --- | --- |
| `WalletClientValidationException` | This exception is thrown when a validation error occurs while using the Wallet client. For example, if required data is missing or invalid. |
| `WalletClientDependencyException` | This exception is thrown when a dependency error occurs while using the Wallet client. For example, if a required dependency is unavailable or incompatible. |
| `WalletClientServiceException` | This exception is thrown when a service error occurs while using the Wallet client. For example, if there is a problem with the server or any other service failure. |
| `TransfersClientValidationException` | This exception is thrown when a validation error occurs while using the Transfers client. For example, if required data is missing or invalid. |
| `TransfersClientDependencyException` | This exception is thrown when a dependency error occurs while using the Transfers client. For example, if a required dependency is unavailable or incompatible. |
| `TransfersClientDependencyException` | This exception is thrown when a service error occurs while using the Transfers client. For example, if there is a problem with the server or any other service failure. |


## How to Contribute
If you want to contribute to this project please review the following documents:
- [The Standard](https://github.com/hassanhabib/The-Standard)
- [C# Coding Standard](https://github.com/hassanhabib/CSharpCodingStandard)
- [The Team Standard](https://github.com/hassanhabib/The-Standard-Team)

If you have a question make sure you either open an issue or send a message [Ahmad Salim](slimahmad6@gmail.com) via mail .

