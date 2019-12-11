using EasySave.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EasySave.View.Composants
{
    public class Multilang
    {
        // https://stackoverflow.com/questions/974598/find-all-controls-in-wpf-window-by-type
        private IEnumerable<T> FindLogicalChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                foreach (object rawChild in LogicalTreeHelper.GetChildren(depObj))
                {
                    if (rawChild is DependencyObject)
                    {
                        DependencyObject child = (DependencyObject)rawChild;
                        if (child is T)
                        {
                            yield return (T)child;
                        }

                        foreach (T childOfChild in FindLogicalChildren<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        public void RefreshControlText(DependencyObject target, IData data)
        {
            IEnumerable<ContentControl> elements = FindLogicalChildren<ContentControl>(target).Where(x => x.Tag != null);

            foreach (var element in elements)
            {
                element.Content = data.GetLang().Translate(element.Tag.ToString());
            }
        }
    }
}
