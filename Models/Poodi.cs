namespace Pood.Models
{
    public class Poodi
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public TimeSpan Avamine { get; set; }
        public TimeSpan Sulgemine { get; set; }
        public int KuulastusteArv { get; set; }

        public Poodi(string nimi, TimeSpan avamine, TimeSpan sulgemine)
        {
            Nimi = nimi;
            Avamine = avamine;
            Sulgemine = sulgemine;
            KuulastusteArv = 0;
        }
        public bool OnLahti(TimeSpan kellaaeg)
        {
            if (kellaaeg >= Avamine && kellaaeg <= Sulgemine)
            {
                return true;
            }
            return false;
        }
    }
}
