using Microsoft.Extensions.Logging;
using MyDesktopCards.View;
using PluginSDK;
using System;
using System.Collections.Generic;

namespace MyDesktopCards
{
    public class PluginInfo : IPlugin
    {
        public Version version { get; } = new Version();
        public string url { get; } = "";
        public string author { get; } = "";


        public PluginInfo()
        {
        }

        public static List<CardInfo> infos { get; } = new List<CardInfo>()
        {
            //DevTest.info
            DigitalClock.info,
            HardWareMonitor.info,
            AISchedule.info,
        };



        public string name => "���濨Ƭ";

        public ILoggerFactory LoggerFactory { get; set; }

        public List<CardInfo> GetAllCards()
        {
            return infos;
        }


        public List<SideBarItemInfo> GetAllSBItems()
        {
            return new List<SideBarItemInfo>();
        }

        public List<WindowInfo> GetAllWindows()
        {
            throw new NotImplementedException();
        }
    }
}
