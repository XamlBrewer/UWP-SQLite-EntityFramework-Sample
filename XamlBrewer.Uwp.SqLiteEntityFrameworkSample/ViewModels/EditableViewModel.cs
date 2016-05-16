using System.Windows.Input;

namespace Mvvm
{
    class EditableViewModel: ViewModelBase
    {
        protected DelegateCommand editCommand; // oops, not private ...
        private bool isInEditMode = false;

        public EditableViewModel()
        {
            if (this.IsInDesignMode)
            {
                return;
            }

            this.editCommand = new DelegateCommand(this.Edit_Executed, this.Edit_CanExecute);
        }

        public ICommand EditCommand
        {
            get { return this.editCommand; }
        }

        public bool IsInEditMode
        {
            get
            {
                return this.isInEditMode;
            }

            set
            {
                this.SetProperty(ref this.isInEditMode, value);
                this.editCommand.RaiseCanExecuteChanged();
            }
        }

        protected virtual bool Edit_CanExecute()
        {
            return !this.IsInEditMode;
        }

        protected virtual void Edit_Executed()
        {
            this.IsInEditMode = true;
        }
    }
}
