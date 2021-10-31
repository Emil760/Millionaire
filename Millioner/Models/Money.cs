using Millioner.Utilities;

namespace Millioner.Models
{
    class Money : ObserableObject
    {
        bool is_non_fire;
        int price;

        public Money(int price, bool is_non_fire = false)
        {
            Price = price;
            IsNonFire = is_non_fire;
        }

        public bool IsNonFire { get => is_non_fire; set => Set(ref is_non_fire, value); }
        public int Price { get => price; set => Set(ref price, value); }
    }
}
