using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FatClient.DataProvider;

namespace FatClient.ViewModel
{
    class FotoCardTagViewModel : INotifyPropertyChanged
    {

        private FotoCardTag _selectedTag;
        private ICommand _selectCommand;
        private ICommand _deselectCommand;
        /// <summary>
        /// Selectable tags (user'll see only unselected tags of those he permitted to see).
        /// </summary>
        public ObservableCollection<FotoCardTag> UnselectedTags { get; set; }

        /// <summary>
        /// Selected tags (FotoCards filtered by this collection).
        /// </summary>
        public ObservableCollection<FotoCardTag> SelectedTags { get; set; }

        public FotoCardTag SelectedTag
        {
            get
            { 
                return _selectedTag;
            }
            set
            {
                OnPropertyChanged("SelectedTag");
                _selectedTag = value;                
            }
        }
        

        public FotoCardTagViewModel()
        {
            //todo - emulation of getting tags from DB
            UnselectedTags = new ObservableCollection<FotoCardTag>
            {
                new FotoCardTag{TagName = "Общие"},
                new FotoCardTag{TagName = "Личные"}
            };
            SelectedTags = new ObservableCollection<FotoCardTag> { };
        }

        public ICommand Select
        {
            get
            {
                if (_selectCommand == null)
                {
                    _selectCommand = new SelectCommand(this);
                }
                return _selectCommand;
            }
        }
        public ICommand Deselect
        {
            get
            {
                if (_deselectCommand == null)
                {
                    _deselectCommand = new DeselectCommand(this);
                }
                return _deselectCommand;
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            Debug.WriteLine("сгенреривоно событие OnPropertyChanged "+prop);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        abstract class ACommand : ICommand
        {
            protected FotoCardTagViewModel _fctvm;
            public ACommand(FotoCardTagViewModel fctvm)
            {
                _fctvm = fctvm;
            }
            public event EventHandler CanExecuteChanged;
            public abstract bool CanExecute(object parameter);
            public abstract void Execute(object parameter);
        }

        class SelectCommand : ACommand
        {
            public SelectCommand(FotoCardTagViewModel fctvm) : base(fctvm)
            {
                Debug.WriteLine("Экземпляр команды инициализирован");
            }
            public override bool CanExecute(object parameter)
            {
                return true;
            }
            public override void Execute(object parameter)
            {
                Debug.WriteLine("Вошли в execute");
                //FotoCardTag Tag = parameter as FotoCardTag;
                if (!_fctvm.SelectedTags.Contains(_fctvm.SelectedTag) && _fctvm.UnselectedTags.Contains(_fctvm.SelectedTag))
                {
                    Debug.WriteLine("Событие сработало");
                    _fctvm.SelectedTags.Add(_fctvm.SelectedTag);
                   // _fctvm.UnselectedTags.Remove(_fctvm.SelectedTag);
                }
            }
        }

        class DeselectCommand : ACommand
        {
            public DeselectCommand(FotoCardTagViewModel fctvm) : base(fctvm)
            {
            }
            public override bool CanExecute(object parameter)
            {
                return true;
            }
            public override void Execute(object parameter)
            {
                //FotoCardTag Tag = parameter as FotoCardTag;
                if (_fctvm.SelectedTags.Contains(_fctvm.SelectedTag) && !_fctvm.UnselectedTags.Contains(_fctvm.SelectedTag))
                {
                    _fctvm.SelectedTags.Remove(_fctvm.SelectedTag);
                    _fctvm.UnselectedTags.Add(_fctvm.SelectedTag);
                }
            }
        }
    }
}
