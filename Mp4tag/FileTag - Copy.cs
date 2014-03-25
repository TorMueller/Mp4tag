using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Knuckleball;
using System.Drawing;

namespace Mp4tag
{
    class FileTag
    {
        private static string title;
        private static string artist;
        private static string releaseDate;
        private static string rating;
        private static string genre;
        private static Image artwork;
        private static string album;
        private static string albumArtist;
        private static string purchaseDate;
        private static string shortDescription;
        private static string longDescription;
        private static MediaKind videoKind;
        private static string actors;
        private static string director;
        private static string producer;
        private static string screenwriter;
        private static string show;
        private static string episodeId;
        private static int season;
        private static int episode;
        private static string tvNetwork;
        private static Boolean isPodcast;
        private static string feedUrl;
        private static string episodeUrl;
        private static string category;
        private static string keyword;
        private static ContentRating advisory;
        //private static string noClue;

        public static void ReadFile(MP4File file)
        {
            try
            {
                title = file.Tags.Title;
            }
            catch
            {
                title = "";
            }

            try
            {
                artist = file.Tags.Artist;
            }
            catch
            {
                artist = "";
            }

            try
            {
                releaseDate = file.Tags.ReleaseDate;
            }
            catch
            {
                releaseDate = "";
            }

            try
            {
                rating = (string)file.Tags.RatingInfo.Rating;
            }
            catch
            {
                rating = "";
            }

            try
            {
                genre = file.Tags.Genre;
            }
            catch
            {
                genre = "";
            }

            try
            {
                artwork = file.Tags.Artwork;
            }
            catch
            {
                artwork = null;
            }

            try
            {
                album = file.Tags.Album;
            }
            catch
            {
                album = "";
            }

            try
            {
                albumArtist = file.Tags.AlbumArtist;
            }
            catch
            {
                albumArtist = "";
            }

            try
            {
                purchaseDate = file.Tags.PurchasedDate;
            }
            catch
            {
                purchaseDate = "";
            }

            try
            {
                shortDescription = file.Tags.Description;
            }
            catch
            {
                shortDescription = "";
            }

            try
            {
                longDescription = file.Tags.LongDescription;
            }
            catch
            {
                longDescription = "";
            }

            try
            {
                videoKind = file.Tags.MediaType;
            }
            catch
            {
                videoKind = 0;
            }

            try
            {
                if (file.Tags.MovieInfo.HasCast)
                {
                    actors = String.Join(",", file.Tags.MovieInfo.Cast);
                }
                else
                {
                    actors = "";
                }
            }
            catch
            {
                actors = "";
            }

            try
            {
                if (file.Tags.MovieInfo.HasDirectors)
                {
                    director = String.Join(",", file.Tags.MovieInfo.Directors);
                }
                else
                {
                    director = "";
                }
            }
            catch
            {
                director = "";
            }
            
            try
            {
                if (file.Tags.MovieInfo.HasScreenwriters)
                {
                    screenwriter = String.Join(",", file.Tags.MovieInfo.Screenwriters);
                }
                else
                {
                    screenwriter = "";
                }
            }
            catch
            {
                screenwriter = "";
            }

            try
            {
                show = file.Tags.TVShow;
            }
            catch
            {
                show = "";
            }

            try
            {
                episodeId = file.Tags.EpisodeId;
            }
            catch
            {
                episodeId = "";
            }

            try
            {
                season = (int)file.Tags.SeasonNumber;
            }
            catch
            {
                season = 0;
            }

            try
            {
                episode = (int)file.Tags.EpisodeNumber;
            }
            catch
            {
                episode = 0;
            }

            try
            {
                tvNetwork = file.Tags.TVNetwork;
            }
            catch
            {
                tvNetwork = "";
            }

            try
            {
                isPodcast = (Boolean)file.Tags.IsPodcast;
            }
            catch
            {
                isPodcast = false;
            }

            feedUrl = "";
            episodeUrl = "";

            try
            {
                category = file.Tags.Category;
            }
            catch
            {
                category = "";
            }

            try
            {
                keyword = file.Tags.Keywords;
            }
            catch
            {
                keyword = "";
            }

            try
            {
                advisory = file.Tags.ContentRating;
            }
            catch
            {
                advisory = 0;
            }
        }

        public static Object GetFileTag(string tag)
        {
            if (tag == "title")
                return title;
            else if (tag == "artist")
                return artist;
            else if (tag == "releaseDate")
                return releaseDate;
            else if (tag == "rating")
                return rating;
            else if (tag == "genre")
                return genre;
            else if (tag == "artwork")
                return artwork;
            else if (tag == "album")
                return album;
            else if (tag == "albumArtist")
                return albumArtist;
            else if (tag == "purchaseDate")
                return purchaseDate;
            else if (tag == "shortDescrition")
                return shortDescription;
            else if (tag == "longDescrition")
                return longDescription;
            else if (tag == "videoKind")
                return videoKind;
            else if (tag == "actors")
                return actors;
            else if (tag == "director")
                return director;
            else if (tag == "producer")
                return producer;
            else if (tag == "screenwriter")
                return screenwriter;
            else if (tag == "show")
                return show;
            else if (tag == "episodeId")
                return episodeId;
            else if (tag == "season")
                return season;
            else if (tag == "episode")
                return episode;
            else if (tag == "tvNetwork")
                return tvNetwork;
            else
                return null;
        }
    }
}
