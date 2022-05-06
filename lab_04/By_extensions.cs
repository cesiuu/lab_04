using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_04
{
    public class By_extensions
    {
        public By_extensions()
        {

        }
        private static IDictionary<string, long[]> jpg = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Jpg { get { return jpg; } set { } }
        private static IDictionary<string, long[]> png = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Png { get { return png; } set { } }
        private static IDictionary<string, long[]> gif = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Gif { get { return gif; } set { } }
        private static IDictionary<string, long[]> doc = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Doc { get { return doc; } set { } }
        private static IDictionary<string, long[]> txt = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Txt { get { return txt; } set { } }
        private static IDictionary<string, long[]> mp3 = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Mp3 { get { return mp3; } set { } }
        private static IDictionary<string, long[]> other = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Other { get { return other; } set { } }
        private static IDictionary<string, List<long>> extensions = new Dictionary<string, List<long>>();
        public static IDictionary<string, List<long>> Extensions { get => (IDictionary<string, List<long>>)extensions; set { } }
        private static List<long> jpgs = new List<long>();
        public static List<long> Jpgs { get { return jpgs; } }
        private static List<long> pngs = new List<long>();
        public static List<long> Pngs { get { return pngs; } }
        private static List<long> gifs = new List<long>();
        public static List<long> Gifs { get { return gifs; } }
        private static List<long> docs = new List<long>();
        public static List<long> Docs { get { return docs; } }
        private static List<long> txts = new List<long>();
        public static List<long> Txts { get { return txts; } }
        private static List<long> mp3s = new List<long>();
        public static List<long> Mp3s { get { return mp3s; } }
        private static List<long> others = new List<long>();
        public static List<long> Others { get { return others; } }
        public static void Print()
        {
            List<long> jpgproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> pngproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> gifproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> docproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> txtproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> mp3properties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> otherproperties = new List<long> { 0, 0, 0, 0, 0 };
            foreach (File f in File.Files)
            {
                if (f.Extension == ".jpg")
                {
                    jpgproperties[0]++;
                    jpgproperties[1] = jpgproperties[1] + f.Size;
                    jpgs.Add(f.Size);
                }
                else
                if (f.Extension == ".png")
                {
                    pngproperties[0]++;
                    pngproperties[1] = pngproperties[1] + f.Size;
                    pngs.Add(f.Size);
                }
                else
                if (f.Extension == ".gif")
                {
                    gifproperties[0]++;
                    gifproperties[1] = gifproperties[1] + f.Size;
                    gifs.Add(f.Size);
                }
                else
                if (f.Extension == ".doc")
                {
                    docproperties[0]++;
                    docproperties[1] = docproperties[1] + f.Size;
                    docs.Add(f.Size);
                }
                else
                if (f.Extension == ".txt")
                {
                    txtproperties[0]++;
                    txtproperties[1] = txtproperties[1] + f.Size;
                    txts.Add(f.Size);
                }
                else
                if (f.Extension == ".mp3")
                {
                    mp3properties[0]++;
                    mp3properties[1] = mp3properties[1] + f.Size;
                    jpgs.Add(f.Size);
                }
                else
                {
                    otherproperties[0]++;
                    otherproperties[1] = otherproperties[1] + f.Size;
                    others.Add(f.Size);
                }
            }
            jpgproperties[2] = (jpgproperties[0] == 0) ? 0 : jpgproperties[1] / jpgproperties[0];
            jpgproperties[3] = jpgs.AsQueryable().Any() ? jpgs.AsQueryable().Min() : 0;
            jpgproperties[4] = jpgs.AsQueryable().Any() ? jpgs.AsQueryable().Max() : 0;
            Extensions.Add("jpg", jpgproperties);
            jpgproperties = new List<long> { 0, 0, 0, 0, 0 };
            pngproperties[2] = (pngproperties[0] == 0) ? 0 : pngproperties[1] / pngproperties[0];
            pngproperties[3] = pngs.AsQueryable().Any() ? pngs.AsQueryable().Min() : 0;
            pngproperties[4] = pngs.AsQueryable().Any() ? pngs.AsQueryable().Max() : 0;
            Extensions.Add("png", pngproperties);
            pngproperties = new List<long> { 0, 0, 0, 0, 0 };
            gifproperties[2] = (gifproperties[0] == 0) ? 0 : gifproperties[1] / gifproperties[0];
            gifproperties[3] = gifs.AsQueryable().Any() ? gifs.AsQueryable().Min() : 0;
            gifproperties[4] = gifs.AsQueryable().Any() ? gifs.AsQueryable().Max() : 0;
            Extensions.Add("gif", gifproperties);
            gifproperties = new List<long> { 0, 0, 0, 0, 0 };
            txtproperties[2] = (txtproperties[0] == 0) ? 0 : txtproperties[1] / txtproperties[0];
            txtproperties[3] = txts.AsQueryable().Any() ? txts.AsQueryable().Min() : 0;
            txtproperties[4] = txts.AsQueryable().Any() ? txts.AsQueryable().Max() : 0;
            Extensions.Add("txt", txtproperties);
            txtproperties = new List<long> { 0, 0, 0, 0, 0 };
            docproperties[2] = (docproperties[0] == 0) ? 0 : docproperties[1] / docproperties[0];
            docproperties[3] = docs.AsQueryable().Any() ? docs.AsQueryable().Min() : 0;
            docproperties[4] = docs.AsQueryable().Any() ? docs.AsQueryable().Max() : 0;
            Extensions.Add("doc", docproperties);
            docproperties = new List<long> { 0, 0, 0, 0, 0 };
            mp3properties[2] = (mp3properties[0] == 0) ? 0 : mp3properties[1] / mp3properties[0];
            mp3properties[3] = mp3s.AsQueryable().Any() ? mp3s.AsQueryable().Min() : 0;
            mp3properties[4] = mp3s.AsQueryable().Any() ? mp3s.AsQueryable().Max() : 0;
            Extensions.Add("mp3", mp3properties);
            mp3properties = new List<long> { 0, 0, 0, 0, 0 };
            otherproperties[2] = (otherproperties[0] == 0) ? 0 : otherproperties[1] / otherproperties[0];
            otherproperties[3] = others.AsQueryable().Any() ? others.AsQueryable().Min() : 0;
            otherproperties[4] = others.AsQueryable().Any() ? others.AsQueryable().Max() : 0;
            Extensions.Add("[other]", otherproperties);
            otherproperties = new List<long> { 0, 0, 0, 0, 0 };
            Console.WriteLine("   By extensions:");
            Console.WriteLine(String.Format("{0,-26}{1,-13}{2,-16}{3,-16}{4,-16}{5,-16}", " ", "[count]", "[total size]", "[avg size]", "[min size]", "[max size]"));
            foreach (KeyValuePair<string, List<long>> pair in Extensions)
            Console.WriteLine(String.Format("{0,-8}{1,-19}{2,-13}{3,-16}{4,-16}{5,-16}{6,-16}", " ", pair.Key, pair.Value[0], pair.Value[1] + " KB", pair.Value[2] + " KB", pair.Value[3] + " KB", pair.Value[4] + " KB"));
            Console.WriteLine();
        }
    }
}
