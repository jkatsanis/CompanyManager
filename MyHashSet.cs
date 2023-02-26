
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
            _buckets = CreateBuckets(capacity);
            _currentMaxDepth = 0;
        }

        private int NoOfBuckets => _buckets.Length;

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

        public void Remove(T value)
        {
            if(value == null)
            {
                return;
            }

            var hashCode = value.GetHashCode();
            List<T> bucket = _buckets[GetBucketIndex(hashCode)];

            bucket.Remove(value);

            return;
        }

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