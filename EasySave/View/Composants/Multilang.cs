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
    /// <summary>
    /// Used to refresh the components that can be translated
    /// </summary>
    public class Multilang
    {
        /// <summary>
        /// Find all the components in a recursive way
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Translate the texts of the components that can be translated and found in the FindLogicalChildren
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
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
