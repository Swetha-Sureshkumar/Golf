using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GolfApp.Structures
{
    public class Matching : IEnumerable<Hit>
    {
        public static readonly Matching Empty = new Matching();

        private IList<Hit> _hits = new List<Hit>();

        public Matching()
        {
        }

        public Matching(Hit hit)
        {
            _hits.Add(hit);
        }
        public Matching(IList<Hit> hits)
        {
            _hits = hits;
        }
        public bool IsPlanar()
        {
            for (var i = 0; i < _hits.Count; ++i)
            for (var j = i + 1; j < _hits.Count; ++j)
                if (_hits[i].Intersects(_hits[j]))
                    return false;

            return true;
        }

        public static Matching operator +(Matching matchingLeft, Matching matchingRight)
        {
            return new Matching()
                .Add(matchingLeft)
                .Add(matchingRight);
        }

        public static Matching operator +(Matching matching, Hit hit)
        {
            return new Matching()
                .Add(hit)
                .Add(matching);
        }

        public static Matching operator +(Hit hit, Matching matching)
        {
            return matching + hit;
        }

        private Matching Add(Hit hit)
        {
            _hits.Add(hit);
            return this;
        }

        private Matching Add(Matching matching)
        {
            _hits = _hits.Concat(matching._hits).ToList();
            return this;
        }

        public IEnumerator<Hit> GetEnumerator()
        {
            return _hits.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _hits).GetEnumerator();
        }
    }
}