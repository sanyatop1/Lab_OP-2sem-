using System.Collections.Generic;
using System;

    public class ConcertRepository
    {
        private Random _random= new Random();
        private List<Concert>  _concerts;
        public ConcertRepository()
        {
            _concerts= new System.Collections.Generic.List<Concert>()
            {
                new Concert() {id =1 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =2 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =3 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =4 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =5 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =6,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =7,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =8 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =9 ,name ="Golos", songers="Potap, Vinnuk"},
                new Concert() {id =10 ,name ="Zirki", songers="Polyakova"},
                new Concert() {id =11 ,name ="Golos", songers="Potap, Vinnuk"},
            };

        }
        public int GetPagesCount(int pageLength)
        {
            if(pageLength< 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageLength));
            }
           return (int)Math.Ceiling( this._concerts.Count/(float) pageLength);
        }
        private List<Concert> SearchConcert(string searchValue)
        {
             if (string.IsNullOrEmpty(searchValue))
            {
                return this._concerts;
            }
            
            List<Concert> searchConcert= new List<Concert>();
            foreach(Concert c in _concerts)
            {
                if(c.name.Contains(searchValue)||c.songers.Contains(searchValue))
                {
                    searchConcert.Add(c);
                }
            }
            return searchConcert;
        }
        public int GetSearchPagesCount(string searchValue, int pageLength)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                return this.GetPagesCount(pageLength);
            }
            if(pageLength< 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageLength));
            }
            
            return (int)Math.Ceiling( this.SearchConcert(searchValue).Count/(float) pageLength);
        }
        public List <Concert> GetSearcPage(string searchValue,int pageNumber, int pageLeght)
        {
             if(pageNumber< 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            }
             if(pageLeght< 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageLeght));
            }
            List <Concert> searchConcert = this.SearchConcert(searchValue);
             return GetListPage(searchConcert,pageNumber,pageLeght);
        }
        private static List <Concert> GetListPage(List<Concert> list, int pageNumber, int pageLeght)
        {
            List<Concert> page =new List<Concert>();
            int offset =(pageNumber-1)*pageLeght;
            for(int i=0;i<pageLeght; i++)
            {
                int k=offset +i;
                if(k>=list.Count)
                {
                    break;
                }
                page.Add(list[k]);
            }
            return page;

        }
        public List<Concert> GetPage(int pageNumber, int pageLeght )
        {
            if(pageNumber< 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            }
            if(pageLeght< 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageLeght));
            }
            
            return GetListPage(_concerts,pageNumber,pageLeght);
        }
        public List<Concert> GetAll()
        {
            return _concerts;
        }
        public Concert GetById(long concertId)
        {int index = FindIndex(concertId);
            if (index ==-1)
            {
                return null;
            }
            
            return _concerts[index];
        }
        public long Insert(Concert concert)
        {
            _concerts.Add(concert);
            concert.id= _random.Next()%1000;
            return concert.id;
        }
        private int FindIndex(long concertId)
        {
            for(int i=0; i<_concerts.Count; i++)
            {
                Concert c =_concerts[i];
                if (c.id==concertId)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Delete(long concertId)
        {
            int index = FindIndex(concertId);
            if (index ==-1)
            {
                return false;
            }
            _concerts.RemoveAt(index);
            return true;
            

        }
        public bool Update (long concertId, Concert updateConcert)
        {
             int index = FindIndex(concertId);
            if (index ==-1)
            {
                return false;
            }
           _concerts[index]=updateConcert;
           return true;
            
        }

    }
