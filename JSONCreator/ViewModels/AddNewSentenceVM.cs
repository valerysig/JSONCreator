using JSONCreator.AuxiliaryClasses;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JSONCreator.ViewModels
{
    public class AddNewSentenceVM : TopViewModel
    {
        #region Members
        private string _ChineseTextBox;
        private string _EnglishTextBox;
        private ObservableCollection<Sentence> _InputedSentences;

        private ICommand _RemoveCurrentSentenceCmd;

        private ICommand _AddToListCmd;
        private ICommand _ClearInputsCmd;
        private ICommand _AddSentencesCmd;
        private ICommand _ClearListCmd;
        #endregion

        #region Properties
        public string ChineseTextBox
        {
            get
            {
                return _ChineseTextBox;
            }
            set
            {
                _ChineseTextBox = value;
                OnPropertyChanged(nameof(ChineseTextBox));
            }
        }
        public string EnglishTextBox
        {
            get
            {
                return _EnglishTextBox;
            }
            set
            {
                _EnglishTextBox = value;
                OnPropertyChanged(nameof(EnglishTextBox));
            }
        }
        public ObservableCollection<Sentence> InputedSentences
        {
            get
            {
                return _InputedSentences;
            }
            set
            {
                _InputedSentences = value;
                OnPropertyChanged(nameof(InputedSentences));
            }
        }

        public ICommand RemoveCurrentSentenceCmd
        {
            get
            {
                return _RemoveCurrentSentenceCmd;
            }
            set
            {
                _RemoveCurrentSentenceCmd = value;
                OnPropertyChanged(nameof(RemoveCurrentSentenceCmd));
            }
        }

        public ICommand AddToListCmd
        {
            get
            {
                return _AddToListCmd;
            }
            set
            {
                _AddToListCmd = value;
                OnPropertyChanged(nameof(AddToList));
            }
        }
        public ICommand ClearInputsCmd
        {
            get
            {
                return _ClearInputsCmd;
            }
            set
            {
                _ClearInputsCmd = value;
                OnPropertyChanged(nameof(ClearInputs));
            }
        }
        public ICommand AddSentencesCmd
        {
            get
            {
                return _AddSentencesCmd;
            }
            set
            {
                _AddSentencesCmd = value;
                OnPropertyChanged(nameof(AddSentences));
            }
        }
        public ICommand ClearListCmd
        {
            get
            {
                return _ClearListCmd;
            }
            set
            {
                _ClearListCmd = value;
                OnPropertyChanged(nameof(ClearListCmd));
            }
        }
        #endregion

        #region Constructors
        public AddNewSentenceVM()
        {
            InputedSentences = new ObservableCollection<Sentence>();
            ClearInputs();

            //Init the Commands
            RemoveCurrentSentenceCmd = new RelayCommand<Sentence>(RemoveCurrentSentence);

            AddToListCmd = new RelayCommand(AddToList, AddToListPossible);
            ClearInputsCmd = new RelayCommand(ClearInputs, ClearInputsPossible);
            AddSentencesCmd = new RelayCommand(AddSentences, AddSentencesPossible);
            ClearListCmd = new RelayCommand(ClearList, ClearListPossible);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Removes the selected sentence
        /// </summary>
        /// <param name="currentSentence">The sentence to be removed</param>
        private void RemoveCurrentSentence(Sentence currentSentence)
        {
            InputedSentences.Remove(currentSentence);
        }

        /// <summary>
        /// Adds the inputed sentence to the List, and clears the inputs
        /// </summary>
        private void AddToList()
        {
            InputedSentences.Add(new Sentence
            {
                Chinese = ChineseTextBox,
                English = EnglishTextBox
            });

            ClearInputs();
        }

        /// <summary>
        /// Determines whether or not the input can be added to the list
        /// </summary>
        /// <returns></returns>
        private bool AddToListPossible()
        {
            return ChineseTextBox != "" && EnglishTextBox != "";
        }

        /// <summary>
        /// Clears the input text boxes
        /// </summary>
        private void ClearInputs()
        {
            ChineseTextBox = "";
            EnglishTextBox = "";
        }

        /// <summary>
        /// Determines whether or not the inputs can be cleared
        /// </summary>
        /// <returns></returns>
        private bool ClearInputsPossible()
        {
            return ChineseTextBox != "" || EnglishTextBox != ""; 
        }


        private void AddSentences()
        {
            pendingData.AddSentences(new List<Sentence>(InputedSentences));

            ClearList();
        }

        private bool AddSentencesPossible()
        {
            return InputedSentences.Count > 0;
        }

        private void ClearList()
        {
            InputedSentences = new ObservableCollection<Sentence>();
        }

        private bool ClearListPossible()
        {
            return InputedSentences.Count > 0;
        }
        #endregion
    }
}
