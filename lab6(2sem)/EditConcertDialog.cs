
    public class EditConcertDialog: CreateConcertDialog
    {
        public EditConcertDialog()
        {
            this.Title="Edit Concert";

        }
        public void SetConcert(Concert concert)
        {
           this.ConcertSongersInput.Text=concert.songers;
            this.nameInput.Text=concert.name;
           this.startDateField.Text=concert.startDate.ToShortDateString();
        }
    }
