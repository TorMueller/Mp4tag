using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Collections;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;

namespace Mp4tag
{
    class Config
    {
        /// <summary>
        /// Gets the needed language file version of the application
        /// </summary>
        public static string LanguageVersion { get; private set; }

        ///// <summary>
        ///// Gets the version of the application
        ///// </summary>
        //public static string Version { get; private set; }

        /// <summary>
        /// Gets the current language of the application
        /// </summary>
        public static string Language { get; private set; }

        ///// <summary>
        ///// Gets the default movie rating source of the application
        ///// </summary>
        //public static string MovieRatingSource { get; private set; }

        ///// <summary>
        ///// Gets the default movie rating source of the application
        ///// </summary>
        //public static string TvRatingSource { get; private set; }

        /// <summary>
        /// Gets the default movie rating source of the application
        /// </summary>
        public static Boolean AutoUpdate { get; private set; }

        /// <summary>
        /// Loads the configuration from registry
        /// </summary>
        public static void Load()
        {
            RegistryKey key = (Registry.CurrentUser).CreateSubKey("Software");
            key = key.CreateSubKey(Properties.Resources.appName);

            //// Get App Version from Assembly
            //Assembly asm = Assembly.GetExecutingAssembly();
            //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
            //string asmVersion = (fvi.FileVersion).ToString();

            //if (key.GetValue("Version") == null)
            //{
            //    key.SetValue("Version", asmVersion, RegistryValueKind.String);
            //    Version = asmVersion;
            //}
            //else
            //{
            //    Version = (key.GetValue("Version")).ToString();
            //}

            // Check App Version
            //if (Version != asmVersion)
            //{
            //    key = (Registry.CurrentUser).CreateSubKey("Software");
            //    key.DeleteSubKeyTree(Properties.Resources.appName);
            //    key = key.CreateSubKey(Properties.Resources.appName);
            //    key.SetValue("Version", Version, RegistryValueKind.String);
            //}

            if (key.GetValue("LanguageVersion") == null)
            {
                key.SetValue("LanguageVersion", Properties.Resources.languageVersion, RegistryValueKind.String);
                LanguageVersion = Properties.Resources.languageVersion;
            }
            else
            {
                LanguageVersion = (key.GetValue("LanguageVersion")).ToString();
            }

            if (key.GetValue("Language") == null)
            {
                key.SetValue("Language", Properties.Resources.defaultLanguage, RegistryValueKind.String);
                Language = Properties.Resources.defaultLanguage;
            }
            else
            {
                Language = (key.GetValue("Language")).ToString();
            }

            //if (key.GetValue("MovieRatingSource") == null)
            //{
            //    key.SetValue("MovieRatingSource", Properties.Resources.defaultMovieSource, RegistryValueKind.String);
            //    MovieRatingSource = Properties.Resources.defaultMovieSource;
            //}
            //else
            //{
            //    MovieRatingSource = (key.GetValue("MovieRatingSource")).ToString();
            //}

            //if (key.GetValue("TvRatingSource") == null)
            //{
            //    key.SetValue("TvRatingSource", Properties.Resources.defaultTvSource, RegistryValueKind.String);
            //    TvRatingSource = Properties.Resources.defaultTvSource;
            //}
            //else
            //{
            //    TvRatingSource = (key.GetValue("TvRatingSource")).ToString();
            //}

            if (key.GetValue("AutoUpdate") == null)
            {
                key.SetValue("AutoUpdate", Properties.Resources.autoUpdate, RegistryValueKind.String);
                AutoUpdate = Boolean.Parse(Properties.Resources.autoUpdate);
            }
            else
            {
                AutoUpdate = Boolean.Parse((key.GetValue("AutoUpdate")).ToString());
            }
        }

        /// <summary>
        /// Saves the configuration from registry
        /// </summary>
        public static void Save()
        {
        }
    }
}
