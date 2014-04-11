using GalaSoft.MvvmLight;
using BoilerPlate.Model;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;

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
        private LogAreaViewModel logArea;

        #region WindowProperties

        /// <summary>
        /// WindowTitle property.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public string WindowTitle
        {
            get
            {
                return this._WindowTitle;
            }

            set
            {
                if (this._WindowTitle != value)
                {
                    this._WindowTitle = value;
                    RaisePropertyChanged(() => WindowTitle);
                }

            }
        }
        private string _WindowTitle = "BoilerPlate";

        /// <summary>
        /// WelcomeIcon property.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public string WindowIcon
        {
            get
            {
                return this._WindowIcon;
            }

            set
            {
                if (this._WindowIcon != value)
                {
                    this._WindowTitle = value;
                    RaisePropertyChanged(() => WindowIcon);
                }

            }
        }
        private string _WindowIcon = "Resources/flame-icon.png";

        /// <summary>
        /// Resize mode of window. Defaults to CanResize.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public ResizeMode ResizeMode
        {
            get
            {
                return this._ResizeMode;
            }

            set
            {
                if (this._ResizeMode != value)
                {
                    this._ResizeMode = value;
                    RaisePropertyChanged(() => ResizeMode);
                }

            }
        }
        private ResizeMode _ResizeMode = ResizeMode.CanResize;

        /// <summary>
        /// Height of the Main Content area. Default value is 600 px.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public SizeToContent SizeWindowToContent
        {
            get
            {
                return this._SizeWindowToContent;
            }
            set
            {
                if (this._SizeWindowToContent != value)
                {
                    this._SizeWindowToContent = value;
                    RaisePropertyChanged(() => SizeWindowToContent);
                }
            }
        }
        private SizeToContent _SizeWindowToContent = SizeToContent.WidthAndHeight;

        /// <summary>
        /// Height of the Main Content area. Default value is 600 px.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public int MainContentHeight
        {
            get
            {
                return this._MainContentHeight;
            }
            set
            {
                if (this._MainContentHeight != value)
                {
                    this._MainContentHeight = value;
                    RaisePropertyChanged(() => MainContentHeight);
                }
            }
        }
        private int _MainContentHeight = 600;

        /// <summary>
        /// Height of the Main Content area. Default value is 800 px.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public int MainContentWidth
        {
            get
            {
                return this._MainContentWidth;
            }
            set
            {
                if (this._MainContentWidth != value)
                {
                    this._MainContentWidth = value;
                    RaisePropertyChanged(() => MainContentWidth);
                }
            }
        }
        private int _MainContentWidth = 800;

        #endregion WindowProperties

        #region ExpanderProperties

        /// <summary>
        /// Read-Only method to retrieve the entire Expander Area Height.
        /// Includes LogAreaHeight + ExpanderHeaderHeight
        /// </summary>
        public int ExpanderAreaHeight
        {
            get
            {
                return this.logArea.LogAreaHeight + this._ExpanderHeaderHeight;
            }
        }
        private int _ExpanderHeaderHeight = 40;

        /// <summary>
        /// Used to track if the Log Area is expanded.  
        /// If the value is changed the ExpanderArea is collapsed/expanded as needed.
        /// Changes to the property's value raise the PropertyChanged event. 
        /// </summary>
        public bool LogAreaIsExpanded
        {
            get
            {
                return this._LogAreaIsExpanded;
            }
            set
            {
                if (this._LogAreaIsExpanded != value)
                {
                    if (this._LogAreaIsExpanded) { this.LogArea_Collapse(); }
                    else { this.LogArea_Expand(); }
                    RaisePropertyChanged(() => LogAreaIsExpanded);
                }
            }
        }
        private bool _LogAreaIsExpanded;

        /// <summary>
        /// Code to execute when the Log Area is expanded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogArea_Expand()
        {
            this._LogAreaIsExpanded = true;
            this.MainContentHeight += this.logArea.LogAreaHeight;

        }

        /// <summary>
        /// Code to execute when the Log Area is collapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogArea_Collapse()
        {
            this._LogAreaIsExpanded = false;
            this.MainContentHeight -= this.logArea.LogAreaHeight;

        }

        #endregion ExpanderProperties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            logArea = new LogAreaViewModel();
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// <param name="dataService"></param>
        //public MainViewModel(IDataService dataService)
        //{
        //    _dataService = dataService;
        //    _dataService.GetData(
        //        (item, error) =>
        //        {
        //            if (error != null)
        //            {
        //                // Report error here
        //                return;
        //            }

        //            WindowTitle = item.Title;
        //        });

        //}

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Relay command to handle the click of the Resize toggle button.
        /// </summary>
        private RelayCommand _buttonClickCommand;
        public RelayCommand Button_ClickCommand
        {
            get
            {
                return this._buttonClickCommand ??
                    (this._buttonClickCommand = new RelayCommand(
                        () => this.ButtonClicked()));

            }
        }
        private void ButtonClicked()
        {
            try
            {
                //string _myModule = dataTag + System.Reflection.MethodBase.GetCurrentMethod().Name;
                //_logger.WriteLog("Add Company Code mapping", _myModule, 5);

                this.ResizeMode = ResizeMode.NoResize;
            }
            catch (Exception e)
            {

            }

        }

        private bool _ButtonIsChecked = false;
        public bool Button_IsChecked
        {
            get
            {
                return this._ButtonIsChecked;
            }
            set
            {
                if (this._ButtonIsChecked != value)
                {
                    this._ButtonIsChecked = value;
                    this.ResizeMode = this.Button_IsChecked ? ResizeMode.NoResize : ResizeMode.CanResize;
                    RaisePropertyChanged(() => Button_IsChecked);
                }
            }
        }

        #endregion Methods


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}