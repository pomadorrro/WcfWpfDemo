using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatClient.DataProvider
{
    /// <summary>
    /// 
    /// </summary>
    class FotoCard : INotifyPropertyChanged
    {
        /// <summary>
        /// Name of a Photo Card
        /// </summary>
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public Image image { get; set; }

    }
}
