using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace APNumberPads
{
	// @protocol APNumberPadStyle <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "APNumberPadStyle")]
	interface APNumberPadStyle
	{
		// @required +(CGRect)numberPadFrame;
		[Static, Abstract]
		[Export("numberPadFrame")]
		CGRect NumberPadFrame { get; }

		// @required +(CGFloat)separator;
		[Static, Abstract]
		[Export("separator")]
		nfloat Separator { get; }

		// @required +(UIColor *)numberPadBackgroundColor;
		[Static, Abstract]
		[Export("numberPadBackgroundColor")]
		UIColor NumberPadBackgroundColor { get; }

		// @required +(UIFont *)numberButtonFont;
		[Static, Abstract]
		[Export("numberButtonFont")]
		UIFont NumberButtonFont { get; }

		// @required +(UIColor *)numberButtonBackgroundColor;
		[Static, Abstract]
		[Export("numberButtonBackgroundColor")]
		UIColor NumberButtonBackgroundColor { get; }

		// @required +(UIColor *)numberButtonHighlightedColor;
		[Static, Abstract]
		[Export("numberButtonHighlightedColor")]
		UIColor NumberButtonHighlightedColor { get; }

		// @required +(UIColor *)numberButtonTextColor;
		[Static, Abstract]
		[Export("numberButtonTextColor")]
		UIColor NumberButtonTextColor { get; }

		// @required +(UIFont *)functionButtonFont;
		[Static, Abstract]
		[Export("functionButtonFont")]
		UIFont FunctionButtonFont { get; }

		// @required +(UIColor *)functionButtonBackgroundColor;
		[Static, Abstract]
		[Export("functionButtonBackgroundColor")]
		UIColor FunctionButtonBackgroundColor { get; }

		// @required +(UIColor *)functionButtonHighlightedColor;
		[Static, Abstract]
		[Export("functionButtonHighlightedColor")]
		UIColor FunctionButtonHighlightedColor { get; }

		// @required +(UIColor *)functionButtonTextColor;
		[Static, Abstract]
		[Export("functionButtonTextColor")]
		UIColor FunctionButtonTextColor { get; }

		// @required +(UIImage *)clearFunctionButtonImage;
		[Static, Abstract]
		[Export("clearFunctionButtonImage")]
		UIImage ClearFunctionButtonImage { get; }

		// @required +(UIImage *)clearFunctionButtonImageHighlighted;
		[Static, Abstract]
		[Export("clearFunctionButtonImageHighlighted")]
		UIImage ClearFunctionButtonImageHighlighted { get; }
	}

	// @interface APNumberPad : UIView <UIInputViewAudioFeedback>
	[BaseType(typeof(UIView), Name = "APNumberPad")]
	interface APNumberPad : IUIInputViewAudioFeedback
	{
		// +(instancetype)numberPadWithDelegate:(id<APNumberPadDelegate>)delegate numberPadStyleClass:(Class)styleClass;
		[Static]
		[Export("numberPadWithDelegate:numberPadStyleClass:")]
		APNumberPad Create(APNumberPadDelegate @delegate, Class styleClass);

		// +(instancetype)numberPadWithDelegate:(id<APNumberPadDelegate>)delegate;
		[Static]
		[Export("numberPadWithDelegate:")]
		APNumberPad Create(APNumberPadDelegate @delegate);

		// @property (readonly, nonatomic, strong) UIButton * leftFunctionButton;
		[Export("leftFunctionButton", ArgumentSemantic.Strong)]
		UIButton LeftFunctionButton { get; }

		// @property (readwrite, nonatomic, strong) UIButton * clearButton;
		[Export("clearButton", ArgumentSemantic.Strong)]
		UIButton ClearButton { get; set; }

		// @property (readonly, nonatomic, strong) Class<APNumberPadStyle> styleClass;
		[Export("styleClass", ArgumentSemantic.Strong)]
		APNumberPadStyle StyleClass { get; }
	}

	// @protocol APNumberPadDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name = "APNumberPadDelegate")]
	interface APNumberPadDelegate
	{
		// @optional -(void)numberPad:(APNumberPad *)numberPad functionButtonAction:(UIButton *)functionButton textInput:(UIResponder<UITextInput> *)textInput;
		[Export("numberPad:functionButtonAction:textInput:")]
		void FunctionButtonAction(APNumberPad numberPad, UIButton functionButton, IUITextInput textInput);
	}
}