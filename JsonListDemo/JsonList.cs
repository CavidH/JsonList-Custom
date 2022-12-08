using Newtonsoft.Json;

namespace JsonListDemo
{
    public class JsonList
    {
        private static string _fileName = "Name.json";
        private List<string> list;

        public void Add(string item)
        {
            list = GetList();
            list.Add(item);
            WriteList(list);
        }
        public bool Search(string item)
        {
            list = GetList();
            return list.Contains(item);
        }
        public void Update(int index, string item)
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


        private List<string> GetList()
        {
            List<string>? deserializedData;
            try
            {
                string fileData = File.ReadAllText(_fileName);
                deserializedData = JsonConvert.DeserializeObject<List<string>>(fileData);
                return deserializedData;
            }
            catch (Exception)
            {
                deserializedData = new List<string>();
                return deserializedData;
            }

        }
        private void WriteList(List<string> data)
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
    }
}
