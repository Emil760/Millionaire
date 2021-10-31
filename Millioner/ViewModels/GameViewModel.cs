using Millioner.Models;
using Millioner.Utilities;
using Millioner.Views;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Millioner.ViewModels
{
    class GameViewModel : ObserableObject
    {
        private User user;
        private Window game_window;
        private Timer timer;
        private MediaPlayer player;

        private Task[] tasks;
        private ObservableCollection<Money> moneys;
        private ObservableCollection<BtnAnswer> questions;

        private Money current_money;
        private Money non_fire_number;
        private bool money_is_enabled;
        private bool take_money_is_enabled;
        private int complexity;

        private ObservableCollection<BtnAnswer> answers;
        private string question;
        private BtnAnswer answer;

        private Tips phone_tip;
        private Tips people_tip;
        private Tips x2_tip;
        private Tips fifty_fifty_tip;

        private bool x2_used;

        public GameViewModel(Window window, User user)
        {
            game_window = window;
            game_window.Closed += GameWindow_Closed;
            this.user = user;

            GiveAnswerCommand = new Command(GiveAnswer);
            FireNumberChangedCommand = new Command(FireNumberChanged);
            TakeMoneyCommand = new Command(TakeMoney);
            PeopleTipCommand = new Command(UsePeopleTip);
            PhoneTipCommand = new Command(UsePhoneTip);
            X2TipCommand = new Command(UseX2Tip);
            FiftyFiftyCommand = new Command(UseFiftyFifty);

            Answers = new ObservableCollection<BtnAnswer>();
            answers.Add(new BtnAnswer(Stat.Disabled));
            answers.Add(new BtnAnswer(Stat.Disabled));
            answers.Add(new BtnAnswer(Stat.Disabled));
            answers.Add(new BtnAnswer(Stat.Disabled));

            PeopleTip = new Tips();
            PhoneTip = new Tips();
            X2Tip = new Tips();
            FiftyFiftyTip = new Tips();

            MoneyIsEnabled = false;
            complexity = 0;

            tasks = Task.GetRandomGuestions();

            timer = new Timer(13000);
            timer.Elapsed += StarGameTimer;
            timer.Start();

            player = new MediaPlayer();
            player.Open(new Uri("Resources\\musics\\hello.wav", UriKind.Relative));
            player.Play();
        }

        public ICommand GiveAnswerCommand { get; }
        public ICommand FireNumberChangedCommand { get; }
        public ICommand TakeMoneyCommand { get; }
        public ICommand PhoneTipCommand { get; }
        public ICommand PeopleTipCommand { get; }
        public ICommand X2TipCommand { get; }
        public ICommand FiftyFiftyCommand { get; }

        public ObservableCollection<BtnAnswer> Questions { get => questions; set => Set(ref questions, value); }
        public ObservableCollection<Money> Moneys { get => moneys; set => Set(ref moneys, value); }

        public Money CurrentMoney { get => current_money; set => Set(ref current_money, value); }
        public Money NonFireNumber { get => non_fire_number; set => Set(ref non_fire_number, value); }
        public bool MoneyIsEnabled { get => money_is_enabled; set => Set(ref money_is_enabled, value); }
        public bool TakeMoneyIsEnabled { get => take_money_is_enabled; set => Set(ref take_money_is_enabled, value); }

        public ObservableCollection<BtnAnswer> Answers { get => answers; set => Set(ref answers, value); }
        public string Question { get => question; set => Set(ref question, value); }

        public Tips FiftyFiftyTip { get => fifty_fifty_tip; set => Set(ref fifty_fifty_tip, value); }
        public Tips X2Tip { get => x2_tip; set => Set(ref x2_tip, value); }
        public Tips PeopleTip { get => people_tip; set => Set(ref people_tip, value); }
        public Tips PhoneTip { get => phone_tip; set => Set(ref phone_tip, value); }

        private void StarGameTimer(object sender, ElapsedEventArgs e)
        {
            MoneyIsEnabled = true;
            timer.Elapsed -= StarGameTimer;
            timer.Stop();
            player.Dispatcher.Invoke(() =>
            {
                player.Stop();
            });
            MessageBox.Show("Select non fire number", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            Moneys = new ObservableCollection<Money>();
            Moneys.Add(new Money(1000000));
            Moneys.Add(new Money(500000));
            Moneys.Add(new Money(250000));
            Moneys.Add(new Money(100000));
            Moneys.Add(new Money(50000));
            Moneys.Add(new Money(25000));
            Moneys.Add(new Money(12500));
            Moneys.Add(new Money(10000));
            Moneys.Add(new Money(5000));
            Moneys.Add(new Money(2000));
            Moneys.Add(new Money(1000));
            Moneys.Add(new Money(500));
            Moneys.Add(new Money(300));
            Moneys.Add(new Money(200));
            Moneys.Add(new Money(100));
        }

        private void GiveAnswer(object param)
        {
            answer = (BtnAnswer)param;

            timer.Elapsed += CheckAnswerTimer;
            timer.Interval = 2000;
            timer.Start();

            AnswersChangeStat(Stat.Disabled);
            answer.Stat = Stat.Wait;
            TipsChangeState(false);
            TakeMoneyIsEnabled = false;
        }

        private void CheckAnswerTimer(object sender, ElapsedEventArgs e)
        {
            timer.Elapsed -= CheckAnswerTimer;
            timer.Stop();
            if (answer.Variant == tasks[complexity - 1].Answer1)
            {
                CorrectAnswerMusic();
                answer.Stat = Stat.Correct;
                if (complexity == 15) GameOver();
                else
                {
                    x2_used = false;
                    timer.Elapsed += NextQuestionTimer;
                }
            }
            else if (x2_used)
            {
                x2_used = false;
                timer.Elapsed += ReTryTimer;
            }
            else
            {
                WrongAnswerMusic();
                answer.Stat = Stat.Wrong;
                timer.Elapsed += GameOverTimer;
            }
            timer.Start();
        }

        private void FireNumberChanged(object param)
        {
            CurrentMoney.IsNonFire = true;
            NonFireNumber = CurrentMoney;
            MoneyIsEnabled = false;
            (FireNumberChangedCommand as Command).Clear();
            PrepareQuestion();
        }

        private void NextQuestionTimer(object sender, ElapsedEventArgs e)
        {
            timer.Elapsed -= NextQuestionTimer;
            timer.Stop();
            player.Dispatcher.Invoke(() =>
            {
                player.Stop();
            });
            PrepareQuestion();
            TakeMoneyIsEnabled = true;
        }

        private void ReTryTimer(object sender, ElapsedEventArgs e)
        {
            timer.Elapsed -= ReTryTimer;
            timer.Stop();
            player.Dispatcher.Invoke(() =>
            {
                player.Stop();
            });
            TipsChangeState(true);
            AnswersChangeStat(Stat.Enabled);
            answer.Stat = Stat.Clicked;
            TakeMoneyIsEnabled = true;
        }

        private void GameOverTimer(object sender, ElapsedEventArgs e)
        {
            timer.Elapsed -= GameOverTimer;
            timer.Stop();
            GameOver();
        }

        private void PrepareQuestion()
        {
            complexity++;
            CurrentMoney = Moneys[Moneys.Count - complexity];

            string[] temp = tasks[complexity - 1].MeshUp();
            Question = tasks[complexity - 1].Question;
            TipsChangeState(true);

            for (int i = 0; i < answers.Count; i++)
            {
                Answers[i].Variant = temp[i];
                Answers[i].Stat = Stat.Enabled;
            }
        }

        private void UseFiftyFifty(object param)
        {
            string[] str = new string[4];
            for (int i = 0; i < answers.Count; i++)
                if (answers[i].Stat != Stat.Clicked)
                    str[i] = answers[i].Variant;

            int[] num = Tips.FiftyFifty(tasks[complexity - 1].Answer1, str);
            answers[num[0]].Stat = Stat.Clicked;
            answers[num[1]].Stat = Stat.Clicked;
            player.Open(new Uri("Resources\\musics\\50_50.wav", UriKind.Relative));
            player.Play();

            FiftyFiftyTip.CanUse = false;
        }

        private void UseX2Tip(object param)
        {
            x2_used = true;
            X2Tip.CanUse = false;
        }

        private void UsePeopleTip(object param)
        {
            int correct = 0;
            for (int i = 0; i < answers.Count; i++)
                if (answers[i].Variant == tasks[complexity - 1].Answer1)
                    correct = i;
            player.Open(new Uri("Resources\\musics\\aud_voting.wav", UriKind.Relative));
            player.Play();
            PeopleTipWindow window = new PeopleTipWindow();
            window.DataContext = new PeopleTipViewModel(correct, complexity);
            window.ShowDialog();
            player.Stop();
            PeopleTip.CanUse = false;
        }

        private void UsePhoneTip(object param)
        {
            PhoneTip.CanUse = false;
            int correct = 0;
            int[] nums = new int[] { -1, -1, -1, -1 };
            for (int i = 0; i < nums.Length; i++)
            {
                if (answers[i].Stat != Stat.Clicked) nums[i] = i;
                if (answers[i].Variant == tasks[complexity - 1].Answer1) correct = i;
            }
            correct = Tips.Phone(correct, complexity, nums);
            player.Open(new Uri("Resources\\musics\\friend_clock.wav", UriKind.Relative));
            player.Play();
            MessageBox.Show($"You friend says: {answers[correct].Variant}");
            player.Stop();
        }

        private void GameOver()
        {
            if (CurrentMoney.Price > NonFireNumber.Price)
            {
                if (complexity == 15)
                {
                    user.AddGame(complexity, moneys[moneys.Count - complexity + 1].Price);
                    MessageBox.Show($"You are a millioner!!!");
                }
                else
                {
                    user.AddGame(complexity - 1, moneys[moneys.Count - complexity + 1].Price);
                    MessageBox.Show($"You win: {NonFireNumber.Price}");
                }
            }
            else
            {
                user.AddGame(complexity - 1);
                MessageBox.Show($"You lost: :(");
            }
            game_window.Dispatcher.Invoke(() =>
            {
                game_window.Close();
            });
        }

        private void TipsChangeState(bool is_enabled)
        {
            PeopleTip.IsEnabled = is_enabled;
            PhoneTip.IsEnabled = is_enabled;
            X2Tip.IsEnabled = is_enabled;
            FiftyFiftyTip.IsEnabled = is_enabled;
        }

        private void AnswersChangeStat(Stat stat)
        {
            for (int i = 0; i < answers.Count; i++)
                answers[i].Stat = stat;
        }

        private void CorrectAnswerMusic()
        {
            if (complexity >= 10)
            {
                player.Dispatcher.Invoke(() =>
                {
                    player.Open(new Uri("Resources\\musics\\10correct.wav", UriKind.Relative));
                    player.Play();
                    timer.Interval = 5000;
                });
            }
            else if (complexity >= 5)
            {
                player.Dispatcher.Invoke(() =>
                {
                    player.Open(new Uri("Resources\\musics\\6correct.wav", UriKind.Relative));
                    player.Play();
                    timer.Interval = 3000;
                });
            }
            else
            {
                player.Dispatcher.Invoke(() =>
                {
                    player.Open(new Uri("Resources\\musics\\1correct.wav", UriKind.Relative));
                    player.Play();
                    timer.Interval = 1000;
                });
            }
        }

        private void WrongAnswerMusic()
        {
            if (complexity >= 10)
            {
                player.Dispatcher.Invoke(() =>
                {
                    player.Open(new Uri("Resources\\musics\\10wrong.wav", UriKind.Relative));
                    timer.Interval = 5000;
                    player.Play();
                });
            }
            else if (complexity >= 5)
            {
                player.Dispatcher.Invoke(() =>
                {
                    player.Open(new Uri("Resources\\musics\\6wrong.wav", UriKind.Relative));
                    timer.Interval = 3000;
                    player.Play();
                });
            }
            else
            {
                player.Dispatcher.Invoke(() =>
                {
                    player.Open(new Uri("Resources\\musics\\1wrong.wav", UriKind.Relative));
                    timer.Interval = 1000;
                    player.Play();
                });
            }
        }

        private void TakeMoney(object param)
        {
            MessageBox.Show($"You win: {moneys[moneys.Count - complexity + 1].Price}");
            user.AddGame(complexity - 1, moneys[moneys.Count - complexity + 1].Price);
            game_window.Close();
        }

        private void GameWindow_Closed(object sender, EventArgs e)
        {
            timer.Stop();
            player.Dispatcher.Invoke(() =>
            {
                player.Stop();
            });
        }

    }
}
