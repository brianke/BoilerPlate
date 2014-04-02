using GalaSoft.MvvmLight;
using BoilerPlate.Model;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace BoilerPlate.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        private string _WindowTitle = "BoilerPlate";
        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return _WindowTitle;
            }

            set
            {
                if (_WindowTitle == value)
                {
                    return;
                }

                _WindowTitle = value;
                RaisePropertyChanged(() => WindowTitle);
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WindowTitle = item.Title;
                });

        }

        #region MainContent

        private int _MainContentHeight = 600;
        /// <summary>
        /// Height of the Main Content area
        /// </summary>
        public int MainContentHeight
        {
            get
            {
                return this._MainContentHeight;
            }
            set
            {
                this._MainContentHeight = value;
                this.RaisePropertyChanged(() => MainContentHeight);
            }
        }

        #endregion MainContent


        #region Expander

        private int _LogAreaGridHeight = 80;
        /// <summary>
        /// Method to retrieve the Log Area Grid Height
        /// </summary>
        public int LogAreaGridHeight
        {
            get
            {
                return _LogAreaGridHeight;
            }
        }

        private int _ExpanderHeaderHeight = 40;
        /// <summary>
        /// Method to retrieve the entire Expander Height
        /// </summary>
        public int ExpanderAreaHeight
        {
            get
            {
                return LogAreaGridHeight + _ExpanderHeaderHeight;
            }
        }

        private bool _LogAreaIsExpanded;
        /// <summary>
        /// Used to track if the Log Area is expanded
        /// </summary>
        public bool LogAreaIsExpanded
        {
            get 
            {
                return _LogAreaIsExpanded;
            }
            set
            {
                if (_LogAreaIsExpanded) { this.LogArea_Collapse(); }
                else { this.LogArea_Expand(); }
            }
        }
        
        /// <summary>
        /// Code to execute when the Log Area is expanded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogArea_Expand()
        {
            this._LogAreaIsExpanded = true;
            this.MainContentHeight += LogAreaGridHeight;
            
        }

        /// <summary>
        /// Code to execute when the Log Area is collapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogArea_Collapse()
        {
            this._LogAreaIsExpanded = false;
            this.MainContentHeight -= LogAreaGridHeight;

        }

        #endregion Expander




        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}