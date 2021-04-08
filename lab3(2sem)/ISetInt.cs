interface ISetInt 
{
int Count ();
int []Arr ();
bool Add(int value);
bool Read(string file);
bool Write(string file);

bool Remove(int value);
bool Contains(int value);
void Clear ();
void Log ();

void CopyTo(int []array);
}
