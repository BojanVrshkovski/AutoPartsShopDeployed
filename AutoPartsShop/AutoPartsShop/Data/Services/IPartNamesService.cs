using AutoPartsShop.Data.Base;
using AutoPartsShop.Data.ViewModels;
using AutoPartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.Services
{
    public interface IPartNamesService:IEntityBaseRepository<PartName>
    {
        Task<PartName> GetPartNameByIdAsync(int id);
        Task<NewPartNameDropDownsVM> GetNewPartNameDropDownsValues();
        Task AddNewPartNameAsync(NewPartNameVM data);
        Task UpdateNewPartNameAsync(NewPartNameVM data);
    }
}
