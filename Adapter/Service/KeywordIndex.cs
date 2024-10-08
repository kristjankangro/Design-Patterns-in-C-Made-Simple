﻿using Demo.Clip01.Abstractions;
using Demo.Common;

namespace Demo.Clip01
{
    public class KeywordIndex<TItem> where TItem : IWithKeywords
    {
        private IDictionary<string, IList<TItem>> Index { get; } =
            new Dictionary<string, IList<TItem>>();

        public void Add(TItem item)
        {
            foreach (string keyword in item.Keywords)
            {
                this.Add(keyword.ToLowerInvariant(), item);
            }
        }

        private void Add(string keyword, TItem item) => 
            this.GetListFor(keyword).Add(item);

        private IList<TItem> GetListFor(string keyword) =>
            this.Index.TryGetValue(keyword, out IList<TItem> list) ? list
            : this.CreateListFor(keyword);

        private IList<TItem> CreateListFor(string keyword) 
        {
            IList<TItem> list = new List<TItem>();
            this.Index[keyword] = list;
            return list;
        }

        public IEnumerable<TItem> Find(string keyword) =>
            this.Index.TryGetValue(keyword.ToLowerInvariant(), out IList<TItem> items) ? items
            : Enumerable.Empty<TItem>();
        public IEnumerable<TItem> FindApproximate(string keyword) =>
            this.Index.Where(entry => entry.Key.Contains(keyword.ToLowerInvariant()))
                .SelectMany(entry => entry.Value);
        public override string ToString() =>
            this.Index
                .SelectMany(keyValue => keyValue.Value.Select(item => (keyword: keyValue.Key, item: item)))
                .Select(tuple => $"{tuple.keyword} -> {tuple.item}")
                .Join(Environment.NewLine);
    }
}
