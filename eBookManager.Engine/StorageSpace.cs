using System;
using System.Collections.Generic;
using System.Text;

namespace eBookManager.Engine
{
    [Serializable]
    public class StorageSpace
    {
        //The ID to reference the Storage Space with
        public int ID { get; set; }

        //The name the user will give and that you appear to him
        public string Name { get; set; }

        //The Description the user will give and that you appear to him
        public string Description { get; set; }

        //The list of books (documents) inside the storage space, it is actually just useful informations about the book, such as name, file path, etc
        public List<Document> BookList { get; set; }

    }
}
