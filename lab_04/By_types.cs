using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_04
{
    public class By_types
    {
        public By_types()
        {

        }
        private List<string> types = new List<string>();
        public string this[int index]
        { get
            {
                if (index < 0 || index >= types.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                return types[index];
            } set
            {
                if (index < 0 || index >= types.Count)
                    throw new IndexOutOfRangeException("Index out of range");

                types[index] = value;
            }
        }
        //używam IDictionary<> ze względu na potrzebę powiązania między typem a zbiorem właściwości
        private static IDictionary<string, long[]> image = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Image { get { return image; } set { } }
        private static IDictionary<string, long[]> audio = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Audio { get { return audio; } set { } }
        private static IDictionary<string, long[]> video = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Video { get { return video; } set { } }
        private static IDictionary<string, long[]> document = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Document { get { return document; } set { } }
        private static IDictionary<string, long[]> other = new Dictionary<string, long[]>();
        public static IDictionary<string, long[]> Other { get { return other; } set { } }
        private static IDictionary<string, List<long>> filetypes = new Dictionary<string, List<long>>();
        public static IDictionary<string, List<long>> Filetypes { get => (IDictionary<string, List<long>>)filetypes; set { } }
        //używam List<> ze względu na potrzebę wykonania operacji na każdym elemencie zbioru, oraz modifykacji tego zbioru
        private static List<long> images = new List<long>();
        public static List<long> Images { get { return images; } }
        private static List<long> audios = new List<long>();
        public static List<long> Audios { get { return audios; } }
        private static List<long> videos = new List<long>();
        public static List<long> Videos { get { return videos; } }
        private static List<long> documents = new List<long>();
        public static List<long> Documents { get { return documents; } }
        private static List<long> others = new List<long>();
        public static List<long> Others { get { return others; } }
        private static List<string> alltypes = new List<string> { "image   ", "audio   ", "video   ", "document", "other   " };
        public static List<string> Alltypes { get { return alltypes; } }
        public static void Print()
        {
            List<long> imageproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> audioproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> videoproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> documentproperties = new List<long> { 0, 0, 0, 0, 0 };
            List<long> otherproperties = new List<long> { 0, 0, 0, 0, 0 };
            foreach (File file in File.Files)
            {
                if (file.Extension == ".png" || file.Extension == ".webp" || file.Extension == ".jpg" || file.Extension == ".gif" || file.Extension == ".tiff")
                {
                    file.Type = "image   ";
                    imageproperties[0]++;
                    imageproperties[1] = imageproperties[1] + file.Size;
                    images.Add(file.Size);
                }
                else
                if (file.Extension == ".ogg" || file.Extension == ".mp3" || file.Extension == ".wav")
                {
                    file.Type = "audio";
                    audioproperties[0]++;
                    audioproperties[1] = audioproperties[1] + file.Size;
                    audios.Add(file.Size);
                }
                else
                if (file.Extension == ".mkv" || file.Extension == ".mp4" || file.Extension == ".webm")
                {
                    file.Type = "video";
                    videoproperties[0]++;
                    videoproperties[1] = videoproperties[1] + file.Size;
                    videos.Add(file.Size);
                }

                else
                if (file.Extension == ".txt" || file.Extension == ".doc" || file.Extension == ".docx" || file.Extension == ".xml" || file.Extension == ".xlmx")

                {
                    file.Type = "document";
                    documentproperties[0]++;
                    documentproperties[1] = documentproperties[1] + file.Size;
                    documents.Add(file.Size);
                }
                else
                if (!alltypes.Contains(file.Type))
                {
                    file.Type = "other";
                    otherproperties[0]++;
                    otherproperties[1] = otherproperties[1] + file.Size;
                    others.Add(file.Size);
                }
            }
                imageproperties[2] = (imageproperties[0] == 0) ? 0 : imageproperties[1] / imageproperties[0];
                imageproperties[3] = images.AsQueryable().Any() ? images.AsQueryable().Min() : 0;
                imageproperties[4] = images.AsQueryable().Any() ? images.AsQueryable().Max() : 0;
                Filetypes.Add("image", imageproperties);
                imageproperties = new List<long> { 0, 0, 0, 0, 0 };
                audioproperties[2] = (audioproperties[0] == 0) ? 0 : audioproperties[1] / audioproperties[0];
                audioproperties[3] = audios.AsQueryable().Any() ? audios.AsQueryable().Min() : 0;
                audioproperties[4] = audios.AsQueryable().Any() ? audios.AsQueryable().Max() : 0;
                Filetypes.Add("audio", audioproperties);
                audioproperties = new List<long> { 0, 0, 0, 0, 0 };
                videoproperties[2] = (videoproperties[0] == 0) ? 0 : videoproperties[1] / videoproperties[0];
                videoproperties[3] = videos.AsQueryable().Any() ? videos.AsQueryable().Min() : 0;
                videoproperties[4] = videos.AsQueryable().Any() ? videos.AsQueryable().Max() : 0;
                Filetypes.Add("video", videoproperties);
                videoproperties = new List<long> { 0, 0, 0, 0, 0 };
                documentproperties[2] = (documentproperties[0] == 0) ? 0 : documentproperties[1] / documentproperties[0];
                documentproperties[3] = documents.AsQueryable().Any() ? documents.AsQueryable().Min() : 0;
                documentproperties[4] = documents.AsQueryable().Any() ? documents.AsQueryable().Max() : 0;
                Filetypes.Add("document", documentproperties);
                documentproperties = new List<long> { 0, 0, 0, 0, 0 };
                otherproperties[2] = (otherproperties[0] == 0) ? 0 : otherproperties[1] / otherproperties[0];
                otherproperties[3] = others.AsQueryable().Any() ? others.AsQueryable().Min() : 0;
                otherproperties[4] = others.AsQueryable().Any() ? others.AsQueryable().Max() : 0;
                Filetypes.Add("[other]", otherproperties);
                otherproperties = new List<long> { 0, 0, 0, 0, 0 };
                Console.WriteLine("   By types:");
                Console.WriteLine(String.Format("{0,-26}{1,-13}{2,-16}{3,-16}{4,-16}{5,-16}", " ", "[count]", "[total size]", "[avg size]", "[min size]", "[max size]"));
                foreach (KeyValuePair<string, List<long>> pair in Filetypes)
                Console.WriteLine(String.Format("{0,-8}{1,-19}{2,-13}{3,-16}{4,-16}{5,-16}{6,-16}", " ", pair.Key, pair.Value[0], pair.Value[1] + " KB", pair.Value[2] + " KB", pair.Value[3] + " KB", pair.Value[4] + " KB"));
                Console.WriteLine();
        }
    }
}