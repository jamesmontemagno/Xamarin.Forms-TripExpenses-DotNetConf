using System;
using System.Collections.Generic;
using System.Text;
using TripExpenses.Models;
using TripExpenses.ViewModels;
using Xamarin.Forms;

namespace TripExpenses.Views
{
  public class ExpensesPage : ContentPage
  {

    public ExpensesViewModel ViewModel
    {
      get { return BindingContext as ExpensesViewModel; }
      set { BindingContext = value; }
    }

    public ExpensesPage()
    {
      this.Title = "Expenses";
      ViewModel = new ExpensesViewModel();

      ToolbarItems.Add(new ToolbarItem
      {
        Icon = "refresh.png",
        Command = ViewModel.LoadExpenses,
        Name = "refresh"
      });

      var list = new ListView();
      list.ItemsSource = ViewModel.Expenses;

      var cell = new DataTemplate(typeof(TextCell));
      cell.SetBinding(TextCell.TextProperty, "Name");
      cell.SetBinding(TextCell.DetailProperty, "Price");

      list.ItemTemplate = cell;

      list.ItemTapped += (sender, args) =>
        {
          if (list.SelectedItem == null)
            return;

          var detailPage = new DetailsPage(args.Item as TripExpense);
          Navigation.PushAsync(detailPage);

          list.SelectedItem = null;
        };


      var newExpense = new Button
      {
        Text = "New Expense"
      };

      newExpense.Clicked += async (sender, args) =>
      {
        var detailPage = new DetailsPage(null);
        await Navigation.PushAsync(detailPage);
      };

      var progress = new ActivityIndicator();
      progress.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
      progress.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");


      Content = new StackLayout
      {
        Spacing = 10,
        Padding = 10,
        Children = { progress, list, newExpense }
      };

      
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      if(!ViewModel.Initialized)
        ViewModel.LoadExpenses.Execute(null);
    }
  }
}
