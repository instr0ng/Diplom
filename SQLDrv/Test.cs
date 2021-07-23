using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Threading;

namespace SQLDrv
{
    public partial class Test : Form
    {

        SqlConnection conn;
        string[] Clerc = new string[1000];
        public Form set;

        public Test(Form f)
        {
            set = f;
            InitializeComponent();
            conn = Settings.sqlConnection;
        }

        //Таблицы 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        static readonly string[] Mfam = new string[]
        {
            "Авилов", "Липин", "Истлентьев", "Чеботов", "Андроников", "Бабин", "Карпенцев", "Бойдало", "Терещенко", "Ветров",
            "Бессуднов", "Игнатенко", "Булгаков", "Кривков", "Шеломов", "Яранцев", "Гибазов", "Митрохов", "Рожков", "Бояринов",
            "Гусенков", "Сопов", "Янечко", "Щербина", "Заседателев", "Кириленко", "Палванов", "Клюшников", "Хабибов", "Баженов",
            "Карандашов", "Пищальников", "Вишняков", "Дешевых", "Ягодинский", "Белов", "Капишников", "Зууфин", "Чистяков", "Нарыков",
            "Путилин", "Мамкин", "Зобов", "Яхлаков", "Шипицин", "Кузьмин", "Маховицкий", "Пермяков", "Кокорин", "Разумов", "Борев",
            "Вихров", "Шадрин", "Яцко", "Бажанов", "Бехтерев", "Бояров", "Огарков", "Самарин", "Кочнев", "Шульга", "Григорьев",
            "Белочкин", "Валеев", "Кичеев", "Жеглов", "Полков", "Картавый", "Просвирнин", "Митькин", "Панарин", "Квасков", "Огарков",
            "Аслаханов", "Баженов", "Лихачев", "Слобожанин", "Кирсанов", "Помельников", "Бережной", "Савин", "Корниец", "Казакевич",
            "Кононов", "Голышев", "Евлентьев", "Усачёв", "Кудашев", "Водопьянов", "Михалицин", "Аронов", "Кулагин", "Коровин", "Максимов",
            "Полухин", "Бальсунов", "Ярилов", "Дураничев", "Кудрявцев", "Горюшин"
        };

        static readonly string[] Wfam = new string[]
        {
            "Ковригина", "Чазова", "Целобанова", "Быстрова", "Тесла", "Борева", "Вавилова", "Худовекова", "Попова", "Ханинова",
            "Горева", "Папенина", "Сыропоршнева", "Комиссарова", "Набиуллина", "Ёжина", "Сиякаева", "Бебнева", "Саврасова",
            "Ажикелямова", "Захарьина", "Кривоухова", "Королева", "Горшкова", "Горюнова", "Шибалкина", "Емельянова", "Веретёнова",
            "Крылова", "Вотякова", "Яимова", "Шелепина", "Бажанова", "Игнатова", "Таначёва", "Безрукова", "Дагирова", "Краснова",
            "Тихоненко", "Тихоненко", "Якуничева", "Зимина", "Перехваткина", "Райта", "Ясакова", "Раскатова", "Танкова", "Салькова",
            "Кудрявцева", "Гусарова", "Савинкова", "Коршунова", "Куваева", "Экономова", "Яндуткина", "Богрова", "Саламатова", "Корнеева",
            "Лукина", "Созонтова", "Веретёнова", "Овсова", "Нямина", "Тихонова", "Попова", "Цедлица", "Шувалова", "Сайтахметова", "Ветрова"
            , "Кологреева", "Аленина", "Ошуркова", "Яна", "Янишина", "Витюгова", "Бондарева", "Матвиенко", "Яфракова", "Дрокова", "Стаина",
            "Игнатенко", "Суботина", "Строганова", "Яромеева", "Вязьмитина", "Алеева", "Волкова", "Курганова", "Смирнова", "Ярыгина", "Ульяшина",
            "Качусова", "Смехова", "Богуна", "Драгомирова", "Шкригунова", "Абрамовича", "Курзыбова", "Павлова", "Райкова"
        };

        static readonly string[] Mname = new string[]
        {
            "Филимон", "Богдан", "Даниил", "Ян", "Юлий", "Ким", "Алексей", "Владлен", "Арсений", "Дмитрий",
            "Прокл", "Владислав", "Максимильян", "Капитон", "Юлий", "Евдоким", "Ян", "Владислав", "Всеслав",
            "Кузьма", "Осип", "Андриян", "Чеслав", "Емельян", "Георгий", "Лаврентий", "Сократ", "Семён", "Семён",
            "Емельян", "Макар", "Кир", "Модест", "Виталий", "Богдан", "Тарас", "Тихон", "Владимир", "Агап", "Евдоким",
            "Прокл", "Платон", "Лука", "Прокл", "Мстислав", "Денис", "Антип", "Игорь", "Лукьян", "Рюрик", "Якуб",
            "Фока", "Никита", "Бронислав", "Алексей", "Архип", "Никифор", "Ярослав", "Вадим", "Феофан", "Мирон",
            "Парфен", "Филипп", "Евграф", "Анатолий", "Потап", "Федор", "Тимур", "Капитон", "Прокофий", "Мирослав",
            "Демьян", "Арсений", "Измаил", "Руслан", "Модест", "﻿Август", "Лев", "Викентий", "Владислав", "Анатолий",
            "Лев", "Платон", "Варфоломей", "Варфоломей", "Михей", "Всеслав", "Михаил", "Елизар", "Николай", "Елизар",
            "Михей", "Ипполит", "Тихон", "Федот", "Варфоломей", "Сократ", "Эмиль", "Виссарион", "Андрон"
        };

        static readonly string[] Wname = new string[]
        {
            "Татьяна", "Клара", "Марфа", "Ирина", "Лариса", "Элеонора", "Ярослава", "Татьяна", "Любовь", "Лиана",
            "Анфиса", "Дарья", "Розалия", "Алиса", "Полина", "Инга", "Лидия", "Рената", "Майя", "Христина", "Анфиса",
            "Наталья", "Екатерина", "Инесса", "Юнона", "Каролина", "Агафья", "Раиса", "Ксения", "Анисья", "Алиса",
            "Лидия", "Арина", "Всеслава", "Всеслава", "Валерия", "Екатерина", "Валентина", "Жанна", "Таисия",
            "Ксения", "Алиса", "Мирослава", "Ираида", "Евдокия", "Алина", "Татьяна", "Вероника", "Аза", "Оксана",
            "Татьяна", "Милена", "Ангелина", "Евгения", "Диана", "Зинаида", "Альбина", "Наталия", "Рената", "Зинаида",
            "Анфиса", "Берта", "Маргарита", "Эмма", "Регина", "Роза", "Лариса", "Анфиса", "Агния", "Дина", "Анастасия",
            "Элеонора", "Эльвира", "Лилия", "Антонина", "Раиса", "Владислава", "Владлена", "Роза", "Ангелина",
            "Зинаида", "Ника", "Марианна", "Нина", "Христина", "Яна", "Анисья", "Мария", "Зинаида", "Кира", "Регина",
            "Эвелина", "Арина", "Вера", "Ева", "Валерия", "Агафья", "Антонина", "Аза", "Нина"
        };

        static readonly string[] Motch = new string[]
        {
            "Олегович", "Леонидович", "Ипатиевич", "Архипович", "Кондратиевич", "Ерофеевич", "Якубович", "Михаилович", "Куприянович", "Давидович",
            "Евгениевич", "Куприянович", "Адамович", "Самсонович", "Венедиктович", "Зиновиевич", "Ипатович", "Никифорович", "Онисимович", "Назарович",
            "Дмитриевич", "Георгиевич", "Афанасиевич", "Изяславович", "Иосифович", "Иосифович", "Мартьянович", "Епифанович", "Арсениевич", "Глебович",
            "Арсениевич", "Демьянович", "Святославович", "Игоревич", "Тарасович", "Несторович", "Ираклиевич", "Демьянович", "Елисеевич", "Савелиевич",
            "Даниилович", "Филимонович", "Епифанович", "Андроникович", "Александрович", "Андреевич", "Якубович", "Мечиславович", "Федорович", "Леонидович",
            "Никитевич", "Фролович", "Давидович", "Макарович", "Арсениевич", "Кириллович", "Андронович", "Денисович", "Никанорович", "Моисеевич",
            "Андриянович", "Александрович", "Венедиктович", "Ерофеевич", "Иванович", "Ростиславович", "Ермолаевич", "Вячеславович", "Эдуардович",
            "Агапович", "Демьянович", "Гаврилевич", "Елисеевич", "Владимирович", "Дмитриевич", "Никифорович", "Ираклиевич", "Архипович", "Игоревич",
            "Прохорович", "Григориевич", "Адрианович", "Ерофеевич", "Прокофиевич", "Фролович", "Богданович", "Давидович", "Вадимович", "Фомевич", "Кондратович",
            "Макарович", "Климентович", "Капитонович", "Архипович", "Артемович", "Савелиевич", "Андронович", "Георгиевич", "Матвеевич", "Самуилович"
        };

        static readonly string[] Wotch = new string[]
        {
            "Иларионовна", "Елизаровна", "Захаровна", "Кузьмевна", "Михеевна", "Андрияновна", "Василиевна", "Евгениевна", "Якововна", "Федоровна",
            "Андрияновна", "Ростиславовна", "Андрияновна", "Трофимовна", "Леонидовна", "Павеловна", "Геннадиевна", "Данииловна", "Семеновна",
            "Леонидовна", "Константиновна", "Никитевна", "Вячеславовна", "Станиславовна", "Всеволодовна", "Феликсовна", "Станиславовна", "Игоревна",
            "Тимофеевна", "Марковна", "Казимировна", "Виталиевна", "Яновна", "Василиевна", "Виталиевна", "Тихоновна", "Казимировна", "Емельяновна",
            "Василиевна", "Потаповна", "Юлиевна", "Леонидовна", "Глебовна", "Олеговна", "Владиленовна", "Александровна", "Александровна", "Георгиевна",
            "Ивановна", "Трофимовна", "Павеловна", "Данилевна", "Тимуровна", "Германовна", "Елизаровна", "Елисеевна", "Станиславовна", "Карповна",
            "Андрияновна", "Кузьмевна", "Ефимовна", "Федотовна", "Борисовна", "Марковна", "Ипполитовна", "Брониславовна", "Мефодиевна", "Ростиславовна",
            "Ростиславовна", "Мефодиевна", "Захаровна", "Якововна", "Никитевна", "Семеновна", "Олеговна", "Владиленовна", "Степановна", "Захаровна",
            "Германовна", "Иосифовна", "Тимуровна", "Кузьмевна", "Ивановна", "Германовна", "Анатолиевна", "Феликсовна", "Василиевна", "Афанасиевна",
            "Фомевна", "Станиславовна", "Ираклиевна", "Анатолиевна", "Феликсовна", "Потаповна", "Потаповна", "Петровна", "Тихоновна", "Якововна", "Федотовна", "Юлиевна"
        };

        static readonly byte[] crc8Table = new byte[]
        {
        0x00, 0x5E, 0xBC, 0xE2, 0x61, 0x3F, 0xDD, 0x83,
        0xC2, 0x9C, 0x7E, 0x20, 0xA3, 0xFD, 0x1F, 0x41,
        0x9D, 0xC3, 0x21, 0x7F, 0xFC, 0xA2, 0x40, 0x1E,
        0x5F, 0x01, 0xE3, 0xBD, 0x3E, 0x60, 0x82, 0xDC,
        0x23, 0x7D, 0x9F, 0xC1, 0x42, 0x1C, 0xFE, 0xA0,
        0xE1, 0xBF, 0x5D, 0x03, 0x80, 0xDE, 0x3C, 0x62,
        0xBE, 0xE0, 0x02, 0x5C, 0xDF, 0x81, 0x63, 0x3D,
        0x7C, 0x22, 0xC0, 0x9E, 0x1D, 0x43, 0xA1, 0xFF,
        0x46, 0x18, 0xFA, 0xA4, 0x27, 0x79, 0x9B, 0xC5,
        0x84, 0xDA, 0x38, 0x66, 0xE5, 0xBB, 0x59, 0x07,
        0xDB, 0x85, 0x67, 0x39, 0xBA, 0xE4, 0x06, 0x58,
        0x19, 0x47, 0xA5, 0xFB, 0x78, 0x26, 0xC4, 0x9A,
        0x65, 0x3B, 0xD9, 0x87, 0x04, 0x5A, 0xB8, 0xE6,
        0xA7, 0xF9, 0x1B, 0x45, 0xC6, 0x98, 0x7A, 0x24,
        0xF8, 0xA6, 0x44, 0x1A, 0x99, 0xC7, 0x25, 0x7B,
        0x3A, 0x64, 0x86, 0xD8, 0x5B, 0x05, 0xE7, 0xB9,
        0x8C, 0xD2, 0x30, 0x6E, 0xED, 0xB3, 0x51, 0x0F,
        0x4E, 0x10, 0xF2, 0xAC, 0x2F, 0x71, 0x93, 0xCD,
        0x11, 0x4F, 0xAD, 0xF3, 0x70, 0x2E, 0xCC, 0x92,
        0xD3, 0x8D, 0x6F, 0x31, 0xB2, 0xEC, 0x0E, 0x50,
        0xAF, 0xF1, 0x13, 0x4D, 0xCE, 0x90, 0x72, 0x2C,
        0x6D, 0x33, 0xD1, 0x8F, 0x0C, 0x52, 0xB0, 0xEE,
        0x32, 0x6C, 0x8E, 0xD0, 0x53, 0x0D, 0xEF, 0xB1,
        0xF0, 0xAE, 0x4C, 0x12, 0x91, 0xCF, 0x2D, 0x73,
        0xCA, 0x94, 0x76, 0x28, 0xAB, 0xF5, 0x17, 0x49,
        0x08, 0x56, 0xB4, 0xEA, 0x69, 0x37, 0xD5, 0x8B,
        0x57, 0x09, 0xEB, 0xB5, 0x36, 0x68, 0x8A, 0xD4,
        0x95, 0xCB, 0x29, 0x77, 0xF4, 0xAA, 0x48, 0x16,
        0xE9, 0xB7, 0x55, 0x0B, 0x88, 0xD6, 0x34, 0x6A,
        0x2B, 0x75, 0x97, 0xC9, 0x4A, 0x14, 0xF6, 0xA8,
        0x74, 0x2A, 0xC8, 0x96, 0x15, 0x4B, 0xA9, 0xF7,
        0xB6, 0xE8, 0x0A, 0x54, 0xD7, 0x89, 0x6B, 0x35
        };
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////Таблицы 
        


        //Функция кодирования по CRC8
        public static byte CRC8(byte[] bytes, int len)
        {
            byte crc = 0;
            for (var i = 0; i < len; ++i)
                crc = crc8Table[crc ^ bytes[i]];
            return crc;
        }

        //Функция для выбора всех чекбоксов
        private void CompAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            for (int i = 0; i < 8; i++)
                CompCB.SetItemChecked(i, box.Checked);
        }

       //Функция запуска добавления при нажатии на кнопку "Добавить"
        private void insertBT_Click(object sender, EventArgs e)
        {
            time.Text = "Идет добавление объектов в базу данных...";
            time.ForeColor = Color.Blue;
            _ = Sel();
            
        }

        //Функция добавления выбранных компонентов в базу данных
        private async Task Sel()
        {
            SqlCommand command;

            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 50;

            DateTime dold = DateTime.Now;

            double Gtype = 1;
            string pcip = "127.0.0.1";

            if (Dns.GetHostAddresses(Dns.GetHostName()).Length > 0)
            {
                pcip = Dns.GetHostAddresses(Dns.GetHostName())[0].ToString();
                for (int i = 0; i < Dns.GetHostAddresses(Dns.GetHostName()).Length; i++)
                    if (Dns.GetHostAddresses(Dns.GetHostName())[i].ToString().Length > 7)
                    {
                        if (Dns.GetHostAddresses(Dns.GetHostName())[i].ToString().Remove(7, Dns.GetHostAddresses(Dns.GetHostName())[i].ToString().Length - 7) == "192.168")
                            pcip = Dns.GetHostAddresses(Dns.GetHostName())[i].ToString();
                    }
            }

            for (int j = 0; j < 8; j++)
                if (CompCB.GetItemChecked(j))
                    Gtype += Math.Pow(2, j + 1);

            command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from comps", conn);
            string pcid = command.ExecuteScalar().ToString();

            command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from comports", conn);
            string comid = command.ExecuteScalar().ToString();

            command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from rslines", conn);
            string rsid = command.ExecuteScalar().ToString();

            command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
            string DevItmID = command.ExecuteScalar().ToString();

            try
            {
                command = new SqlCommand("CREATE TABLE rslist (id int, name varchar(50))", conn);
                command.ExecuteNonQuery();
            }
            catch
            {
                command = new SqlCommand("DELETE rslist", conn);
                command.ExecuteNonQuery();
            }

            for (int i = 0; i < rslist.CheckedItems.Count; i++)
            {
                command = new SqlCommand($"insert into rslist values ({i + 1}, '{rslist.CheckedItems[i]}')", conn);
                command.ExecuteNonQuery();
            }

            command = new SqlCommand(
                "DECLARE @ncom INT, @rscomid INT, @rstypeid INT, @rs INT, @rscnt INT, @ipc INT, @icom INT, @irs INT, @jrs INT, @idev INT, @addr INT, @cntReader INT, @cntKey INT, @cntShl INT \n" +
                "DECLARE @rsname varchar(50) \n" +
                $"DECLARE @pcid INT, @comid INT, @rsid INT, @devid INT \n" +
                $"SET @pcid = {pcid} \n" +
                $"SET @rscnt = {rslist.CheckedItems.Count} \n" +
                $"SET @devid = {DevItmID} \n" +
                $"SET @comid = {comid} \n" +
                $"SET @rsid = {rsid} \n" +
                $"SET @ipc = 1 \n" +
                $"SET @icom = 1 \n" +
                $"SET @irs = 1 \n" +
                $"SET @idev = 1 \n" +
                $"SET @jrs = 1; \n" +
                $"set @irs = 1 \n" +
                $"WHILE @ipc <= {countPC.Value} \n" +
                $"BEGIN \n" +
                    $"insert into Comps values (@pcid, @pcid, '{CompsName.Text}' + convert(varchar, @ipc), NULL, '{pcip}', {Gtype},NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL); \n" +
                    $"set @icom = 1 \n" +

                    $"WHILE @icom <= {PortCount.Value} \n" +
                    $"BEGIN \n" +
                        $"insert into Comports values(@comid, @pcid, @icom, 2, 3, {ComType.SelectedIndex + 1}, NULL, '127.0.0.1', 1, NULL, NULL, 1, NULL, 9600);  \n" +
                        $"set @irs = 1 \n" +
                        $"set @addr = 1 \n " +

                        $"WHILE @irs <= @rscnt \n" +
                        $"BEGIN \n" +
                            $"set @rstypeid = (select distinct DeviceType from dtypesElement d join rslist r on d.name = r.name where r.id = @irs) \n" +
                            $"set @rsname = (select distinct name from rslist where id = @irs) \n" +
                            $"set @jrs = 1 \n" +

                            $"WHILE @jrs <= {RScount.Value} \n" +
                            $"BEGIN \n" +
                                $"insert into RSLines values (@rsid, @rsid, @comid, 0, @addr, @rsname, @rstypeid, NULL, 0, 0, 0, '127.0.0.1', NULL, NULL, NULL, 0, 0, NULL, 0, 1, 0, NULL, 0, 1, NULL); \n" +
                                $"set @cntReader = (select distinct CountReader from dTypesElement where name = @rsname and DeviceVersionStr IS NULL) \n" +
                                $"set @cntKey = (select distinct CountKey from dTypesElement where name = @rsname and DeviceVersionStr IS NULL) \n" +
                                $"set @cntShl = (select distinct CountShl from dTypesElement where name = @rsname and DeviceVersionStr IS NULL) \n" +
                                $"set @idev = 1 \n" +

                                $"WHILE @idev <= @cntReader \n" +
                                $"BEGIN \n" +
                                    $"insert into DevItems values (@devid, @pcid, @rsid, @addr * 256 + @idev, @devid, 'Считыватель ' + convert(varchar, @idev) + '. Прибор ' + convert(varchar, @addr), Null, 0, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) \n" +
                                    $"set @idev = @idev + 1 \n" +
                                    $"set @devid = @devid + 1 \n" +
                                $"END \n" +
                                $"set @idev = 1 \n" +

                                $"WHILE @idev <= @cntKey \n" +
                                $"BEGIN \n" +
                                    $"insert into DevItems values (@devid, @pcid, @rsid, @addr * 256 + @idev, @devid, 'Реле ' + convert(varchar, @idev) + '. Прибор ' + convert(varchar, @addr), Null, 0, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) \n" +
                                    $"set @idev = @idev + 1 \n" +
                                    $"set @devid = @devid + 1 \n" +
                                $"END \n" +
                                $"set @idev = 1 \n" +

                                $"WHILE @idev <= @cntKey \n" +
                                $"BEGIN \n" +
                                    $"insert into DevItems values (@devid, @pcid, @rsid, @addr * 256 + @idev, @devid, 'ШС ' + convert(varchar, @idev) + '. Прибор ' + convert(varchar, @addr), Null, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) \n" +
                                    $"set @idev = @idev + 1 \n" +
                                    $"set @devid = @devid + 1 \n" +
                                $"END \n" +

                                $"set @addr = @addr + 1 \n" +
                                $"set @jrs = @jrs + 1 \n" +
                                $"set @rsid = @rsid + 1 \n" +
                            $"END \n" +
                            $"set @irs = @irs + 1 \n" +
                        $"END \n" +

                        $"set @icom = @icom + 1 \n" +
                        $"set @comid = @comid + 1 \n" +
                    $"END \n" +

                    $"set @ipc = @ipc + 1; \n" +
                    $"set @pcid = @pcid + 1; \n" +
                $"END", conn);

            command.CommandTimeout = 5000;

            await command.ExecuteNonQueryAsync();

            time.Text = "Объекты добавлены";
            time.ForeColor = Color.Green;

            progressBar1.Visible = false;
        }


        private void potrCBx_CheckedChanged(object sender, EventArgs e)
        {
            portGB.Enabled = true;
        }

        private void RSCBx_CheckedChanged(object sender, EventArgs e)
        {
            RSGB.Enabled = true;
        }


        //Загрузка формы
        private void Test_Load(object sender, EventArgs e)
        {
            rslist.Items.Clear();
            rslist.Text = "";
            SqlCommand command = new SqlCommand("select name from dtypesElement where elementtype=4", conn);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                rslist.Items.Add(read.GetValue(0).ToString());
            }
            read.Close();
        }

       
        //Функция для удаления по названию компьютера
        private void DeleteBT_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Maximum = 5;
            SqlCommand command;
            string DelcompID = CompsName.Text;
            command = new SqlCommand("delete d from comps c join devitems d  on c.id = d.computerID where c.name like '%" + DelcompID + "%'", conn);
            command.ExecuteNonQuery();
            progressBar1.Value++;
            command = new SqlCommand("update r set name = null, devicetype = null, priority = null from comps c join Comports cp on c.id = cp.computerID join rslines r on cp.id = r.comportID where c.name like '%" + DelcompID + "%'", conn);
            command.ExecuteNonQuery();
            progressBar1.Value++;
            command = new SqlCommand("delete r from comps c join Comports cp on c.id = cp.computerID join rslines r on cp.id = r.comportID where c.name like '%" + DelcompID + "%'", conn);
            command.ExecuteNonQuery();
            progressBar1.Value++;
            command = new SqlCommand("delete cp from comps c join comports cp on c.id = cp.computerID where  c.name like '%" + DelcompID + "%'", conn);
            command.ExecuteNonQuery();
            progressBar1.Value++;
            command = new SqlCommand("delete from comps where name like '%" + DelcompID + "%'", conn);
            command.ExecuteNonQuery();
            progressBar1.Value++;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        //Обновление страниц
        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataReader read;
            if (tab.SelectedIndex == 1)
            {

                RStype.Items.Clear();
                RStype.Text = "";
                command = new SqlCommand("select name from dtypesElement where elementtype=4", conn);
                read = command.ExecuteReader();
                while (read.Read())
                {
                    RStype.Items.Add(read.GetValue(0).ToString());
                }
                read.Close();
                RStype.SelectedIndex = 0;

                command = new SqlCommand("select name from comps", conn);
                read = command.ExecuteReader();
                SelPC.Items.Clear();
                SelPC.Text = "";
                selCom.Items.Clear();
                selCom.Text = "";
                while (read.Read())
                    SelPC.Items.Add(read.GetValue(0).ToString());
                read.Close();
                SelPC.SelectedIndex = SelPC.Items.Count - 1;
            }
            if (tab.SelectedIndex == 3)
            {
                userlist.Items.Clear();
                userlist.Text = "";
                command = new SqlCommand("select Name, Firstname, Midname, ID from pList", conn);
                read = command.ExecuteReader();
                while (read.Read())
                {
                    try
                    {
                        userlist.Items.Add(read.GetValue(0).ToString() + " " + read.GetValue(1).ToString().Remove(1, read.GetValue(1).ToString().Length - 1) + ". " + read.GetValue(2).ToString().Remove(1, read.GetValue(2).ToString().Length - 1) + "." + "(" + read.GetValue(3).ToString() + ")");
                    }
                    catch
                    {
                    }

                }
                read.Close();

                userlist.SelectedIndex = userlist.Items.Count - 1;
            }
        }

        //Обновление компонентов страницы при выборе порта
        private void selCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var command = new SqlCommand("select cp.ID from comps c join comports cp on c.id=cp.computerID where c.Name = @name and number = @num", conn);
            command.Parameters.AddWithValue("name", SelPC.Text);
            command.Parameters.AddWithValue("num", selCom.Text.Remove(0, 3));
            var comid = command.ExecuteScalar().ToString();
            command = new SqlCommand("select name from rslines where comportID = @ID", conn);
            command.Parameters.AddWithValue("ID", comid);
            SqlDataReader read = command.ExecuteReader();
            ParentCB.Items.Clear();
            ParentCB.Text = "";
            while (read.Read())
                ParentCB.Items.Add(read.GetValue(0).ToString());
            read.Close();
        }

        //Обновление компонентов страницы при выборе компа
        private void SelPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            var command = new SqlCommand("select number from comps c join comports cp on c.id=cp.computerID where c.name = @name", conn);
            command.Parameters.AddWithValue("name", SelPC.Text);
            SqlDataReader read = command.ExecuteReader();
            selCom.Items.Clear();
            selCom.Text = "";
            while (read.Read())
                selCom.Items.Add("COM" + read.GetValue(0).ToString());
            read.Close();
            selCom.SelectedIndex = selCom.Items.Count - 1;
        }

        //Функция добавления компонентов (для вклвдки приборы)
        private void InsPR_Click(object sender, EventArgs e)
        {
            
            string RSpar = "0";
            RSPB.Visible = true;
            RSPB.Maximum = (int)PRnum.Value;
            if (ParentCB.SelectedIndex > -1)
            {
                SqlCommand command = new SqlCommand("select cp.ID from comps c join comports cp on c.id=cp.computerID where c.Name = @name and number = @num", conn);
                command.Parameters.AddWithValue("name", SelPC.Text);
                command.Parameters.AddWithValue("num", selCom.Text.Remove(0, 3));
                string comid = command.ExecuteScalar().ToString();
                command = new SqlCommand("select id from rslines where comportID = @comID and name = @name", conn);
                command.Parameters.AddWithValue("comID", comid);
                command.Parameters.AddWithValue("name", ParentCB.Text);
                RSpar = command.ExecuteScalar().ToString();

            }

            for (int i = 1; i <= PRnum.Value; i++)
            {

                SqlCommand command = new SqlCommand("select DeviceType from dtypesElement where name = @name", conn);
                command.Parameters.AddWithValue("name", RStype.Text);
                string RSTypeID = command.ExecuteScalar().ToString();
                command = new SqlCommand("select cp.ID from comps c join comports cp on c.id=cp.computerID where c.Name = @name and number = @num", conn);
                command.Parameters.AddWithValue("name", SelPC.Text);
                command.Parameters.AddWithValue("num", selCom.Text.Remove(0, 3));
                string comid = command.ExecuteScalar().ToString();

                command = new SqlCommand("select ID from comps  where name = @name", conn);
                command.Parameters.AddWithValue("name", SelPC.Text);
                string pcid = command.ExecuteScalar().ToString();

                command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from rslines", conn);
                string rsid = command.ExecuteScalar().ToString();
                command = new SqlCommand("select coalesce(MAX(GLineNo) + 1, 1) from rslines", conn);
                string adrid = command.ExecuteScalar().ToString();

                command = new SqlCommand("insert into RSLines values (@ID, @ID, @Com, @PKUID, @GLine, @Name, @Type, NULL, 0, 0, 0, @IP, NULL, NULL, NULL, 0, 0, NULL, 0, @Interface, 0, NULL, 0, 1, NULL);", conn);
                command.Parameters.AddWithValue("ID", rsid);
                command.Parameters.AddWithValue("Com", comid);
                command.Parameters.AddWithValue("PKUID", RSpar);
                command.Parameters.AddWithValue("GLine", adrid);
                command.Parameters.AddWithValue("Name", RStype.Text + " (" + adrid + ")");
                command.Parameters.AddWithValue("IP", "127.0.0.1");
                command.Parameters.AddWithValue("Interface", 1);
                command.Parameters.AddWithValue("Type", RSTypeID);

                command.ExecuteNonQuery();


                //DEVITEMS----------------------------------------------------------------------------------------------------
                command = new SqlCommand("select CountReader from dTypesElement where name = @name", conn);
                command.Parameters.AddWithValue("name", RStype.Text);
                int countReader = (int)command.ExecuteScalar();

                for (int j = 1; j <= countReader; j++)
                {
                    command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
                    string DevItmID = command.ExecuteScalar().ToString();
                    command = new SqlCommand("insert into DevItems values (@ID, @compID, @DeviceID, @Address, @ID, @Name, Null, 0, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
                    command.Parameters.AddWithValue("ID", DevItmID);
                    command.Parameters.AddWithValue("CompID", pcid);
                    command.Parameters.AddWithValue("DeviceId", rsid);
                    command.Parameters.AddWithValue("Address", Convert.ToInt32(adrid) * 256 + j);
                    command.Parameters.AddWithValue("Name", "Считыватель " + j + ". Прибор " + adrid);
                    command.ExecuteNonQuery();
                }

                command = new SqlCommand("select CountKey from dTypesElement where name = @name", conn);
                command.Parameters.AddWithValue("name", RStype.Text);
                int countKey = (int)command.ExecuteScalar();

                for (int j = 1; j <= countKey; j++)
                {
                    command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
                    string DevItmID = command.ExecuteScalar().ToString();
                    command = new SqlCommand("insert into DevItems values (@ID, @compID, @DeviceID, @Address, @ID, @Name, Null, 0, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
                    command.Parameters.AddWithValue("ID", DevItmID);
                    command.Parameters.AddWithValue("CompID", pcid);
                    command.Parameters.AddWithValue("DeviceId", rsid);
                    command.Parameters.AddWithValue("Address", Convert.ToInt32(adrid) * 256 + j);
                    command.Parameters.AddWithValue("Name", "Реле " + j + ". Прибор " + adrid);
                    command.ExecuteNonQuery();
                }

                command = new SqlCommand("select CountShl from dTypesElement where name = @name", conn);
                command.Parameters.AddWithValue("name", RStype.Text);
                int countShl = (int)command.ExecuteScalar();

                for (int j = 1; j <= countShl; j++)
                {
                    command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
                    string DevItmID = command.ExecuteScalar().ToString();
                    command = new SqlCommand("insert into DevItems values (@ID, @compID, @DeviceID, @Address, @ID, @Name, Null, 1, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
                    command.Parameters.AddWithValue("ID", DevItmID);
                    command.Parameters.AddWithValue("CompID", pcid);
                    command.Parameters.AddWithValue("DeviceId", rsid);
                    command.Parameters.AddWithValue("Address", Convert.ToInt32(adrid) * 256 + j);
                    command.Parameters.AddWithValue("Name", "ШС " + j + ". Прибор " + adrid);
                    command.ExecuteNonQuery();
                }
                RSPB.Value++;
            }
            RSPB.Visible = false;
            RSPB.Value = 0;
        }

        private void DelPR_Click(object sender, EventArgs e)
        {
            RSPB.Visible = true;
            RSPB.Maximum = 3;
            SqlCommand command = new SqlCommand("select cp.ID from comps c join comports cp on c.id=cp.computerID where c.Name = @name and number = @num", conn);
            command.Parameters.AddWithValue("name", SelPC.Text);
            command.Parameters.AddWithValue("num", selCom.Text.Remove(0, 3));
            string comID = command.ExecuteScalar().ToString();
            command = new SqlCommand("delete d from rslines r join devitems d on r.id = d.deviceID where r.comportID = @ID and r.name like '" + RStype.Text + "%'", conn);
            command.Parameters.AddWithValue("ID", comID);
            command.ExecuteNonQuery();
            RSPB.Value++;
            command = new SqlCommand("update r set name = null, devicetype = null, priority = null from comports c join rslines r on c.id=r.comportID where c.id = @ID and r.name like '%" + RStype.Text + "%'", conn);
            command.Parameters.AddWithValue("ID", comID);
            command.ExecuteNonQuery();
            RSPB.Value++;
            command = new SqlCommand("delete from rslines where comportID = @ID and name is null", conn);
            command.Parameters.AddWithValue("ID", comID);
            command.ExecuteNonQuery();
            RSPB.Value++;
            RSPB.Visible = false;
            RSPB.Value = 0;
        }

        

        //Функция добавления пароля
        private void insertPass(string pass)
        {
            if ((userlist.Items.Count > 0))
            {
                SqlCommand command;
                command = new SqlCommand("select coalesce(max(ID) + 1, 1) from pMark", Settings.sqlConnection);
                string passID = command.ExecuteScalar().ToString();
                string name;
                Random rand = new Random();
                if (Ruser.Checked)
                {
                    name = userlist.Items[rand.Next(0, userlist.Items.Count)].ToString();
                }
                else
                    name = userlist.Text;

                string owner = "";


                owner = name.Remove(0, name.LastIndexOf("(") + 1);
                owner = owner.Remove(owner.Length - 1, 1);

                command = new SqlCommand("insert pMark values (@ID, 4, 0, 128, @key, @key2, 16128, @owner, @name, 1, 1, @ds, @de, 0, NULL, NULL, 1, NULL, NULL)", Settings.sqlConnection);
                command.Parameters.AddWithValue("ID", passID);
                command.Parameters.AddWithValue("key", pass);
                command.Parameters.AddWithValue("key2", "ю");
                command.Parameters.AddWithValue("owner", owner);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("ds", "22.07.2020 0:00:00");
                command.Parameters.AddWithValue("de", "22.07.2031 23:59:59");
                //command.Parameters.AddWithValue("pc", "DEMO-12");
                command.ExecuteScalar();
            }
        }

        //Кодирование ключа
        private void insPass_Click(object sender, EventArgs e)
        {
            byte[] tes = new byte[8];
            string nstr;
            passPB.Visible = true;
            passPB.Maximum = (int)numPass.Value; 
            SqlCommand command = new SqlCommand("select count(*) from pmark", conn);
            int k = (int)command.ExecuteScalar();
            for (uint j = 0; j < numPass.Value; j++)
            {
                ulong test = (ulong)k;
                char[] ascii;
                test += j;
                test <<= 8;
                test += 0x1;
                tes = BitConverter.GetBytes(test);
                tes[7] = CRC8(BitConverter.GetBytes(test), 7);
                ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x1 });
                nstr = ascii[0].ToString();
                for (int i = 0; i < tes.Length; i++)
                {

                    switch (tes[i])
                    {
                        case 0x0:
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                            nstr += ascii[0].ToString();
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x1 });
                            nstr += ascii[0].ToString();
                            break;
                        case 0xFE:
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                            nstr += ascii[0].ToString();
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x2 });
                            nstr += ascii[0].ToString();
                            break;
                        case 0x20:
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                            nstr += ascii[0].ToString();
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x3 });
                            nstr += ascii[0].ToString();
                            break;
                        case 0x5C:
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                            nstr += ascii[0].ToString();
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x4 });
                            nstr += ascii[0].ToString();
                            break;
                        case 0xA:
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0xFE });
                            nstr += ascii[0].ToString();
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { 0x5 });
                            nstr += ascii[0].ToString();
                            break;
                        default:
                            ascii = Encoding.GetEncoding(0).GetChars(new byte[] { tes[i] });
                            nstr += ascii[0].ToString();
                            break;
                    }
                }

                insertPass(nstr);
                passPB.Value++;
            }
            passPB.Visible = false;
            passPB.Value = 0;
        }

        //Функция добавления сотрудников
        private void userINS_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            userPB.Visible = true;
            userPB.Maximum = (int)userNum.Value;
            for (int i = 0; i < userNum.Value; i++)
            {
                SqlCommand command = new SqlCommand("select coalesce(max(ID) + 1, 1) from pList", conn);
                string ListID = command.ExecuteScalar().ToString();
                int pol = rand.Next(0, 2);
                if (pol == 0)
                {
                    command = new SqlCommand("insert pList (ID, Name, FirstName, MidName, status, Schedule, TabNumber, ChangeTime) values (@ID, @Name, @Fname, @Mname, @status, 0, @ID, @Time)", conn);
                    command.Parameters.AddWithValue("ID", ListID);
                    command.Parameters.AddWithValue("Name", Mfam[rand.Next(0, 100)]);
                    command.Parameters.AddWithValue("Fname", Mname[rand.Next(0, 100)]);
                    command.Parameters.AddWithValue("Mname", Motch[rand.Next(0, 100)]);
                    command.Parameters.AddWithValue("Status", rand.Next(1, 8));
                    command.Parameters.AddWithValue("Time", DateTime.Now);
                    command.ExecuteScalar();
                }
                else
                {
                    command = new SqlCommand("insert pList (ID, Name, FirstName, MidName, status, Schedule, TabNumber, ChangeTime) values (@ID, @Name, @Fname, @Mname, @status, 0, @ID, @Time)", conn);
                    command.Parameters.AddWithValue("ID", ListID);
                    command.Parameters.AddWithValue("Name", Wfam[rand.Next(0, 100)]);
                    command.Parameters.AddWithValue("Fname", Wname[rand.Next(0, 100)]);
                    command.Parameters.AddWithValue("Mname", Wotch[rand.Next(0, 100)]);
                    command.Parameters.AddWithValue("Status", rand.Next(1, 8));
                    command.Parameters.AddWithValue("Time", DateTime.Now);
                    command.ExecuteScalar();
                }
                userPB.Value++;
            }
            userPB.Visible = false;
            userPB.Value = 0;
        }

        //Чекбокс для рандомного выбора сотрудника для добавления пароля
        private void Ruser_CheckedChanged(object sender, EventArgs e)
        {
            if (Ruser.Checked)
            {
                userlist.Enabled = false;
            }
            else
            {
                userlist.Enabled = true;
            }
        }


        //Функции изменения окна с параметрами пароля
        private void SelectTypePass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSettingsList(PassSettingsList, sender);
        }

        private void ChangeSettingsList(object sender, object type)
        {
            SqlCommand command;
            SqlDataReader read;
            CheckedListBox box = (CheckedListBox)sender;
            ComboBox typebox = (ComboBox)type;

            PermBox.Items.Clear();
            command = new SqlCommand("select name from Groups", Settings.sqlConnection);
            read = command.ExecuteReader();
            while (read.Read())
                PermBox.Items.Add(read.GetValue(0).ToString());
            read.Close();

            TypeKeyBox.Enabled = false;

            box.Items.Clear();
            switch (typebox.SelectedIndex)
            {
                case 0:
                    PasswordBox.Enabled = true;
                    box.Items.Add("Менеджер сервера");
                    box.Items.Add("Администратор базы данных");
                    box.Items.Add("Оперативная задача");
                    box.Items.Add("Учет рабочего времени");
                    box.Items.Add("Генератор отчетов");
                    box.Items.Add("Оболочка");
                    box.Items.Add("Персональная карточка");

                    break;
                case 1:
                    box.Items.Add("Хранить код ключа в ПКУ");
                    break;
                case 2 or 3 or 5 or 6:
                    TypeKeyBox.Enabled = true;
                    box.Items.Add("Упрощенный ввод");
                    box.Items.Add("Хранить код ключа в приборах");
                    box.Items.Add("Хранить код ключа в ПКУ");
                    box.Items.Add("Ключ заблокирован");
                    box.Items.Add("Стоп-лист");
                    break;
                case 4 or 8 or 9 or 10:
                    box.Items.Add("Ключ заблокирован");
                    break;

            }

        }

        //Функция удаления паролей по id сотрудника
        private void passDel_Click(object sender, EventArgs e)
        {
            userPB.Visible = true;
            userPB.Maximum = 1;
            string name = userlist.Text;
            string owner = name.Remove(0, name.LastIndexOf("(") + 1);
            owner = owner.Remove(owner.Length - 1, 1);
            SqlCommand command = new SqlCommand("delete from pmark where owner = @ownerID", conn);
            command.Parameters.AddWithValue("ownerID", owner);
            command.ExecuteScalar();
            userPB.Value++;
            userPB.Visible = false;
            userPB.Value = 0;
        }


        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            set.Enabled = true;
            set.Focus();
        }
    }
}
