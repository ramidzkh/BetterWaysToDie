namespace BetterWaysToDie.Mixins
{
    public static class MixinHelper
    {
        /// <summary>
        /// Performs an unchecked cast of this object into the given type. This method should only be used for duck and accessor interfaces
        /// </summary>
        /// <param name="o">Object to cast</param>
        /// <typeparam name="T">Type to cast into</typeparam>
        /// <returns>This object, but as the requested type</returns>
        public static T As<T>(this object o)
        {
            return (T) o;
        } 
    }
}
