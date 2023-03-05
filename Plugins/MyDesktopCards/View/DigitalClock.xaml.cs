﻿using Microsoft.Extensions.Logging;
using MyDesktopCards.ViewModel;
using PluginSDK;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace MyDesktopCards.View
{
    /// <summary>
    /// DigitalClock.xaml 的交互逻辑
    /// </summary>
    public partial class DigitalClock : UserControl, ICard
    {
        internal static CardInfo info = new CardInfo(null, "数字时钟", "", typeof(DigitalClock));
        private DigitalClockVM vm;

        ILogger logger;

        public DigitalClock(Guid guid, ILoggerFactory loggerFactory)
        {
            GUID = guid;
            logger = loggerFactory.CreateLogger<DigitalClock>();
            InitializeComponent();

        }

        public int HeightPix => 4;

        public int WidthPix => 9;

        public Guid GUID { get; private set; }

        public void OnDisabled()
        {
            vm.Active = false;
        }

        public void OnEnabled()
        {
            vm = new DigitalClockVM();
            DataContext = vm;
            vm.Active = true;
        }

        public void ShowSetting()
        {

        }


        //public void OverrideUI()
        //{

        //    DependencyObject rootElement;
        //    using (FileStream fs = new FileStream(@"D:\Source\Repos\MyWidget\MainApp\Assets\override\DigitalClock.xaml", FileMode.Open))
        //    {
        //        rootElement = (DependencyObject)XamlReader.Load(fs);
        //    }
        //    Content = rootElement;
        //}

        //private void StackPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    OverrideUI();
        //}
    }
}
