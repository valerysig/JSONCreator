using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCreator.DAL
{
    public sealed class WordsAccess
    {
        #region Members
        private static volatile WordsAccess instance;
        private static object syncRoot = new Object();
        #endregion

        #region Constructors
        private WordsAccess()
        {

        }
        #endregion

        #region Properties
        public static WordsAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new WordsAccess();
                        }
                    }
                }

                return instance;
            }
        }
        #endregion

        #region Methods

        // TODO: Make all queries Async

        /// <summary>
        /// Returns a list of all of the words in the Database
        /// </summary>
        /// <returns>A list of words</returns>
        public List<Word> GetAllWords()
        {
            List<Word> finalWords;
            using (var db = new ChineseAppEntities())
            {
                var gottenWords = from words in db.Words
                                  select words;
                finalWords = gottenWords.ToList();
            }

            return finalWords;
        }

        /// <summary>
        /// Stores the given words in the DB
        /// </summary>
        /// <param name="newWord">The words to be stored</param>
        public void SaveWords(params Word[] newWord)
        {
            SaveWords(newWord.ToList());
        }

        /// <summary>
        /// Stores the given words in the DB
        /// </summary>
        /// <param name="newWords">A list of words to be stored</param>
        async public void SaveWords(List<Word> newWords)
        {
            using (var db = new ChineseAppEntities())
            {
                db.Words.AddRange(newWords);
                await db.SaveChangesAsync();
                //db.SaveChanges();
            }
        }
        #endregion
    }
}
