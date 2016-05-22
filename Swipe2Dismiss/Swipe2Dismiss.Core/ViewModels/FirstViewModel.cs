using System.Collections.ObjectModel;
using MvvmCross.Core.ViewModels;

namespace Swipe2Dismiss.Core.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
        public ObservableCollection<MyItemViewModel> MyItems { get; } = new ObservableCollection<MyItemViewModel>();

        public FirstViewModel()
        {
            var deleteCommand = new MvxCommand<MyItemViewModel>(DeleteItem);
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
            MyItems.Add(new MyItemViewModel(deleteCommand) {Text = "Swipe me please!"});
        }

        private void DeleteItem(MyItemViewModel item)
        {
            InvokeOnMainThread(() => MyItems.Remove(item));
        }
    }
}
