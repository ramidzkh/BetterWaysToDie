using System.Collections.Generic;

namespace BetterWaysToDie.Registry
{
    public interface IRegistry<T>
    {
        T this[string name] { get; set; }

        string Remove(T entry);

        T Remove(string name);

        string GetId(T entry);

        bool IsRegistered(T entry);

        bool IsRegistered(string name);

        IDictionary<string, T> GetEntries();
    }
}
