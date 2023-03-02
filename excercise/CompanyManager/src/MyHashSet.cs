
namespace CompanyManager
{
    public sealed class MyHashSet<T>
    {
        private const int InitialBuckets = 4;
        private const int MaxDepth = 3;
        private List<T>[] _buckets;
        private int _currentMaxDepth;

        public MyHashSet() : this(InitialBuckets)
        {
        }

        private MyHashSet(int capacity)
        {
         
        }

        private int NoOfBuckets => _buckets.Length;

        /// <summary>
        ///     Adds a value to the hash set.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <returns>true if the value was added successfully, false if the value is null or already exists in the hash set.</returns>
        public bool Add(T value)
        {
            return true;
        }

        /// <summary>
        ///     Removes a value from the hash table.
        /// </summary>
        /// <param name="value">The value to be removed.</param>
        public void Remove(T value)
        {        
            return;
        }

        /// <summary>
        ///     Determines whether the hash table contains a specific value.
        /// </summary>
        /// <param name="value">The value to locate in the hash table.</param>
        /// <returns>true if the hash table contains an element with the specified value, otherwise false.</returns>
        public bool Contains(T value)
        {     
            return false;
        }

        /// <summary>
        ///     Returns a list of all values stored in the hash table.
        /// </summary>
        /// <returns>A list of all values stored in the hash table.</returns>
        public List<T> GetValues()
        {      
            return new List<T>(0);
        }

        /// <summary>
        ///     Doubles the capacity of the hash set.
        /// </summary>
        private void Grow()
        {

        }

        private int GetBucketIndex(int hashCode) => Math.Abs(hashCode) % NoOfBuckets;

        /// <summary>
        ///     Creates an array of buckets for the hash set, with a given amount and maximum depth.
        /// </summary>
        /// <param name="amount">The number of buckets to create.</param>
        /// <returns>An array of <see cref="List{T}"/> instances representing the buckets for the hash set.</returns>
        private static List<T>[] CreateBuckets(int amount)
        {
            return new List<T>[0];
        }
    }
}