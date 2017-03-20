using JSONCreator.AuxiliaryClasses;
using JSONCreator.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONCreator.ViewModels
{
    public abstract class TopViewModel : INotifyPropertyChanged
    {
        #region Members
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected WordsAccess dbWords = WordsAccess.Instance;
        protected PendingData pendingData = PendingData.Instance;
        #endregion

        #region Constructors
        public TopViewModel()
        {

        }
        #endregion

        #region Aux Methods
        /// <summary>
        /// Alert the UI that a property was changed
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        protected void OnPropertyChanged(String propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
