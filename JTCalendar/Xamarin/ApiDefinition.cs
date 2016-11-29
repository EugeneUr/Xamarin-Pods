using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace JTCalendar
{
	// @protocol JTCalendarPage <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTCalendarPage
	{
		// @required -(void)setManager:(JTCalendarManager *)manager;
		[Abstract]
		[Export("setManager:")]
		void SetManager(JTCalendarManager manager);

		// @required -(NSDate *)date;
		// @required -(void)setDate:(NSDate *)date;
		[Abstract]
		[Export("date")]
		NSDate Date { get; set; }

		// @required -(void)reload;
		[Abstract]
		[Export("reload")]
		void Reload();
	}

	interface IJTCalendarPage { }

	// @protocol JTCalendarWeek <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTCalendarWeek
	{
		// @required -(void)setManager:(JTCalendarManager *)manager;
		[Abstract]
		[Export("setManager:")]
		void SetManager(JTCalendarManager manager);

		// @required -(NSDate *)startDate;
		[Abstract]
		[Export("startDate")]
		NSDate StartDate { get; }

		// @required -(void)setStartDate:(NSDate *)startDate updateAnotherMonth:(BOOL)enable monthDate:(NSDate *)monthDate;
		[Abstract]
		[Export("setStartDate:updateAnotherMonth:monthDate:")]
		void SetStartDate(NSDate startDate, bool enable, NSDate monthDate);
	}

	interface IJTCalendarWeek { }

	// @protocol JTCalendarWeekDay <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTCalendarWeekDay
	{
		// @required -(void)setManager:(JTCalendarManager *)manager;
		[Abstract]
		[Export("setManager:")]
		void SetManager(JTCalendarManager manager);

		// @required -(void)reload;
		[Abstract]
		[Export("reload")]
		void Reload();
	}

	interface IJTCalendarWeekDay { }

	// @protocol JTCalendarDay <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTCalendarDay
	{
		// @required -(void)setManager:(JTCalendarManager *)manager;
		[Abstract]
		[Export("setManager:")]
		void SetManager(JTCalendarManager manager);

		// @required -(NSDate *)date;
		// @required -(void)setDate:(NSDate *)date;
		[Abstract]
		[Export("date")]
		NSDate Date { get; set; }

		// @required -(BOOL)isFromAnotherMonth;
		// @required -(void)setIsFromAnotherMonth:(BOOL)isFromAnotherMonth;
		[Abstract]
		[Export("isFromAnotherMonth")]
		bool IsFromAnotherMonth { get; set; }
		//bool IsFromAnotherMonth();

		// required -(void)setIsFromAnotherMonth:(BOOL)isFromAnotherMonth;
		//[Abstract]
		//[Export("setIsFromAnotherMonth:")]
		//void SetIsFromAnotherMonth(bool isFromAnotherMonth);
	}

	interface IJTCalendarDay { }

	// @protocol JTCalendarDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTCalendarDelegate
	{
		// @optional -(UIView *)calendarBuildMenuItemView:(JTCalendarManager *)calendar;
		[Export("calendarBuildMenuItemView:")]
		UIView BuildMenuItemView(JTCalendarManager calendar);

		// @optional -(void)calendar:(JTCalendarManager *)calendar prepareMenuItemView:(UIView *)menuItemView date:(NSDate *)date;
		[Export("calendar:prepareMenuItemView:date:")]
		void PrepareMenuItemView(JTCalendarManager calendar, UIView menuItemView, NSDate date);

		// @optional -(BOOL)calendar:(JTCalendarManager *)calendar canDisplayPageWithDate:(NSDate *)date;
		[Export("calendar:canDisplayPageWithDate:")]
		bool ShouldDisplayPage(JTCalendarManager calendar, NSDate date);

		// @optional -(NSDate *)calendar:(JTCalendarManager *)calendar dateForPreviousPageWithCurrentDate:(NSDate *)currentDate;
		[Export("calendar:dateForPreviousPageWithCurrentDate:")]
		NSDate GetDatePreviousPage(JTCalendarManager calendar, NSDate currentDate);

		// @optional -(NSDate *)calendar:(JTCalendarManager *)calendar dateForNextPageWithCurrentDate:(NSDate *)currentDate;
		[Export("calendar:dateForNextPageWithCurrentDate:")]
		NSDate GetDateForNextPage(JTCalendarManager calendar, NSDate currentDate);

		// @optional -(void)calendarDidLoadPreviousPage:(JTCalendarManager *)calendar;
		[Export("calendarDidLoadPreviousPage:")]
		void DidLoadPreviousPage(JTCalendarManager calendar);

		// @optional -(void)calendarDidLoadNextPage:(JTCalendarManager *)calendar;
		[Export("calendarDidLoadNextPage:")]
		void DidLoadNextPage(JTCalendarManager calendar);

		// @optional -(UIView<JTCalendarPage> *)calendarBuildPageView:(JTCalendarManager *)calendar;
		[Export("calendarBuildPageView:")]
		IJTCalendarPage BuildPageView(JTCalendarManager calendar);

		// @optional -(UIView<JTCalendarWeekDay> *)calendarBuildWeekDayView:(JTCalendarManager *)calendar;
		[Export("calendarBuildWeekDayView:")]
		IJTCalendarWeekDay BuildWeekDayView(JTCalendarManager calendar);

		// @optional -(UIView<JTCalendarWeek> *)calendarBuildWeekView:(JTCalendarManager *)calendar;
		[Export("calendarBuildWeekView:")]
		IJTCalendarWeek BuildWeekView(JTCalendarManager calendar);

		// @optional -(UIView<JTCalendarDay> *)calendarBuildDayView:(JTCalendarManager *)calendar;
		[Export("calendarBuildDayView:")]
		IJTCalendarDay BuildDayView(JTCalendarManager calendar);

		// @optional -(void)calendar:(JTCalendarManager *)calendar prepareDayView:(UIView<JTCalendarDay> *)dayView;
		[Export("calendar:prepareDayView:")]
		void PrepareDayView(JTCalendarManager calendar, JTCalendarDayView dayView);

		// @optional -(void)calendar:(JTCalendarManager *)calendar didTouchDayView:(UIView<JTCalendarDay> *)dayView;
		[Export("calendar:didTouchDayView:")]
		void DayViewSelected(JTCalendarManager calendar, JTCalendarDayView dayView);
	}

	interface IJTCalendarDelegate { }

	// @protocol JTContent <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTContent
	{
		// @required -(void)setManager:(JTCalendarManager *)manager;
		[Abstract]
		[Export("setManager:")]
		void SetManager(JTCalendarManager manager);

		// @required -(NSDate *)date;
		// @required -(void)setDate:(NSDate *)date;
		[Abstract]
		[Export("date")]
		NSDate Date { get; set; }

		// @required -(void)loadPreviousPage;
		[Abstract]
		[Export("loadPreviousPage")]
		void LoadPreviousPage();

		// @required -(void)loadNextPage;
		[Abstract]
		[Export("loadNextPage")]
		void LoadNextPage();

		// @required -(void)loadPreviousPageWithAnimation;
		[Abstract]
		[Export("loadPreviousPageWithAnimation")]
		void LoadPreviousPageWithAnimation();

		// @required -(void)loadNextPageWithAnimation;
		[Abstract]
		[Export("loadNextPageWithAnimation")]
		void LoadNextPageWithAnimation();
	}

	interface IJTContent { }

	// @protocol JTMenu <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface JTMenu
	{
		// @required -(void)setManager:(JTCalendarManager *)manager;
		[Abstract]
		[Export("setManager:")]
		void SetManager(JTCalendarManager manager);

		// @required -(void)setPreviousDate:(NSDate *)previousDate currentDate:(NSDate *)currentDate nextDate:(NSDate *)nextDate;
		[Abstract]
		[Export("setPreviousDate:currentDate:nextDate:")]
		void SetPreviousDate(NSDate previousDate, NSDate currentDate, NSDate nextDate);

		// @required -(void)updatePageMode:(NSUInteger)pageMode;
		[Abstract]
		[Export("updatePageMode:")]
		void UpdatePageMode(nuint pageMode);

		// @required -(UIScrollView *)scrollView;
		[Abstract]
		[Export("scrollView")]
		UIScrollView ScrollView { get; }
	}

	interface IJTMenu { }

	// @interface JTDateHelper : NSObject
	[BaseType(typeof(NSObject))]
	interface JTDateHelper
	{
		// -(NSCalendar *)calendar;
		[Export("calendar")]
		NSCalendar Calendar { get; }

		// -(NSDateFormatter *)createDateFormatter;
		[Export("createDateFormatter")]
		NSDateFormatter CreateDateFormatter();

		// -(NSDate *)addToDate:(NSDate *)date months:(NSInteger)months;
		[Export("addToDate:months:")]
		NSDate AddMonths(NSDate date, nint months);

		// -(NSDate *)addToDate:(NSDate *)date weeks:(NSInteger)weeks;
		[Export("addToDate:weeks:")]
		NSDate AddWeeks(NSDate date, nint weeks);

		// -(NSDate *)addToDate:(NSDate *)date days:(NSInteger)days;
		[Export("addToDate:days:")]
		NSDate AddDays(NSDate date, nint days);

		// -(NSUInteger)numberOfWeeks:(NSDate *)date;
		[Export("numberOfWeeks:")]
		nuint NumberOfWeeks(NSDate date);

		// -(NSDate *)firstDayOfMonth:(NSDate *)date;
		[Export("firstDayOfMonth:")]
		NSDate FirstDayOfMonth(NSDate date);

		// -(NSDate *)firstWeekDayOfMonth:(NSDate *)date;
		[Export("firstWeekDayOfMonth:")]
		NSDate FirstWeekDayOfMonth(NSDate date);

		// -(NSDate *)firstWeekDayOfWeek:(NSDate *)date;
		[Export("firstWeekDayOfWeek:")]
		NSDate FirstWeekDayOfWeek(NSDate date);

		// -(BOOL)date:(NSDate *)dateA isTheSameMonthThan:(NSDate *)dateB;
		[Export("date:isTheSameMonthThan:")]
		bool IsSameMonth(NSDate dateA, NSDate dateB);

		// -(BOOL)date:(NSDate *)dateA isTheSameWeekThan:(NSDate *)dateB;
		[Export("date:isTheSameWeekThan:")]
		bool IsSameWeek(NSDate dateA, NSDate dateB);

		// -(BOOL)date:(NSDate *)dateA isTheSameDayThan:(NSDate *)dateB;
		[Export("date:isTheSameDayThan:")]
		bool IsSameDay(NSDate dateA, NSDate dateB);

		// -(BOOL)date:(NSDate *)dateA isEqualOrBefore:(NSDate *)dateB;
		[Export("date:isEqualOrBefore:")]
		bool IsEqualOrBefore(NSDate dateA, NSDate dateB);

		// -(BOOL)date:(NSDate *)dateA isEqualOrAfter:(NSDate *)dateB;
		[Export("date:isEqualOrAfter:")]
		bool IsEqualOrAfter(NSDate dateA, NSDate dateB);

		// -(BOOL)date:(NSDate *)date isEqualOrAfter:(NSDate *)startDate andEqualOrBefore:(NSDate *)endDate;
		[Export("date:isEqualOrAfter:andEqualOrBefore:")]
		bool IsBetween(NSDate date, NSDate startDate, NSDate endDate);
	}

	// @interface JTCalendarSettings : NSObject
	[BaseType(typeof(NSObject))]
	interface JTCalendarSettings
	{
		// @property (nonatomic) BOOL pageViewHideWhenPossible;
		[Export("pageViewHideWhenPossible")]
		bool PageViewHideWhenPossible { get; set; }

		// @property (nonatomic) BOOL weekModeEnabled;
		[Export("weekModeEnabled")]
		bool WeekModeEnabled { get; set; }

		// @property (nonatomic) NSUInteger pageViewNumberOfWeeks;
		[Export("pageViewNumberOfWeeks")]
		nuint PageViewNumberOfWeeks { get; set; }

		// @property (nonatomic) BOOL pageViewHaveWeekDaysView;
		[Export("pageViewHaveWeekDaysView")]
		bool PageViewHaveWeekDaysView { get; set; }

		// @property (nonatomic) NSUInteger pageViewWeekModeNumberOfWeeks;
		[Export("pageViewWeekModeNumberOfWeeks")]
		nuint PageViewWeekModeNumberOfWeeks { get; set; }

		// @property (nonatomic) JTCalendarWeekDayFormat weekDayFormat;
		[Export("weekDayFormat", ArgumentSemantic.Assign)]
		JTCalendarWeekDayFormat WeekDayFormat { get; set; }

		// @property (nonatomic) BOOL zeroPaddedDayFormat;
		[Export("zeroPaddedDayFormat")]
		bool ZeroPaddedDayFormat { get; set; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}

	// @interface JTCalendarDelegateManager : NSObject
	[BaseType(typeof(NSObject))]
	interface JTCalendarDelegateManager
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		[Export("manager", ArgumentSemantic.Weak)]
		JTCalendarManager Manager { get; set; }

		// -(UIView *)buildMenuItemView;
		[Export("buildMenuItemView")]
		UIView BuildMenuItemView();

		// -(void)prepareMenuItemView:(UIView *)menuItemView date:(NSDate *)date;
		[Export("prepareMenuItemView:date:")]
		void PrepareMenuItemView(UIView menuItemView, NSDate date);

		// -(UIView<JTCalendarPage> *)buildPageView;
		[Export("buildPageView")]
		IJTCalendarPage BuildPageView();

		// -(BOOL)canDisplayPageWithDate:(NSDate *)currentDate;
		[Export("canDisplayPageWithDate:")]
		bool CanDisplayPageWithDate(NSDate currentDate);

		// -(NSDate *)dateForPreviousPageWithCurrentDate:(NSDate *)currentDate;
		[Export("dateForPreviousPageWithCurrentDate:")]
		NSDate DateForPreviousPageWithCurrentDate(NSDate currentDate);

		// -(NSDate *)dateForNextPageWithCurrentDate:(NSDate *)currentDate;
		[Export("dateForNextPageWithCurrentDate:")]
		NSDate DateForNextPageWithCurrentDate(NSDate currentDate);

		// -(UIView<JTCalendarWeekDay> *)buildWeekDayView;
		[Export("buildWeekDayView")]
		IJTCalendarWeekDay BuildWeekDayView();

		// -(UIView<JTCalendarWeek> *)buildWeekView;
		[Export("buildWeekView")]
		IJTCalendarWeek BuildWeekView();

		// -(UIView<JTCalendarDay> *)buildDayView;
		[Export("buildDayView")]
		IJTCalendarDay BuildDayView();

		// -(void)prepareDayView:(UIView<JTCalendarDay> *)dayView;
		[Export("prepareDayView:")]
		void PrepareDayView(IJTCalendarDay dayView);

		// -(void)didTouchDayView:(UIView<JTCalendarDay> *)dayView;
		[Export("didTouchDayView:")]
		void DidTouchDayView(IJTCalendarDay dayView);
	}

	// @interface JTCalendarScrollManager : NSObject
	[BaseType(typeof(NSObject))]
	interface JTCalendarScrollManager
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		[Export("manager", ArgumentSemantic.Weak)]
		JTCalendarManager Manager { get; set; }

		// @property (nonatomic, weak) UIView<JTMenu> * menuView;
		[Export("menuView", ArgumentSemantic.Weak)]
		IJTMenu MenuView { get; set; }

		// @property (nonatomic, weak) UIScrollView<JTContent> * horizontalContentView;
		[Export("horizontalContentView", ArgumentSemantic.Weak)]
		IJTContent HorizontalContentView { get; set; }

		// -(void)setMenuPreviousDate:(NSDate *)previousDate currentDate:(NSDate *)currentDate nextDate:(NSDate *)nextDate;
		[Export("setMenuPreviousDate:currentDate:nextDate:")]
		void SetMenuPreviousDate(NSDate previousDate, NSDate currentDate, NSDate nextDate);

		// -(void)updateMenuContentOffset:(CGFloat)percentage pageMode:(NSUInteger)pageMode;
		[Export("updateMenuContentOffset:pageMode:")]
		void UpdateMenuContentOffset(nfloat percentage, nuint pageMode);

		// -(void)updateHorizontalContentOffset:(CGFloat)percentage;
		[Export("updateHorizontalContentOffset:")]
		void UpdateHorizontalContentOffset(nfloat percentage);
	}

	// @interface JTCalendarManager : NSObject
	[BaseType(typeof(NSObject))]
	interface JTCalendarManager
	{
		[Wrap("WeakDelegate")]
		IJTCalendarDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<JTCalendarDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		IJTCalendarDelegate WeakDelegate { get; set; }

		// @property (nonatomic, weak) UIView<JTMenu> * menuView;
		[Export("menuView", ArgumentSemantic.Weak)]
		IJTMenu MenuView { get; set; }

		// @property (nonatomic, weak) UIScrollView<JTContent> * contentView;
		[Export("contentView", ArgumentSemantic.Weak)]
		IJTContent ContentView { get; set; }

		// @property (readonly, nonatomic) JTDateHelper * dateHelper;
		[Export("dateHelper")]
		JTDateHelper DateHelper { get; }

		// @property (readonly, nonatomic) JTCalendarSettings * settings;
		[Export("settings")]
		JTCalendarSettings Settings { get; }

		// @property (readonly, nonatomic) JTCalendarDelegateManager * delegateManager;
		[Export("delegateManager")]
		JTCalendarDelegateManager DelegateManager { get; }

		// @property (readonly, nonatomic) JTCalendarScrollManager * scrollManager;
		[Export("scrollManager")]
		JTCalendarScrollManager ScrollManager { get; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();

		// -(NSDate *)date;
		// -(void)setDate:(NSDate *)date;
		[Export("date")]
		NSDate Date { get; set; }

		// -(void)reload;
		[Export("reload")]
		void Reload();
	}

	// @interface JTHorizontalCalendarView : UIScrollView <JTContent>
	[BaseType(typeof(UIScrollView))]
	interface JTHorizontalCalendarView : JTContent
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (nonatomic) NSDate * date;
		//[Export("date", ArgumentSemantic.Assign)]
		//NSDate Date { get; set; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}

	// @interface JTVerticalCalendarView : UIScrollView <JTContent>
	[BaseType(typeof(UIScrollView))]
	interface JTVerticalCalendarView : JTContent
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (nonatomic) NSDate * date;
		//[Export("date", ArgumentSemantic.Assign)]
		//NSDate Date { get; set; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}

	// @interface JTCalendarMenuView : UIView <JTMenu, UIScrollViewDelegate>
	[BaseType(typeof(UIView))]
	interface JTCalendarMenuView : JTMenu, IUIScrollViewDelegate
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (nonatomic) CGFloat contentRatio;
		[Export("contentRatio")]
		nfloat ContentRatio { get; set; }

		// @property (readonly, nonatomic) UIScrollView * scrollView;
		//[Export("scrollView")]
		//UIScrollView ScrollView { get; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}

	// @interface JTCalendarPageView : UIView <JTCalendarPage>
	[BaseType(typeof(UIView))]
	interface JTCalendarPageView : JTCalendarPage
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (nonatomic) NSDate * date;
		//[Export("date", ArgumentSemantic.Assign)]
		//NSDate Date { get; set; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}

	// @interface JTCalendarWeekDayView : UIView <JTCalendarWeekDay>
	[BaseType(typeof(UIView))]
	interface JTCalendarWeekDayView : JTCalendarWeekDay
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (readonly, nonatomic) NSArray * dayViews;
		[Export("dayViews")]
		UIView[] DayViews { get; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();

		// -(void)reload;
		//[Export("reload")]
		//void Reload();
	}

	// @interface JTCalendarWeekView : UIView <JTCalendarWeek>
	[BaseType(typeof(UIView))]
	interface JTCalendarWeekView : JTCalendarWeek
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (readonly, nonatomic) NSDate * startDate;
		//[Export("startDate")]
		//NSDate StartDate { get; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}

	// @interface JTCalendarDayView : UIView <JTCalendarDay>
	[BaseType(typeof(UIView))]
	interface JTCalendarDayView : JTCalendarDay
	{
		// @property (nonatomic, weak) JTCalendarManager * manager;
		//[Export("manager", ArgumentSemantic.Weak)]
		//JTCalendarManager Manager { get; set; }

		// @property (nonatomic) NSDate * date;
		//[Export("date", ArgumentSemantic.Assign)]
		//NSDate Date { get; set; }

		// @property (readonly, nonatomic) UIView * circleView;
		[Export("circleView")]
		UIView CircleView { get; }

		// @property (readonly, nonatomic) UIView * dotView;
		[Export("dotView")]
		UIView DotView { get; }

		// @property (readonly, nonatomic) UILabel * textLabel;
		[Export("textLabel")]
		UILabel TextLabel { get; }

		// @property (nonatomic) CGFloat circleRatio;
		[Export("circleRatio")]
		nfloat CircleRatio { get; set; }

		// @property (nonatomic) CGFloat dotRatio;
		[Export("dotRatio")]
		nfloat DotRatio { get; set; }

		// @property (nonatomic) BOOL isFromAnotherMonth;
		//[Export("isFromAnotherMonth")]
		//bool IsFromAnotherMonth { get; set; }

		// -(void)commonInit;
		[Export("commonInit")]
		void CommonInit();
	}
}
