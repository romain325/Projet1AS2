using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace prjtS2.MainApp.AdminPanel
{
    /// <summary>
    /// Logique d'interaction pour AddLessonPanel.xaml
    /// </summary>
    public partial class AddLessonPanel : UserControl, INotifyPropertyChanged
    {
        public int _Progress;

        public AddLessonPanel()
        {
            InitializeComponent();
            Progress = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Progress
        {
            get => _Progress;
            set
            {
                _Progress = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// /Reference to an instance of the manager
        /// </summary>
        Managing.Manager Mng => Managing.Manager.Instance;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Append when all the downloads are done
        /// </summary>
        private void FileFinished(object sender, AsyncCompletedEventArgs args)
        {
            prog.Text = "Finished!!";
        }

        /// <summary>
        /// Download Status Changed, Set the Progress bar value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StatusChanged(object sender, DownloadProgressChangedEventArgs args)
        {
            Progress = args.ProgressPercentage;
        }

        /// <summary>
        /// Interaction logique for the Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valide_Click(object sender, RoutedEventArgs e)
        {

            if (FunctLibrary.Library.LECON.ContainsKey(title.Text.ToLower())) { MessageBox.Show("Une lecon possedant le meme titre existe deja"); return; }
            if (img.Text == "" || img.Text is null)
            {
                var l = new FunctLibrary.Lecon(title.Text, content.Text, @"data\logo.png");
                prog.Text = "Finished!!";
                Mng.DataManager.LeconData.AddOneToFile(l);
                Mng.EventHub.OnLessonDicChanged(this);

            }
            else if (!FunctLibrary.Tools.WebRequest.InternetInteraction.CheckLinkIsJpgOrPng(img.Text))
            {
                MessageBox.Show("Le lien donné n'est pas valable ! Rien n'a été enregistré. . .");
                return;
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += StatusChanged;
                    client.DownloadFileCompleted += FileFinished;
                    client.DownloadFileAsync(new Uri(img.Text), "data/img/lecon/" + title.Text.ToLower() + ".png");
                    MessageBox.Show(Directory.GetCurrentDirectory());
                }
                prog.Visibility = Visibility.Visible;
                bar.Visibility = Visibility.Visible;

                //Create a new lesson and save changes and Invoke event
                var l = new FunctLibrary.Lecon(title.Text, content.Text, @"data\img\lecon\" + title.Text.ToLower() + ".png");
                Mng.DataManager.LeconData.AddOneToFile(l);
                Mng.EventHub.OnLessonDicChanged(this);
            }
        }
    }
}
