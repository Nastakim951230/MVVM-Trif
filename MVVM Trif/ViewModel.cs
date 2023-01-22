using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
namespace MVVM_Trif
{
     class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double pervoe;
        private double vtoroe;
        private double rez;

        public string CountChange // свойство для отображения числа в TextBlock
        {
            get
            {
                return rez.ToString();
            }
        }
        public double Pervoe
        {
            get { return pervoe; }
            set { pervoe = value; 
           
            }
        }
        public double Vtoroe
        {
            get { return vtoroe; }
            set { vtoroe = value; }
        }
        public List<string> ComboChange // свойство для заполнения Combobox
        {
            get
            {
                return Model.arifmetika;
            }
        }
        int cbIndex = -1;
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));  // событие, которое реагирует на изменение свойства
            }
        }
        public string CBIndex // свойство для отображения фамилии в Combobox
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.znaki[cbIndex];
                }

            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        // обработчик события для Command (увеличение значения числа на 1)
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (cbIndex == -1)
            {
               
            }
            else
            {
               switch(cbIndex)
                {
                    case 0:
                        rez = pervoe + vtoroe;
                        break;
                    case 1:
                        rez = pervoe - vtoroe;
                        break;
                    case 2:
                        rez = pervoe * vtoroe;
                        break;
                    case 3:
                        rez = pervoe / vtoroe;
                        break;
                }
            }
            PropertyChanged(this, new PropertyChangedEventArgs("CountChange"));
        }
        public CommandBinding bind; // создание объекта для привязки команды
        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }
    }
}
