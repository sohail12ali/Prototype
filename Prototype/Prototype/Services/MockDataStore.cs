using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prototype.Models;
using Realms;

namespace Prototype.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly IEnumerable<Item> items;
        private readonly Realm _realm;

        public MockDataStore()
        {
            _realm = Realm.GetInstance();
            _realm.BeginWrite();
            items = _realm?.All<Item>()?.ToList();
        }

        ~MockDataStore()
        {
            _realm.Dispose();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            _realm.Add(item, true);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _realm.Remove(oldItem);
            _realm.Add(item, true);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            _realm.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}