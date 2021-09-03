using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Proga
{
    // Класс, который управляет глобальным низкоуровневым подключением клавиатуры
    class globalKeyboardHook
        {
        #region Constant, Structure and Delegate Definitions
        // определяет тип обратного вызова для
        // public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);
        public struct keyboardHookStruct
            {
                public int vkCode;
                public int scanCode;
                public int flags;
                public int time;
                public int dwExtraInfo;
            }
            const int WH_KEYBOARD_LL = 13;
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_SYSKEYUP = 0x105;
        #endregion
        #region Instance Variables
        // Коллекции ключей для наблюдения
        public List<Keys> HookedKeys = new List<Keys>();
            IntPtr hhook = IntPtr.Zero;
        #endregion
        #region Events
        // Происходит при нажатии одной из подключенных клавиш
        public event KeyEventHandler KeyDown;
        // Происходит при отпускании одного из подключенных клавиш
        public event KeyEventHandler KeyUp;
        #endregion
        #region Constructors and Destructors
        // Инициализирует новый экземпляр класса <see cref = "globalKeyboardHook" /> и устанавливает перехват клавиатуры.
        public globalKeyboardHook()
            {
                hook();
            }
        // Освобождает неуправляемые ресурсы и выполняет другие операции очистки до
        // <see cref = "globalKeyboardHook" /> восстанавливается сборщиком мусора и удаляет хук клавиатуры.
        ~globalKeyboardHook()
            {
                unhook();
            }
        #endregion
        #region Public Methods
        /// Устанавливает глобальный Hook
        public void hook()
            {
                IntPtr hInstance = LoadLibrary("User32");
                //hhook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hInstance, 0);
                delegateHookProc = hookProc;
                hhook = SetWindowsHookEx(WH_KEYBOARD_LL, delegateHookProc, hInstance, 0);
            }
            public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);
            keyboardHookProc delegateHookProc;
        // Удаляет глобальный Hook
        public void unhook()
            {
                UnhookWindowsHookEx(hhook);
            }
        /// Обратный для клавиши клавиатуры
        /// <param name="code">Код Hook, если он не >= 0, функция не должна делать ничего</param>
        /// <param name="wParam">Тип события</param>
        /// <param name="lParam">Информация о событии Keyhook</param>
        /// <returns></returns>
        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
            {
                if (code >= 0)
                {
                    Keys key = (Keys)lParam.vkCode;
                    if (HookedKeys.Contains(key))
                    {
                        KeyEventArgs kea = new KeyEventArgs(key);
                        if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                        {
                            KeyDown(this, kea);
                        }
                        else
                        if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                        {
                            KeyUp(this, kea);
                        }
                        if (kea.Handled)
                            return 1;
                    }
                }
                return CallNextHookEx(hhook, code, wParam, ref lParam);
        }
        #endregion
        #region DLL imports
        /// Устанавливает Hook окна, делает желаемое событие, один экземпляр или идентификатор потока должен быть ненулевым
        /// <param name="idHook">Идентификатор события, которое вы хотите подключить</param>
        /// <param name="callback">Обратный отклик.</param>
        /// <param name="hInstance">Дескриптор, к которому вы хотите прикрепить событие, может быть нулевым</param>
        /// <param name="threadId">Поток, к которому вы хотите прикрепить событие, может быть нулевым</param>
        /// <returns>a handle to the desired hook</returns>
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);
        /// <summary>
        /// Unhooks the windows hook.
        /// </summary>
        /// <param name="hInstance">The hook handle that was returned from SetWindowsHookEx</param>
        /// <returns>True в случае успеха, false в противном случае</returns>
        [DllImport("user32.dll")]
            static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        /// <summary>
        /// Вызывает следующий Hook.
        /// </summary>
        /// <param name="idHook">The hook id</param>
        /// <param name="nCode">The hook code</param>
        /// <param name="wParam">The wparam.</param>
        /// <param name="lParam">The lparam.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
            static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);
        // Загружает библиотеку.
        // <param name="lpFileName">Наименование библиотеки</param>
        // <returns>A handle to the library</returns>
        [DllImport("kernel32.dll")]
            static extern IntPtr LoadLibrary(string lpFileName);
            #endregion
        }
    }