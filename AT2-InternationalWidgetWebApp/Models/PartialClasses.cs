using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AT2_InternationalWidgetWebApp.Models
{

    [MetadataType(typeof(ItemsMetadata))]
    public partial class Item
    {
    }

    [MetadataType(typeof(InvoicesMetadata))]
    public partial class Invoice
    {
    }

    [MetadataType(typeof(ItemsLinesMetadata))]
    public partial class ItemLine
    {
    }
}