using JSONCreator.AuxiliaryClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JSONCreator.ViewModels
{
    public class AddNewWordVM : TopViewModel
    {
        #region Members
        private String _ChineseTextBox;
        private String _PinYinTextBox;
        private String _EnglishTextBox;
        private ObservableCollection<Word> _WordsPending;

        private ICommand _PendingAddBtn;
        private ICommand _PendingClearBtn;
        private ICommand _AddBtn;
        private ICommand _ClearBtn;
        private ICommand _AddToDBBtn;
        #endregion

        #region Properties
        public String ChineseTextBox
        {
            get
            {
                return _ChineseTextBox;
            }
            set
            {
                _ChineseTextBox = value;
                OnPropertyChanged("ChineseTextBox");
            }
        }
        public String PinYinTextBox
        {
            get
            {
                return _PinYinTextBox;
            }
            set
            {
                _PinYinTextBox = value;
                OnPropertyChanged("PinYinTextBox");
            }
        }
        public String EnglishTextBox
        {
            get
            {
                return _EnglishTextBox;
            }
            set
            {
                _EnglishTextBox = value;
                OnPropertyChanged("EnglishTextBox");
            }
        }
        public ObservableCollection<Word> WordsPending
        {
            get
            {
                return _WordsPending;
            }

            set
            {
                _WordsPending = value;
                OnPropertyChanged("WordsPending");
            }
        }

        public ICommand PendingAddBtn
        {
            get
            {
                return _PendingAddBtn;
            }
            set
            {
                _PendingAddBtn = value;
                OnPropertyChanged("PendingAddBtn");
            }
        }
        public ICommand PendingClearBtn
        {
            get
            {
                return _PendingClearBtn;
            }
            set
            {
                _PendingClearBtn = value;
                OnPropertyChanged("PendingClearBtn");
            }
        }
        public ICommand AddBtn
        {
            get
            {
                return _AddBtn;
            }
            set
            {
                _AddBtn = value;
                OnPropertyChanged("AddBtn");
            }
        }
        public ICommand ClearBtn {
            get
            {
                return _ClearBtn;
            }
            set
            {
                _ClearBtn = value;
                OnPropertyChanged("ClearBtn");
            }
        }
        public ICommand AddToDBBtn {
            get
            {
                return _AddToDBBtn;
            }
            set
            {
                _AddToDBBtn = value;
                OnPropertyChanged("AddToDBBtn");
            }
        }
        #endregion

        #region Constructors
        public AddNewWordVM()
        {
            ClearInput();
            ClearList();

            PendingAddBtn = new RelayCommand(AddWord, AddWordPossible);
            PendingClearBtn = new RelayCommand(ClearInput, ClearInputPossible);
            AddBtn = new RelayCommand(AddAllWords, AddAllWordsPossible);
            ClearBtn = new RelayCommand(ClearList, ClearListPossible);
            AddToDBBtn = new RelayCommand(AddAllWordsToDB, AddAllWordsToDBPossible);
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// Adds a new word to the pending list and clears the input
        /// </summary>
        private void AddWord()
        {
            //TODO: Check if the word has been added already
            Word newWord = new Word
            {
                Chinese = ChineseTextBox,
                PinYin = PinYinTextBox,
                English = EnglishTextBox
            };

            WordsPending.Add(newWord);

            ClearInput();
        }

        /// <summary>
        /// Determins whether or not The word can be added to the pending list
        /// </summary>
        /// <returns>True if the word can be added</returns>
        private bool AddWordPossible()
        {
            return ChineseTextBox != "" && PinYinTextBox != "" && EnglishTextBox != "";
        }

        /// <summary>
        /// Clears the inputed fields
        /// </summary>
        private void ClearInput()
        {
            ChineseTextBox = "";
            PinYinTextBox = "";
            EnglishTextBox = "";
        }

        /// <summary>
        /// Determines whtether the input fields can be cleared
        /// </summary>
        /// <returns>True if the fields are not emppty</returns>
        private bool ClearInputPossible()
        {
            return ChineseTextBox != "" || PinYinTextBox != "" || EnglishTextBox != "";
        }

        /// <summary>
        /// Adds the pending words to the JSON data
        /// And clears the pending list
        /// </summary>
        private void AddAllWords()
        {
            pendingData.AddWords(new List<Word>(WordsPending));
            ClearList();
        }

        /// <summary>
        /// Determines whether or not the pending data can be added to the JSON data
        /// </summary>
        /// <returns></returns>
        private bool AddAllWordsPossible()
        {
            return WordsPending.Count != 0;
        }

        /// <summary>
        /// Clears the pending data list
        /// </summary>
        private void ClearList()
        {
            WordsPending = new ObservableCollection<Word>();
        }

        /// <summary>
        /// Determines whether or not the pending list can be cleared
        /// </summary>
        /// <returns></returns>
        private bool ClearListPossible()
        {
            return WordsPending.Count != 0;
        }

        /// <summary>
        /// Adds the pending data to the DB
        /// And clears the list
        /// </summary>
        private void AddAllWordsToDB()
        {
            dbWords.SaveWords(new List<Word>(WordsPending));
            ClearList();
        }

        /// <summary>
        /// Determknes whether or not the pending data can be added to the DB
        /// </summary>
        /// <returns>True if the pending data is not empty</returns>
        private bool AddAllWordsToDBPossible()
        {
            return AddAllWordsPossible();
        }

        #endregion

        #region Aux Methods

        #endregion
    }
}
