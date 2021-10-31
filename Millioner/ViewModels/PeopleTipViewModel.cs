using Millioner.Models;
using Millioner.Utilities;

namespace Millioner.ViewModels
{
    class PeopleTipViewModel : ObserableObject
    {
        private int heightA;
        private int heightB;
        private int heightC;
        private int heightD;

        private string a;
        private string b;
        private string c;
        private string d;

        public PeopleTipViewModel(int correct, int complexity)
        {
            int[] nums = Tips.PeopleHelp(correct, complexity);
            heightA = nums[0] * 3;
            heightB = nums[1] * 3;
            heightC = nums[2] * 3;
            heightD = nums[3] * 3;

            A = nums[0].ToString();
            B = nums[1].ToString();
            C = nums[2].ToString();
            D = nums[3].ToString();
        }

        public int Correct { get; set; }
        public int Complexity { get; set; }

        public int HeightA { get => heightA; set => Set(ref heightA, value); }
        public int HeightB { get => heightB; set => Set(ref heightB, value); }
        public int HeightC { get => heightC; set => Set(ref heightC, value); }
        public int HeightD { get => heightD; set => Set(ref heightD, value); }

        public string A { get => a; set => Set(ref a, value); }
        public string B { get => b; set => Set(ref b, value); }
        public string C { get => c; set => Set(ref c, value); }
        public string D { get => d; set => Set(ref d, value); }
    }
}
