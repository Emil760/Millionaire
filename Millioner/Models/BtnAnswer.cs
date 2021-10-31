using Millioner.Utilities;

namespace Millioner.Models
{
    enum Stat { Enabled, Disabled, Wait, Wrong, Correct, Clicked };

    class BtnAnswer : ObserableObject
    {
        string variant;
        Stat stat;

        public BtnAnswer(Stat stat)
        {
            Stat = stat;
        }

        public BtnAnswer(string variant, Stat stat) : this(stat)
        {
            Variant = variant;
        }

        public string Variant { get => variant; set => Set(ref variant, value); }
        public Stat Stat { get => stat; set => Set(ref stat, value); }
    }
}
