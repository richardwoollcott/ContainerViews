using System;

using UIKit;

namespace ContainerViews
{
    public partial class ViewController : UIViewController
    {
        private FirstViewController firstViewController;

        private SecondViewController secondViewController;

        private UIStoryboard board;

        public UIStoryboard Board
        {
            get
            {
                return board ?? (board = UIStoryboard.FromName("Main", null));
            }
        }

        public FirstViewController FirstVC
        {
            get
            {
                return firstViewController ?? (firstViewController = board.InstantiateViewController("FirstVC") as FirstViewController);
            }
        }

        public SecondViewController SecondVC
        {
            get
            {
                return secondViewController ?? (secondViewController = board.InstantiateViewController("SecondVC") as SecondViewController);
            }
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            board = UIStoryboard.FromName("Main", null);

            FirstViewButton.TouchUpInside += (object sender, EventArgs e) => 
            {
                FirstVC.View.Frame = this.MainContainer.Bounds;
                FirstVC.WillMoveToParentViewController(this);
                this.MainContainer.Add(FirstVC.View);

                this.AddChildViewController(FirstVC);
                FirstVC.DidMoveToParentViewController(this);

                SecondVC.RemoveFromParentViewController();
            };

            SecondViewButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                SecondVC.View.Frame = this.MainContainer.Bounds;
                SecondVC.WillMoveToParentViewController(this);
                this.MainContainer.Add(SecondVC.View);

                this.AddChildViewController(SecondVC);
                SecondVC.DidMoveToParentViewController(this);

                FirstVC.RemoveFromParentViewController();
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

