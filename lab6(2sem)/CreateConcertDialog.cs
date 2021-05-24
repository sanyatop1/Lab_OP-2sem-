using Terminal.Gui;
    public class CreateConcertDialog: Dialog
    {
        public bool calceled;
        protected TextField ConcertSongersInput;
        protected TextField nameInput;
        
        protected DateField startDateField;

        public CreateConcertDialog()
        {
            this.Title="Create Concert";
            Button okBtn= new Button(" OK");
    okBtn.Clicked+= OnCreateDialogSubmit; 
    Button cancelBtn= new Button("Cancel");
    cancelBtn.Clicked+= OnCreateDialogCanceled;
  this.AddButton(cancelBtn);
  this.AddButton(okBtn);
  int rightColumX=20;
   Label ConcertSongersLbl= new Label(2,2,"Songers: ");
    ConcertSongersInput = new TextField("")
   {
       X=rightColumX, Y=Pos.Top(ConcertSongersLbl),
       Width=40,

   };
   this.Add(ConcertSongersLbl,ConcertSongersInput);

   Label nameLbl= new Label(2,4,"Name: ");
   nameInput = new TextField("")
   {
       X=rightColumX, Y=Pos.Top(nameLbl),
       Width=40,

   };
   this.Add(nameLbl,nameInput);

   

   Label startDateLbl= new Label(2,8,"Start date: ");
    startDateField = new DateField()
   {
       X=rightColumX, Y=Pos.Top(startDateLbl),
       Width=40,
       IsShortFormat=false,

   };
   this.Add(startDateLbl,startDateField);


  
        }

    public Concert GetConcert()
    {
        return new Concert()
        {
            songers= ConcertSongersInput.Text.ToString(),
            name = nameInput.Text.ToString(),
            startDate =System.DateTime.Parse(startDateField.Text.ToString()),
        };

    }
          private void OnCreateDialogCanceled()
  {
    this.calceled=true;
    Application.RequestStop();

  }
  private void OnCreateDialogSubmit()
  {
    this.calceled=false;
    Application.RequestStop();

  }
    }
