using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml;

namespace Mp4tag
{
    class Metadata
    {
        private static Hashtable mediaKind = new Hashtable();
        private static Hashtable contentRating = new Hashtable();
        private static Hashtable genres = new Hashtable();
        private static Hashtable hdVideo = new Hashtable();
        private static Hashtable ratingInfo = new Hashtable();
        private static XmlDocument xmlDoc = new XmlDocument();

        private static string ratingsFile = System.Windows.Forms.Application.StartupPath + "\\data\\Ratings.xml";

        public static void Initialize()
        {
            // mediaKind
            mediaKind.Add(0, "Unknown");
            //mediaKind.Add("Music", 1);
            //mediaKind.Add("Audiobook", 2);
            mediaKind.Add(6, "Music Video");
            mediaKind.Add(9, "Movie");
            mediaKind.Add(10, "TV Show");
            //mediaKind.Add("Booklet", 11);
            //mediaKind.Add("Ringtone", 14);
            //mediaKind.Add("Pocast", 21);
            //mediaKind.Add("iTunesU", 23);

            // contentRating
            contentRating.Add(0, "None");
            contentRating.Add(2, "Clean");
            contentRating.Add(1, "Explicit");

            // genre
            // --> Music Videos 1602-1634
            Hashtable musicVideos = new Hashtable();
            musicVideos.Add(1602, "Blues");
            musicVideos.Add(1603, "Comedy");
            musicVideos.Add(1604, "Children's Music");
            musicVideos.Add(1605, "Classical");
            musicVideos.Add(1606, "Country");
            musicVideos.Add(1607, "Electronic");
            musicVideos.Add(1608, "Holiday");
            musicVideos.Add(1609, "Opera");
            musicVideos.Add(1610, "Singer/Songwriter");
            musicVideos.Add(1611, "Jazz");
            musicVideos.Add(1612, "Latino");
            musicVideos.Add(1613, "New Age");
            musicVideos.Add(1614, "Pop");
            musicVideos.Add(1615, "R&B/Soul");
            musicVideos.Add(1616, "Soundtrack");
            musicVideos.Add(1617, "Dance");
            musicVideos.Add(1618, "Hip-Hop/Rap");
            musicVideos.Add(1619, "World");
            musicVideos.Add(1620, "Alternative");
            musicVideos.Add(1621, "Rock");
            musicVideos.Add(1622, "Christian & Gospel");
            musicVideos.Add(1623, "Vocal");
            musicVideos.Add(1624, "Reggae");
            musicVideos.Add(1625, "Easy Listening");
            musicVideos.Add(1626, "Podcasts");
            musicVideos.Add(1627, "J-Pop");
            musicVideos.Add(1628, "Enka");
            musicVideos.Add(1629, "Anime");
            musicVideos.Add(1630, "Kayokyoku");
            musicVideos.Add(1631, "Disney");
            musicVideos.Add(1632, "French Pop");
            musicVideos.Add(1633, "German Pop");
            musicVideos.Add(1634, "German Folk");
            genres.Add(6, musicVideos);
            // --> Movie 4401-4428
            Hashtable movie = new Hashtable();
            movie.Add(4401, "Action & Adventure");
            movie.Add(4402, "Anime");
            movie.Add(4403, "Classics");
            movie.Add(4404, "Comedy");
            movie.Add(4405, "Documentary");
            movie.Add(4406, "Drama");
            movie.Add(4407, "Foreign");
            movie.Add(4408, "Horror");
            movie.Add(4409, "Independent");
            movie.Add(4410, "Kids & Family");
            movie.Add(4411, "Musicals");
            movie.Add(4412, "Romance");
            movie.Add(4413, "Sci-Fi & Fantasy");
            movie.Add(4414,"Short Films");
            movie.Add(4415, "Special Interest");
            movie.Add(4416, "Thriller");
            movie.Add(4417, "Sports");
            movie.Add(4418, "Western");
            movie.Add(4419, "Urban");
            movie.Add(4420, "Holiday");
            movie.Add(4421, "Made for TV");
            movie.Add(4422, "Concert Films");
            movie.Add(4423, "Music Docementaries");
            movie.Add(4424, "Music Feature Films");
            movie.Add(4425, "Japanese Cinema");
            movie.Add(4426, "Jidaigeki");
            movie.Add(4427, "Tokusatsu");
            movie.Add(4428, "Korean Cinema");
            genres.Add(9, movie);
            // --> TV (4000-4011)
            Hashtable tv = new Hashtable();
            tv.Add(4000, "Comedy");
            tv.Add(4001, "Drama");
            tv.Add(4002, "Animation");
            tv.Add(4003, "Action & Adventure");
            tv.Add(4004, "Classic");
            tv.Add(4005, "Kids");
            tv.Add(4006, "Nonfiction");
            tv.Add(4007, "Reality TV");
            tv.Add(4008, "Sci-Fi & Fantasy");
            tv.Add(4009, "Sports");
            tv.Add(4010, "Teens");
            tv.Add(4011, "Latino TV");
            genres.Add(10, tv);

            // hdVideo
            hdVideo.Add(0, "SD");
            hdVideo.Add(1, "HD - 720");
            hdVideo.Add(2, "HD - 1080");

            // ratingInfo
            if (System.IO.File.Exists(ratingsFile))
            {
                xmlDoc.Load(ratingsFile);
            }
        }

        public static string[] GetMediaTypes()
        {
            List<string> mediaTypes = new List<string>();

            foreach (DictionaryEntry entry in mediaKind)
            {
                mediaTypes.Add((string)entry.Value);
            }

            return mediaTypes.ToArray();
        }

        public static string GetMediaType(int mediaType)
        {
            if (mediaKind.Contains(mediaType))
            {
                return (string)mediaKind[mediaType];
            }
            else
            {
                return "";
            }
        }

        public static int? GetMediaType(string mediaType)
        {
            foreach (DictionaryEntry entry in mediaKind)
            {
                if ((string)entry.Value == mediaType)
                {
                    return (int)entry.Key;
                }
            }
            return null;
        }

        public static string[] GetContentRatings()
        {
            List<string> contentRatings = new List<string>();

            foreach (DictionaryEntry entry in contentRating)
            {
                contentRatings.Add((string)entry.Value);
            }

            return contentRatings.ToArray();
        }

        public static string GetContentRating(int content)
        {
            if (contentRating.Contains(content))
            {
                return (string)contentRating[content];
            }
            else
            {
                return "";
            }
        }

        public static int? GetContentRating(string content)
        {
            foreach (DictionaryEntry entry in contentRating)
            {
                if ((string)entry.Value == content)
                {
                    return (int)entry.Key;
                }
            }
            return null;
        }

        public static string[] GetAllGenres()
        {
            List<string> allGenres = new List<string>();

            foreach (DictionaryEntry entry in genres)
            {
                Hashtable innerTable = (Hashtable)entry.Value;
                foreach (DictionaryEntry inner in innerTable)
                {
                    allGenres.Add((string)inner.Value);
                }
            }

            return allGenres.ToArray();
        }

        public static string[] GetGenres(int mediaType)
        {
            List<string> allGenres = new List<string>();

            if (!genres.Contains(mediaType))
            {
                return allGenres.ToArray();
            }

            Hashtable innerTable = (Hashtable)genres[mediaType];
            foreach (DictionaryEntry inner in innerTable)
            {
                allGenres.Add((string)inner.Value);
            }
            
            return allGenres.ToArray();
        }

        public static string[] GetGenres(string mediaType)
        {
            List<string> allGenres = new List<string>();

            if (GetMediaType(mediaType) == null)
            {
                return allGenres.ToArray();
            }

            return GetGenres((int)GetMediaType(mediaType));
        }

        public static string GetGenre(int mediaType, int genre)
        {
            if (!genres.Contains(mediaType))
            {
                return "";
            }

            Hashtable innerTable = (Hashtable)genres[mediaType];
            if (innerTable.Contains(genre))
            {
                return (string)innerTable[genre];
            }
            else
            {
                return "";
            }
        }

        public static string GetGenre(string mediaType, int genre)
        {
            if (GetMediaType(mediaType) == null)
            {
                return "";
            }

            return GetGenre((int)GetMediaType(mediaType), genre);
        }

        public static int? GetGenre(int mediaType, string genre)
        {
            if (!genres.Contains(mediaType))
            {
                return null;
            }

            Hashtable innerTable = (Hashtable)genres[mediaType];
            foreach (DictionaryEntry entry in innerTable)
            {
                if ((string)entry.Value == genre)
                {
                    return (int)entry.Key;
                }
            }
            
            return null;
        }

        public static int? GetGenre(string mediaType, string genre)
        {
            if (GetMediaType(mediaType) == null)
            {
                return null;
            }

            return GetGenre((int)GetMediaType(mediaType), genre);
        }

        public static string[] GetHDVideos()
        {
            List<string> hd = new List<string>();

            foreach (DictionaryEntry entry in hdVideo)
            {
                hd.Add((string)entry.Value);
            }

            return hd.ToArray();
        }

        public static string GetHDVideo(int hd)
        {
            if (hdVideo.Contains(hd))
            {
                return (string)hdVideo[hd];
            }
            else
            {
                return "";
            }
        }

        public static int? GetHDVideo(string hd)
        {
            foreach (DictionaryEntry entry in hdVideo)
            {
                if ((string)entry.Value == hd)
                {
                    return (int)entry.Key;
                }
            }
            return null;
        }

        public static string[] GetRatingSources(int mediaType)
        {
            List<string> allSources = new List<string>();
            string mediaSource = "";

            if (mediaType == 9)
            {
                mediaSource = "movie";
            }
            else if (mediaType == 10)
            {
                mediaSource = "TV";
            }

            XmlNodeList medias = xmlDoc.GetElementsByTagName("ratings");

            foreach (XmlNode media in medias)
            {
                if (media.Attributes["media"].Value == mediaSource)
                {
                    XmlNodeList prefixes = media.ChildNodes;

                    foreach (XmlNode prefix in prefixes)
                    {
                        allSources.Add(prefix.Attributes["prefix"].Value);
                    }
                }
            }

            return allSources.ToArray();
        }

        public static string[] GetRatingSources(string mediaType)
        {
            List<string> ratings = new List<string>();

            if (GetMediaType(mediaType) == null)
            {
                return ratings.ToArray();
            }

            return GetRatingSources((int)GetMediaType(mediaType));
        }

        public static string[] GetRatings(int mediaType, string ratingSource)
        {
            List<string> ratingList = new List<string>();

            string mediaSource = "";

            if (mediaType == 9)
            {
                mediaSource = "movie";
            }
            else if (mediaType == 10)
            {
                mediaSource = "TV";
            }

            XmlNodeList medias = xmlDoc.GetElementsByTagName("ratings");

            foreach (XmlNode media in medias)
            {
                if (media.Attributes["media"].Value == mediaSource)
                {
                    XmlNodeList prefixes = media.ChildNodes;

                    foreach (XmlNode prefix in prefixes)
                    {
                        if (prefix.Attributes["prefix"].Value == ratingSource)
                        {
                            XmlNodeList ratings = prefix.ChildNodes;

                            foreach (XmlNode rating in ratings)
                            {
                                ratingList.Add(rating.InnerText);
                            }
                        }
                    }
                }
            }

            return ratingList.ToArray();
        }

        public static string[] GetRatings(string mediaType, string ratingSource)
        {
            List<string> ratings = new List<string>();

            if (GetMediaType(mediaType) == null)
            {
                return ratings.ToArray();
            }

            return GetRatings((int)GetMediaType(mediaType), ratingSource);
        }

        public static int? GetRatingValue(int mediaType, string ratingSource, string rating)
        {
            string mediaSource = "";

            if (mediaType == 9)
            {
                mediaSource = "movie";
            }
            else if (mediaType == 10)
            {
                mediaSource = "TV";
            }

            XmlNodeList medias = xmlDoc.GetElementsByTagName("ratings");

            foreach (XmlNode media in medias)
            {
                if (media.Attributes["media"].Value == mediaSource)
                {
                    XmlNodeList prefixes = media.ChildNodes;

                    foreach (XmlNode prefix in prefixes)
                    {
                        if (prefix.Attributes["prefix"].Value == ratingSource)
                        {
                            XmlNodeList ratingNodes = prefix.ChildNodes;

                            foreach (XmlNode ratingNode in ratingNodes)
                            {
                                if (ratingNode.InnerText == rating)
                                {
                                    try
                                    {
                                        return Convert.ToInt32(ratingNode.Attributes["itunes-value"].Value);
                                    }
                                    catch
                                    {
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        public static int? GetRatingValue(string mediaType, string ratingSource, string rating)
        {
            if (GetMediaType(mediaType) == null)
            {
                return null;
            }

            return GetRatingValue((int)GetMediaType(mediaType), ratingSource, rating);
        }
    }
}
