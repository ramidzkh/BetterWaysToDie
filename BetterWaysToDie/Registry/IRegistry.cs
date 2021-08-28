using System.Collections.Generic;

namespace BetterWaysToDie.Registry
{
    public interface IRegistry<T>
    {
        T Register(string name, T entry);

        string Remove(T entry);

        T Remove(string name);

        T Get(string name);

        string GetId(T entry);

        bool IsRegistered(T entry);

        bool IsRegistered(string name);

        IDictionary<string, T> GetEntries();
    }
}
