using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App2.Services
{
    public interface IAddIToExisting<Parrent,Children>
    {
        Task<bool> AddItemAsync(Parrent Header);
        Task<bool> AddItemToexistingAsync(Parrent HeaderItem,Children childrenItem);
        Task<bool> UpdateHeadersync(Parrent HeaderItem);
        Task<bool> UpdateBodyasync(Children ChildtenItem);
        Task<bool> DeleteItemHeaderAsync(Parrent HeaderItem);
        Task<bool> GetItemsCollectionAsync(Parrent HeaderItem, Children childrenItem);
        Task<IEnumerable<Parrent>> GetItemsAsync(bool forceRefresh = false);
    }
}
