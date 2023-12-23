using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        private readonly object _syncLock = new object();

        public async Task<List<string>> InitializeList(IEnumerable<string> items)
        {
            //Note: Use LINQ or use ForEachAsync

            //var bag = new ConcurrentBag<string>();
            //var tasks = items.Select(async item =>
            //{
            //    var r = await Task.Run(() => item);
            //    bag.Add(r);
            //});
            //await Task.WhenAll(tasks);

            //return bag.ToList();

            //I chose to use ForEachAsync builtin
            var bag = new ConcurrentBag<string>();
            await Parallel.ForEachAsync(items, async (i, _) =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() => {
                    foreach (var item in itemsToInitialize)
                    {
                        lock (_syncLock)
                        {
                            concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                        }
                }
                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}