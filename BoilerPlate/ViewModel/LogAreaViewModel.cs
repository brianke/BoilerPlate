using GalaSoft.MvvmLight;

namespace BoilerPlate.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LogAreaViewModel : ViewModelBase
    {

        #region LogAreaProperties

        /// <summary>
        /// Method to retrieve the Log Area Grid Height
        /// </summary>
        public int LogAreaHeight
        {
            get
            {
                return _LogAreaHeight;
            }
            set
            {
                this._LogAreaHeight = value;
                this.RaisePropertyChanged(() => LogAreaHeight);
            }
        }
        private int _LogAreaHeight = 80;

        /// <summary>
        /// Method to retrieve the Log Area Grid Height
        /// </summary>
        public int LogAreaWidth
        {
            get
            {
                return _LogAreaWidth;
            }
            set
            {
                this._LogAreaWidth = value;
                this.RaisePropertyChanged(() => LogAreaWidth);
            }
        }
        private int _LogAreaWidth = 400;



        #endregion end LogAreaProperties


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the LogAreaViewModel class.
        /// </summary>
        public LogAreaViewModel()
        {
        }

        #endregion Constructors
    }
}