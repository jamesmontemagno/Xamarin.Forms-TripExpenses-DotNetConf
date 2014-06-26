Xamarin.Forms-TripExpenses
==========================

Xamarin Forms Azure Demo of a simple 

Setup

* Signup for an Azure Mobile Services account: http://azure.microsoft.com/en-us/services/mobile-services/
* Create a new Azure Mobile Services Table Called "TripExpense"
* Open "AzureService.cs" in TripExpenses shared project
* Edit: MobileService = new MobileServiceClient(
        "https://"+"PUT-SITE-HERE" +".azure-mobile.net/",
        "PUT-YOUR-API-KEY-HERE");
