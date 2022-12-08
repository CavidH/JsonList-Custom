using Newtonsoft.Json;

namespace CustomJsonList
{
    public class JsonList<T>
    {
        private static string _fileName = "Data.json";
        private List<T> list;
        //public JsonList() { }
        //public JsonList(string filePath) => _fileName = filePath;


        #region Indexer
        public T this[int i]
        {
            get { return Get(i); }
            set { Add(value); }
        }

        #endregion
        public void Add(T item)
        {
            list = GetList();
            list.Add(item);
            WriteList(list);
        }
        public T Get(int index)
        {
            list = GetList();
            return list[index];

        }
        public void AddRange(List<T> items)
        {
            list = GetList();
            list.AddRange(items);
            WriteList(list);
        }
        public bool Search(T item)
        {
            list = GetList();
            return list.Contains(item);
        }
        public void Update(int index, T item)
        {
            list = GetList();
            list[index] = item;
            WriteList(list);
        }
        public void Delete(int index)
        {
            list = GetList();
            list.RemoveAt(index);
            WriteList(list);
        }

        #region Privates
        private List<T> GetList()
        {
            List<T>? deserializedData;
            try
            {
                string fileData = File.ReadAllText(_fileName);
                deserializedData = JsonConvert.DeserializeObject<List<T>>(fileData);
                return deserializedData;
            }
            catch (Exception)
            {
                deserializedData = new List<T>();
                return deserializedData;
            }

        }
        private void WriteList(List<T> data)
        {
            string serializedList = JsonConvert.SerializeObject(data);
            try
            {
                File.WriteAllText(_fileName, serializedList);

            }
            catch (Exception)
            {
                File.Create(_fileName);
                WriteList(data);
            }
        }
        #endregion
    }
}
