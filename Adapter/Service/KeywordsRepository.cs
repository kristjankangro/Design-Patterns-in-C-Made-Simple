namespace Demo.Common;

    class KeywordsRepository
    {
        public IEnumerable<string> FindFor(string videoHandle) =>
            videoHandle == "see-key-on" ? new [] {"long", "brothers"}
                : Enumerable.Empty<string>();
    }
