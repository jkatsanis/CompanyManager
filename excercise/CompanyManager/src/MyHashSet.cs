
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
            //TODO
            _buckets = CreateBuckets(capacity);
            _currentMaxDepth = 0;
        }

        private int NoOfBuckets => _buckets.Length;

        /// <summary>
        ///     Adds a value to the hash set.
        /// </summary>
        /// <param name="value">The value to add.</param>
        /// <returns>true if the value was added successfully, false if the value is null or already exists in the hash set.</returns>
        public bool Add(T value)
        {
            if (value == null || Contains(value))
            {
                return false;
            }

            var hashCode = value.GetHashCode();
            List<T> bucket = _buckets[GetBucketIndex(hashCode)];
            bucket.Add(value);

            _currentMaxDepth = Math.Max(_currentMaxDepth, bucket.Count);
            if (_currentMaxDepth > MaxDepth)
            {
                Grow();
            }

            return true;
        }

        /// <summary>
        ///     Removes a value from the hash table.
        /// </summary>
        /// <param name="value">The value to be removed.</param>
        public void Remove(T value)
        {
            if (value == null)
            {
                return;
            }

            var hashCode = value.GetHashCode();
            List<T> bucket = _buckets[GetBucketIndex(hashCode)];

            bucket.Remove(value);

            return;
        }

        /// <summary>
        ///     Determines whether the hash table contains a specific value.
        /// </summary>
        /// <param name="value">The value to locate in the hash table.</param>
        /// <returns>true if the hash table contains an element with the specified value, otherwise false.</returns>
        public bool Contains(T value)
        {
            if (value == null)
            {
                return false;
            }

            var hashCode = value.GetHashCode();
            List<T> bucket = _buckets[GetBucketIndex(hashCode)];
            foreach (var existingValue in bucket)
            {
                if (existingValue!.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Returns a list of all values stored in the hash table.
        /// </summary>
        /// <returns>A list of all values stored in the hash table.</returns>
        public List<T> GetValues()
        {
            var list = new List<T>();
            for (var i = 0; i < NoOfBuckets; i++)
            {
                List<T> bucket = _buckets[i];
                foreach (var element in bucket)
                {
                    list.Add(element);
                }
            }

            return list;
        }

        /// <summary>
        ///     Doubles the capacity of the hash set.
        /// </summary>
        private void Grow()
        {
            var newSet = new MyHashSet<T>(NoOfBuckets * 2);
            foreach (var value in GetValues())
            {
                newSet.Add(value);
            }

            _buckets = newSet._buckets;
            _currentMaxDepth = newSet._currentMaxDepth;
        }

        private int GetBucketIndex(int hashCode) => Math.Abs(hashCode) % NoOfBuckets;

        /// <summary>
        ///     Creates an array of buckets for the hash set, with a given amount and maximum depth.
        /// </summary>
        /// <param name="amount">The number of buckets to create.</param>
        /// <returns>An array of <see cref="List{T}"/> instances representing the buckets for the hash set.</returns>
        private static List<T>[] CreateBuckets(int amount)
        {
            var buckets = new List<T>[amount];
            for (var i = 0; i < amount; i++)
            {
                buckets[i] = new(MaxDepth + 1);
            }

            return buckets;
        }
    }
}