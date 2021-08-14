﻿using System;
using DiunsaSCM.Core.Entities;
namespace DiunsaSCM.Core.Models
{
    public class PurchCommercialDepartmentDTO : AuditableModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}