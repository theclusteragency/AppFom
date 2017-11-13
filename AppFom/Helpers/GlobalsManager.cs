using System;
using System.Collections.Generic;
using AppFom.Models;

namespace AppFom.Helpers
{
    public class GlobalsManager
    {
        public string APIKEY { get { return "R0m3FHbz7pMHbVJRDJ0N6YyxDKOCuWu8fQP2AaOc"; } }

        public User USERFOM { get; set; }

        public string TOKENAPNS { get; set; }

        public List<Event> MISEVENTOS { get; set; }
    }
}
