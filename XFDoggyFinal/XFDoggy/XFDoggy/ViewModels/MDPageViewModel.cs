using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using XFDoggy.Models;

namespace XFDoggy.ViewModels
{
    public class MDPageViewModel : BindableBase, INavigationAware
    {
        #region Repositories (遠端或本地資料存取)
        #endregion

        #region ViewModel Property (用於在 View 中作為綁定之用)

        #region 功能表項目與代表圖示的顏色
        #region 差旅費用申請Color
        private Color _差旅費用申請Color;
        /// <summary>
        /// 差旅費用申請Color
        /// </summary>
        public Color 差旅費用申請Color
        {
            get { return this._差旅費用申請Color; }
            set { this.SetProperty(ref this._差旅費用申請Color, value); }
        }
        #endregion

        #region 我要請假Color
        private Color _我要請假Color;
        /// <summary>
        /// 我要請假Color
        /// </summary>
        public Color 我要請假Color
        {
            get { return this._我要請假Color; }
            set { this.SetProperty(ref this._我要請假Color, value); }
        }
        #endregion

        #region 填寫工作日報表Color
        private Color _填寫工作日報表Color;
        /// <summary>
        /// 填寫工作日報表Color
        /// </summary>
        public Color 填寫工作日報表Color
        {
            get { return this._填寫工作日報表Color; }
            set { this.SetProperty(ref this._填寫工作日報表Color, value); }
        }
        #endregion

        #region 最新消息Color
        private Color _最新消息Color;
        /// <summary>
        /// 最新消息Color
        /// </summary>
        public Color 最新消息Color
        {
            get { return this._最新消息Color; }
            set { this.SetProperty(ref this._最新消息Color, value); }
        }
        #endregion

        #region 登出Color
        private Color _登出Color;
        /// <summary>
        /// 登出Color
        /// </summary>
        public Color 登出Color
        {
            get { return this._登出Color; }
            set { this.SetProperty(ref this._登出Color, value); }
        }
        #endregion
        #endregion

        #endregion

        #region Field 欄位

        public DelegateCommand 差旅費用申請Command { get; set; }
        public DelegateCommand 我要請假Command { get; set; }
        public DelegateCommand 填寫工作日報表Command { get; set; }
        public DelegateCommand 最新消息Command { get; set; }
        public DelegateCommand 登出Command { get; set; }

        public readonly IPageDialogService _dialogService;
        private readonly INavigationService _navigationService;

        Color 尚未點選之功能表項目顏色 = Color.FromHex("#AA000000");
        Color 已經點選之功能表項目顏色 = Color.FromHex("#e88229");
        #endregion

        #region Constructor 建構式
        public MDPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {

            _dialogService = dialogService;
            _navigationService = navigationService;

            #region 點選功能表項目，要執行的命令
            差旅費用申請Command = new DelegateCommand(async() =>
            {
                //_dialogService.DisplayAlertAsync("警告", "差旅費用申請Command 功能尚未建置", "確定");
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.差旅費用申請.ToString()}/NaviPage/差旅費用申請HomePage");
            });
            我要請假Command = new DelegateCommand(async () =>
            {
                //_dialogService.DisplayAlertAsync("警告", "我要請假Command 功能尚未建置", "確定");
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.我要請假.ToString()}/NaviPage/我要請假HomePage");
            });
            填寫工作日報表Command = new DelegateCommand(async () =>
            {
                //_dialogService.DisplayAlertAsync("警告", "填寫工作日報表Command 功能尚未建置", "確定");
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.填寫工作日報表.ToString()}/NaviPage/填寫工作日報表HomePage");
            });
            最新消息Command = new DelegateCommand(async () =>
            {
                //_dialogService.DisplayAlertAsync("警告", "最新消息Command 功能尚未建置", "確定");
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.最新消息.ToString()}/NaviPage/最新消息HomePage");
            });
            登出Command = new DelegateCommand(async () =>
            {
                //_dialogService.DisplayAlertAsync("警告", "登出Command 功能尚未建置", "確定");
                await _navigationService.NavigateAsync($"xf:///MDPage?Menu={MenuItemEnum.登出.ToString()}/NaviPage/MainPage");
            });
            #endregion
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Set功能表項目已經啟用();
            if (parameters.ContainsKey("Menu"))
            {
                // 若有傳入正在執行的功能表項目，則將這個功能表項目予以高亮
                var fooMenu = parameters["Menu"] as string;
                var fooMenuEnum = (MenuItemEnum)Enum.Parse(typeof(MenuItemEnum), fooMenu);
                Set功能表項目已經啟用(fooMenuEnum);
            }
        }
        #endregion

        #region Navigation Events (頁面導航事件)
        #endregion

        #region 設計時期或者執行時期的ViewModel初始化
        #endregion

        #region 相關事件
        #endregion

        #region 相關的Command定義
        #endregion

        #region 其他方法
        /// <summary>
        /// 依據所點選的功能表項目，將這個功能表項目文字與圖示，變換成為已選取的顏色
        /// </summary>
        /// <param name="pMenuItemEnum"></param>
        void Set功能表項目已經啟用(MenuItemEnum pMenuItemEnum = MenuItemEnum.全部重置)
        {
            差旅費用申請Color = 尚未點選之功能表項目顏色;
            我要請假Color = 尚未點選之功能表項目顏色;
            填寫工作日報表Color = 尚未點選之功能表項目顏色;
            最新消息Color = 尚未點選之功能表項目顏色;
            登出Color = 尚未點選之功能表項目顏色;

            switch (pMenuItemEnum)
            {
                case MenuItemEnum.全部重置:
                    break;
                case MenuItemEnum.差旅費用申請:
                    差旅費用申請Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.我要請假:
                    我要請假Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.填寫工作日報表:
                    填寫工作日報表Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.最新消息:
                    最新消息Color = 已經點選之功能表項目顏色;
                    break;
                case MenuItemEnum.登出:
                    登出Color = 已經點選之功能表項目顏色;
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
