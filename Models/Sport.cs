namespace Final_LitchiLearn.Models
{
    public class Sport
    {   
        public int SportID { get; set; }

        UserAccountModel UserAccount { get; set; }
        public string NameOfSport { get; set; }
        public string SportType { get; set; }

        public string Day { get; set; }
        public string Time { get; set; }
        



    }
}
