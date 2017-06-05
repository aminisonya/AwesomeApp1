using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwesomeApp.Models.ViewModels
{
    public class WeightCreateViewModel : ItemViewModel<int?>
    {
        public int? WorkoutId { get; set; }
    }
}