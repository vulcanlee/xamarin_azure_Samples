using Prism.Unity;
using XFDoggy.Views;

namespace XFDoggy
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("xf:///MDPage/NaviPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NaviPage>();
            Container.RegisterTypeForNavigation<MDPage>();
            Container.RegisterTypeForNavigation<差旅費用申請HomePage>();
            Container.RegisterTypeForNavigation<我要請假HomePage>();
            Container.RegisterTypeForNavigation<填寫工作日報表HomePage>();
            Container.RegisterTypeForNavigation<最新消息HomePage>();
        }
    }
}
