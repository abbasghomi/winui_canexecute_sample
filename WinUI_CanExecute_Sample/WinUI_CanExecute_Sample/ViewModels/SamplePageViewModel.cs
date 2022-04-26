using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace WinUI_CanExecute_Sample.ViewModels
{
    public partial class SamplePageViewModel : ObservableRecipient
    {
        private string _myText = "";
        public string MyText
        {
            get => _myText;
            set
            {
                if (SetProperty(ref _myText, value))
                {
                    OnPropertyChanged(nameof(MyText));
                    //this is the key code to have the CanExecute logic checked on PropertyChanged event
                    ButtonClickCommand.NotifyCanExecuteChanged();
                }
            }
        }

        [ObservableProperty]
        [AlsoNotifyCanExecuteFor("Button2ClickCommand")]
        private string _myText2 = "";

        public SamplePageViewModel()
        {
        }

        private bool ButtonClickCanExecute()
        {
            //can execute logic
            return MyText.Length>0;
        }

        [ICommand(CanExecute = "ButtonClickCanExecute")]
        public async Task ButtonClickAsync()
        {

        }

        private bool Button2ClickCanExecute()
        {
            //can execute logic
            return MyText2.Length>0;
        }

        [ICommand(CanExecute = "Button2ClickCanExecute")]
        public async Task Button2ClickAsync()
        {

        }
    }
}
