﻿using JSONCreator.AuxiliaryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JSONCreator.ViewModels
{
    public class MainWindowVM : TopViewModel
    {
        #region Members
        private ICommand _PreviewTaClicked;
        #endregion

        #region Properties
        public ICommand PreviewTaClicked
        {
            get
            {
                return _PreviewTaClicked;
            }
            set
            {
                _PreviewTaClicked = value;
                OnPropertyChanged("PreviewTaClicked");
            }
        }
        #endregion

        #region Constructors
        public MainWindowVM()
        {
            PreviewTaClicked = new RelayCommand(PreviewTabClickedCmd, () => true);
        }

        #endregion

        #region Commands
        private void PreviewTabClickedCmd()
        {
            Console.WriteLine("Clicked!!!!!!!!!!");
            //MessageBox.Show("Clicked!!!");
        }
        #endregion
    }
}
