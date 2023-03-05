﻿using Microsoft.Extensions.Logging;
using MyDesktopCards.ViewModel;
using PluginSDK;
using System;
using System.Windows.Controls;

namespace MyDesktopCards.View
{
    /// <summary>
    /// HardWareMonitor.xaml 的交互逻辑
    /// </summary>
    public partial class HardWareMonitor : UserControl, ICard
    {
        internal static CardInfo info = new CardInfo(null, "性能监控", "", typeof(HardWareMonitor));

        private ILogger<HardWareMonitor> logger => Logger.CreateLogger<HardWareMonitor>();
        private HardwareMonitorVM vm;

        public HardWareMonitor(Guid guid)
        {
            GUID = guid;

            InitializeComponent();

        }
        public int HeightPix => 1;

        public int WidthPix => 4;

        public Guid GUID { get; private set; }


        public void OnDisabled()
        {
            vm.Active = false;
        }


        public void OnEnabled()
        {

            vm = new HardwareMonitorVM();
            vm.Active = true;
            DataContext = vm;
        }

        public void ShowSetting()
        {

        }
    }
}
