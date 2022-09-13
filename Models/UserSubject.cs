namespace Final_LitchiLearn.Models
{
    public class UserSubject
    {
        //many to many relationshop
        //User (teacher) has many subjects and a subjects is taughts by many (teachers)
        //Associative table
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }   
        public int SubjectID { get; set; }
        public Subject Subject { get; set; }
    }
}
