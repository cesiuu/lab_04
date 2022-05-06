using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    namespace lab_04
    {
        public class By_sizes
        {
        private static IDictionary<string, long[]> lessthan1kb = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Lessthan1kb { get { return lessthan1kb; } set { } }
        private static IDictionary<string, long[]> kbtomb = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Kbtomb { get { return kbtomb; } set { } }
        private static IDictionary<string, long[]> mbtogb = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Mbtogb { get { return mbtogb; } set { } }
        private static IDictionary<string, long[]> morethan1gb = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Morethan1gb { get { return morethan1gb; } set { } }
        private static IDictionary<string, List<long>> sizes = new Dictionary<string, List<long>>();
        public static IDictionary<string, List<long>> Sizes { get => (IDictionary<string, List<long>>)sizes; set { } }
        private static List<long> lessthan1kbs = new List<long>();
            public static List<long> Lessthan1kbs { get { return lessthan1kbs; } }
            private static List<long> kbtombs = new List<long>();
            public static List<long> Kbtombs { get { return kbtombs; } }
            private static List<long> mbtogbs = new List<long>();
            public static List<long> Mbtogbs { get { return mbtogbs; } }
            private static List<long> morethan1gbs = new List<long>();
            public static List<long> Morethan1gbs { get { return morethan1gbs; } }
            public static void Print()
            {
            List<long> ltkb = new List<long> { 0, 0, 0, 0, 0 };
            List<long> kbtomb = new List<long> { 0, 0, 0, 0, 0 };
            List<long> mbtogb = new List<long> { 0, 0, 0, 0, 0 };
            List<long> mtgb = new List<long> { 0, 0, 0, 0, 0 };
            foreach (File f in File.Files)
            {
                if (f.Size * 1024 < 1024)
                {
                    ltkb[0]++;
                    ltkb[1] = ltkb[1] + f.Size;
                    lessthan1kbs.Add(f.Size);
                }
                if (f.Size * 1024 >= 1024 && f.Size * 1024 <= 1024 * 1024)
                {
                    kbtomb[0]++;
                    kbtomb[1] = kbtomb[1] + f.Size;
                    kbtombs.Add(f.Size);
                }
                if (f.Size * 1024 >= 1024 * 1024 && f.Size * 1024 <= 1024 * 1024 * 1024)
                {
                    mbtogb[0]++;
                    mbtogb[1] = mbtogb[1] + f.Size;
                    mbtogbs.Add(f.Size);
                }
                if (f.Size * 1024 > 1024 * 1024 * 1024)
                {
                    mtgb[0]++;
                    mtgb[1] = mtgb[1] + f.Size;
                    morethan1gbs.Add(f.Size);
                }
            }
                ltkb[2] = (ltkb[0] == 0) ? 0 : ltkb[1] / ltkb[0];
                ltkb[3] = Lessthan1kbs.AsQueryable().Any() ? Lessthan1kbs.AsQueryable().Min() : 0;
                ltkb[4] = Lessthan1kbs.AsQueryable().Any() ? Lessthan1kbs.AsQueryable().Max() : 0;
                Sizes.Add("      . <= 1KB", ltkb);
                ltkb = new List<long> { 0, 0, 0, 0, 0 };
                kbtomb[2] = (kbtomb[0] == 0) ? 0 : kbtomb[1] / kbtomb[0];
                kbtomb[3] = Kbtombs.AsQueryable().Any() ? Kbtombs.AsQueryable().Min() : 0;
                kbtomb[4] = Kbtombs.AsQueryable().Any() ? Kbtombs.AsQueryable().Max() : 0;
                Sizes.Add("1KB < . <= 1MB", kbtomb);
                kbtomb = new List<long> { 0, 0, 0, 0, 0 };
                mbtogb[2] = (mbtogb[0] == 0) ? 0 : mbtogb[1] / mbtogb[0];
                mbtogb[3] = Mbtogbs.AsQueryable().Any() ? Mbtogbs.AsQueryable().Min() : 0;
                mbtogb[4] = Mbtogbs.AsQueryable().Any() ? Mbtogbs.AsQueryable().Max() : 0;
                Sizes.Add("1MB < . <= 1GB", mbtogb);
                mbtogb = new List<long> { 0, 0, 0, 0, 0 };
                mtgb[2] = (mtgb[0] == 0) ? 0 : mtgb[1] / mtgb[0];
                mtgb[3] = Morethan1gbs.AsQueryable().Any() ? Morethan1gbs.AsQueryable().Min() : 0;
                mtgb[4] = Morethan1gbs.AsQueryable().Any() ? Morethan1gbs.AsQueryable().Max() : 0;
                Sizes.Add("1GB < .       ", mtgb);
                mtgb = new List<long> { 0, 0, 0, 0, 0 };
                Console.WriteLine("   By sizes:");
                Console.WriteLine(String.Format("{0,-26}{1,-13}{2,-16}{3,-16}{4,-16}{5,-16}", " ", "[count]", "[total size]", "[avg size]", "[min size]", "[max size]"));
                foreach (KeyValuePair<string, List<long>> pair in Sizes)
                Console.WriteLine(String.Format("{0,-8}{1,-19}{2,-13}{3,-16}{4,-16}{5,-16}{6,-16}", " ", pair.Key, pair.Value[0], pair.Value[1] + " KB", pair.Value[2] + " KB", pair.Value[3] + " KB", pair.Value[4] + " KB"));
                Console.WriteLine();
            }
        }
    }
