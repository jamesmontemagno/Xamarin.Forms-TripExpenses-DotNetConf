using System;
using System.Collections.Generic;
using System.Text;

namespace TripExpenses.Models
{
  public class TripExpense
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Billable { get; set; }
    public string Category { get; set; }
    public string Price { get; set; }
  }
}
