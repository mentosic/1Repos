using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace X_COM
{
    public partial class index : Form
    {
        public static ContextElectro db = new ContextElectro();
        public static int user = 0;
        public static string keyAdmin = "12345";

        public index()
        {
            InitializeComponent();
            helpTextProductSearch();
            iniz();
            goProduct();
        }

        // вывод продуктов по фильтрам //
        private void goProduct()
        {
            panel1.Controls.Clear();
            int numProduct = 0;
            foreach (Product P in db.Products)
                numProduct++;
            int[] listProductSort = new int[numProduct]; // массив id подходящих под сортировку товаров

            sortedListProduct(listProductSort, numProduct); // сортировка по умолчанию
            sortedTypeListProduct(listProductSort, numProduct); // сортировка по типу
            sortedBrendListProduct(listProductSort, numProduct); // сортировка по производителю
            sortedPriceListProduct(listProductSort, numProduct); // сортировка по стоимости
            sortedDiscontListProduct(listProductSort, numProduct); // сортировка по наличию скидки
            sortedNumListProduct(listProductSort, numProduct); // сортировка по наличии на складе
            sortedMessageListProduct(listProductSort, numProduct); // сортировка о наличии отзывов

            if (textBox1.Text != "Что Вас интересует?")
                filterTextProduct(listProductSort, numProduct); // фильтр по поиску

            int check = 0; // проверка, нашлись ли элементы согласно фильтрам
            for (int i = 0; i < numProduct; i++)
            {
                if (listProductSort[i] != 0) // если есть хоть одно совпадение
                {
                    check = 1;
                    break;
                }
            }

            if (check == 0) // нет совпадений - выводим надпись об этом
            {
                Label error = new Label();

                error.ForeColor = Color.DarkRed;
                error.BackColor = this.BackColor;
                error.Size = new Size(600, 90);
                error.Font = new Font("Microsoft Sans Serif", 36, FontStyle.Bold);
                error.TextAlign = ContentAlignment.TopLeft;
                error.Text = "Совпадения не найдены";

                error.Location = new Point(60, 150);
                panel1.Controls.Add(error);
            }
            else
            {
                // массивы оъектов элементов управления //
                PictureBox[] PictureBackground = new PictureBox[numProduct]; // фон основной инфы
                PictureBox[] PictureBackgroundPath = new PictureBox[numProduct]; // картинка
                Label[] infoName = new Label[numProduct]; // имя запчасти, вид и производитель
                Label[] price = new Label[numProduct]; // стоимость
                Label[] priceWow = new Label[numProduct]; // стоимость
                Button[] btn = new Button[numProduct]; // кнопка отзывы
                PictureBox[] img = new PictureBox[numProduct]; // кнопка-корзина

                // размеры //
                int PictureBackgroundWidth = 680;
                int PictureBackgroundHeight = 150;

                int PictureBackgroundPathWidth = 140;
                int PictureBackgroundPathHeight = 140;

                int infoNameWidth = 200;
                int infoNameHeight = 140;

                int priceWidth = 200;
                int priceHeight = 40;

                int btnWidth = 130;
                int btnHeight = 35;

                int imgWidth = 80;
                int imgHeight = 80;

                // координаты на форме //
                int PictureBackgroundX = 15;
                int PictureBackgroundY = 5;

                int PictureBackgroundPathX = 35;
                int PictureBackgroundPathY = 10;

                int infoNameX = 190;
                int infoNameY = 10;

                int priceX = 400;
                int priceY = 40;

                int btnX = 430;
                int btnY = 90;

                int imgX = 610;
                int imgY = 40;

                int k = 0; // счетчик
                for (int i = 0; i < numProduct; i++)
                {
                    foreach (Product P in db.Products)
                    {
                        if (listProductSort[i] == P.id && P.copy == false)
                        {
                            // кнопка-корзина //
                            img[k] = new PictureBox();
                            try
                            {
                                img[k].Image = Properties.Resources.Кнопка;
                            }
                            catch { }
                            img[k].SizeMode = PictureBoxSizeMode.StretchImage;
                            img[k].Size = new Size(imgWidth, imgHeight);
                            img[k].BackColor = Color.DarkRed;
                            // вывод объекта по следующим координатам //
                            img[k].Location = new Point(imgX, imgY);
                            panel1.Controls.Add(img[k]);
                            // переход к след координатам //
                            imgY += PictureBackgroundHeight + 30;
                            // событие нажатия на кнопку //
                            img[k].Click += new EventHandler(pictureBox_Clicked);
                            // в качестве имени кнопки будем использовать айди товара //
                            img[k].Name = P.id.ToString();
                            // событие наведение на кнопку курсора //
                            img[k].MouseEnter += new EventHandler(pictureBox_MouseEnter);
                            // событие отведение курсора от кнопки //
                            img[k].MouseLeave += new EventHandler(pictureBox_MouseLeave);

                            // кнопка //
                            btn[k] = new Button();
                            btn[k].ForeColor = Color.White;
                            btn[k].BackColor = Color.Navy;
                            btn[k].Size = new Size(btnWidth, btnHeight);
                            btn[k].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                            btn[k].Text = "Отзывы";
                            // вывод объекта по следующим координатам //
                            btn[k].Location = new Point(btnX, btnY);
                            panel1.Controls.Add(btn[k]);
                            // переход к след координатам //
                            btnY += PictureBackgroundHeight + 30;
                            // событие нажатия на кнопку //
                            btn[k].Click += new EventHandler(button_Clicked);
                            // в качестве имени кнопки будем использовать айди товара //
                            btn[k].Name = P.id.ToString();
                            // событие наведение на кнопку курсора //
                            btn[k].MouseEnter += new EventHandler(button_MouseEnter);
                            // событие отведение курсора от кнопки //
                            btn[k].MouseLeave += new EventHandler(button_MouseLeave);

                            // стоимость //
                            price[k] = new Label();
                            price[k].ForeColor = Color.White;
                            price[k].BackColor = Color.Peru;
                            price[k].Size = new Size(priceWidth, priceHeight);
                            price[k].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                            price[k].TextAlign = ContentAlignment.TopLeft;
                            // поиск акций //
                            if (P.stock != 0)
                            {
                                priceWow[k] = new Label();
                                priceWow[k].ForeColor = Color.DarkRed;
                                priceWow[k].BackColor = Color.Peru;
                                priceWow[k].Size = new Size(priceWidth, priceHeight-12);
                                priceWow[k].Font = new Font("Microsoft Sans Serif", 16, FontStyle.Strikeout);
                                priceWow[k].TextAlign = ContentAlignment.TopLeft;
                                priceWow[k].Text = "";
                                foreach (Stock stock in db.Stocks)
                                {
                                    if (stock.id == P.stock)
                                    {
                                        double ops = Math.Round(P.price - (P.price * (stock.discount / 100)), 2);
                                        price[k].Text = $"Цена: {ops} руб.";
                                        priceWow[k].Text = $"{P.price} руб. {stock.discount}%";
                                        // вывод объекта по следующим координатам //
                                        priceWow[k].Location = new Point(priceX, priceY-30);
                                        panel1.Controls.Add(priceWow[k]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                price[k].Text = $"Цена: {P.price} руб.";
                            }
                            if (P.number != 0)
                                price[k].Text += $"\nВ наличии: {P.number} ед.";
                            else
                                price[k].Text += $"\nНет в наличии:(";
                            // вывод объекта по следующим координатам //
                            price[k].Location = new Point(priceX, priceY);
                            panel1.Controls.Add(price[k]);
                            // переход к след координатам //
                            priceY += PictureBackgroundHeight + 30;

                            // имя, вид и производитель //
                            infoName[k] = new Label();
                            infoName[k].ForeColor = Color.Black;
                            infoName[k].BackColor = Color.White;
                            infoName[k].Size = new Size(infoNameWidth, infoNameHeight);
                            infoName[k].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                            infoName[k].TextAlign = ContentAlignment.TopLeft;
                            infoName[k].Text = $"Имя: {P.name}\n\nВид:\n{P.type}\n\nПроизводитель:\n{P.brend}";
                            // вывод объекта по следующим координатам //
                            infoName[k].Location = new Point(infoNameX, infoNameY);
                            panel1.Controls.Add(infoName[k]);
                            // переход к след координатам //
                            infoNameY += PictureBackgroundHeight + 30;

                            // картинка //
                            PictureBackgroundPath[k] = new PictureBox();
                            try
                            {
                                PictureBackgroundPath[k].Image = Image.FromFile(P.path);
                            }
                            catch { }
                            PictureBackgroundPath[k].SizeMode = PictureBoxSizeMode.StretchImage;
                            PictureBackgroundPath[k].Size = new Size(PictureBackgroundPathWidth, PictureBackgroundPathHeight);
                            PictureBackgroundPath[k].BackColor = Color.DarkRed;
                            // вывод объекта по следующим координатам //
                            PictureBackgroundPath[k].Location = new Point(PictureBackgroundPathX, PictureBackgroundPathY);
                            panel1.Controls.Add(PictureBackgroundPath[k]);
                            // переход к след координатам //
                            PictureBackgroundPathY += PictureBackgroundHeight + 30;

                            // фон основной инфы
                            PictureBackground[k] = new PictureBox();
                            PictureBackground[k].Size = new Size(PictureBackgroundWidth, PictureBackgroundHeight);
                            PictureBackground[k].BackColor = Color.RoyalBlue;
                            // вывод объекта по следующим координатам //
                            PictureBackground[k].Location = new Point(PictureBackgroundX, PictureBackgroundY);
                            panel1.Controls.Add(PictureBackground[k]);
                            // переход к след координатам //
                            PictureBackgroundY += PictureBackgroundHeight + 30;
                        }
                    }
                }
            }
        }

        // фильтр по поиску //
        private void filterTextProduct(int[] array, int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (array[j] != 0)
                {
                    string s = textBox1.Text.Trim();
                    foreach (Product P in db.Products)
                    {
                        if (P.id == array[j])
                        {
                            if (!P.name.Contains(s))
                                array[j] = 0;
                            break;
                        }
                    }
                }
            }
        }

        // проверка на отзывы //
        private void sortedMessageListProduct(int[] array, int i)
        {
            if (checkBox2.Checked == true)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] != 0)
                    {
                        foreach (Product P in db.Products.Include(M=>M.Messages))
                        {
                            if (array[j] == P.id)
                            {
                                int flag = 0;
                                foreach (Message M in P.Messages)
                                {
                                    flag = 1;
                                    break;
                                }
                                if (flag == 0)
                                    array[j] = 0;
                            }
                        }
                    }
                }
            }
        }

        // проверка на наличие //
        private void sortedNumListProduct(int[] array, int i)
        {
            if (checkBox1.Checked == true)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] != 0)
                    {
                        foreach (Product P in db.Products)
                        {
                            if (array[j] == P.id)
                            {
                                if (P.number == 0)
                                    array[j] = 0;
                            }
                        }
                    }
                }
            }
        }

        // проверка на скидку //
        private void sortedDiscontListProduct(int[] array, int i)
        {
            if (checkBox3.Checked == true)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] != 0)
                    {
                        foreach (Product P in db.Products)
                        {
                            if (array[j] == P.id)
                            {
                                if (P.stock == 0)
                                    array[j] = 0;
                            }
                        }
                    }
                }
            }
        }

        // сортировка по стоимости //
        private void sortedPriceListProduct(int[] array, int i)
        {
            for (int j = 0; j < i; j++)
            {
                if (array[j] != 0)
                {
                    foreach (Product P in db.Products)
                    {
                        if (array[j] == P.id)
                        {
                            double money = 0;
                            if (P.stock != 0)
                            {
                                foreach (Stock D in db.Stocks)
                                {
                                    if (D.id == P.stock)
                                    {
                                        money = P.price - (P.price / 100 * D.discount);
                                        break;
                                    }
                                }
                            }
                            if (money == 0)
                                money = P.price;
                            if (money < (int)numericUpDown1.Value || money > (int)numericUpDown2.Value)
                                array[j] = 0;
                            break;
                        }
                    }
                }
            }
        }

        // сортировка по производителю //
        private void sortedBrendListProduct(int[] array, int i)
        {
            if (comboBox3.Text != "Все производители")
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] != 0)
                    {
                        foreach (Product P in db.Products)
                        {
                            if (P.id == array[j])
                            {
                                if (P.brend != comboBox3.Text)
                                    array[j] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // сортировка по типу //
        private void sortedTypeListProduct(int[] array, int i)
        {
            if (comboBox2.Text != "Все виды")
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] != 0)
                    {
                        foreach (Product P in db.Products)
                        {
                            if (P.id == array[j])
                            {
                                if (P.type != comboBox2.Text)
                                    array[j] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // сортировка по умолчанию //
        private void sortedListProduct(int[] array, int i)
        {
            // заносив все id продуктов в массив //
            int k = 0;
            foreach (Product P in db.Products)
            {
                array[k] = P.id;
                k++;
            }

            // для сортировки //
            Product[] newList = new Product[i]; // массив объектов
            int num = 0; // для навигации по массиву
            foreach (Product P in db.Products)
            {
                newList[num] = P;
                num++;
            }

            // сортировка //
            if (comboBox1.Text == "Сначала дешевые")
            {
                // сортировка по возрастанию цены //
                for (int i1 = 0; i1 < i; i1++)
                {
                    for (int i2 = 0; i2 < i; i2++)
                    {
                        double price1 = 0;
                        double price2 = 0;

                        if (newList[i1].stock != 0) // проверка на скидку
                        {
                            foreach (Stock d in db.Stocks)
                            {
                                if (d.id == newList[i1].stock)
                                {
                                    price1 = newList[i1].price - (newList[i1].price / 100 * d.discount);
                                    break;
                                }
                            }
                        }
                        else
                            price1 = newList[i1].price;

                        if (newList[i2].stock != 0) // проверка на скидку
                        {
                            foreach (Stock d in db.Stocks)
                            {
                                if (d.id == newList[i2].stock)
                                {
                                    price2 = newList[i2].price - (newList[i2].price / 100 * d.discount);
                                    break;
                                }
                            }
                        }
                        else
                            price2 = newList[i2].price;

                        if (price1 < price2) // сортировка пузырьком
                        {
                            Product help = newList[i1];
                            newList[i1] = newList[i2];
                            newList[i2] = help;
                        }
                    }
                }
                // заносим id в массив айдишников //
                for (int j = 0; j < i; j++)
                    array[j] = newList[j].id;
            }

            if (comboBox1.Text == "Сначала дорогие")
            {
                // сортировка по возрастанию цены //
                for (int i1 = 0; i1 < i; i1++)
                {
                    for (int i2 = 0; i2 < i; i2++)
                    {
                        double price1 = 0;
                        double price2 = 0;

                        if (newList[i1].stock != 0) // проверка на скидку
                        {
                            foreach (Stock d in db.Stocks)
                            {
                                if (d.id == newList[i1].stock)
                                {
                                    price1 = newList[i1].price - (newList[i1].price / 100 * d.discount);
                                    break;
                                }
                            }
                        }
                        else
                            price1 = newList[i1].price;

                        if (newList[i2].stock != 0) // проверка на скидку
                        {
                            foreach (Stock d in db.Stocks)
                            {
                                if (d.id == newList[i2].stock)
                                {
                                    price2 = newList[i2].price - (newList[i2].price / 100 * d.discount);
                                    break;
                                }
                            }
                        }
                        else
                            price2 = newList[i2].price;

                        if (price1 > price2) // сортировка пузырьком
                        {
                            Product help = newList[i1];
                            newList[i1] = newList[i2];
                            newList[i2] = help;
                        }
                    }
                }
                // заносим id в массив айдишников //
                for (int j = 0; j < i; j++)
                    array[j] = newList[j].id;
            }

            if (comboBox1.Text == "По размеру скидки")
            {
                // сортировка по размеру скидки //
                for (int i1 = 0; i1 < i; i1++)
                {
                    for (int i2 = 0; i2 < i; i2++)
                    {
                        double price1 = 0;
                        double price2 = 0;

                        if (newList[i1].stock != 0) // проверка на скидку
                        {
                            foreach (Stock d in db.Stocks)
                            {
                                if (d.id == newList[i1].stock)
                                {
                                    price1 = newList[i1].price / 100 * d.discount;
                                    break;
                                }
                            }
                        }
                        else
                            price1 = 0;

                        if (newList[i2].stock != 0) // проверка на скидку
                        {
                            foreach (Stock d in db.Stocks)
                            {
                                if (d.id == newList[i2].stock)
                                {
                                    price2 = newList[i2].price / 100 * d.discount;
                                    break;
                                }
                            }
                        }
                        else
                            price2 = 0;

                        if (price1 > price2) // сортировка пузырьком
                        {
                            Product help = newList[i1];
                            newList[i1] = newList[i2];
                            newList[i2] = help;
                        }
                    }
                }
                // заносим id в массив айдишников //
                for (int j = 0; j < i; j++)
                    array[j] = newList[j].id;
            }

            if (comboBox1.Text == "По популярности") // по кол-во отзывам
            {
                for (int i1 = 0; i1 < i; i1++)
                {
                    for (int i2 = 0; i2 < i; i2++)
                    {
                        double score1 = 0;
                        double score2 = 0;
                        foreach (Message M in newList[i1].Messages)
                            score1++;
                        foreach (Message M in newList[i2].Messages)
                            score2++;

                        if (score1 > score2) // сортировка пузырьком
                        {
                            Product help = newList[i1];
                            newList[i1] = newList[i2];
                            newList[i2] = help;
                        }
                    }
                }
                // заносим id в массив айдишников //
                for (int j = 0; j < i; j++)
                    array[j] = newList[j].id;
            }
        }

        // функция вывода подсказки в поле для поиска //
        private void helpTextProductSearch()
        {
            textBox1.Text = "Что Вас интересует?"; // текст подсказки
            textBox1.ForeColor = Color.Gray; // цвет подсказки
        }

        // при нажатии на поле поиска для последующего ввода //
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.ForeColor == Color.Gray)
            {
                textBox1.Text = null; // содержимое становится пустым
                textBox1.ForeColor = Color.Black; // цвет текста черный
            }
        }

        // если форма для поиска перестает быть активной //
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                helpTextProductSearch();
        }

        // фильтры //
        private void iniz()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            comboBox1.Items.Add("По популярности");
            comboBox1.Items.Add("Сначала дорогие");
            comboBox1.Items.Add("Сначала дешевые");
            comboBox1.Items.Add("По размеру скидки");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Add("Все виды");
            comboBox2.SelectedIndex = 0;
            foreach (Product P in db.Products)
            {
                int flag = 0;
                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (comboBox2.Items[i].ToString() == P.type)
                        flag = 1;
                }
                if (flag == 0)
                    comboBox2.Items.Add(P.type);
            }

            comboBox3.Items.Add("Все производители");
            comboBox3.SelectedIndex = 0;
            foreach (Product P in db.Products)
            {
                int flag = 0;
                for (int i = 0; i < comboBox3.Items.Count; i++)
                {
                    if (comboBox3.Items[i].ToString() == P.brend)
                        flag = 1;
                }
                if (flag == 0)
                    comboBox3.Items.Add(P.brend);
            }

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 9999999;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        // сбросить //
        private void button6_Click(object sender, EventArgs e)
        {
            iniz();
            goProduct();
        }

        // адрес (тестовые данные) //
        private void label5_Click(object sender, EventArgs e)
        {
            test();
        }

        private void test()
        {
            
         
            db.SaveChanges();

            Bonus B = new Bonus()
            {
                name = "123",
                discount = 15,
            };
            db.Bonus.Add(B);
            db.SaveChanges();
                       db.SaveChanges();

            iniz();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Navy;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Peru;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Navy;
            button2.ForeColor = Color.White;  
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Peru;
            button2.ForeColor = Color.White;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Navy;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Peru;
            button3.ForeColor = Color.White;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Navy;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Peru;
            button4.ForeColor = Color.White;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.RoyalBlue;
            button5.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Moccasin;
            button5.ForeColor = Color.Black;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.RoyalBlue;
            button6.ForeColor = Color.White;         
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Moccasin;
            button6.ForeColor = Color.Black;       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            goProduct();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            goProduct();
        }

        // отзывы //
        private void button_Clicked(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            int idProduct = Convert.ToInt32(((System.Windows.Forms
                    .Button)sender).Name); // получаем айдишник выбранного продукта
            MessageProduct messageProduct = new MessageProduct(idProduct);
            messageProduct.ShowDialog();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            Button.BackColor = Color.RoyalBlue;
            Button.ForeColor = Color.White;
        }
        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            Button.BackColor = Color.Navy;
            Button.ForeColor = Color.White;          
        }
        
        // добавить в корзину //
        private void pictureBox_Clicked(object sender, EventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            int idProduct = Convert.ToInt32(((System.Windows.Forms
                    .PictureBox)sender).Name); // получаем айдишник выбранного продукта

            if (user == 0)
            {
                UserInput _user = new UserInput();
                _user.ShowDialog();
            }
            else
            {
                Buy buy = new Buy(idProduct);
                buy.ShowDialog();
            }
            userCheck();
        }
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            img.Image = Properties.Resources.КнопкаАктивна;
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox img = (PictureBox)sender;
            img.Image = Properties.Resources.Кнопка;
        }

        // о нас //
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсоая работа на тему: информационные технологии в сфере онлайн магазин электроники" +
                "\n\nВыполнил студент группы ИТ-202\nДаниил Сергеев", "Курсовая работа");
        }

        // вход в аккаунт //
        private void button2_Click(object sender, EventArgs e)
        {
            if (user != 0)
            {
                button2.Text = "Вход в аккаунт";
                user = 0;
            }
            else
            {
                UserInput _user = new UserInput();
                _user.ShowDialog();
                if (user != 0)
                {
                    button2.Text = "Выйти из аккаунт";
                }
            }
        }

        // проверка на вход //
        private void userCheck()
        {
            if (user == 0)
                button2.Text = "Вход в аккаунт";
            else
                button2.Text = "Выйти из аккаунт";
        }

        // моя корзина //
        private void button3_Click(object sender, EventArgs e)
        {
            if (user == 0)
            {
                UserInput _user = new UserInput();
                _user.ShowDialog();
            }
            else
            {
                ProfileAndBuyer profileAndBuyer = new ProfileAndBuyer();
                profileAndBuyer.ShowDialog();
            }
        }

        // меню админа //
        private void button4_Click(object sender, EventArgs e)
        {
            AdminOpen adminOpen = new AdminOpen();
            adminOpen.ShowDialog();
            iniz();
            goProduct();
        }
    }
}
