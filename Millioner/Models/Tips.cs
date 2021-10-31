using Millioner.Utilities;
using System;

namespace Millioner.Models
{
    class Tips : ObserableObject
    {
        private bool is_enabled;
        private bool can_use;

        public Tips()
        {
            IsEnabled = false;
            CanUse = true;
        }

        public bool IsEnabled { get => is_enabled; set => Set(ref is_enabled, value); }
        public bool CanUse { get => can_use; set => Set(ref can_use, value); }

        public static int[] FiftyFifty(string answer, string[] answers)
        {
            Random random = new Random();
            int[] nums = new int[2] { -1, -1 };
            int num;
            for (int i = 0; i < 2; i++)
            {
                while (true)
                {
                    num = random.Next(0, 4);
                    if (answers[num] != null && answer != answers[num] && nums[0] != num)
                    {
                        nums[i] = num;
                        break;
                    }
                }
            }
            return nums;
        }

        public static int Phone(int correct, int complexity, int[] answers)
        {
            Random random = new Random();
            int min, max;
            min = correct;
            if (complexity >= 10) max = 2 + min;
            else if (complexity >= 5) max = 1 + min;
            else return correct;

            if (random.Next(min, max) == correct) return correct;
            else
            {
                do
                {
                    correct = random.Next(0, 4);
                } while (answers[correct] != -1);
                return correct;
            }
        }

        public static int[] PeopleHelp(int correct, int complexity)
        {
            int[] nums = new int[4];
            Random random = new Random();
            int num;
            int min, max;

            if (complexity >= 12)
            {
                min = 0;
                max = 35;
            }
            else if (complexity >= 9)
            {
                min = 15;
                max = 45;
            }
            else if (complexity >= 6)
            {
                min = 25;
                max = 60;
            }
            else
            {
                min = 30;
                max = 70;
            }

            nums[correct] = random.Next(min, max);

            for (int i = 0; i < 100 - nums[correct]; i++)
            {
                do
                {
                    num = random.Next(0, 4);
                } while (num == correct);
                nums[num]++;
            }
            return nums;
        }
    }
}
