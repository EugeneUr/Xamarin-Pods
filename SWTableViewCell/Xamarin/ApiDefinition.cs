using System;

#if __UNIFIED__
using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;
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
	//  NSMutableArray+SWUtilityButtons.h

	[Category]
	[BaseType(typeof(NSMutableArray))]
	interface SWUtilityButtonsForNSMutableArray
	{
		// @required - (void)sw_addUtilityButtonWithColor:(UIColor)color title:(NSString *)title;
		[Export("sw_addUtilityButtonWithColor:title:")]
		void AddUtilityButton(UIColor color, string title);

		// @required - (void)sw_addUtilityButtonWithColor:(UIColor *)color attributedTitle:(NSAttributedString *)title;
		[Export("sw_addUtilityButtonWithColor:title:")]
		void AddUtilityButton(UIColor color, NSAttributedString title);

		// @required - (void)sw_addUtilityButtonWithColor:(UIColor)color icon:(id)icon;
		[Export("sw_addUtilityButtonWithColor:icon:")]
		void AddUtilityButton(UIColor color, UIImage icon);

		// @required - (void)sw_addUtilityButtonWithColor:(UIColor)color normalIcon:(id)normalIcon selectedIcon:(id)selectedIcon;
		[Export("sw_addUtilityButtonWithColor:normalIcon:selectedIcon:")]
		void AddUtilityButton(UIColor color, UIImage normalIcon, UIImage selectedIcon);
	}

	[Category]
	[BaseType(typeof(NSArray))]
	interface SWUtilityButtonsForNSArray
	{
		// @required - (BOOL)sw_isEqualToButtons:(NSArray *)buttons;
		[Export("sw_isEqualToButtons:")]
		bool IsEqualToButtons(UIButton[] buttons);
	}


	//  SWCellScrollView.h

	[BaseType(typeof(UIScrollView), Name = "SWCellScrollView")]
	interface SWCellScrollView : IUIGestureRecognizerDelegate
	{
	}


	//  SWLongPressGestureRecognizer.h

	[BaseType(typeof(UILongPressGestureRecognizer), Name = "SWLongPressGestureRecognizer")]
	interface SWLongPressGestureRecognizer
	{
	}


	//  SWTableViewCell.h

	interface ISWTableViewCellDelegate
	{
	}

	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "SWTableViewCellDelegate")]
	interface SWTableViewCellDelegate
	{
		// @optional - (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerLeftUtilityButtonWithIndex:(NSInteger)index;
		[Export("swipeableTableViewCell:didTriggerLeftUtilityButtonWithIndex:")]
		void DidTriggerLeftUtilityButton(SWTableViewCell cell, nint index);

		// @optional - (void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index;
		[Export("swipeableTableViewCell:didTriggerRightUtilityButtonWithIndex:")]
		void DidTriggerRightUtilityButton(SWTableViewCell cell, nint index);

		// @optional - (void)swipeableTableViewCell:(SWTableViewCell *)cell scrollingToState:(SWCellState)state;
		[Export("swipeableTableViewCell:scrollingToState:")]
		void ScrollingToState(SWTableViewCell cell, SWCellState state);

		// @optional - (BOOL)swipeableTableViewCellShouldHideUtilityButtonsOnSwipe:(SWTableViewCell *)cell;
		[Export("swipeableTableViewCellShouldHideUtilityButtonsOnSwipe:")]
		bool ShouldHideUtilityButtonsOnSwipe(SWTableViewCell cell);

		// @optional - (BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state;
		[Export("swipeableTableViewCell:canSwipeToState:")]
		bool CanSwipeToState(SWTableViewCell cell, SWCellState state);

		// @optional - (void)swipeableTableViewCellDidEndScrolling:(SWTableViewCell *)cell;
		[Export("swipeableTableViewCellDidEndScrolling:")]
		void DidEndScrolling(SWTableViewCell cell);
	}

	[BaseType(typeof(UITableViewCell), Name = "SWTableViewCell")]
	interface SWTableViewCell
	{
		// @property (copy, nonatomic) NSArray * leftUtilityButtons;
		[Export("leftUtilityButtons", ArgumentSemantic.Copy)]
		UIButton[] LeftUtilityButtons { get; set; }

		// @property (copy, nonatomic) NSArray * rightUtilityButtons;
		[Export("rightUtilityButtons", ArgumentSemantic.Copy)]
		UIButton[] RightUtilityButtons { get; set; }

		// @property (nonatomic, weak) id<SWTableViewCellDelegate> delegate;
		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Weak)]
		ISWTableViewCellDelegate Delegate { get; set; }

		// @required - (void)setRightUtilityButtons:(NSArray *)rightUtilityButtons WithButtonWidth:(CGFloat)width;
		[Export("setRightUtilityButtons:WithButtonWidth:")]
		void SetRightUtilityButtons(UIButton[] rightUtilityButtons, nfloat width);

		// @required - (void)setLeftUtilityButtons:(NSArray *)leftUtilityButtons WithButtonWidth:(CGFloat)width;
		[Export("setLeftUtilityButtons:WithButtonWidth:")]
		void SetLeftUtilityButtons(UIButton[] leftUtilityButtons, nfloat width);

		// @required - (void)hideUtilityButtonsAnimated:(BOOL)animated;
		[Export("hideUtilityButtonsAnimated:")]
		void HideUtilityButtons(bool animated);

		// @required - (void)showLeftUtilityButtonsAnimated:(BOOL)animated;
		[Export("showLeftUtilityButtonsAnimated:")]
		void ShowLeftUtilityButtons(bool animated);

		// @required - (void)showRightUtilityButtonsAnimated:(BOOL)animated;
		[Export("showRightUtilityButtonsAnimated:")]
		void ShowRightUtilityButtons(bool animated);

		// @required - (BOOL)isUtilityButtonsHidden;
		[Export("isUtilityButtonsHidden")]
		bool IsUtilityButtonsHidden { get; }
	}


	//  SWUtilityButtonTapGestureRecognizer.h

	[BaseType(typeof(UITapGestureRecognizer), Name = "SWUtilityButtonTapGestureRecognizer")]
	interface SWUtilityButtonTapGestureRecognizer
	{
		// @property (nonatomic) NSUInteger buttonIndex;
		[Export("buttonIndex")]
		nuint ButtonIndex { get; set; }
	}


	//  SWUtilityButtonView.h

	[BaseType(typeof(UIView), Name = "SWUtilityButtonView")]
	interface SWUtilityButtonView
	{
		// @required - (id)initWithUtilityButtons:(NSArray *)utilityButtons parentCell:(SWTableViewCell *)parentCell utilityButtonSelector:(SEL)utilityButtonSelector;
		[Export("initWithUtilityButtons:parentCell:utilityButtonSelector:")]
		IntPtr Constructor(NSObject[] utilityButtons, SWTableViewCell parentCell, Selector utilityButtonSelector);

		// @required - (id)initWithFrame:(CGRect)frame utilityButtons:(NSArray *)utilityButtons parentCell:(SWTableViewCell *)parentCell utilityButtonSelector:(SEL)utilityButtonSelector;
		[Export("initWithFrame:utilityButtons:parentCell:utilityButtonSelector:")]
		IntPtr Constructor(CGRect frame, NSObject[] utilityButtons, SWTableViewCell parentCell, Selector utilityButtonSelector);

		// @property (readonly, nonatomic, weak) SWTableViewCell * parentCell;
		[Export("parentCell", ArgumentSemantic.Weak)]
		SWTableViewCell ParentCell { get; }

		// @property (copy, nonatomic) NSArray * utilityButtons;
		[Export("utilityButtons", ArgumentSemantic.Copy)]
		NSObject[] UtilityButtons { get; set; }

		// @property (assign, nonatomic) SEL utilityButtonSelector;
		[Export("utilityButtonSelector", ArgumentSemantic.UnsafeUnretained)]
		Selector UtilityButtonSelector { get; set; }

		// @required - (void)setUtilityButtons:(NSArray *)utilityButtons WithButtonWidth:(CGFloat)width;
		[Export("setUtilityButtons:WithButtonWidth:")]
		void SetUtilityButtons(NSObject[] utilityButtons, nfloat width);

		// @required - (void)pushBackgroundColors;
		[Export("pushBackgroundColors")]
		void PushBackgroundColors();

		// @required - (void)popBackgroundColors;
		[Export("popBackgroundColors")]
		void PopBackgroundColors();
	}
}

//using System;
//using Foundation;
//using ObjCRuntime;
//using UIKit;

//namespace SWTableViewCells
//{
//	// @interface SWCellScrollView : UIScrollView <UIGestureRecognizerDelegate>
//	[BaseType(typeof(UIScrollView))]
//	interface SWCellScrollView : IUIGestureRecognizerDelegate
//	{
//	}

//	// @interface SWLongPressGestureRecognizer : UILongPressGestureRecognizer
//	[BaseType(typeof(UILongPressGestureRecognizer))]
//	interface SWLongPressGestureRecognizer
//	{
//	}

//	// @interface SWUtilityButtonTapGestureRecognizer : UITapGestureRecognizer
//	[BaseType(typeof(UITapGestureRecognizer))]
//	interface SWUtilityButtonTapGestureRecognizer
//	{
//		// @property (nonatomic) NSUInteger buttonIndex;
//		[Export("buttonIndex")]
//		nuint ButtonIndex { get; set; }
//	}

//	// @interface SWUtilityButtons (NSMutableArray)
//	[Category]
//	[BaseType(typeof(NSMutableArray))]
//	interface NSMutableArray_SWUtilityButtons
//	{
//		// -(void)sw_addUtilityButtonWithColor:(UIColor *)color title:(NSString *)title;
//		[Export("sw_addUtilityButtonWithColor:title:")]
//		void Sw_addUtilityButtonWithColor(UIColor color, string title);

//		// -(void)sw_addUtilityButtonWithColor:(UIColor *)color attributedTitle:(NSAttributedString *)title;
//		[Export("sw_addUtilityButtonWithColor:attributedTitle:")]
//		void Sw_addUtilityButtonWithColor(UIColor color, NSAttributedString title);

//		// -(void)sw_addUtilityButtonWithColor:(UIColor *)color icon:(UIImage *)icon;
//		[Export("sw_addUtilityButtonWithColor:icon:")]
//		void Sw_addUtilityButtonWithColor(UIColor color, UIImage icon);

//		// -(void)sw_addUtilityButtonWithColor:(UIColor *)color normalIcon:(UIImage *)normalIcon selectedIcon:(UIImage *)selectedIcon;
//		[Export("sw_addUtilityButtonWithColor:normalIcon:selectedIcon:")]
//		void Sw_addUtilityButtonWithColor(UIColor color, UIImage normalIcon, UIImage selectedIcon);
//	}

//	// @interface SWUtilityButtons (NSArray)
//	[Category]
//	[BaseType(typeof(NSArray))]
//	interface NSArray_SWUtilityButtons
//	{
//		// -(BOOL)sw_isEqualToButtons:(NSArray *)buttons;
//		[Export("sw_isEqualToButtons:")]
//		//[Verify(StronglyTypedNSArray)]
//		bool Sw_isEqualToButtons(UIButton[] buttons);
//	}

//	// @protocol SWTableViewCellDelegate <NSObject>
//	[BaseType(typeof(NSObject))]
//	[Model]
//	interface SWTableViewCellDelegate
//	{
//		// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerLeftUtilityButtonWithIndex:(NSInteger)index;
//		[Export("swipeableTableViewCell:didTriggerLeftUtilityButtonWithIndex:")]
//		void LeftUtilityButtonTriggered(SWTableViewCell cell, nint index);

//		// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index;
//		[Export("swipeableTableViewCell:didTriggerRightUtilityButtonWithIndex:")]
//		void RightUtilityButtonTriggered(SWTableViewCell cell, nint index);

//		// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell scrollingToState:(SWCellState)state;
//		[Export("swipeableTableViewCell:scrollingToState:")]
//		void ScrollTo(SWTableViewCell cell, SWCellState state);

//		// @optional -(BOOL)swipeableTableViewCellShouldHideUtilityButtonsOnSwipe:(SWTableViewCell *)cell;
//		[Export("swipeableTableViewCellShouldHideUtilityButtonsOnSwipe:")]
//		bool ShouldHideUtilityButtonsOnSwipe(SWTableViewCell cell);

//		// @optional -(BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state;
//		[Export("swipeableTableViewCell:canSwipeToState:")]
//		bool CanSwipe(SWTableViewCell cell, SWCellState state);

//		// @optional -(void)swipeableTableViewCellDidEndScrolling:(SWTableViewCell *)cell;
//		[Export("swipeableTableViewCellDidEndScrolling:")]
//		void ScrollingEnded(SWTableViewCell cell);

//		// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell didScroll:(UIScrollView *)scrollView;
//		[Export("swipeableTableViewCell:didScroll:")]
//		void DidScroll(SWTableViewCell cell, UIScrollView scrollView);
//	}

//	// @interface SWTableViewCell : UITableViewCell
//	[BaseType(typeof(UITableViewCell))]
//	interface SWTableViewCell
//	{
//		// @property (copy, nonatomic) NSArray * leftUtilityButtons;
//		[Export("leftUtilityButtons", ArgumentSemantic.Copy)]
//		UIButton[] LeftUtilityButtons { get; set; }

//		// @property (copy, nonatomic) NSArray * rightUtilityButtons;
//		[Export("rightUtilityButtons", ArgumentSemantic.Copy)]
//		UIButton[] RightUtilityButtons { get; set; }

//		[Wrap("WeakDelegate")]
//		SWTableViewCellDelegate Delegate { get; set; }

//		// @property (nonatomic, weak) id<SWTableViewCellDelegate> delegate;
//		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
//		NSObject WeakDelegate { get; set; }

//		// -(void)setRightUtilityButtons:(NSArray *)rightUtilityButtons WithButtonWidth:(CGFloat)width;
//		[Export("setRightUtilityButtons:WithButtonWidth:")]
//		void SetRightUtilityButtons(UIButton[] rightUtilityButtons, nfloat width);

//		// -(void)setLeftUtilityButtons:(NSArray *)leftUtilityButtons WithButtonWidth:(CGFloat)width;
//		[Export("setLeftUtilityButtons:WithButtonWidth:")]
//		void SetLeftUtilityButtons(UIButton[] leftUtilityButtons, nfloat width);

//		// -(void)hideUtilityButtonsAnimated:(BOOL)animated;
//		[Export("hideUtilityButtonsAnimated:")]
//		void HideUtilityButtonsAnimated(bool animated);

//		// -(void)showLeftUtilityButtonsAnimated:(BOOL)animated;
//		[Export("showLeftUtilityButtonsAnimated:")]
//		void ShowLeftUtilityButtonsAnimated(bool animated);

//		// -(void)showRightUtilityButtonsAnimated:(BOOL)animated;
//		[Export("showRightUtilityButtonsAnimated:")]
//		void ShowRightUtilityButtonsAnimated(bool animated);

//		// -(BOOL)isUtilityButtonsHidden;
//		[Export("isUtilityButtonsHidden")]
//		bool IsUtilityButtonsHidden { get; }
//	}
//}


//namespace SWTableViewCells
//{
//	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
//	// to the project by right-clicking (or Control-clicking) the folder containing this source
//	// file and clicking "Add files..." and then simply select the native library (or libraries)
//	// that you want to bind.
//	//
//	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
//	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
//	// architectures that the native library supports and fills in that information for you,
//	// however, it cannot auto-detect any Frameworks or other system libraries that the
//	// native library may depend on, so you'll need to fill in that information yourself.
//	//
//	// Once you've done that, you're ready to move on to binding the API...
//	//
//	//
//	// Here is where you'd define your API definition for the native Objective-C library.
//	//
//	// For example, to bind the following Objective-C class:
//	//
//	//     @interface Widget : NSObject {
//	//     }
//	//
//	// The C# binding would look like this:
//	//
//	//     [BaseType (typeof (NSObject))]
//	//     interface Widget {
//	//     }
//	//
//	// To bind Objective-C properties, such as:
//	//
//	//     @property (nonatomic, readwrite, assign) CGPoint center;
//	//
//	// You would add a property definition in the C# interface like so:
//	//
//	//     [Export ("center")]
//	//     CGPoint Center { get; set; }
//	//
//	// To bind an Objective-C method, such as:
//	//
//	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
//	//
//	// You would add a method definition to the C# interface like so:
//	//
//	//     [Export ("doSomething:atIndex:")]
//	//     void DoSomething (NSObject object, int index);
//	//
//	// Objective-C "constructors" such as:
//	//
//	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
//	//
//	// Can be bound as:
//	//
//	//     [Export ("initWithElmo:")]
//	//     IntPtr Constructor (ElmoMuppet elmo);
//	//
//	// For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
//	//

//	//// @protocol SWTableViewCellDelegate <NSObject>
//	//[Protocol, Model]
//	//[BaseType(typeof(NSObject))]
//	//interface SWTableViewCellDelegate
//	//{
//	//	// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerLeftUtilityButtonWithIndex:(NSInteger)index;
//	//	[Export("swipeableTableViewCell:didTriggerLeftUtilityButtonWithIndex:")]
//	//	void LeftUtilityButtonTriggered(SWTableViewCell cell, nint index);

//	//	// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell didTriggerRightUtilityButtonWithIndex:(NSInteger)index;
//	//	[Export("swipeableTableViewCell:didTriggerRightUtilityButtonWithIndex:")]
//	//	void RightUtilityButtonTriggered(SWTableViewCell cell, nint index);

//	//	// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell scrollingToState:(SWCellState)state;
//	//	[Export("swipeableTableViewCell:scrollingToState:")]
//	//	void Scroll(SWTableViewCell cell, SWCellState state);

//	//	// @optional -(BOOL)swipeableTableViewCellShouldHideUtilityButtonsOnSwipe:(SWTableViewCell *)cell;
//	//	[Export("swipeableTableViewCellShouldHideUtilityButtonsOnSwipe:")]
//	//	bool ShouldHideUtilityButtonsOnSwipe(SWTableViewCell cell);

//	//	// @optional -(BOOL)swipeableTableViewCell:(SWTableViewCell *)cell canSwipeToState:(SWCellState)state;
//	//	[Export("swipeableTableViewCell:canSwipeToState:")]
//	//	bool CanSwipeToState(SWTableViewCell cell, SWCellState state);

//	//	// @optional -(void)swipeableTableViewCellDidEndScrolling:(SWTableViewCell *)cell;
//	//	[Export("swipeableTableViewCellDidEndScrolling:")]
//	//	void ScrollingEnded(SWTableViewCell cell);

//	//	// @optional -(void)swipeableTableViewCell:(SWTableViewCell *)cell didScroll:(UIScrollView *)scrollView;
//	//	[Export("swipeableTableViewCell:didScroll:")]
//	//	void DidScroll(SWTableViewCell cell, UIScrollView scrollView);
//	//}

//	//// @interface SWTableViewCell : UITableViewCell
//	//[BaseType(typeof(UITableViewCell))]
//	//interface SWTableViewCell
//	//{
//	//	// @property (copy, nonatomic) NSArray * leftUtilityButtons;
//	//	[Export("leftUtilityButtons", ArgumentSemantic.Copy)]
//	//	//[Verify(StronglyTypedNSArray)]
//	//	NSObject[] LeftUtilityButtons { get; set; }

//	//	// @property (copy, nonatomic) NSArray * rightUtilityButtons;
//	//	[Export("rightUtilityButtons", ArgumentSemantic.Copy)]
//	//	//[Verify(StronglyTypedNSArray)]
//	//	NSObject[] RightUtilityButtons { get; set; }

//	//	[Wrap("WeakDelegate")]
//	//	SWTableViewCellDelegate Delegate { get; set; }

//	//	// @property (nonatomic, weak) id<SWTableViewCellDelegate> delegate;
//	//	[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
//	//	NSObject WeakDelegate { get; set; }

//	//	// -(void)setRightUtilityButtons:(NSArray *)rightUtilityButtons WithButtonWidth:(CGFloat)width;
//	//	[Export("setRightUtilityButtons:WithButtonWidth:")]
//	//	//[Verify(StronglyTypedNSArray)]
//	//	void SetRightUtilityButtons(NSObject[] rightUtilityButtons, nfloat width);

//	//	// -(void)setLeftUtilityButtons:(NSArray *)leftUtilityButtons WithButtonWidth:(CGFloat)width;
//	//	[Export("setLeftUtilityButtons:WithButtonWidth:")]
//	//	//[Verify(StronglyTypedNSArray)]
//	//	void SetLeftUtilityButtons(NSObject[] leftUtilityButtons, nfloat width);

//	//	// -(void)hideUtilityButtonsAnimated:(BOOL)animated;
//	//	[Export("hideUtilityButtonsAnimated:")]
//	//	void HideUtilityButtonsAnimated(bool animated);

//	//	// -(void)showLeftUtilityButtonsAnimated:(BOOL)animated;
//	//	[Export("showLeftUtilityButtonsAnimated:")]
//	//	void ShowLeftUtilityButtonsAnimated(bool animated);

//	//	// -(void)showRightUtilityButtonsAnimated:(BOOL)animated;
//	//	[Export("showRightUtilityButtonsAnimated:")]
//	//	void ShowRightUtilityButtonsAnimated(bool animated);

//	//	// -(BOOL)isUtilityButtonsHidden;
//	//	[Export("isUtilityButtonsHidden")]
//	//	//[Verify(MethodToProperty)]
//	//	bool IsUtilityButtonsHidden { get; }
//	//}

//	//[Static]
//	////[Verify(ConstantsInterfaceAssociation)]
//	//partial interface Constants
//	//{
//	//	// extern double SWTableViewCellVersionNumber;
//	//	[Field("SWTableViewCellVersionNumber", "__Internal")]
//	//	double SWTableViewCellVersionNumber { get; }

//	//	// extern const unsigned char [] SWTableViewCellVersionString;
//	//	[Field("SWTableViewCellVersionString", "__Internal")]
//	//	byte[] SWTableViewCellVersionString { get; }
//	//}
//}

