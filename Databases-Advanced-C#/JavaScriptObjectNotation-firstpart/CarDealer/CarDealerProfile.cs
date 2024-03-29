﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DataTransferObject;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            
            this.CreateMap<SupplierInputModel, Supplier>();

            this.CreateMap<PartInputModel, Part>();

            this.CreateMap<CustumerInputModel, Customer>();

            this.CreateMap<SalesInputModel, Sale>();
        }
    }
}
