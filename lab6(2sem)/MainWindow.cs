using Terminal.Gui;
using System;
using System.Collections;
using System.Collections.Generic;
    public class MainWindow:Window
    {
      private Label totalPageLbl;
      private string searchValue="";
      private  Label pageLabel;
      private TextField searchInput;
      private int page =1;
      private int pageLeght=5;
         private ListView allConcertListView;
         private ConcertRepository repo;
        public MainWindow()
        {
            this.Title="Concert Db";
        allConcertListView = new ListView( new List<Concert>())
        {
          Width=Dim.Fill(),
          Height=Dim.Fill(),

        };
         allConcertListView.OpenSelectedItem+=OnOpenConcert;
         Button prevPageBtn=new Button(2,6,"Prev");
         prevPageBtn.Clicked+=OnPrviousPage;
          pageLabel=new Label("?")
         {
           X=Pos.Right(prevPageBtn)+2,
           Y=Pos.Top(prevPageBtn),
           Width=5

         };
          totalPageLbl=new Label("/")
         {
           X=Pos.Right(pageLabel)+2,
           Y=Pos.Top(prevPageBtn),
           Width=5

         };

         Button nextPageBtn = new Button("Next")
         {
           X=Pos.Right(totalPageLbl)+2,
           Y=Pos.Top(prevPageBtn),
           
         };
         nextPageBtn.Clicked+= OnNextPage;
         this.Add(prevPageBtn,pageLabel,totalPageLbl,nextPageBtn);
         FrameView frameView =new FrameView("Concerts")
         {
           X=2,
           Y=8,
           Width=Dim.Fill()- 4,
           Height=pageLeght+2,
         };
         frameView.Add(allConcertListView);
       this.Add(frameView);

       Button deleteConcert =new Button("Delete Concert")
       {
         X=Pos.Left(frameView),
         Y=Pos.Bottom(frameView)+2
       };
       deleteConcert.Clicked+=OnDeleteConcert;
       this.Add(deleteConcert);
       Button CreateNewConcertBtn=new Button (2,2,"Create new Concert");
       CreateNewConcertBtn.Clicked+= OnCreateButtonCliked;
      this.Add(CreateNewConcertBtn);
       searchInput = new TextField(2,4,20,"");
      searchInput.KeyPress+= OnSearcEnter;
      this.Add(searchInput);
      
        }
        private void OnSearcEnter(KeyEventEventArgs args)
        {
         if( args.KeyEvent.Key==Key.Enter)
         {
           this.searchValue=this.searchInput.Text.ToString();
           this.ShowCurrentPage();

         }
        }
        private void OnDeleteConcert()
        {
          int index =MessageBox.Query("Delete Concert,", "Are you sure?","No","Yes");
          if (index==1)
          {
            int concertIndex =this.allConcertListView.SelectedItem;
            if(concertIndex==-1)
            {
              MessageBox.ErrorQuery("Delete Concert","No Concert selected","OK");
              return;
            }
           Concert selectedConcert=(Concert) this.allConcertListView.Source.ToList()[concertIndex];
           if (selectedConcert ==null)
           {
             return;
           }
           if(!repo.Delete(selectedConcert.id))
           {
             MessageBox.ErrorQuery("Delete Concert","Can not deleted Concert","OK");
             return;
           }
            this.ShowCurrentPage();
          }
        }
        
        public void SetRepository(ConcertRepository repository)
        {
            this.repo=repository;
           this.ShowCurrentPage();
            

        }
        private void OnPrviousPage()
        {
          
         
          if(page==1)
          {
            return;
          }
        
          this.page-=1;
          ShowCurrentPage();
        }
        private void OnNextPage()
        {
          
          int totelPages =repo.GetPagesCount(pageLeght);
          if(page>=totelPages)
          {
            return;
          }
        
          this.page+=1;
          ShowCurrentPage();
        }
        private void ShowCurrentPage()
        {
          int totalPages=repo.GetSearchPagesCount(searchValue,pageLeght);
          if(page>totalPages&&page>1)
          {
            page=totalPages;
          }
           this.pageLabel.Text=page.ToString();
            this.totalPageLbl.Text=repo.GetSearchPagesCount(searchValue,pageLeght).ToString();
             this.allConcertListView.SetSource(repo.GetSearcPage(searchValue,page,pageLeght));

        }
        private void OnCreateButtonCliked()
  {
    CreateConcertDialog dialog= new CreateConcertDialog();
   Application.Run(dialog);
   if (!dialog.calceled)
   {
    Concert concert =dialog.GetConcert();
   long concertId =repo.Insert(concert);
   concert.id=concertId;
   allConcertListView.SetSource(repo.GetPage(page,pageLeght));

   
   }

  }
  private void OnOpenConcert(ListViewItemEventArgs args)
  {
    Concert concert =(Concert)args.Value;
    OpenConcertDialog dialog=new OpenConcertDialog();
    dialog.SetConcert(concert);
    Application.Run(dialog);
    if(dialog.deleted)
    {

      bool result =repo.Delete(concert.id);
      if(result)
      {
        int pages=repo.GetPagesCount(pageLeght);
        if(page> pages&& page>1)
        {
          page-=1;
          this.ShowCurrentPage();
        }
        allConcertListView.SetSource(repo.GetPage(page,pageLeght));
      }
      else
      {
        MessageBox.ErrorQuery("Delete Concert","Can not delete Concert","OK");
      }
    }
    if(dialog.updated)
    {
      bool result =repo.Update(concert.id,dialog.GetBook());
      if(result)
      {
        allConcertListView.SetSource(repo.GetPage(page,pageLeght));

      }
      else
      {
        MessageBox.ErrorQuery("Update Concert","Can not update Concert","OK");
      }
    }
  }
    }
