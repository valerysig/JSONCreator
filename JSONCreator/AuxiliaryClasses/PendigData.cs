using JSONCreator.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCreator.AuxiliaryClasses
{
    public sealed class PendingData
    {
        #region Members
        private static volatile PendingData instance;
        private static object syncRoot = new Object();

        private Dictionary<String, Word> wordsPending;
        private List<Sentence> sentencesPending;

        private OutputListVM _OutputListVM;
        #endregion

        #region Constructors
        private PendingData()
        {
            wordsPending = new Dictionary<string, Word>();
            sentencesPending = new List<Sentence>();
        }
        #endregion

        #region Properties
        public static PendingData Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new PendingData();
                        }
                    }
                }

                return instance;
            }
        }

        public ObservableCollection<Word> WordsPending
        {
            get
            {
                return new ObservableCollection<Word>(wordsPending.Values);
            }
        }
        public ObservableCollection<Sentence> SentencesPending
        {
            get
            {
                return new ObservableCollection<Sentence>(sentencesPending);
            }
        }

        public OutputListVM OutputListVM
        {
            set
            {
                _OutputListVM = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add new words to the pending words Dictionary
        /// </summary>
        /// <param name="newWords">A list of the words to be added
        ///                         (Here we assume that the inputed words don't exist in the Dict)</param>
        public void AddWords(List<Word> newWords)
        {
            foreach (var newWord in newWords)
            {
                //Assuming that the word wasn't added before, otherwise it will be replaced
                wordsPending[newWord.Chinese] = newWord;
            }
            _OutputListVM.RefreshLists();
        }

        /// <summary>
        /// Adds new sentences to the pending data
        /// </summary>
        /// <param name="newSentences">A list of sentences to be added</param>
        public void AddSentences(List<Sentence> newSentences)
        {
            sentencesPending.AddRange(newSentences);
            _OutputListVM.RefreshLists();
        }

        public String DisplayAllWords()
        {
            return wordsPending.Values.ToString();
        }
        #endregion
    }
}
