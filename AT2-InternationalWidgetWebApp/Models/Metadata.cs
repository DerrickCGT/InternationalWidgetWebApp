using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AT2_InternationalWidgetWebApp.Models
{
    public class ItemsMetadata
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string ItemPrice;
    }

    public class InvoicesMetadata
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string OrderTotalPrice;
    }
    public class ItemsLinesMetadata
    {
        [DisplayFormat(DataFormatString = "{0:C}")]
        public string ItemTotal;
    }
}