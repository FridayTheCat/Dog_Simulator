using System;

namespace Luna_s_Simulator
{
    public class GameEngine
    {
        //Показатели
        public int Money { get; private set; } = 100;
        public int Monge { get; private set; } = 20;
        public int Food { get; private set; } = 100;
        public int Happy { get; private set; } = 100 ;
        public int PeeAndPoop { get; private set; } = 0;

        //Рандом
        private readonly Random _Random = new Random();

        //Walker
        private int _TimerForWalk = 0;
        private bool _Walker = false;

        //Worker
        private int _WorkerMin = 0;
        private int _WorkerMax = 0;

        //Buyer
        private int _Buyer = 0;
        private int _BuyerPay = 0;

        //Feeder
        private int _Feeder = 0;
        private int _FeederWaste = 0;

        //Player
        private int _Player = 0;

        //Добывание денег
        public void Work() => Money += _Random.Next(10, 21);

        //Покупка корма
        public void BuyMonge()
        {
            Money -= 30;
            Monge += 30;
        }

        //Проверка достаточности денег для отображения кнопки
        public bool ChekMoney() => Money > 30;

        //Расход корма для заполнения сытости
        public void Feed()
        {
            Food += 10;

            if (Food > 100)
                Food = 100;

            Monge -= 10;
        }

        //Проверка наличия корма для отображения кнопки
        public bool ChekMonge() => Monge >= 10;

        //Повышение радости
        public void Play()
        {
            Happy += 10;

            if (Happy > 100)
                Happy = 100;
        }

        //Выгул собаки
        public void Walk() => PeeAndPoop = 0;

        //Основной метод жизни
        public void Live()
        {
            //Убывающие показатели за тик таймера
            Food -= 4;
            Happy -= 3;
            PeeAndPoop += 5;

            //Если есть Worker - получение денег
            Money += _Random.Next(_WorkerMin, _WorkerMax);

            //Покупка корма, если достаточно денег
            if (Money >= _BuyerPay)
            {
                Money -= _BuyerPay;
                Monge += _Buyer;
            }

            //Кормление, если достаточно корма
            if (Monge >= _FeederWaste)
            {
                Monge -= _FeederWaste;
                Food += _Feeder;
            }

            //Если есть Player - повышение счастья
            Happy += _Player;

            //Если есть Walker - выгул
            if (_Walker)
            {
                _TimerForWalk++;
                if (_TimerForWalk % 19 == 0)
                    PeeAndPoop = 0;
            }
            if (Food >= 100)
                Food = 100;

            //Границы шкал
            if (Happy >= 100)
                Happy = 100;

            if (PeeAndPoop <= 0)
                PeeAndPoop = 0;

            if (Food <= 0)
                Food = 0;

            if (Happy <= 0)
                Happy = 0;

            if (PeeAndPoop >= 100)
                PeeAndPoop = 100;
        }

        //Покупка Worker
        public void BuyWorker(int cost)
        {
            Money -= cost;
            switch (cost)
            {
                case 100:
                    _WorkerMin = 1;
                    _WorkerMax = 11;
                    break;
                case 200:
                    _WorkerMin = 10;
                    _WorkerMax = 16;
                    break;
                case 300:
                    _WorkerMin = 15;
                    _WorkerMax = 26;
                    break;
            }
        }

        //Покупка Buyer
        public void BuyBuyer(int cost)
        {
            Money -= cost;
            switch (cost)
            {
                case 100:
                    _Buyer = 5;
                    _BuyerPay = 5;
                    break;
                case 200:
                    _Buyer = 10;
                    _BuyerPay = 10;
                    break;
                case 300:
                    _Buyer = 15;
                    _BuyerPay = 15;
                    break;
            }
        }

        //Покупка Feeder
        public void BuyFeeder(int cost)
        {
            Money -= cost;
            switch (cost)
            {
                case 100:
                    _Feeder = 3;
                    _FeederWaste = 3;
                    break;
                case 200:
                    _Feeder = 6;
                    _FeederWaste = 6;
                    break;
                case 300:
                    _Feeder = 9;
                    _FeederWaste = 9;
                    break;
            }
        }

        //Покупка Player
        public void BuyPlayer(int cost)
        {
            Money -= cost;
            switch (cost)
            {
                case 100:
                    _Player = 3;
                    break;
                case 200:
                    _Player = 6;
                    break;
                case 300:
                    _Player = 9;
                    break;
            }
        }

        //Покупка Walker
        public void BuyWalker(int cost)
        {
            Money -= cost;
            _Walker = true;
        }

        //Проверка наличия денег на улучшений для отображения кнопок
        public bool HaveMoneyForV1() => Money >= 100;
        public bool HaveMoneyForV2() => Money >= 200;
        public bool HaveMoneyForV3() => Money >= 300;
        public bool HaveMoneyForWalker() => Money >= 500;

        //Проверка условия победы
        public bool CheckWin() => (_WorkerMax == 26 && _Buyer == 15 && _Feeder == 9 && _Player == 9 && _Walker
            && Food >= 80 && Happy >= 80 && PeeAndPoop <= 30);

        //Проверка условия поражения
        public bool CheckLoose() => (Food <= 0 || Happy <= 0 || PeeAndPoop >= 100);

        //Рандомизация скорости игры
        public int RandomizeSpeed() => _Random.Next(400, 1201);
    }
}
