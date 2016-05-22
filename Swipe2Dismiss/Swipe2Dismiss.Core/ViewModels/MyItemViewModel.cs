using MvvmCross.Core.ViewModels;

namespace Swipe2Dismiss.Core.ViewModels
{
    public class MyItemViewModel
    {
        public MvxCommand<MyItemViewModel> DeleteCommand { get; }
        public string Text { get; set; }

        public MyItemViewModel(MvxCommand<MyItemViewModel> deleteCommand)
        {
            DeleteCommand = deleteCommand;
        }

        public void Delete()
        {
            DeleteCommand?.Execute(this);
        }
    }
}