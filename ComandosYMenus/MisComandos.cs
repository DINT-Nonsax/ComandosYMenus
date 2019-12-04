using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComandosYMenus
{
    public static class MisComandos
    {
        public static readonly RoutedUICommand Vaciar = new RoutedUICommand
        (
            "Vaciar",
            "Vaciar",
            typeof(MisComandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.P, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Salir = new RoutedUICommand
        (
            "Salir",
            "Salir",
            typeof(MisComandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );
    }
}
