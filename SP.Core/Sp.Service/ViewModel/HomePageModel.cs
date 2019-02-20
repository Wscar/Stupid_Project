using System;
using System.Collections.Generic;
using System.Text;

namespace Sp.Service.ViewModel
{
  public  class HomePageModelM<T> where T:class,new()
    {
        T PageModel { get; set; }
    }
}
