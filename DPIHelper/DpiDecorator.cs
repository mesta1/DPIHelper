using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DPIHelper
{
    public class DpiDecorator : Decorator
    {
      public DpiDecorator()
      {
         Loaded += OnLoaded;
         Unloaded -= OnLoaded;
      }


      private void OnLoaded(object sender, RoutedEventArgs e)
      {
         if (null != e)
            e.Handled = true;


         var source = PresentationSource.FromVisual(this);

         if (null != source && null != source.CompositionTarget)
         {
            var matrix = source.CompositionTarget.TransformToDevice;

            var dpiTransform = new ScaleTransform(1 / matrix.M11, 1 / matrix.M22);

            if (dpiTransform.CanFreeze)
               dpiTransform.Freeze();

            LayoutTransform = dpiTransform;
         }
      }
   }
}
