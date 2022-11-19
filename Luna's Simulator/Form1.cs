using System;
using System.Drawing;
using System.Windows.Forms;

namespace Luna_s_Simulator
{
    public partial class Form1 : Form
    {
        //Инициализация движка
        GameEngine gameEngine = new GameEngine();

        //Переменная для вывода времени игры
        uint lifeTime = 0;

        public Form1()
        {
            InitializeComponent();

            //Маштабирование контента на экране
            float scaleX = ((float)Screen.PrimaryScreen.WorkingArea.Width / 1386);
            float scaleY = ((float)Screen.PrimaryScreen.WorkingArea.Height / 788);
            SizeF aSf = new SizeF(scaleX, scaleY);
            this.Scale(aSf);

            pictureBox1.Image = Form2.LunaBasic;
        }

        //Кнопки
        private void bStart_Click(object sender, EventArgs e) => StartGame();
        private void bPause_Click(object sender, EventArgs e) => PauseGame();
        private void bReset_Click(object sender, EventArgs e) => ResetGame();

        //Настройка UI при старте и старт таймеров
        private void StartGame()
        {
            bStart.Enabled = false;
            bPause.Enabled = true;
            bReset.Enabled = false;
            bGoToWork.Enabled = true;
            bBuyMonge.Enabled = true;
            bFeed.Enabled = true;
            bPlay.Enabled = true;
            bWalk.Enabled = true;

            bWorker1.Enabled = true;
            bBuyer1.Enabled = true;
            bFeeder1.Enabled = true;
            bPlayer1.Enabled = true;
            bWalker.Enabled = true;

            bWorker2.Enabled = true;
            bBuyer2.Enabled = true;
            bFeeder2.Enabled = true;
            bPlayer2.Enabled = true;

            bWorker3.Enabled = true;
            bBuyer3.Enabled = true;
            bFeeder3.Enabled = true;
            bPlayer3.Enabled = true;

            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        //Настройка UI при паузе и стоп таймеров
        private void PauseGame()
        {
            bStart.Enabled = true;
            bPause.Enabled = false;
            bReset.Enabled = true;
            bGoToWork.Enabled = false;
            bBuyMonge.Enabled = false;
            bFeed.Enabled = false;
            bPlay.Enabled = false;
            bWalk.Enabled = false;

            bWorker1.Enabled = false;
            bBuyer1.Enabled = false;
            bFeeder1.Enabled = false;
            bPlayer1.Enabled = false;
            bWalker.Enabled = false;

            bWorker2.Enabled = false;
            bBuyer2.Enabled = false;
            bFeeder2.Enabled = false;
            bPlayer2.Enabled = false;

            bWorker3.Enabled = false;
            bBuyer3.Enabled = false;
            bFeeder3.Enabled = false;
            bPlayer3.Enabled = false;

            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }

        //Настройка UI при ресете и сам ресет
        private void ResetGame()
        {
            bStart.Enabled = true;
            bPause.Enabled = false;
            bReset.Enabled = false;

            bWorker1.Visible = true;
            tbCostWorker1.Visible = true;
            tbWorker1.Visible = true;
                bWorker2.Visible = false;
                tbCostWorker2.Visible = false;
                tbWorker2.Visible = false;
                    bWorker3.Visible = false;
                    tbCostWorker3.Visible = false;
                    tbWorker3.Visible = false;

            bBuyer1.Visible = true;
            tbCostBuyer1.Visible = true;
            tbBuyer1_1.Visible = true;
            tbBuyer1_2.Visible = true;
                bBuyer2.Visible = false;
                tbCostBuyer2.Visible = false;
                tbBuyer2_1.Visible = false;
                tbBuyer2_2.Visible = false;
                    bBuyer3.Visible = false;
                    tbCostBuyer3.Visible = false;
                    tbBuyer3_1.Visible = false;
                    tbBuyer3_2.Visible = false;

            bFeeder1.Visible = true;
            tbCostFeeder1.Visible = true;
            tbFeeder1.Visible = true;
                bFeeder2.Visible = false;
                tbCostFeeder2.Visible = false;
                tbFeeder2.Visible = false;
                    bFeeder3.Visible = false;
                    tbCostFeeder3.Visible = false;
                    tbFeeder3.Visible = false;

            bPlayer1.Visible = true;
            tbCostPlayer1.Visible = true;
            tbPlayer1.Visible = true;
                bPlayer2.Visible = false;
                tbCostPlayer2.Visible = false;
                tbPlayer2.Visible = false;
                    bPlayer3.Visible = false;
                    tbCostPlayer3.Visible = false;
                    tbPlayer3.Visible = false;

            bWalker.Visible = true;
            tbCostWalker.Visible = true;
            tbWalker.Visible = true;

            tbNowWorker.Text = "Worker: None";
            tbNowBuyer_1.Text = "None";
            tbNowBuyer_2.Text = "None";
            tbNowFeeder.Text = "Feeder: None";
            tbNowPlayer.Text = "Player: None";
            tbNowWalker.Text = "Walker: None";

            pbFeeded.Value = 100;
            pbHappy.Value = 100;
            pbPeeAndPoop.Value = 0;

            pbPeeAndPoop.ChangeColor(Brushes.Green);
            pbHappy.ChangeColor(Brushes.Green);
            pbFeeded.ChangeColor(Brushes.Green);

            pictureBox1.Image = Form2.LunaBasic;

            tbMoney.Text = $"Money - 100$";
            tbMonge.Text = $"Monge - 20";
            tbFeeded.Text = $"Feeded - 100%";
            tbHappy.Text = $"Happy - 100%";
            tbPeeAndPoop.Text = $"Need to Pee&Poop - 0%";

            lifeTime = 0;
            timer1.Interval = 1000;

            gameEngine = new GameEngine();
        }

        //Основной таймер и его рандомизация каждые 5 секунд
        private void timer1_Tick(object sender, EventArgs e)
        {
            gameEngine.Live();
            if (lifeTime % 5 == 0)
            timer1.Interval = gameEngine.RandomizeSpeed();
        }

        //Кнопки действий
        private void bGoToWork_Click(object sender, EventArgs e) => gameEngine.Work();

        private void bBuyMonge_Click(object sender, EventArgs e) => gameEngine.BuyMonge();

        private void bFeed_Click(object sender, EventArgs e) => gameEngine.Feed();

        private void bPlay_Click(object sender, EventArgs e) => gameEngine.Play();

        private void bWalk_Click(object sender, EventArgs e) => gameEngine.Walk();

        //Фоновый фиксированный таймер отображения UI и проверки условий победы и поражения
        private void timer2_Tick(object sender, EventArgs e)
        {
            //Обновление UI
            tbMoney.Text = $"Money - {gameEngine.Money}$";
            tbMonge.Text = $"Monge - {gameEngine.Monge}";
            tbFeeded.Text = $"Feeded - {gameEngine.Food}%";
            tbHappy.Text = $"Happy - {gameEngine.Happy}%";
            tbPeeAndPoop.Text = $"Need to Pee&Poop - {gameEngine.PeeAndPoop}%";

            bBuyMonge.Enabled = gameEngine.ChekMoney();
            bFeed.Enabled = gameEngine.ChekMonge();

            pbFeeded.Value = gameEngine.Food;
            pbHappy.Value = gameEngine.Happy;
            pbPeeAndPoop.Value = gameEngine.PeeAndPoop;

            bWorker1.Enabled = gameEngine.HaveMoneyForV1();
            bWorker2.Enabled = gameEngine.HaveMoneyForV2();
            bWorker3.Enabled = gameEngine.HaveMoneyForV3();

            bBuyer1.Enabled = gameEngine.HaveMoneyForV1();
            bBuyer2.Enabled = gameEngine.HaveMoneyForV2();
            bBuyer3.Enabled = gameEngine.HaveMoneyForV3();

            bFeeder1.Enabled = gameEngine.HaveMoneyForV1();
            bFeeder2.Enabled = gameEngine.HaveMoneyForV2();
            bFeeder3.Enabled = gameEngine.HaveMoneyForV3();

            bPlayer1.Enabled = gameEngine.HaveMoneyForV1();
            bPlayer2.Enabled = gameEngine.HaveMoneyForV2();
            bPlayer3.Enabled = gameEngine.HaveMoneyForV3();

            bWalker.Enabled = gameEngine.HaveMoneyForWalker();

            //Изменение цвета прогресс бара в зависимости от показателей собаки
            if (gameEngine.Food <= 21)
                pbFeeded.ChangeColor(Brushes.Red);
            if (gameEngine.Food > 20 && gameEngine.Food <= 50)
                pbFeeded.ChangeColor(Brushes.Yellow);
            if (gameEngine.Food > 50)
                pbFeeded.ChangeColor(Brushes.Green);

            if (gameEngine.Happy <= 20)
                pbHappy.ChangeColor(Brushes.Red);
            if (gameEngine.Happy > 20 && gameEngine.Happy <= 50)
                pbHappy.ChangeColor(Brushes.Yellow);
            if (gameEngine.Happy > 50)
                pbHappy.ChangeColor(Brushes.Green);

            if (gameEngine.PeeAndPoop >= 80)
                pbPeeAndPoop.ChangeColor(Brushes.Red);
            if (gameEngine.PeeAndPoop < 80 && gameEngine.PeeAndPoop >= 50)
                pbPeeAndPoop.ChangeColor(Brushes.Yellow);
            if (gameEngine.PeeAndPoop < 50)
                pbPeeAndPoop.ChangeColor(Brushes.Green);

            //Изменение фотографии собаки в зависимости от её показателей
            if (gameEngine.Food > 50 && gameEngine.Happy > 50 && gameEngine.PeeAndPoop < 50)
                pictureBox1.Image = Form2.LunaBasic;
            if ((gameEngine.Food <= 50 && gameEngine.Food > 20) || (gameEngine.Happy <= 50 && gameEngine.Happy > 20) || (gameEngine.PeeAndPoop >= 50 && gameEngine.PeeAndPoop < 80))
                pictureBox1.Image = Form2.LunaYellow;
            if (gameEngine.Food <= 20 || gameEngine.Happy <= 20 || gameEngine.PeeAndPoop >= 80)
                pictureBox1.Image = Form2.LunaAngry;
            
            //Проверка условия победы
            if (gameEngine.CheckWin())
            {
                PauseGame();
                bStart.Enabled = false;
                pictureBox1.Image = Form2.LunaWin;
                MessageBox.Show($"Луна стала самой счастливой собакой!\nВы выиграли за {lifeTime} секунд.");
            }

            //Проверка условия поражения
            if (gameEngine.CheckLoose())
            {
                PauseGame();
                bStart.Enabled = false;
                pictureBox1.Image = Form2.LunaLose;
                MessageBox.Show($"Луна расстроилась и обиделась на Вас!\nВы проиграли за {lifeTime} секунд.");
            }
        }

        //Кнопки покупки улучшений
        private void bWorker1_Click(object sender, EventArgs e)
        {
            gameEngine.BuyWorker(100);
            bWorker1.Visible = false;
            tbWorker1.Visible = false;
            tbCostWorker1.Visible = false;
            bWorker2.Visible = true;
            tbWorker2.Visible = true;
            tbCostWorker2.Visible = true;

            tbNowWorker.Text = $"Worker: {tbWorker1.Text}";
        }

        private void bWorker2_Click(object sender, EventArgs e)
        {
            gameEngine.BuyWorker(200);
            bWorker2.Visible = false;
            tbWorker2.Visible = false;
            tbCostWorker2.Visible = false;
            bWorker3.Visible = true;
            tbWorker3.Visible = true;
            tbCostWorker3.Visible = true;

            tbNowWorker.Text = $"Worker: {tbWorker2.Text}";
        }

        private void bWorker3_Click(object sender, EventArgs e)
        {
            gameEngine.BuyWorker(300);
            bWorker3.Visible = false;
            tbWorker3.Visible = false;
            tbCostWorker3.Visible = false;

            tbNowWorker.Text = $"Worker: {tbWorker3.Text}";
        }

        private void bBuyer1_Click(object sender, EventArgs e)
        {
            gameEngine.BuyBuyer(100);
            bBuyer1.Visible = false;
            tbBuyer1_1.Visible = false;
            tbBuyer1_2.Visible = false;
            tbCostBuyer1.Visible = false;
            bBuyer2.Visible = true;
            tbBuyer2_1.Visible = true;
            tbBuyer2_2.Visible = true;
            tbCostBuyer2.Visible = true;

            tbNowBuyer_1.Text = $"{tbBuyer1_1.Text}";
            tbNowBuyer_2.Text = $"{tbBuyer1_2.Text}";
        }

        private void bBuyer2_Click(object sender, EventArgs e)
        {
            gameEngine.BuyBuyer(200);
            bBuyer2.Visible = false;
            tbBuyer2_1.Visible = false;
            tbBuyer2_2.Visible = false;
            tbCostBuyer2.Visible = false;
            bBuyer3.Visible = true;
            tbBuyer3_1.Visible = true;
            tbBuyer3_2.Visible = true;
            tbCostBuyer3.Visible = true;

            tbNowBuyer_1.Text = $"{tbBuyer2_1.Text}";
            tbNowBuyer_2.Text = $"{tbBuyer2_2.Text}";
        }

        private void bBuyer3_Click(object sender, EventArgs e)
        {
            gameEngine.BuyBuyer(300);
            bBuyer3.Visible = false;
            tbBuyer3_1.Visible = false;
            tbBuyer3_2.Visible = false;
            tbCostBuyer3.Visible = false;

            tbNowBuyer_1.Text = $"{tbBuyer3_1.Text}";
            tbNowBuyer_2.Text = $"{tbBuyer3_2.Text}";
        }

        private void bFeeder1_Click(object sender, EventArgs e)
        {
            gameEngine.BuyFeeder(100);
            bFeeder1.Visible = false;
            tbFeeder1.Visible = false;
            tbCostFeeder1.Visible = false;
            bFeeder2.Visible = true;
            tbFeeder2.Visible = true;
            tbCostFeeder2.Visible = true;

            tbNowFeeder.Text = $"Feeder: {tbFeeder1.Text}";
        }

        private void bFeeder2_Click(object sender, EventArgs e)
        {
            gameEngine.BuyFeeder(200);
            bFeeder2.Visible = false;
            tbFeeder2.Visible = false;
            tbCostFeeder2.Visible = false;
            bFeeder3.Visible = true;
            tbFeeder3.Visible = true;
            tbCostFeeder3.Visible = true;

            tbNowFeeder.Text = $"Feeder: {tbFeeder2.Text}";
        }

        private void bFeeder3_Click(object sender, EventArgs e)
        {
            gameEngine.BuyFeeder(300);
            bFeeder3.Visible = false;
            tbFeeder3.Visible = false;
            tbCostFeeder3.Visible = false;

            tbNowFeeder.Text = $"Feeder: {tbFeeder3.Text}";
        }

        private void bPlayer1_Click(object sender, EventArgs e)
        {
            gameEngine.BuyPlayer(100);
            bPlayer1.Visible = false;
            tbPlayer1.Visible = false;
            tbCostPlayer1.Visible = false;
            bPlayer2.Visible = true;
            tbPlayer2.Visible = true;
            tbCostPlayer2.Visible = true;

            tbNowPlayer.Text = $"Player: {tbPlayer1.Text}";
        }

        private void bPlayer2_Click(object sender, EventArgs e)
        {
            gameEngine.BuyPlayer(200);
            bPlayer2.Visible = false;
            tbPlayer2.Visible = false;
            tbCostPlayer2.Visible = false;
            bPlayer3.Visible = true;
            tbPlayer3.Visible = true;
            tbCostPlayer3.Visible = true;

            tbNowPlayer.Text = $"Player: {tbPlayer2.Text}";
        }

        private void bPlayer3_Click(object sender, EventArgs e)
        {
            gameEngine.BuyPlayer(300);
            bPlayer3.Visible = false;
            tbPlayer3.Visible = false;
            tbCostPlayer3.Visible = false;

            tbNowPlayer.Text = $"Player: {tbPlayer3.Text}";
        }

        private void bWalker_Click(object sender, EventArgs e)
        {
            gameEngine.BuyWalker(500);
            bWalker.Visible = false;
            tbWalker.Visible = false;
            tbCostWalker.Visible = false;

            tbNowWalker.Text = $"Walker: {tbWalker.Text}";
        }

        //Фоновый таймер с интервалом в 1 секунду для отображения времени на конечном MessageBox
        private void timer3_Tick(object sender, EventArgs e)
        {
            lifeTime += 1;
        }
    }
}
