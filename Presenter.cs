using CompLaba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MainInterface
{
    public class Presenter
    {    
        Model MyModel = new Model(); // модель
        Result result = new Result();   // результаты      
        public void _add_auto(int weight_v, int value_v, string fuel_v) // добавление автомобиля
        {
            Auto auto = new Auto(weight_v, value_v, fuel_v);
            MyModel.add_auto(auto);
        }

        public void _remove_auto(string? str) //удаление автомобился 
        {

            str = Regex.Match(str, @"\d+").Value;
            int index = Convert.ToInt32(str);
            index--;
            if (MyModel.vehicle.Count < index && index < 0)
                throw new ArgumentOutOfRangeException("Неверный номер");
            if (Equals(MyModel.vehicle[index].Type_Vehicle, "Автомобиль"))
                MyModel.remove_auto(index);
            else
                throw new ArgumentOutOfRangeException("Автомобиля с таким номером не существует");
        }
        public void _add_horse_wagon(int weight_v, List<float> horse) // добавления повозки
        {
            Horse_wagon horse_Wagon = new Horse_wagon(weight_v);
            for (int i = 0; i < horse.Count(); i++)
                horse_Wagon.point(horse[i]);
            MyModel.add_horse_wagon(horse_Wagon);
        }
        public void _remove_horse_wagon(string? str) // удаление повозки
        {
            if (str != null)
            {
                str = Regex.Match(str, @"\d+").Value;
                int index = Convert.ToInt32(str);
                index--;
                if (MyModel.vehicle.Count < index && index < 0)
                    throw new ArgumentOutOfRangeException("Неверный номер");
                if (Equals(MyModel.vehicle[index].Type_Vehicle, "Конная повозка"))
                    MyModel.remove_horse_wagon(index);
                else
                    throw new ArgumentOutOfRangeException("Конной повозки с таким номером не существует");
            }
        }
        void _competition() // подсчет расстояния
        {
            for (int i = 0; MyModel.vehicle.Count() > i; i++)
            {
                MyModel.vehicle[i].calculate();
            }
        }
        public bool only_number_check(KeyEventArgs e, bool nonNumberEntered) // проверка на ввод с клавиатуры 
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }

            return nonNumberEntered;
        }
        public bool all_enter_auto_check(int? weight, int? value, string? fuel_type) // проверка характеристик автомобиля
        {
            bool all = true;
            if (weight <= 0)
                all = false;
            if (value <= 0)
                all = false;
            if (fuel_type == null)
                all = false;
            return all;
        } 
        public bool all_enter_hourse_wagon_check(int? weight, List<float>? force) // проверка характеристик конной повозки
        {
            bool all = true;
            if (weight <= 0)
                all = false;
            if (force.Count() == 0)
                all = false;
            else
                if (force[0] <= 0)
                all = false;
            return all;
        }
        public List<string> search_auto(int weight) // поиск информации об автомобиле по его массе
        {
            List<string> list = new List<string>();
            for (int i = 0; MyModel.vehicle.Count() > i; i++)
            {
                if (MyModel.vehicle[i].Weight == weight && Equals(MyModel.vehicle[i].Type_Vehicle, "Автомобиль"))
                    list.Add(MyModel.vehicle[i].print(i));
            }
            return list;
        }
        public List<string> search_horse_wagon(int weight) // поиск информации о повозке по ее массе
        {
            List<string> list = new List<string>();
            for (int i = 0; MyModel.vehicle.Count() > i; i++)
            {
                if (MyModel.vehicle[i].Weight == weight && Equals(MyModel.vehicle[i].Type_Vehicle, "Конная повозка"))
                    list.Add(MyModel.vehicle[i].print(i));
            }
            return list;
        }
        public List<string> print_auto() // вывод информации об автомобилях 
        {
            List<string> list = new List<string>();
            for (int i = 0; MyModel.vehicle.Count() > i; i++)
            {
                if (Equals(MyModel.vehicle[i].Type_Vehicle, "Автомобиль"))
                    list.Add(MyModel.vehicle[i].print(i));
            }
            return list;
        }
        public List<string> print_horse_wagon() // вывод информации о конной повозки 
        {         
            List<string> list = new List<string>();
            for (int i = 0; MyModel.vehicle.Count() > i; i++)
            {
                if (Equals(MyModel.vehicle[i].Type_Vehicle, "Конная повозка"))
                    list.Add(MyModel.vehicle[i].print(i));
            }
            return list;
        }
        public int soft_convert(string str) // безпопасный перевод из строки в число
        {
            int value = 0;
            if (str != null && str !="") 
                value = Convert.ToInt32(str);
            return value;
        }
        public bool force_check(float value) // проверка для характеристики коня
        {        
            if ( value <= 100)
                return true;
            return false;

        } 

        public List<string> _result() // подсчет и вывод результатов
        {            
            _competition();
            int i = 0;
            List<string> list = new List<string>();
            result.print_result(MyModel.vehicle);
            MyModel.All_player_info = result.return_player_Infos();
            foreach (Player_info item in MyModel.All_player_info)
            {
                list.Add($" Место {i+1}  Участник {item.player}  Дистанция {item.distance} км.");
                i++;
            }
            return list;
        }
    }
 
}
