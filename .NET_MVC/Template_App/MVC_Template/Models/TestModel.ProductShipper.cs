﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 9/19/2023 8:35:18 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

#nullable enable annotations
#nullable disable warnings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace MVC_Template.Models
{
    public partial class ProductShipper
    {

        public ProductShipper()
        {
            OnCreated();
        }

        public int ShipperID { get; set; }

        public string ShipperName { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime LastModified { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
