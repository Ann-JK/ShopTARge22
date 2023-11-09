using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IKindergartensS5ervices
    {
        Task<Kindergarten> Create(KindergartenDTO dto);
        Task<Kindergarten> DetailsAsync(Guid id);
        Task<Kindergarten> Delete(Guid id);
        Task<Kindergarten> Update(KindergartenDTO dto);
    }
}
