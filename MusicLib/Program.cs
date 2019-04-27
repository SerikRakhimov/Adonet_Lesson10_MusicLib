using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLib
{
    class Program
    {
        static void Main(string[] args)
        {
            string menu;
            Group group;    // выбранная группа

            var choice = new Choice();
            choice.DataInit();

            Console.WriteLine("\n\t\t МУЗЫКАЛЬНАЯ БИБЛИОТЕКА");
            while (true)
            {
                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\n\t\tГлавное меню:\n");
                Console.WriteLine("\t1 - Просмотр/добавление групп и песен");
                Console.WriteLine("\t2 - Поиск по названию группы");
                Console.WriteLine("\t3 - Поиск по названию песни");
                Console.WriteLine("\t4 - Рейтинг песен (прямая сортировка)");
                Console.WriteLine("\t5 - Рейтинг песен (обратная сортировка)");
                Console.WriteLine("\t0 - Выход\n");
                Console.Write("\tВаш выбор = ");
                menu = Console.ReadLine();

                if (menu == "0")
                {
                    break;
                }
                else if (menu == "1")   // Просмотр/добавление групп и песен
                {
                    group = choice.ChoiceGroup();

                    if (group != null)
                    {
                        choice.ChoiceSong(group);
                    }

                }
                else if (menu == "2")   // Поиск по названию группы
                {
                    Console.Write("\n\tВведите название группы = ");
                    string seach = Console.ReadLine();
                    if (seach != "")
                    {
                        using (DataContext context = new DataContext())
                        {

                            var songs = context.Songs.Include("Group").Where(song => song.Group.Name.Contains(seach)).OrderBy(t => t.Group.Name).ThenBy(t => t.Name).ToList();

                            choice.ListInfo(songs, $"В названии группы содержится '{seach}'");

                        }
                    }
                }
                else if (menu == "3")   // Поиск по названию песни
                {
                    Console.Write("\n\tВведите название песни = ");
                    string seach = Console.ReadLine();
                    if (seach != "")
                    {
                        using (DataContext context = new DataContext())
                        {

                            var songs = context.Songs.Include("Group").Where(song => song.Name.Contains(seach)).OrderBy(t => t.Group.Name).ThenBy(t => t.Name).ToList();

                            choice.ListInfo(songs, $"В названии песни содержится '{seach}'");

                        }
                    }
                }

                else if (menu == "4")   // Рейтинг песен (прямая сортировка)
                {
                    using (DataContext context = new DataContext())
                    {
                        var songs = context.Songs.Include("Group").OrderBy(t => t.Rating).ThenBy(t => t.Group.Name).ThenBy(t => t.Name).ToList();

                        choice.ListInfo(songs, "Рейтинг песен (прямая сортировка)");

                    }
                }
                else if (menu == "5")   // Рейтинг песен (обратная сортировка)
                {
                    using (DataContext context = new DataContext())
                    {
                        var songs = context.Songs.Include("Group").OrderByDescending(t => t.Rating).ThenBy(t => t.Group.Name).ThenBy(t => t.Name).ToList();

                        choice.ListInfo(songs, "Рейтинг песен (обратная сортировка)");

                    }
                }
            }
        }
    }
}
