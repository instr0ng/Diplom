using System;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace SQLDrv
{
    public partial class Test : Form
    {
        SqlConnection conn;
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
            PCGB.Enabled = false;
            portGB.Enabled = false;
            RSGB.Enabled = false;
            insertBT.Enabled = false;
            DeleteBT.Enabled = false;
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
                                $"set @rstypeid = (select distinct DeviceType from dtypesElement d join rslist r on (d.name = r.name and d.DeviceVersionStr is null) or (d.name + ' ' + d.DeviceVersionStr) = r.name  where r.id = @irs) \n" +
                                $"set @rsname = (select distinct d.name from dtypesElement d join rslist r on (d.name = r.name and d.DeviceVersionStr is null) or (d.name + ' ' + d.DeviceVersionStr) = r.name where r.id = @irs) \n" +
                                $"set @jrs = 1 \n" +

                                $"WHILE @jrs <= {RScount.Value} \n" +
                                $"BEGIN \n" +
                                    $"insert into RSLines values (@rsid, @rsid, @comid, 0, @addr, substring(@rsname, 1, 25), @rstypeid, NULL, 0, 0, 0, '127.0.0.1', NULL, NULL, NULL, 0, 0, NULL, 0, 1, 0, NULL, 0, 1, NULL); \n" +
                                    $"set @cntReader = (select distinct CountReader from dTypesElement where name = @rsname and DeviceVersionStr IS NULL) \n" +
                                    $"set @cntKey = (select distinct CountKey from dTypesElement where (name = @rsname and DeviceVersionStr is null) or (name + ' ' + DeviceVersionStr) = @rsname) \n" +
                                    $"set @cntShl = (select distinct CountShl from dTypesElement where (name = @rsname and DeviceVersionStr is null) or (name + ' ' + DeviceVersionStr) = @rsname) \n" +
                                    $"set @idev = 1 \n" +

                                    $"WHILE @idev <= @cntReader \n" +
                                    $"BEGIN \n" +
                                        $"insert into DevItems values (@devid, @pcid, @rsid, @addr * 256 + @idev, @devid, 'Считыватель ' + convert(varchar, @idev) + ', Прибор ' + convert(varchar, @addr), Null, 0, 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) \n" +
                                        $"set @idev = @idev + 1 \n" +
                                        $"set @devid = @devid + 1 \n" +
                                    $"END \n" +
                                    $"set @idev = 1 \n" +

                                    $"WHILE @idev <= @cntKey \n" +
                                    $"BEGIN \n" +
                                        $"insert into DevItems values (@devid, @pcid, @rsid, @addr * 256 + @idev, @devid, 'Реле ' + convert(varchar, @idev) + ', Прибор ' + convert(varchar, @addr), Null, 0, 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) \n" +
                                        $"set @idev = @idev + 1 \n" +
                                        $"set @devid = @devid + 1 \n" +
                                    $"END \n" +
                                    $"set @idev = 1 \n" +

                                    $"WHILE @idev <= @cntShl \n" +
                                    $"BEGIN \n" +
                                        $"insert into DevItems values (@devid, @pcid, @rsid, @addr * 256 + @idev, @devid, 'ШС ' + convert(varchar, @idev) + ', Прибор ' + convert(varchar, @addr), Null, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) \n" +
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

                command.CommandTimeout = 500;

                await command.ExecuteNonQueryAsync();
            

            time.Text = "Объекты добавлены";
            time.ForeColor = Color.Green;
            PCGB.Enabled = true;
            portGB.Enabled = true;
            RSGB.Enabled = true;
            insertBT.Enabled = true;
            DeleteBT.Enabled = true;
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
            ComType.SelectedIndex = 1;
        }

        //Функция для удаления по названию компьютера
        private void DeleteBT_Click(object sender, EventArgs e)
        {
            time.Text = "";
            progressBar1.Style = ProgressBarStyle.Continuous;
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
            time.ForeColor = Color.Red;
            time.Text = "Объекты удалены";

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

        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            set.Enabled = true;
            set.Focus();
        }

        private void ComType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rslist.Items.Clear();
            rslist.Text = "";
            SqlCommand command = new SqlCommand("select iif(DeviceVersionStr is null, name, name + ' ' + DeviceVersionStr) from dtypesElement where elementtype=4", conn);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                rslist.Items.Add(read.GetValue(0).ToString());
            }
            read.Close();
        }
    }
}
