﻿using PluginSDK.Controls;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MainApp.Converters
{
    public class UIElement2RenderBitmap : IValueConverter
    {
        //https://stackoverflow.com/questions/14118003/snapshot-of-an-wpf-canvas-area-using-rendertargetbitmap
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //targetType = typeof(RenderTargetBitmap);

            //MyThumb target = (MyThumb)value;
            //RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)target.RenderSize.Width, (int)target.RenderSize.Height, 96, 96, PixelFormats.Pbgra32);
            //renderTargetBitmap.Render(target);

            ////PngBitmapEncoder encoder = new PngBitmapEncoder();
            ////encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
            ////FileStream fs = new FileStream("1.png", FileMode.Create);
            ////encoder.Save(fs);
            ////fs.Close();

            //return renderTargetBitmap;

            MyThumb elt = (MyThumb)value;

            //PresentationSource source = PresentationSource.FromVisual(elt);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)elt.RenderSize.Width,
                  (int)elt.RenderSize.Height, 96, 96, PixelFormats.Default);

            VisualBrush sourceBrush = new VisualBrush(elt);
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0),
                      new Point(elt.RenderSize.Width, elt.RenderSize.Height)));
            }
            rtb.Render(drawingVisual);
            
            return rtb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
