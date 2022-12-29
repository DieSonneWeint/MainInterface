using CompLaba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainInterface
{
    internal class Model // хранит информацию 
    {
        public List<Vehicle> vehicle = new List<Vehicle>(); // список транспорта
        List<Player_info> all_player_info = new List<Player_info>(); // список информации об игроках
        public List<Player_info> All_player_info //свойства списка игроков
        {get { return all_player_info;} //возврат значений списка игроков
         set { all_player_info = value; } // установка значений списка игроков
        }
        public void  add_auto(Auto auto) // добавления автомобиля  
        {
            vehicle.Add(auto);
        }
        public void remove_auto(int index) // удаления автомобиля 
        {
            vehicle.RemoveAt(index);
        }
        public void add_horse_wagon(Horse_wagon horse_wagon) // добавление конной повозки 
        {
            vehicle.Add(horse_wagon);
        }
        public void remove_horse_wagon(int index)// удаление конной повозки
        {
            vehicle.RemoveAt(index);
        }
    }
}
