﻿using System;
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

namespace SQLDrv
{
    public partial class Test : Form
    {

        SqlConnection conn;
        string[] Clerc = new string[1000];


        public Test()
        {
            InitializeComponent();
            conn = Settings.sqlConnection;
        }

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

        public static byte CRC8(byte[] bytes, int len)
        {
            byte crc = 0;
            for (var i = 0; i < len; ++i)
                crc = crc8Table[crc ^ bytes[i]];
            return crc;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void CompAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            for (int i = 0; i < 8; i++)
                CompCB.SetItemChecked(i, box.Checked);
        }

        private void insertBT_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            progressBar1.Visible = true;
            progressBar1.Maximum = (int)countPC.Value;
            progressBar1.Value = 0;
            DateTime dold = DateTime.Now;

            double Gtype = 1;
            string pcip = "";

            if (Dns.GetHostAddresses(Dns.GetHostName()).Length > 0)
            {
                int j = 0;
                pcip = Dns.GetHostAddresses(Dns.GetHostName())[j].ToString();
                while (pcip.Remove(7, pcip.Length - 7) != "192.168")    //text.Text.Remove(7, text.Text.Length - 7) != "192.168"
                {
                    pcip = Dns.GetHostAddresses(Dns.GetHostName())[j].ToString();
                    j++;
                }
            }

            for (int j = 0; j < 8; j++)
                if (CompCB.GetItemChecked(j))
                    Gtype += Math.Pow(2, j + 1);

            command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from comps", conn);
            string pcid = command.ExecuteScalar().ToString();

            command = new SqlCommand("DECLARE @number INT \n" +
                "SET @number = 1 \n" +
                $"DECLARE @id INT \n" +
                $"SET @id = {pcid}; \n" +
                $"WHILE @number <= {countPC.Value} \n" +
                $"BEGIN \n" +
                $"insert into Comps values (@id, @id, '{CompsName.Text}' + convert(varchar, @number), NULL, '{pcip}', {Gtype},NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL); \n" +
                $"set @number = @number + 1; \n" +
                $"set @id = @id + 1; \n" +
                $"END", conn);
            command.ExecuteNonQuery();

            /*

            for (int i = 1; i <= countPC.Value; i++)
            {
                //COMPS------------------------------------------------------------------------------------------------------------
                
                command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from comps", conn);
                string pcid = command.ExecuteScalar().ToString();


                command = new SqlCommand("insert into Comps values (@ID, @ID, @Name, NULL, @IP, @Gtype,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);", conn);
                command.Parameters.AddWithValue("ID", pcid);
                command.Parameters.AddWithValue("Name", CompsName.Text + i);
                command.Parameters.AddWithValue("IP", pcip);
               
                command.Parameters.AddWithValue("Gtype", Gtype);
                command.ExecuteNonQuery();

                //COMPORTS------------------------------------------------------------------------------------------------------------
                for (int comc = 1; comc <= PortCount.Value; comc++)
                {
                    command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from comports", conn);
                    string comid = command.ExecuteScalar().ToString();

                    command = new SqlCommand("insert into Comports values (@ID, @compID, @Number, @Adaptor, 3, @Type, NULL, @IP, 1, NULL, NULL, 1, NULL, @Baud);", conn);
                    command.Parameters.AddWithValue("ID", comid);
                    command.Parameters.AddWithValue("compID", pcid);
                    command.Parameters.AddWithValue("Number", comc);
                    command.Parameters.AddWithValue("IP", "127.0.0.1");
                    command.Parameters.AddWithValue("Adaptor", 2);
                    command.Parameters.AddWithValue("Type", ComType.SelectedIndex + 1);
                    command.Parameters.AddWithValue("Baud", 9600);

                    command.ExecuteNonQuery();
                    int adrpr = 1;

                    //RSLINES------------------------------------------------------------------------------------------------------------
                    for (int rs = 0; rs < rslist.CheckedItems.Count; rs++)
                    {
                        command = new SqlCommand("select DeviceType from dtypesElement where name = @name", conn);
                        command.Parameters.AddWithValue("name", rslist.CheckedItems[rs]);
                        string RSTypeID = command.ExecuteScalar().ToString();

                        for (int rsc = 1; rsc <= RScount.Value; rsc++)
                        {
                            command = new SqlCommand("select coalesce(MAX(ID) + 1, 1) from rslines", conn);
                            string rsid = command.ExecuteScalar().ToString();

                            command = new SqlCommand("insert into RSLines values (@ID, @ID, @Com, @PKUID, @GLine, @Name, @Type, NULL, 0, 0, 0, @IP, NULL, NULL, NULL, 0, 0, NULL, 0, @Interface, 0, NULL, 0, 1, NULL);", conn);
                            command.Parameters.AddWithValue("ID", rsid);
                            command.Parameters.AddWithValue("Com", comid);
                            command.Parameters.AddWithValue("PKUID", 0);
                            command.Parameters.AddWithValue("GLine", adrpr);
                            command.Parameters.AddWithValue("Name", rslist.CheckedItems[rs] + " (" + adrpr + ")");
                            command.Parameters.AddWithValue("IP", "127.0.0.1");
                            command.Parameters.AddWithValue("Interface", 1);
                            command.Parameters.AddWithValue("Type", RSTypeID);

                            command.ExecuteNonQuery();


                            //DEVITEMS----------------------------------------------------------------------------------------------------
                            command = new SqlCommand("select CountReader from dTypesElement where name = @name", conn);
                            command.Parameters.AddWithValue("name", rslist.CheckedItems[rs]);
                            int countReader = (int)command.ExecuteScalar();

                            for (int j = 1; j <= countReader; j++)
                            {
                                command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
                                string DevItmID = command.ExecuteScalar().ToString();
                                command = new SqlCommand("insert into DevItems values (@ID, @compID, @DeviceID, @Address, @ID, @Name, Null, 0, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
                                command.Parameters.AddWithValue("ID", DevItmID);
                                command.Parameters.AddWithValue("CompID", pcid);
                                command.Parameters.AddWithValue("DeviceId", rsid);
                                command.Parameters.AddWithValue("Address", Convert.ToInt32(adrpr) * 256 + j);
                                command.Parameters.AddWithValue("Name", "Считыватель " + j + ". Прибор " + adrpr);
                                command.ExecuteNonQuery();
                            }

                            command = new SqlCommand("select CountKey from dTypesElement where name = @name", conn);
                            command.Parameters.AddWithValue("name", rslist.CheckedItems[rs]);
                            int countKey = (int)command.ExecuteScalar();

                            for (int j = 1; j <= countKey; j++)
                            {
                                command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
                                string DevItmID = command.ExecuteScalar().ToString();
                                command = new SqlCommand("insert into DevItems values (@ID, @compID, @DeviceID, @Address, @ID, @Name, Null, 0, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
                                command.Parameters.AddWithValue("ID", DevItmID);
                                command.Parameters.AddWithValue("CompID", pcid);
                                command.Parameters.AddWithValue("DeviceId", rsid);
                                command.Parameters.AddWithValue("Address", Convert.ToInt32(adrpr) * 256 + j);
                                command.Parameters.AddWithValue("Name", "Реле " + j + ". Прибор " + adrpr);
                                command.ExecuteNonQuery();
                            }

                            command = new SqlCommand("select CountShl from dTypesElement where name = @name", conn);
                            command.Parameters.AddWithValue("name", rslist.CheckedItems[rs]);
                            int countShl = (int)command.ExecuteScalar();

                            for (int j = 1; j <= countShl; j++)
                            {
                                command = new SqlCommand("select coalesce(max(ID) + 1, 1) from DevItems", conn);
                                string DevItmID = command.ExecuteScalar().ToString();
                                command = new SqlCommand("insert into DevItems values (@ID, @compID, @DeviceID, @Address, @ID, @Name, Null, 1, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)", conn);
                                command.Parameters.AddWithValue("ID", DevItmID);
                                command.Parameters.AddWithValue("CompID", pcid);
                                command.Parameters.AddWithValue("DeviceId", rsid);
                                command.Parameters.AddWithValue("Address", Convert.ToInt32(adrpr) * 256 + j);
                                command.Parameters.AddWithValue("Name", "ШС " + j + ". Прибор " + adrpr);
                                command.ExecuteNonQuery();
                            }
                            adrpr++;
                        }
                    }
                }
                progressBar1.Value++;
            }
            progressBar1.Visible = false;
            TimeSpan sp = DateTime.Now - dold;
            time.Text = sp.ToString();
            */
        }

        private void potrCBx_CheckedChanged(object sender, EventArgs e)
        {
            portGB.Enabled = true;
        }

        private void RSCBx_CheckedChanged(object sender, EventArgs e)
        {
            RSGB.Enabled = true;
        }

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


        private void DeleteBT_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            string DelcompID = CompsName.Text;
            command = new SqlCommand("delete d from comps c join devitems d  on c.id = d.computerID where c.name like '%" + DelcompID + "%'", conn);
            // command.Parameters.AddWithValue("ID", DelcompID);
            command.ExecuteNonQuery();

            command = new SqlCommand("update r set name = null, devicetype = null, priority = null from comps c join Comports cp on c.id = cp.computerID join rslines r on cp.id = r.comportID where c.name like '%" + DelcompID + "%'", conn);
            command.ExecuteNonQuery();
            command = new SqlCommand("delete r from comps c join Comports cp on c.id = cp.computerID join rslines r on cp.id = r.comportID where c.name like '%" + DelcompID + "%'", conn);
            //command.Parameters.AddWithValue("ID", DelcompID);
            command.ExecuteNonQuery();

            command = new SqlCommand("delete cp from comps c join comports cp on c.id = cp.computerID where  c.name like '%" + DelcompID + "%'", conn);
            //command.Parameters.AddWithValue("ID", DelcompID);
            command.ExecuteNonQuery();

            command = new SqlCommand("delete from comps where name like '%" + DelcompID + "%'", conn);
            //command.Parameters.AddWithValue("ID", DelcompID);
            command.ExecuteNonQuery();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работает - не трогай");
        }

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
        }

        private void DelPR_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select cp.ID from comps c join comports cp on c.id=cp.computerID where c.Name = @name and number = @num", conn);
            command.Parameters.AddWithValue("name", SelPC.Text);
            command.Parameters.AddWithValue("num", selCom.Text.Remove(0, 3));
            string comID = command.ExecuteScalar().ToString();
            command = new SqlCommand("delete d from rslines r join devitems d on r.id = d.deviceID where r.comportID = @ID and r.name like '" + RStype.Text + "%'", conn);
            command.Parameters.AddWithValue("ID", comID);
            command.ExecuteNonQuery();

            command = new SqlCommand("delete from rslines where comportID = @ID and name like '" + RStype.Text + "%'", conn);
            command.Parameters.AddWithValue("ID", comID);
            command.ExecuteNonQuery();
        }

        private void ParentCB_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void RStype_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void SelectTypePass_SelectedIndexChanged(object sender, EventArgs e)
        {

            ChangeSettingsList(PassSettingsList, sender);
        }

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

        private void insPass_Click(object sender, EventArgs e)
        {
            byte[] tes = new byte[8];
            string nstr;
            for (uint j = 0; j < numPass.Value; j++)
            {
                ulong test = 0xf272a595;
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
            }
        }

        private void userINS_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
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
            }
        }

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

        private void PassSettingsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClercsBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
