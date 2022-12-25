using NLua;
using System;
using System.IO;
using System.Windows;

namespace SharpWithLua
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Lua luaState = new Lua()) //Создаем новый объект исполнителя Lua
            {
                var path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + Path.DirectorySeparatorChar + "LuaProgram.txt";
                luaState.DoFile(path);
                LuaFunction scriptFunc = luaState["gcd"] as LuaFunction;
                ResultOutput.Content = scriptFunc.Call(int.Parse(txbA.Text), int.Parse(txbB.Text))[0];
            }
        }
    }
}