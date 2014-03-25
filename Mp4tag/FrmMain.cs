using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace Mp4tag
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private static String fileName = "";
        private static Boolean savePicture = true;

        private void showHelp(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl.Tag != null)
            {
                sslStatus.Text = (ctrl.Tag).ToString();
            }
        }

        private void hideHelp(object sender, EventArgs e)
        {
            sslStatus.Text = Language.GetStatus(this, "default");
        }

        private void AddRegexToComboBox(Control ctrl)
        {
            if (ctrl is ComboBox)
            {
                ComboBox cmbBox = ctrl as ComboBox;
                cmbBox.SelectedIndexChanged += new EventHandler(correctComboBox);
            }
            else
            {
                foreach (Control child in ctrl.Controls)
                {
                    AddRegexToComboBox(child);
                }
            }
        }

        private void ClearAllControls(Control ctrl)
        {
            if (ctrl is CheckBox)
            {
                CheckBox chkBox = ctrl as CheckBox;
                chkBox.Checked = false;
            }
            else if (ctrl is TextBox)
            {
                TextBox txtBox = ctrl as TextBox;
                txtBox.Clear();
            }
            else if (ctrl is ComboBox)
            {
                ComboBox cmbBox = ctrl as ComboBox;
                cmbBox.SelectedIndex = -1;
                cmbBox.Items.Clear();
                cmbBox.Text = "";
            }
            else if (ctrl is RadioButton)
            {
                RadioButton rdoButton = ctrl as RadioButton;
                rdoButton.Checked = false;
            }
            else if (ctrl is DataGridView)
            {
                DataGridView dgv = ctrl as DataGridView;
                dgv.Rows.Clear();
            }
            else
            {
                foreach (Control child in ctrl.Controls)
                {
                    ClearAllControls(child);
                }
            }
        }

        private void EnableGUI()
        {
            itmSave.Enabled = true;
            itmClose.Enabled = true;
            itmEdit.Enabled = true;
            itmTagSources.Enabled = true;
            splMain.Enabled = true;
            sslStatus.Text = Language.GetStatus(this, "default");
        }

        private void DisableGUI()
        {
            itmSave.Enabled = false;
            itmClose.Enabled = false;
            itmEdit.Enabled = false;
            itmTagSources.Enabled = false;
            splMain.Enabled = false;
            sslStatus.Text = Language.GetStatus(this, "noFile");
        }

        private void ClearGUI()
        {
            tbcMain.SelectTab(0);
            picArtwork.Image = Properties.Resources.noImage;
            ClearAllControls(this);
        }

        //private void languageChanged(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem languageItem = (sender as ToolStripMenuItem);

        //    // 1. Close open file with Popupbox

        //    if (LanguageOld.SetLanguage(languageItem.Text))
        //    {
        //        // 2. Remove checked from all
        //        // 3. Check new Language

        //        ClearGUI();
        //        DisableGUI();
        //        Language.Populate(this);
        //    }
        //    return;
        //}

        private void itmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if ((splMain.Size).Width - splMain.SplitterDistance < splMain.Panel2MinSize)
            {
                splMain.SplitterDistance = (splMain.Size).Width - splMain.Panel2MinSize;
            }
        }

        private void itmOpen_Click(object sender, EventArgs e)
        {
            if (ofdFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Knuckleball.MP4File mp4File = Knuckleball.MP4File.Open(ofdFile.FileName);

            //-----------------------
            // Check if file has tags
            //-----------------------

            //MessageBox.Show(MimeType.GetMimeFromFile(ofdFile.FileName));

            if (mp4File.Tags == null)
            {
                MessageBox.Show(this, Language.GetFormMessage(this, "0001"), Language.GetGlobalMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //-------------------------
            // Prepare GUI for new data
            //-------------------------

            ClearGUI();
            DisableGUI();

            fileName = ofdFile.FileName;
            this.Text = Properties.Resources.appName + " - " + GetFileName();
            sslStatus.Text = Language.GetStatus(this, "read");

            //------------------------
            // Now copy data from file
            //------------------------

            // Media Type         
            foreach (String type in Metadata.GetMediaTypes())
            {
                cmbMediaType.Items.Add(type);
            }        
            if (((mp4File.Tags.MediaType).ToString() != "") && (cmbMediaType.Items.Contains(Metadata.GetMediaType((int)mp4File.Tags.MediaType))))
            {
                cmbMediaType.SelectedIndex = cmbMediaType.Items.IndexOf(Metadata.GetMediaType((int)mp4File.Tags.MediaType));
            }            
            else
            {
                FrmMediaType frmMediaType = new FrmMediaType();

                if (frmMediaType.ShowDialog(this) == DialogResult.OK)
                {
                    if (frmMediaType.rdoMediaType9.Checked)
                    {
                        cmbMediaType.SelectedIndex = cmbMediaType.Items.IndexOf(Metadata.GetMediaType(9));
                    }
                    else if (frmMediaType.rdoMediaType10.Checked)
                    {
                        cmbMediaType.SelectedIndex = cmbMediaType.Items.IndexOf(Metadata.GetMediaType(10));
                    }
                    else if (frmMediaType.rdoMediaType6.Checked)
                    {
                        cmbMediaType.SelectedIndex = cmbMediaType.Items.IndexOf(Metadata.GetMediaType(6));
                    }
                    else
                    {
                        cmbMediaType.SelectedIndex = cmbMediaType.Items.IndexOf(Metadata.GetMediaType(0));
                    }
                }
                else
                {
                    ClearGUI();
                    DisableGUI();
                    this.Text = Properties.Resources.appName;
                    return;
                }
            }

            // Title
            if ((mp4File.Tags.Title != null) && (mp4File.Tags.Title != ""))
            {
                cmbTitle.Text = mp4File.Tags.Title;
                cmbTitle.Items.Add("[File] " + mp4File.Tags.Title);                
            }

            //Artist
            if ((mp4File.Tags.Artist != null) && (mp4File.Tags.Artist != ""))
            {
                cmbArtist.Text = mp4File.Tags.Artist;
                cmbArtist.Items.Add("[File] " + mp4File.Tags.Artist);
            }

            // (Release) Date            
            if ((mp4File.Tags.ReleaseDate != null) && (mp4File.Tags.ReleaseDate != ""))
            {
                cmbReleaseDate.Text = mp4File.Tags.ReleaseDate;
                cmbReleaseDate.Items.Add("[File] " + mp4File.Tags.ReleaseDate);
            }

            // Rating
            // MessageBox.Show("Rating: " + mp4File.Tags.RatingInfo.Rating + System.Environment.NewLine + "Rating source: " + mp4File.Tags.RatingInfo.RatingSource + System.Environment.NewLine + "Rating annotation: " + mp4File.Tags.RatingInfo.RatingAnnotation + System.Environment.NewLine + "Rating sort value: " + mp4File.Tags.RatingInfo.SortValue);
            // --> cmbMediaType_SelectedIndexChanged

            // Genre
            // --> cmbMediaType_SelectedIndexChanged
            
            // Picture
            if (mp4File.Tags.ArtworkCount > 0)
            {
                savePicture = true;
                picArtwork.Image = mp4File.Tags.Artwork;
                lblSize.Text = (picArtwork.Image.Width).ToString() + " x " + (picArtwork.Image.Height).ToString();
                btnPictureKeep.Enabled = true;
            }
            else
            {
                btnPictureKeep.Enabled = false;
            }

            // Album
            if ((mp4File.Tags.Album != null) && (mp4File.Tags.Album != ""))
            {
                cmbAlbum.Text = mp4File.Tags.Album;
                cmbAlbum.Items.Add("[File] " + mp4File.Tags.Album);
            }

            // AlbumArtist
            if ((mp4File.Tags.AlbumArtist != null) && (mp4File.Tags.AlbumArtist != ""))
            {
                cmbAlbumArtist.Text = mp4File.Tags.AlbumArtist;
                cmbAlbumArtist.Items.Add("[File] " + mp4File.Tags.AlbumArtist);
            }

            // Purchase Date            
            if ((mp4File.Tags.PurchasedDate != null) && (mp4File.Tags.PurchasedDate != ""))
            {
                cmbPurchaseDate.Text = mp4File.Tags.PurchasedDate;
                cmbPurchaseDate.Items.Add("[File] " + mp4File.Tags.PurchasedDate);
            }

            // Short Description
            if ((mp4File.Tags.Description != null) && (mp4File.Tags.Description != ""))
            {
                txtShortDescription.Text = mp4File.Tags.Description;
                rdoShortDescriptionKeep.Checked = true;
            }
            else
            {
                rdoShortDescriptionBlank.Checked = true;
            }

            // Long Description
            if ((mp4File.Tags.Description != null) && (mp4File.Tags.LongDescription != ""))
            {
                txtLongDescription.Text = mp4File.Tags.LongDescription;
                rdoLongDescriptionKeep.Checked = true;
            }
            else
            {
                rdoLongDescriptionBlank.Checked = true;
            }

            // HD
            foreach (string value in Metadata.GetHDVideos())
            {
                cmbHdVideo.Items.Add(value);
            }
            if (cmbHdVideo.Items.Contains(Metadata.GetHDVideo((int)mp4File.Tags.HDVideo)))
            {
                cmbHdVideo.SelectedIndex = cmbHdVideo.Items.IndexOf(Metadata.GetHDVideo((int)mp4File.Tags.HDVideo));
            }
            else
            {
                cmbHdVideo.SelectedIndex = -1;
            }

            // Cast
            if ((mp4File.Tags.MovieInfo != null) && (mp4File.Tags.MovieInfo.HasCast))
            {
                cmbCast.Text = String.Join(",", mp4File.Tags.MovieInfo.Cast);
                cmbCast.Items.Add("[File] " + cmbCast.Text);
            }

            // Directors
            if ((mp4File.Tags.MovieInfo != null) && (mp4File.Tags.MovieInfo.HasDirectors))
            {
                cmbDirectors.Text = String.Join(",", mp4File.Tags.MovieInfo.Directors);
                cmbDirectors.Items.Add("[File] " + cmbDirectors.Text);
            }

            // Producers
            if ((mp4File.Tags.MovieInfo != null) && (mp4File.Tags.MovieInfo.HasProducers))
            {
                cmbProducers.Text = String.Join(",", mp4File.Tags.MovieInfo.Producers);
                cmbProducers.Items.Add("[File] " + cmbProducers.Text);
            }

            // Screenwriters
            if ((mp4File.Tags.MovieInfo != null) && (mp4File.Tags.MovieInfo.HasScreenwriters))
            {
                cmbScreenwriters.Text = String.Join(",", mp4File.Tags.MovieInfo.Screenwriters);
                cmbScreenwriters.Items.Add("[File] " + cmbScreenwriters.Text);
            }

            // Copyright
            if ((mp4File.Tags.Copyright != "") && (mp4File.Tags.Copyright != ""))
            {
                cmbCopyright.Text = mp4File.Tags.Copyright;
                cmbCopyright.Items.Add("[File] " + mp4File.Tags.Copyright);
            }

            // Studio
            if ((mp4File.Tags.MovieInfo != null) && (mp4File.Tags.MovieInfo.Studio != null) && (mp4File.Tags.MovieInfo.Studio != ""))
            {
                cmbStudio.Text = mp4File.Tags.MovieInfo.Studio;
                cmbStudio.Items.Add("[File] " + mp4File.Tags.MovieInfo.Studio);
            }

            // Show
            if ((mp4File.Tags.TVShow != null) && (mp4File.Tags.TVShow != ""))
            {
                cmbTVShow.Text = mp4File.Tags.TVShow;
                cmbTVShow.Items.Add("[File] " + mp4File.Tags.TVShow);
            }

            // Episode ID
            if ((mp4File.Tags.EpisodeId != null) && (mp4File.Tags.EpisodeId != ""))
            {
                cmbEpisodeId.Text = mp4File.Tags.EpisodeId;
                cmbEpisodeId.Items.Add("[File] " + mp4File.Tags.EpisodeId);
            }

            // Season
            if (mp4File.Tags.SeasonNumber != null)
            {
                cmbSeason.Text = (mp4File.Tags.SeasonNumber).ToString();
                cmbSeason.Items.Add("[File] " + cmbSeason.Text);
            }

            // Episode
            if (mp4File.Tags.EpisodeNumber != null)
            {
                cmbEpisode.Text = (mp4File.Tags.EpisodeNumber).ToString();
                cmbEpisode.Items.Add("[File] " + cmbEpisode.Text);
            }

            // TV Network
            if ((mp4File.Tags.TVNetwork != null) && (mp4File.Tags.TVNetwork != ""))
            {
                cmbTVNetwork.Text = mp4File.Tags.TVNetwork;
                cmbTVNetwork.Items.Add("[File] " + mp4File.Tags.TVNetwork);
            }

            // Podcast
            cmbPodcast.Items.Add(Boolean.TrueString);
            cmbPodcast.Items.Add(Boolean.FalseString);
            if (mp4File.Tags.IsPodcast != null)
            {
                if ((Boolean)mp4File.Tags.IsPodcast)
                {
                    cmbPodcast.SelectedIndex = cmbPodcast.Items.IndexOf(Boolean.TrueString);
                }
                else
                {
                    cmbPodcast.SelectedIndex = cmbPodcast.Items.IndexOf(Boolean.FalseString);
                }
            }

            // Category
            if ((mp4File.Tags.Category != null) && (mp4File.Tags.Category != ""))
            {
                cmbCategory.Text = mp4File.Tags.Category;
                cmbCategory.Items.Add("[File] " + mp4File.Tags.Category);
            }

            // Keyword          
            if ((mp4File.Tags.Keywords != null) && (mp4File.Tags.Keywords != ""))
            {
                cmbKeywords.Text = mp4File.Tags.Keywords;
                cmbKeywords.Items.Add("[File] " + mp4File.Tags.Keywords);
            }

            // Content Rating
            foreach (String content in Metadata.GetContentRatings())
            {
                cmbContentRating.Items.Add(content);
            }
            if (cmbContentRating.Items.Contains(Metadata.GetContentRating((int)mp4File.Tags.ContentRating)))
            {
                cmbContentRating.SelectedIndex = cmbContentRating.Items.IndexOf((mp4File.Tags.ContentRating).ToString());
            }

            // Track number
            if (mp4File.Tags.TrackNumber != null)
            {
                cmbTrackNumber.Text = (mp4File.Tags.TrackNumber).ToString();
                cmbTrackNumber.Items.Add("[File] " + mp4File.Tags.TrackNumber);
            }

            // Track Total
            if (mp4File.Tags.TotalTracks != null)
            {
                cmbTotalTracks.Text = (mp4File.Tags.TotalTracks).ToString();
                cmbTotalTracks.Items.Add("[File] " + mp4File.Tags.TotalTracks);

            }

            // Disk Number
            if (mp4File.Tags.DiscNumber != null)
            {
                cmbDiscNumber.Text = (mp4File.Tags.DiscNumber).ToString();
                cmbDiscNumber.Items.Add("[File] " + mp4File.Tags.DiscNumber);
            }

            // Disk Total
            if (mp4File.Tags.TotalDiscs != null)
            {
                cmbTotalDisc.Text = (mp4File.Tags.TotalDiscs).ToString();
                cmbDiscNumber.Items.Add("[File] " + mp4File.Tags.DiscNumber);
            }

            // Grouping
            if ((mp4File.Tags.Grouping != null) && (mp4File.Tags.Grouping != ""))
            {
                cmbGrouping.Text = mp4File.Tags.Grouping;
                cmbGrouping.Items.Add("[File] " + mp4File.Tags.Grouping);
            }

            // Encoding Tool
            if ((mp4File.Tags.EncodingTool != null) && (mp4File.Tags.EncodingTool != ""))
            {
                cmbEncodingTool.Text = mp4File.Tags.EncodingTool;
                cmbEncodingTool.Items.Add("[File] " + mp4File.Tags.EncodingTool);
            }

            // Encoded By           
            if ((mp4File.Tags.EncodedBy != null) && (mp4File.Tags.EncodedBy != ""))
            {
                cmbEncodedBy.Text = mp4File.Tags.EncodedBy;
                cmbEncodedBy.Items.Add("[File] " + mp4File.Tags.EncodedBy);
            }

            // Comment
            if ((mp4File.Tags.Comment != null) && (mp4File.Tags.Comment != ""))
            {
                cmbComment.Text = mp4File.Tags.Comment;
                cmbComment.Items.Add("[File] " + mp4File.Tags.Comment);
            }

            // Gapless
            cmbGapless.Items.Add("True");
            cmbGapless.Items.Add("False");
            if (mp4File.Tags.IsGapless != null)
            {
                if ((Boolean)mp4File.Tags.IsGapless)
                {
                    cmbGapless.SelectedIndex = 0;
                }
                else
                {
                    cmbGapless.SelectedIndex = 1;
                }
            }         

            // Compilation
            cmbCompilation.Items.Add("True");
            cmbCompilation.Items.Add("False");
            if (mp4File.Tags.IsCompilation != null)
            {
                if ((Boolean)mp4File.Tags.IsCompilation)
                {
                    cmbCompilation.SelectedIndex = 0;
                }
                else
                {
                    cmbCompilation.SelectedIndex = 1;
                }

            }

            // Catalog ID
            // -> not yet supported

            // Sort Name          
            if ((mp4File.Tags.SortName != null) && (mp4File.Tags.SortName != ""))
            {
                cmbSortName.Text = mp4File.Tags.SortName;
                cmbSortName.Items.Add("[File] " + mp4File.Tags.SortName);
            }

            // Sort Artist
            if ((mp4File.Tags.SortArtist != null) && (mp4File.Tags.SortArtist != ""))
            {
                cmbSortArtist.Text = mp4File.Tags.SortArtist;
                cmbSortArtist.Items.Add("[File] " + mp4File.Tags.SortArtist);
            }

            // Sort Show
            if ((mp4File.Tags.SortTVShow != null) && (mp4File.Tags.SortTVShow != ""))
            {
                cmbSortTVShow.Text = mp4File.Tags.SortTVShow;
                cmbSortTVShow.Items.Add("[File] " + mp4File.Tags.SortTVShow);
            }

            // Sort Album Artist           
            if ((mp4File.Tags.SortAlbumArtist != null) && (mp4File.Tags.SortAlbumArtist != ""))
            {
                cmbSortAlbumArtist.Text = mp4File.Tags.SortAlbumArtist;
                cmbSortAlbumArtist.Items.Add("[File] " + mp4File.Tags.SortAlbumArtist);
            }

            // Sort Album            
            if ((mp4File.Tags.SortAlbum != null) && (mp4File.Tags.SortAlbum != ""))
            {
                cmbSortAlbum.Text = mp4File.Tags.SortAlbum;
                cmbSortAlbum.Items.Add("[File] " + mp4File.Tags.SortAlbum);
            }

            // Chapters
            TimeSpan fromStart = new TimeSpan(0, 0, 0);
            for (int i = 0; i < (mp4File.Chapters).Count; i++)
            {
                string columnDuration = mp4File.Chapters[i].Duration.Hours.ToString("00") + ":" + mp4File.Chapters[i].Duration.Minutes.ToString("00") + ":" + mp4File.Chapters[i].Duration.Seconds.ToString("00");
                string columnFromStart = fromStart.Hours.ToString("00") + ":" + fromStart.Minutes.ToString("00") + ":" + fromStart.Seconds.ToString("00");
                dgvChapters.Rows.Add((i + 1).ToString("00"), "Chapter " + (i + 1).ToString(), mp4File.Chapters[i].Title, columnDuration, columnFromStart);
                fromStart += mp4File.Chapters[i].Duration;
            }

            //----------------
            // Enable controls
            //----------------

            EnableGUI();
        }

        private void itmClose_Click(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.appName;
            fileName = "";

            ClearGUI();
            DisableGUI();
        }

        private void itmSave_Click(object sender, EventArgs e)
        {
            DisableGUI();
            sslStatus.Text = Language.GetStatus(this, "write");

            try
            {
                Knuckleball.MP4File mp4File = Knuckleball.MP4File.Open(@fileName);

                // Video Kind
                if (chkMediaType.Checked)
                {
                    mp4File.Tags.MediaType = (Knuckleball.MediaKind)Metadata.GetMediaType(cmbMediaType.Text);
                }

                // Title
                if (chkTitle.Checked)
                {
                    mp4File.Tags.Title = cmbTitle.Text;
                }

                // Artist
                if (chkArtist.Checked)
                {
                    mp4File.Tags.Artist = cmbArtist.Text;
                }

                // Date
                if (chkReleaseDate.Checked)
                {
                    mp4File.Tags.ReleaseDate = cmbReleaseDate.Text;
                }

                // Rating
                if (chkRatingInfo.Checked)
                {
                    if (cmbRating.Text != "")
                    {
                        if (Metadata.GetRatingValue(cmbMediaType.Text, cmbRatingSource.Text, cmbRating.Text) != null)
                        {
                            mp4File.Tags.RatingInfo.Rating = cmbRating.Text;
                            mp4File.Tags.RatingInfo.RatingSource = cmbRatingSource.Text;
                            mp4File.Tags.RatingInfo.SortValue = (int)Metadata.GetRatingValue(cmbMediaType.Text, cmbRatingSource.Text, cmbRating.Text);
                        }
                        else
                        {
                            MessageBox.Show(this, Language.GetFormMessage(this, "0001") + System.Environment.NewLine + System.Environment.NewLine + "Rating: " + cmbRating.Text + System.Environment.NewLine + "Rating source: " + cmbRatingSource.Text + System.Environment.NewLine + "Rating sort value: " + (Metadata.GetRatingValue(cmbMediaType.Text, cmbRatingSource.Text, cmbRating.Text)).ToString(), Language.GetGlobalMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                // Genre
                if (chkGenre.Checked)
                {
                    if (cmbGenre.Text != "")
                    {
                        mp4File.Tags.GenreId = Metadata.GetGenre(cmbMediaType.Text, cmbGenre.Text);
                        mp4File.Tags.Genre = cmbGenre.Text;
                    }
                }

                // Picture
                if (savePicture)
                {
                    mp4File.Tags.Artwork = picArtwork.Image;
                }
                else
                {
                    mp4File.Tags.Artwork = null;
                }

                // Album
                if (chkAlbum.Checked)
                {
                    mp4File.Tags.Album = cmbAlbum.Text;
                }

                // AlbumArtist
                if (chkAlbumArtist.Checked)
                {
                    mp4File.Tags.AlbumArtist = cmbAlbumArtist.Text;
                }

                // Purchase Date
                if (chkPurchaseDate.Checked)
                {
                    mp4File.Tags.PurchasedDate = cmbPurchaseDate.Text;
                }

                // Short Description
                if (rdoShortDescriptionChange.Checked)
                {
                    mp4File.Tags.Description = txtShortDescription.Text;
                }
                else if (rdoShortDescriptionBlank.Checked)
                {
                    mp4File.Tags.Description = "";
                }

                // Long Description
                if (rdoLongDescriptionChange.Checked)
                {
                    mp4File.Tags.LongDescription = txtLongDescription.Text;
                }
                else if (rdoLongDescriptionBlank.Checked)
                {
                    mp4File.Tags.LongDescription = "";
                }

                // HD
                if ((chkHDVideo.Checked) && (cmbHdVideo.Text != ""))
                {
                    mp4File.Tags.HDVideo = (Knuckleball.HDVideo)Metadata.GetHDVideo(cmbHdVideo.Text);
                }

                // Movie Info -> Cast, Directors, Producers, Screenwriters, Studio
                if ((chkCast.Checked) || (chkDirectors.Checked) || (chkProducers.Checked) || (chkScreenwriters.Checked) || (chkStudio.Checked))
                {
                    Knuckleball.MovieInfo movieInfo = new Knuckleball.MovieInfo();

                    // Cast
                    if (chkCast.Checked)
                    {
                        if ((cmbCast.Text).Contains(","))
                        {
                            foreach (String actor in (((cmbCast.Text).Replace(", ", ",")).Replace(" ,", ",")).Split(','))
                            {
                                movieInfo.Cast.Add(actor);
                            }
                        }
                        else
                        {
                            movieInfo.Cast.Add(cmbCast.Text);
                        }
                    }

                    // Directors
                    if (chkDirectors.Checked)
                    {
                        if ((cmbDirectors.Text).Contains(","))
                        {
                            foreach (String director in (((cmbDirectors.Text).Replace(", ", ",")).Replace(" ,", ",")).Split(','))
                            {
                                movieInfo.Directors.Add(director);
                            }
                        }
                        else
                        {
                            movieInfo.Directors.Add(cmbDirectors.Text);
                        }
                    }

                    // Producers
                    if (chkProducers.Checked)
                    {
                        if ((cmbProducers.Text).Contains(","))
                        {
                            foreach (String producer in (((cmbProducers.Text).Replace(", ", ",")).Replace(" ,", ",")).Split(','))
                            {
                                movieInfo.Producers.Add(producer);
                            }
                        }
                        else
                        {
                            movieInfo.Producers.Add(cmbProducers.Text);
                        }
                    }

                    // Screenwriters
                    if (chkScreenwriters.Checked)
                    {
                        if ((cmbScreenwriters.Text).Contains(","))
                        {
                            foreach (String producer in (((cmbScreenwriters.Text).Replace(", ", ",")).Replace(" ,", ",")).Split(','))
                            {
                                movieInfo.Screenwriters.Add(producer);
                            }
                        }
                        else
                        {
                            movieInfo.Screenwriters.Add(cmbScreenwriters.Text);
                        }
                    }

                    // Studio
                    if (chkStudio.Checked)
                    {
                        movieInfo.Studio = cmbStudio.Text;
                    }

                    // Copy MovieInfo
                    mp4File.Tags.MovieInfo = movieInfo;
                }

                // Copyright
                if (chkCopyright.Checked)
                {
                    mp4File.Tags.Copyright = cmbCopyright.Text;
                }

                // Show            
                if (chkTVShow.Checked)
                {
                    mp4File.Tags.TVShow = cmbTVShow.Text;
                }

                // Episode ID            
                if (chkEpisodeId.Checked)
                {
                    mp4File.Tags.EpisodeId = cmbEpisodeId.Text;
                }

                // Season            
                if (chkSeason.Checked)
                {
                    try
                    {
                        mp4File.Tags.SeasonNumber = Convert.ToInt32(cmbSeason.Text);
                    }
                    catch
                    {
                        mp4File.Tags.SeasonNumber = null;
                    }
                }

                // Episode            
                if (chkEpisode.Checked)
                {
                    try
                    {
                        mp4File.Tags.EpisodeNumber = Convert.ToInt32(cmbEpisode.Text);
                    }
                    catch
                    {
                        mp4File.Tags.EpisodeNumber = null;
                    }
                }

                // TV Network            
                if (chkTVNetwork.Checked)
                {
                    mp4File.Tags.TVNetwork = cmbTVNetwork.Text;
                }

                // Podcast            
                if ((chkPodcast.Checked) && (cmbPodcast.Text != ""))
                {
                    mp4File.Tags.IsPodcast = Boolean.Parse(cmbPodcast.Text);
                }

                // Category            
                if (chkCategory.Checked)
                {
                    mp4File.Tags.Category = cmbCategory.Text;
                }

                // Keywords            
                if (chkKeywords.Checked)
                {
                    mp4File.Tags.Keywords = cmbKeywords.Text;
                }

                // ContentRating
                if (chkContentRating.Checked)
                {
                    if (cmbContentRating.Text != "")
                    {
                        mp4File.Tags.ContentRating = (Knuckleball.ContentRating)Metadata.GetContentRating(cmbContentRating.Text);
                    }
                    else
                    {
                        mp4File.Tags.ContentRating = (Knuckleball.ContentRating)(byte.MaxValue);
                    }
                }

                // TrackNumber            
                if (chkTrackNumber.Checked)
                {
                    try
                    {
                        mp4File.Tags.TrackNumber = (short)Convert.ToInt32(cmbTrackNumber.Text);
                    }
                    catch
                    {
                        mp4File.Tags.TrackNumber = null;
                    }

                    // TrackNumberOf            
                    try
                    {
                        mp4File.Tags.TotalTracks = (short)Convert.ToInt32(cmbTotalTracks.Text);
                    }
                    catch
                    {
                        mp4File.Tags.TotalTracks = null;
                    }
                }

                // DiskNumber            
                if (chkDiscNumber.Checked)
                {
                    try
                    {
                        mp4File.Tags.DiscNumber = (short)Convert.ToInt32(cmbDiscNumber.Text);
                    }
                    catch
                    {
                        mp4File.Tags.DiscNumber = null;
                    }

                    // DiskNumberOf            
                    try
                    {
                        mp4File.Tags.TotalDiscs = (short)Convert.ToInt32(cmbTotalDisc.Text);
                    }
                    catch
                    {
                        mp4File.Tags.TotalDiscs = null;
                    }
                }

                // Grouping            
                if (chkGrouping.Checked)
                {
                    mp4File.Tags.Grouping = cmbGrouping.Text;
                }

                // Encoding Tool            
                if (chkEncodingTool.Checked)
                {
                    mp4File.Tags.EncodingTool = cmbEncodingTool.Text;
                }

                // EncodedBy      
                if (chkEncodedBy.Checked)
                {
                    mp4File.Tags.EncodedBy = cmbEncodedBy.Text;
                }

                // Comment      
                if (chkComment.Checked)
                {
                    mp4File.Tags.Comment = cmbComment.Text;
                }

                // Gapless
                if ((chkGapless.Checked) && (cmbGapless.Text != ""))
                {
                    mp4File.Tags.IsGapless = Boolean.Parse(cmbGapless.Text);
                }

                // Compilation
                if ((chkCompilation.Checked) && (cmbCompilation.Text != ""))
                {
                    mp4File.Tags.IsCompilation = Boolean.Parse(cmbCompilation.Text);
                }

                // Sort Name      
                if (chkSortName.Checked)
                {
                    mp4File.Tags.SortName = cmbSortName.Text;
                }

                // Sort Artist      
                if (chkSortArtist.Checked)
                {
                    mp4File.Tags.SortArtist = cmbSortArtist.Text;
                }

                // Sort Show      
                if (chkSortTVShow.Checked)
                {
                    mp4File.Tags.SortTVShow = cmbSortTVShow.Text;
                }

                // Sort Album Artist      
                if (chkSortAlbumArtist.Checked)
                {
                    mp4File.Tags.SortAlbumArtist = cmbSortAlbumArtist.Text;
                }

                // Sort Album      
                if (chkSortAlbum.Checked)
                {
                    mp4File.Tags.SortAlbum = cmbSortAlbum.Text;
                }

                // ==> CHAPTERS CODE HERE!!!

                // Save everything
                mp4File.Save();
            }
            catch
            {
                MessageBox.Show(this, Language.GetFormMessage(this, "0003"), Language.GetGlobalMessage("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            EnableGUI();
        }

        private void cmbMediaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Metadata.GetGenres(cmbMediaType.Text) != null)
            {
                cmbGenre.Items.Clear();
                foreach (string genre in Metadata.GetGenres(cmbMediaType.Text))
                {
                    cmbGenre.Items.Add(genre);
                }
            }

            if (fileName != "")
            {
                Knuckleball.MP4File mp4File = Knuckleball.MP4File.Open(@fileName);

                if ((mp4File.Tags.GenreId != null) && (cmbGenre.Items.Contains(Metadata.GetGenre(cmbMediaType.Text, (int)mp4File.Tags.GenreId))))
                {
                    cmbGenre.SelectedIndex = cmbGenre.Items.IndexOf(Metadata.GetGenre(cmbMediaType.Text, (int)mp4File.Tags.GenreId));
                }
                else if ((mp4File.Tags.Genre != null) && cmbGenre.Items.Contains(mp4File.Tags.Genre))
                {
                    cmbGenre.SelectedIndex = cmbGenre.Items.IndexOf(Metadata.GetGenre(cmbMediaType.Text, (int)mp4File.Tags.GenreId));
                }

                cmbRatingSource.Items.Clear();
                cmbRating.Items.Clear();
                foreach (string ratingSource in Metadata.GetRatingSources(cmbMediaType.Text))
                {
                    cmbRatingSource.Items.Add(ratingSource);
                }
                if ((Metadata.GetMediaType(cmbMediaType.Text) != null) && (((int)Metadata.GetMediaType(cmbMediaType.Text) == 9) || ((int)Metadata.GetMediaType(cmbMediaType.Text) == 10)) && (mp4File.Tags.RatingInfo != null))
                {
                    cmbRatingSource.Enabled = true;

                    if ((mp4File.Tags.RatingInfo.RatingSource != "") && (cmbRatingSource.Items.Contains(mp4File.Tags.RatingInfo.RatingSource)))
                    {
                        cmbRatingSource.SelectedIndex = cmbRatingSource.Items.IndexOf(mp4File.Tags.RatingInfo.RatingSource);
                    }
                    else
                    {
                        cmbRatingSource.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbRatingSource.Enabled = true;
                    cmbRating.Enabled = false;
                }

                // cmbRating
                // --> cmbRatingSource_SelectedIndexChanged

                if ((mp4File.Tags.RatingInfo != null) && (mp4File.Tags.RatingInfo.Rating != "") && (mp4File.Tags.RatingInfo.RatingSource != "") && (cmbRating.Text == ""))
                {
                    MessageBox.Show(this, Language.GetFormMessage(this, "0004") + System.Environment.NewLine + System.Environment.NewLine + "Rating: " + mp4File.Tags.RatingInfo.Rating + System.Environment.NewLine + "Rating source: " + mp4File.Tags.RatingInfo.RatingSource, Language.GetGlobalMessage("warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnPictureSelect_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            picArtwork.Image = Image.FromFile(ofdPicture.FileName);
            savePicture = true;
            lblSize.Text = (picArtwork.Image.Width).ToString() + " x " + (picArtwork.Image.Height).ToString();
        }

        private void btnPictureBlank_Click(object sender, EventArgs e)
        {
            picArtwork.Image = Properties.Resources.noImage;
            savePicture = false;
            lblSize.Text = "";
        }

        private void btnPictureKeep_Click(object sender, EventArgs e)
        {
            Knuckleball.MP4File mp4File = Knuckleball.MP4File.Open(@fileName);

            if (mp4File.Tags.ArtworkCount > 0)
            {
                picArtwork.Image = mp4File.Tags.Artwork;
                savePicture = true;
                lblSize.Text = (picArtwork.Image.Width).ToString() + " x " + (picArtwork.Image.Height).ToString();
            }
            else
            {
                btnPictureBlank.PerformClick();
            }
        }

        private void txtShortDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtShortDescription.Text != "")
            {
                rdoShortDescriptionChange.Checked = true;
            }
        }

        private void txtLongDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtLongDescription.Text != "")
            {
                rdoLongDescriptionChange.Checked = true;
            }
        }

        private void numbersOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbTitle_TextChanged(object sender, EventArgs e)
        {
            txtTagsName.Text = cmbTitle.Text;
        }

        private void cmbArtist_TextChanged(object sender, EventArgs e)
        {
            txtTagsArtist.Text = cmbArtist.Text;
        }

        private void cmbShow_TextChanged(object sender, EventArgs e)
        {
            txtTagsTVShow.Text = cmbTVShow.Text;
        }

        private void cmbAlbumArtist_TextChanged(object sender, EventArgs e)
        {
            txtTagsAlbumArtist.Text = cmbAlbumArtist.Text;
        }

        private void cmbAlbum_TextChanged(object sender, EventArgs e)
        {
            txtTagsAlbum.Text = cmbAlbum.Text;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            ClearGUI();
            DisableGUI();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Initialize some variables
            Config.Load();
            Metadata.Initialize();
            Language.Initialize();

            // Start AutoUpdater first
            if (Config.AutoUpdate)
            {
                AutoUpdate.checkUpdate();
            }

            this.Icon = Properties.Resources.Mp4tag;
            this.Text = Properties.Resources.appName;

            Language.Populate(this);
            AddRegexToComboBox(this);
        }

        public static Control FindFocusedControl(Control control)
        {
            var container = control as ContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control;
        }

        private void copyClipboard(object sender, EventArgs e)
        {
            Control focusedControl = FindFocusedControl(this);

            if (focusedControl is TextBox)
            {
                Clipboard.SetDataObject(((TextBox)focusedControl).SelectedText, true);
            }
            else if (focusedControl is ComboBox)
            {
                Clipboard.SetDataObject(((ComboBox)focusedControl).SelectedText, true);

            }
        }

        private void cutClipboard(object sender, EventArgs e)
        {
            Control focusedControl = FindFocusedControl(this);

            if (focusedControl is TextBox)
            {
                Clipboard.SetDataObject(((TextBox)focusedControl).SelectedText, true);
                ((TextBox)this.ActiveControl).SelectedText = "";
            }
            else if (focusedControl is ComboBox)
            {
                Clipboard.SetDataObject(((ComboBox)focusedControl).SelectedText, true);
                ((ComboBox)focusedControl).SelectedText = "";
            }
        }

        private void pasteClipboard(object sender, EventArgs e)
        {
            Control focusedControl = FindFocusedControl(this);
            int nCursorPosition;

            if (focusedControl is ComboBox)
            {
                nCursorPosition = ((ComboBox)focusedControl).SelectionStart;
                ((ComboBox)focusedControl).Text = ((ComboBox)focusedControl).Text.Insert(nCursorPosition, Clipboard.GetText());
            }
            else if (focusedControl is TextBox)
            {
                nCursorPosition = ((TextBox)focusedControl).SelectionStart;
                ((TextBox)focusedControl).Text = ((TextBox)focusedControl).Text.Insert(nCursorPosition, Clipboard.GetText());
            }    
        }

        private void correctComboBox(object sender, EventArgs e)
        {
            ComboBox cmbBox = sender as ComboBox;
            if ((cmbBox.SelectedIndex != -1) && (Regex.IsMatch(cmbBox.Text, @"^\[.*\]\s.*$")))
            {              
                BeginInvoke(new Action(() => cmbBox.Text = Regex.Replace(cmbBox.Text, @"^\[.*\]\s(.*)$", "$1")));
            }
        }

        public static string GetFileName()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(fileName);

            return fi.Name;
        }

        private void cmbRatingSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRatingSource.SelectedIndex != -1)
            {
                Knuckleball.MP4File mp4File = Knuckleball.MP4File.Open(@fileName);
                cmbRating.Items.Clear();

                foreach (string rating in Metadata.GetRatings(cmbMediaType.Text, cmbRatingSource.Text))
                {
                    cmbRating.Items.Add(rating);
                }

                if (cmbRating.Items.Count > 0)
                {
                    cmbRating.Enabled = true;

                    if ((mp4File.Tags.RatingInfo.Rating != "") && (cmbRating.Items.Contains(mp4File.Tags.RatingInfo.Rating)))
                    {
                        cmbRating.SelectedIndex = cmbRating.Items.IndexOf(mp4File.Tags.RatingInfo.Rating);
                    }
                    else
                    {
                        cmbRating.SelectedIndex = -1;
                    }
                }
                else
                {
                    cmbRating.Enabled = false;
                }
            }
            else
            {
                cmbRating.Enabled = false;
            }
        }

        private void splPicture_Panel1_SizeChanged(object sender, EventArgs e)
        {
            if ((splPicture.Panel1.Width + (splPicture.Panel1.Padding.Left + splPicture.Panel1.Padding.Right)) <= (splPicture.Size.Height + (splPicture.Panel1.Padding.Top + splPicture.Panel1.Padding.Bottom)))
            {
                picArtwork.Size = new Size((splPicture.Panel1.Width + (splPicture.Panel1.Padding.Left + splPicture.Panel1.Padding.Right)), (splPicture.Panel1.Width + (splPicture.Panel1.Padding.Left + splPicture.Panel1.Padding.Right)));
            }
            else
            {
                picArtwork.Size = new Size((splPicture.Panel1.Width + (splPicture.Panel1.Padding.Left + splPicture.Panel1.Padding.Right)), (splPicture.Size.Height + (splPicture.Panel1.Padding.Top + splPicture.Panel1.Padding.Bottom)));
            }
        }

        private void itmAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show(this);
        }

        private void itmSettings_Click(object sender, EventArgs e)
        {
            FrmSettings FrmSettings = new FrmSettings();
            FrmSettings.Show(this);
        }
    }
}
