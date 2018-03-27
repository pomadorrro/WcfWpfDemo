using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatClient.DataProvider
{
    /// <summary>
    /// Each FotoCard has a collection of Tags, so we can filter fotos using Tags.
    /// </summary>
    class FotoCardTag : INotifyPropertyChanged
    {
        private string _tagName;
        /// <summary>
        /// If the tag is selected, we mustn't present it in enabled for selection Tags.
        /// </summary>
        //private bool _isSelected = false;

        //public bool IsSelected
        //{
        //    get { return _isSelected; }
        //    set
        //    {
        //        _isSelected = value;
        //        OnPropertyChanged("IsSelected");
        //    }
        //}

        public string TagName
        {
            get { return _tagName; }
            set
            {
                _tagName = value;
                OnPropertyChanged("TagName");
            }
        }

        /// <summary>
        /// Invokes an event, when a property has changed.
        /// </summary>
        /// <param name="prop"></param>
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
