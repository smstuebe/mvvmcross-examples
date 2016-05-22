using System;
using CoreGraphics;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using Swipe2Dismiss.Core.ViewModels;
using UIKit;

namespace Swipe2Dismiss.iOS.Views
{
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var tableView = new UITableView { RowHeight = 100, BackgroundColor = UIColor.Gray };

            var tableSource = new MvxSimpleTableViewSource(tableView, typeof(SwipeableCell));
            tableView.Source = tableSource;
            View = tableView;

            var bindings = this.CreateBindingSet<FirstView, FirstViewModel>();
            bindings.Bind(tableSource).To(vm => vm.MyItems);
            bindings.Apply();
        }
    }


    public class SwipeableCell : MvxTableViewCell
    {
        private CGPoint _originalCenter;
        private const float DeleteThreshold = 0.5f;

        protected MyItemViewModel ViewModel => BindingContext?.DataContext as MyItemViewModel;

        protected SwipeableCell(IntPtr hwnd) : base(hwnd)
        {
            var deleteRecognizer = new UIPanGestureRecognizer(SwipeHandler) { ShouldBegin = ShouldBegin };
            AddGestureRecognizer(deleteRecognizer);

            var label = new UILabel(ContentView.Frame);
            ContentView.AddSubview(label);

            this.DelayBind(() =>
            {
                var bindings = this.CreateBindingSet<SwipeableCell, MyItemViewModel>();
                bindings.Bind(label).To(vm => vm.Text);
                bindings.Apply();
            });
        }

        public override bool ShouldBegin(UIGestureRecognizer recognizer)
        {
            var deleteRecognizer = recognizer as UIPanGestureRecognizer;
            if (deleteRecognizer == null)
                return false;

            var translation = deleteRecognizer.TranslationInView(Superview);
            return Math.Abs(translation.X) >= Math.Abs(translation.Y) && translation.X <= 0;
        }

        private void SwipeHandler(UIPanGestureRecognizer recognizer)
        {
            if (recognizer.State == UIGestureRecognizerState.Began)
            {
                _originalCenter = Center;
            }
            else if (recognizer.State == UIGestureRecognizerState.Changed)
            {
                var translation = recognizer.TranslationInView(this);
                var x = Math.Min(_originalCenter.X + translation.X, _originalCenter.X);
                Center = new CGPoint(x, Center.Y);
            }
            else if (recognizer.State == UIGestureRecognizerState.Ended)
            {
                if (Center.X > _originalCenter.X * DeleteThreshold)
                {
                    Animate(0.2, () =>
                    {
                        Center = _originalCenter;
                    });
                }
                else
                {
                    AnimateAsync(0.2, () =>
                    {
                        Center = new CGPoint(-Frame.Width, Center.Y);
                    }).ContinueWith(_ => ViewModel.Delete());
                }
            }
        }
    }
}
