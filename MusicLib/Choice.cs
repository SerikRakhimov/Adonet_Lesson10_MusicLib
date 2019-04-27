using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLib
{
    public class Choice
    {
        private string check;
        private int i, number;

        public void DataInit()
        {

            using (DataContext context = new DataContext())
            {
                // очистка таблиц, пример -  http://www.dotnetblog.ru/2014/10/entity-framework.html
                context.Groups.RemoveRange(context.Groups);
                context.Songs.RemoveRange(context.Songs);
                context.SaveChanges();

                Group group1 = new Group
                {
                    Name = "Руки вверх"
                };
                Group group2 = new Group
                {
                    Name = "Винтаж"
                };
                Group group3 = new Group
                {
                    Name = "Инь м Ян"
                };
                context.Groups.AddRange(new List<Group> { group1, group2, group3 });
                Song song1 = new Song
                {
                    Name = "К черту эту гордость",
                    Min = 4,
                    Sec = 10,
                    Rating = 1,
                    Group = group1,
                    Words = "\n\tДва кальяна. Громкий смех подружек пьяных."
                    + "\n\tВ караоке ресторанах только ты одна грустишь."
                    + "\n\tВиноваты сами - чуть не стали вы врагами."
                    + "\n\tИзвинения с цветами - может,ты его простишь."
                };
                Song song2 = new Song
                {
                    Name = "Чужие губы",
                    Min = 4,
                    Sec = 10,
                    Rating = 2,
                    Group = group1,
                    Words = "\n\tВетер шумит негромко листва шелестит в отвe-e-ет"
                    + "\n\tидет не спеша девчонка девчонке шестнадцать лет,"
                    + "\n\tНо в свои лет шестнадцать много узнала она-a"
                    + "\n\tв крепких мужских объятьях столько ночей провела..."
                };
                Song song3 = new Song
                {
                    Name = "Ай-я-яй",
                    Min = 4,
                    Sec = 0,
                    Rating = 3,
                    Group = group1,
                    Words = "\n\tАй - яй - яй девчонка. Где взяла такие ножки?"
                    + "\n\tАй - яй - яй девчонка. Топай, топай по дорожке."
                    + "\n\tАй - яй - яй мальчишки. Все уже сломали глазки."
                    + "\n\tАй - яй - яй мальчишки. На нее глядеть опасно."
                };

                Song song4 = new Song
                {
                    Name = "Балерина",
                    Min = 3,
                    Sec = 55,
                    Rating = 9,
                    Group = group2,
                    Words = "\n\tЕще одна любовь, сошедшая с витрины"
                    + "\n\tСпоткнулась на пороге, закрытый перелом"
                    + "\n\tНо вида не подав, и гордо выгнув спину"
                    + "\n\tКрасиво балерина выходит на поклон"
                };
                Song song5 = new Song
                {
                    Name = "Я и ты",
                    Min = 4,
                    Sec = 15,
                    Rating = 8,
                    Group = group2,
                    Words = "\n\tМожет, я буду морем, а ты соленой водой"
                    + "\n\tИ капли на ладонях - это будет любовь"
                    + "\n\tМожет, я стану ветром, что поднимает листву"
                    + "\n\tМожет, я буду морем, а ты соленой водой"
                };

                Song song6 = new Song
                {
                    Name = "Белая",
                    Min = 4,
                    Sec = 10,
                    Rating = 7,
                    Group = group2,
                    Words = "\n\tКто - то рассыпал на землю мою любовь, пустил по ветру."
                    + "\n\tКто - то без спроса разбудил 'Белую королеву'.-"
                    + "\n\tА я и не против, моей любви хватит -"
                    + "\n\tМашинам и людям, бульварам и домам;"
                    + "\n\tИ от поцелуя на паузу встанут белые мои города."
                };

                Song song7 = new Song
                {
                    Name = "Не отпускай моей руки",
                    Min = 4,
                    Sec = 10,
                    Rating = 5,
                    Group = group3,
                    Words = "\n\tБыли рядом, но где - то там - Вдалеке всё искали друг друга."
                    + "\n\tОказалось, что по пятам За тобою ходил, а лица и не увидал."
                    + "\n\tА я шла по твоим следам! Я ходила по тем же дорогам, -"
                    + "\n\tИ нашла, чуть не опоздав, я прошу об одном: не теряй меня никогда."
                };

                Song song8 = new Song
                {
                    Name = "Камикадзе",
                    Min = 3,
                    Sec = 55,
                    Rating = 6,
                    Group = group3,
                    Words = "\n\tРевность накрыла меня, как снежная лавина."
                    + "\n\tИ со вчерашнего дня меня лишь половина."
                    + "\n\tТенью хожу за тобой, не понимаю, где я -"
                    + "\n\tТолько заноза - любовь болит ещё сильнее."
                };

                Song song9 = new Song
                {
                    Name = "Танцуй",
                    Min = 3,
                    Sec = 55,
                    Rating = 4,
                    Group = group3,
                    Words = "\n\tТы, как всегда, между двух границ. "
                  + "\n\tПоломал все параллели; кто - то врёт, а кто-то верит."
                  + "\n\tТвой грим не стирает дни, лишь замажет жизни пятна, -"
                  + "\n\tКак всегда ты аккуратна. Люди одни, но без меня, - Любовь не вини!"
                };

                context.Songs.AddRange(new List<Song> { song1, song2, song3, song4, song5, song6, song7, song8, song9 });


                context.SaveChanges();

            }
        }


        public Group ChoiceGroup()
        {

            Group selectGroup;

            Group result = null;

            List<Group> groups = new List<Group>();

            using (DataContext context = new DataContext())
            {
                groups = context.Groups.ToList();

                groups.Sort(delegate (Group group1, Group group2)
                { return group1.Name.CompareTo(group2.Name); });

                if (groups.Count == 0)
                {
                    Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"\n\tСписок музыкальных групп пуст.");
                    selectGroup = AddGroup();
                    if (selectGroup != null)
                    {
                        context.Groups.Add(selectGroup);
                        context.SaveChanges();
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("\n\tСписок музыкальных групп :\n");
                        i = 0;
                        groups = context.Groups.ToList();
                        groups.Sort(delegate (Group group1, Group group2)  // сортировка
                        { return group1.Name.CompareTo(group2.Name); });   // 

                        foreach (var group in groups)
                        {
                            i++;
                            Console.WriteLine($"\t{i} - {group.Name} ");
                        };

                        Console.WriteLine($"\n\t'0' - выход, '+' - добавить группу");
                        Console.Write($"\n\tВведите номер группы для просмотра песен (1-{groups.Count}) = ");
                        check = Console.ReadLine();

                        try
                        {
                            number = int.Parse(check);
                            if (number == 0)  // выход с программы
                            {
                                break;
                            }
                            else if (1 <= number && number <= groups.Count)
                            {
                                break;
                            }

                        }
                        catch
                        {
                            if (check == "+")  // добавление
                            {
                                selectGroup = AddGroup();
                                if (selectGroup != null)
                                {
                                    context.Groups.Add(selectGroup);
                                    context.SaveChanges();
                                    Console.WriteLine("\n\tГруппа добавлена.");
                                }
                            }
                        }
                    }

                    if (number != 0)
                    {
                        number--;
                        result = groups[number];
                        context.Entry(result).Collection("Songs").Load();
                    }

                }
            }
            return result;
        }

        public Group AddGroup()
        {
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tДобавление новой записи");
            Console.Write("\n\tНазвание группы = ");
            string name = Console.ReadLine();
            if (name == "")
            {
                return null;
            }
            else
            {
                return new Group { Name = name };
            }
        }

        public void ChoiceSong(Group group)
        {
            Song selectSong;

            using (DataContext context = new DataContext())
            {

                Group groupwork = context.Groups.Where(groupfind => groupfind.Id == group.Id).ToList()[0];

                var songs = groupwork.Songs.ToList();

                songs.Sort(delegate (Song song1, Song song2)
                { return song1.Name.CompareTo(song2.Name); });

                if (songs.Count == 0)
                {
                    Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine($"\n\tМузыкальная группа: {group.Name}");
                    Console.WriteLine($"\n\tСписок песен пуст.");
                    selectSong = AddSong(groupwork);
                    if (selectSong != null)
                    {
                        context.Songs.Add(selectSong);
                        context.SaveChanges();
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine($"\n\tМузыкальная группа: {group.Name}");
                        Console.WriteLine("\n\tСписок песен:\n");
                        i = 0;
                        foreach (var song in songs)
                        {
                            i++;
                            Console.WriteLine($"\t{i} -  {song.Name} (время: {song.Min.ToString("00")}:{song.Sec.ToString("00")}, рейтинг: {song.Rating.ToString()})");
                        };

                        Console.WriteLine($"\n\t0 - выход, '+' - добавить песню");
                        // вывести слова песни
                        Console.Write($"\n\tДля просмотра текста песни введите номер песни (1-{songs.Count}) = ");
                        check = Console.ReadLine();

                        try
                        {
                            number = int.Parse(check);
                            if (number == 0)  // выход с программы
                            {
                                break;
                            }
                            else if (1 <= number && number <= songs.Count)
                            {
                                number--;
                                Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine($"\n\tМузыкальная группа: {songs[number].Group.Name}");
                                Console.WriteLine($"\tСлова песни {songs[number].Name}:");
                                Console.WriteLine($"{songs[number].Words}");
                                break;
                            }
                        }
                        catch
                        {
                            if (check == "+")  // добавление
                            {
                                selectSong = AddSong(groupwork);
                                if (selectSong != null)
                                {
                                    context.Songs.Add(selectSong);
                                    context.SaveChanges();
                                    Console.WriteLine("\tПесня добавлена.");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public Song AddSong(Group group)
        {
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n\tДобавление новой записи");

            Console.Write("\n\tНазвание песни (пусто - выход) = ");
            string name = Console.ReadLine();

            if (name == "")
            {
                return null;
            }

            int min = 0;
            while (true)
            {
                Console.Write("\n\tВремя звучания: минуты (0-59) = ");
                string min_str = Console.ReadLine();
                try
                {
                    min = int.Parse(min_str);
                    if ((0 <= min) && (min <= 59))
                    {
                        break;
                    }
                }
                catch
                {

                }
            };

            int sec = 0;
            while (true)
            {
                Console.Write("\tсекунды (0-59) = ");
                string sec_str = Console.ReadLine();
                try
                {
                    sec = int.Parse(sec_str);
                    if ((0 <= sec) && (sec <= 59))
                    {
                        break;
                    }
                }
                catch
                {

                }
            };


            int rating = 0;
            while (true)
            {
                Console.Write("\n\tРейтинг (1-10) = ");
                string rating_str = Console.ReadLine();
                try
                {
                    rating = int.Parse(rating_str);
                    if ((1 <= rating) && (rating <= 10))
                    {
                        break;
                    }
                }
                catch
                {

                }
            };

            Console.WriteLine("\n\tВведите построчно текст песни\n\t(Enter - завершение ввода строки, пусто - закончить ввод) = ");

            string row;
            string words = "";
            do
            {
                row = Console.ReadLine();
                if (row != "")
                {
                    words += "\n\t" + row;
                }
            } while (row != "");

            if (words == "")
            {
                Console.WriteLine($"\tТекст песни не введен!");
                return null;
            }

            return new Song { Name = name, Words = words, Min = min, Sec = sec, Group = group, Rating = rating };

        }

        public void ListInfo(List<Song> songs, string titul)
        {
            Console.WriteLine("\n\t~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"\n\t{titul}\n");

            int i = 0;

            if (songs.Count == 0)
            {
                Console.WriteLine("\tДанных нет");
            }
            else
            {
                foreach (var song in songs)
                {
                    i++;
                    Console.WriteLine($"\t{i} -  {song.Group.Name} - {song.Name} (время: {song.Min.ToString("00")}:{song.Sec.ToString("00")}, рейтинг: {song.Rating.ToString()})");
                };
            }
        }
    }
}