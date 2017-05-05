using JSONCreator.AuxiliaryClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JSONCreator.ViewModels
{
    public class OutputListVM : TopViewModel
    {
        #region Members
        private string _FilePath;
        private ObservableCollection<Word> _Words;
        private ObservableCollection<Sentence> _Sentences;

        private ICommand _OpenBrowsingDialogCmd;
        private ICommand _SaveFileCmd;
        #endregion

        #region Properties 
        public string FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }
        public ObservableCollection<Word> Words {
            get
            {
                return _Words;
            }
            set
            {
                _Words = value;
                OnPropertyChanged(nameof(Words));
            }
        }
        public ObservableCollection<Sentence> Sentences
        {
            get
            {
                return _Sentences;
            }
            set
            {
                _Sentences = value;
                OnPropertyChanged(nameof(Sentences));
            }
        }

        public ICommand OpenBrowsingDialogCmd
        {
            get
            {
                return _OpenBrowsingDialogCmd;
            }
            set
            {
                _OpenBrowsingDialogCmd = value;
                OnPropertyChanged(nameof(OpenBrowsingDialogCmd));
            }
        }
        public ICommand SaveFileCmd
        {
            get
            {
                return _SaveFileCmd;
            }
            set
            {
                _SaveFileCmd = value;
                OnPropertyChanged(nameof(SaveFileCmd));
            }
        }
        #endregion

        #region Constructors
        public OutputListVM()
        {
            FilePath = "";
            //TODO: Delete this shit
            FilePath = @"C:\Users\Valera\OneDrive\Documents\Testing Folder\valera.json";

            RefreshLists();
            SaveFileCmd = new RelayCommand(SaveFile, SaveFilePossible);
            pendingData.OutputListVM = this;
        }
        #endregion

        #region Meyhods
        /// <summary>
        /// Refreshes the lists from the pending data singleton
        /// </summary>
        public void RefreshLists()
        {
            Words = pendingData.WordsPending;
            Sentences = pendingData.SentencesPending;
        }

        /// <summary>
        /// Saves the data to the JSON file 
        /// </summary>
        private void SaveFile()
        {
            List<data> someShit = new List<data>();
            someShit.Add(new data
            {
                A = 123,
                B = "sdfads"
            });

            string json = JsonConvert.SerializeObject(someShit.ToArray());

            System.IO.File.WriteAllText(FilePath, json);
        }

        /// <summary>
        /// Determines whether or not a file can be saved
        /// </summary>
        /// <returns></returns>
        private bool SaveFilePossible()
        {
            return FilePath != "";
        }
        #endregion
    }
}

//TODO: Delete this shit once the output is ready
class data
{
    public int A { get; set; }
    public string B { get; set; }
};
