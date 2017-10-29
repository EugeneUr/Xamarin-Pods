using System;

#if __UNIFIED__
using ObjCRuntime;
using Foundation;
using UIKit;
#else
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;
using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

namespace SWTableViewCells
{
    public partial class SWTableViewCell : UITableViewCell
    {
        private const string Linker_CellIdentifier = "Linker_CellIdentifier";
        private const string Text_CellIdentifier = "Text_CellIdentifier";

        public SWTableViewCell(UITableViewCellStyle style, NSString reuseIdentifier)
            : base(style, reuseIdentifier)
        {
        }

        public SWTableViewCell(UITableViewCellStyle style, string reuseIdentifier)
            : base(style, reuseIdentifier)
        {
        }

        public static UIButton CreateButton(string title, UIColor color)
        {
            UIButton button = new UIButton(UIButtonType.Custom);
            button.BackgroundColor = color;
            button.SetTitle(title, UIControlState.Normal);
            button.SetTitleColor(UIColor.White, UIControlState.Normal);
            button.TitleLabel.AdjustsFontSizeToFitWidth = true;

            return button;
        }
    }
}