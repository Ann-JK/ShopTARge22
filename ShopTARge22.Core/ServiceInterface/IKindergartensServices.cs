﻿using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IKindergartensServices
    {
        Task<RealEstate> Create(KindergartenDTO dto);
        Task<RealEstate> DetailsAsync(Guid id);
        Task<RealEstate> Delete(Guid id);
        Task<RealEstate> Update(KindergartenDTO dto);
    }
}
