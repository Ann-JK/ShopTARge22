using ShopTARge22.Core.DTO.CocktailsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface ICocktailServices
    {
        Task<CocktailResponseDTO> GetCocktails(CocktailResponseDTO dto);
    }
}
