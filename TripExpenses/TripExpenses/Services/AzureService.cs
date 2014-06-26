
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using TripExpenses.Models;
using System.Linq;

namespace TripExpenses.Services
{
  public class AzureService
  {
    public MobileServiceClient MobileService { get; set; }

    private readonly IMobileServiceTable<TripExpense> expenseTable;

    public AzureService()
    {
#if __ANDROID__ || __IOS__
     Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
#endif

      //comment back in to enable Azure Mobile Services.
     MobileService = new MobileServiceClient(
       "https://" + "PUT-SITE-HERE" + ".azure-mobile.net/",
       "PUT-YOUR-API-KEY-HERE");
      
      expenseTable = MobileService.GetTable<TripExpense>();
    }


    public Task InsertExpenseAsync(TripExpense expense)
    {

      return expenseTable.InsertAsync(expense);
    }

    public Task UpdateExpenseAsync(TripExpense expense)
    {
      return expenseTable.UpdateAsync(expense);
    }

    public Task<IEnumerable<TripExpense>> GetExpensesAsync()
    {
      return expenseTable.ToEnumerableAsync();
    }
   
 
    static readonly AzureService instance = new AzureService();
    /// <summary>
    /// Gets the instance of the Azure Web Service
    /// </summary>
    public static AzureService Instance
    {
      get
      {
        return instance;
      }
    }
  }
}