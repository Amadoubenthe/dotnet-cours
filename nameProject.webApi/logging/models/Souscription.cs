using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameProject.webApi.models
{
    public class Souscription
    {
        public int PersonID {get; set;} 
         public int ProductID {get; set;}
        public int SubscriptionID {get; set;}
        public DateTime SubscriptionDate {get; set;}
        public string SubscriptionState {get; set;} = String.Empty;
        public int ComercialID {get; set;}
        public int SubscriptionTime {get; set;}
    }
}