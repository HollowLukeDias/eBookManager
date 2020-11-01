using eBookManager.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static eBookManager.Helper.ExtensionMethods;
using static System.Math;

namespace Testing
{
    public partial class ImportBooks : Form
    {
        private string _jsonPath = "";
        private List<StorageSpace> _spaces = new List<StorageSpace>(); 
        private int previousSelectedSpaceIndex = 0;
        private enum _storageSpaceSelection 
        { 
            New = -9999,
            NoSelection = -1 
        }

        private HashSet<string> AllowedExtension => new HashSet<string>(StringComparer.InvariantCultureIgnoreCase)
        { ".doc", ".docx", ".pdf", ".epub", ".lit", ".mobi", ".cbz", ".cbr" };

        private enum Extension
        {
            doc = 0,
            docx = 1,
            pdf = 2,
            epub = 3,
            lit = 4,
            mobi = 5,
            cbz = 6,
            cbr = 7
        }


        public ImportBooks()
        {
            InitializeComponent();
            
            //Combines the string "bookData.txt" with the path the application is, in order to find the path for bookData.txt
            _jsonPath = Path.Combine(Application.StartupPath, "bookData.txt");

        }


        private async void ImportBooks_Load(object sender, EventArgs e)
        {
            //Reads the information of the path of bookData.txt
            _spaces = await _spaces.ReadFromDataStore(_jsonPath);
            //If there are any storage space in bookData then the list will be populated
            PopulateStorageSpacesList();

            //If there are no storage space the opetion to create one will appear
            if(dlVirtualStorageSpaces.Items.Count == 0)
            {
                dlVirtualStorageSpaces.Items.Add("<create new storage space>");
            }
            lblEbookCount.Text = "";
            txtStorageSpaceDescription.Text = "";
        }

        /// <summary>
        /// It finds all the directories and populates the list of books with every book inside 
        /// each directory inside the one you chose.
        /// </summary>
        /// <param name="currentDirectory"></param>
        /// <param name="currentNode"></param>    
        private void PopulateBookList(string currentDirectory, TreeNode currentNode)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            //If there are any directories inside the directory it will add it under the current TreeNode node and
            //recursevely call this function in order to see if there are more directories and books inside the new directory
            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
            {
                //Creating a node for this directory
                TreeNode node = new TreeNode(dirInfo.Name);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 5;

                if(currentNode != null)
                    currentNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);

                PopulateBookList(dirInfo.FullName, node);
            }

            //Instead of adding new directories, this one simply goes through the content inside of that directory
            //and if any of those files have the allowed extension, they'll be added into a node
            foreach (FileInfo fileInfo in directoryInfo.GetFiles()
                .Where(file => AllowedExtension.Contains(file.Extension)).ToList())
            {
                //Creates a node with the file name
                TreeNode node = new TreeNode(fileInfo.Name);
                node.Tag = fileInfo.FullName;

                
                //Finds the hash code of the file based on the extension 
                int iconIndex = Enum.Parse(typeof(Extension),
                    fileInfo.Extension.TrimStart('.'), true).GetHashCode();
                node.ImageIndex = iconIndex;
                node.SelectedImageIndex = iconIndex;
                if (currentNode != null)
                    currentNode.Nodes.Add(node);
                else
                    tvFoundBooks.Nodes.Add(node);
            }
        }

        /// <summary>
        /// What happens when you click the button to select the source folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select the location of your eBook and documents";
                DialogResult dlgResult = fbd.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    tvFoundBooks.Nodes.Clear();
                    string path = fbd.SelectedPath;

                    //Creates the root for the Tree View and goes to Populate Books
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    TreeNode root = new TreeNode(dirInfo.Name);
                    root.ImageIndex = 4;
                    root.SelectedImageIndex = 5;
                    tvFoundBooks.Nodes.Add(root);

                    PopulateBookList(dirInfo.FullName, root);
                    tvFoundBooks.Sort();
                    root.Expand();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error message was returned:\n" + ex);
            }
        }
        
        /// <summary>
        /// What happens after you select a book inside the Tree View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFoundBooks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DocumentEngine engine = new DocumentEngine();

            //?? only gets the right operand if it is not null, if it is null it takes from the right
            string path = e.Node.Tag?.ToString() ?? "";


            if (File.Exists(path))
            {

                //Initializes all these variables and get their file with GetFileProperties
                var (dateCreated, dateLastAccessed, fileName, fileExtention, fileLength, hasError) = engine.GetFileProperties(e.Node.Tag.ToString());
                if (!hasError)
                {
                    txtFileName.Text     = fileName;
                    txtExtension.Text    = fileExtention;
                    dtCreated.Value      = dateCreated;
                    dtLastAccessed.Value = dateLastAccessed;
                    txtFilePath.Text     = e.Node.Tag.ToString();
                    txtFileSize.Text     = $"{Round(fileLength.ToMegaBytes(), 2)} MB";
                }
            }
        }

        /// <summary>
        /// It populates the Virtual Storage Spaces List
        /// </summary>
        private void PopulateStorageSpacesList()
        {
            //previousSelectedSpaceIndex = dlVirtualStorageSpaces.SelectedIndex;

            //Creates a list of a key value pair where the key is the intand the value is the string
            List<KeyValuePair<int, string>> storageSpaces = new List<KeyValuePair<int, string>>();

            //Creates an storage space selection with NoSelection (which means noething of use is selected), with the string 
            //telling the user to select some storage space
            BindStorageSpaceList((int) _storageSpaceSelection.NoSelection, "Select Storage Space");

            //Creates the functions that binds the key and value of a storage space spaces into storageSpaces
            void BindStorageSpaceList(int key, string value) => storageSpaces.Add(new KeyValuePair<int, string>(key, value));

            //If there are no storage spaces, it creates an storage space called <Create New>, so the user will know to create it
            if(_spaces is null || _spaces.Count() == 0)  //Pattern Matching
            {
                BindStorageSpaceList((int)_storageSpaceSelection.New, " < Create New > ");
            }
            else
            {
                foreach (var space in _spaces) 
                    BindStorageSpaceList(space.ID, space.Name);
            }
            dlVirtualStorageSpaces.DataSource    = new BindingSource(storageSpaces, null);
            dlVirtualStorageSpaces.DisplayMember = "Value";
            dlVirtualStorageSpaces.ValueMember = "Key";
            dlVirtualStorageSpaces.SelectedIndex = previousSelectedSpaceIndex;

        }

        /// <summary>
        /// Happens when the selected space changes
        /// And thus, depending on which one the user selected the amount of books will change
        /// And the right description will appear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dlVirtualStorageSpaces_SelectedIndexChanged(object sender, EventArgs e)
        { 
            //if the virtual space selected is <create new> then the the new virtual space setting will appear
            int selectedValue = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();
            if(selectedValue == (int) _storageSpaceSelection.New) //-9999
            {
                txtNewStorageSpaceName.Visible = true;
                lblStorageSpaceDescription.Visible = true; 
                txtStorageSpaceDescription.ReadOnly = false; 
                btnSaveNewStorageSpace.Visible = true;
                btnCancelNewStorageSpaceSave.Visible = true;
                previousSelectedSpaceIndex = dlVirtualStorageSpaces.SelectedIndex;
                dlVirtualStorageSpaces.Enabled = false; 
                btnAddNewStorageSpace.Enabled = false; 
                lblEbookCount.Text = "";
                txtStorageSpaceDescription.Text = "";


            }
            //If the virtual space selected is not <Select Virtual Space>
            else if(selectedValue != (int) _storageSpaceSelection.NoSelection) // -1
            {
                //Finds the amount contents of the selected storage space
                int contentCount = (from c in _spaces
                                    where c.ID == selectedValue
                                    select c).Count();

                //If there are contents in that Virtual Space
                if(contentCount > 0)
                {
                    StorageSpace selectedSpace = (from c in _spaces
                                                  where c.ID == selectedValue
                                                  select c).First();
                    txtStorageSpaceDescription.Text = selectedSpace.Description;

                    //If the list of eBooks is not null, they will be selected
                    List<Document> eBooks = 
                        (selectedSpace.BookList == null) ? new List<Document> { } : selectedSpace.BookList;

                    lblEbookCount.Text = $"Storage Space Contains: {eBooks.Count()} {(eBooks.Count() == 1 ? "eBook" : "eBooks")}";
                }
                else
                {
                    lblEbookCount.Text = "";
                }
            }

        }

        /// <summary>
        /// Method will be called when user tries to save the new storage space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveNewStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                //If the size of the name the user has typed isn't equal to 0
                if (txtNewStorageSpaceName.Text.Length != 0)
                {
                    
                    string newName = txtNewStorageSpaceName.Text;
                    bool spaceExists = (!_spaces.StorageSpaceExists(newName, out int nextID)) ? false : throw new Exception(" The storage space you are trying to add already exists.");
                    if (!spaceExists)
                    {
                        StorageSpace newSpace = new StorageSpace();
                        newSpace.Name = newName;
                        newSpace.ID = nextID;
                        newSpace.Description = txtStorageSpaceDescription.Text;
                        _spaces.Add(newSpace);
                        

                        PopulateStorageSpacesList(); // Save new Storage Space Name 

                        dlVirtualStorageSpaces.SelectedIndex = newSpace.ID;
                        //Hide the set up for the new storage space
                        txtNewStorageSpaceName.Clear(); 
                        txtNewStorageSpaceName.Visible = false; 
                        lblStorageSpaceDescription.Visible = false; 
                        txtStorageSpaceDescription.ReadOnly = true; 
                        txtStorageSpaceDescription.Clear(); 
                        btnSaveNewStorageSpace.Visible = false; 
                        btnCancelNewStorageSpaceSave.Visible = false;
                        dlVirtualStorageSpaces.Enabled = true;
                        dlVirtualStorageSpaces.SelectedIndex = previousSelectedSpaceIndex;
                        btnAddNewStorageSpace.Enabled = true;

                    }
                }
            }
            catch (Exception ex)
            {
                txtNewStorageSpaceName.SelectAll();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Simply shoes the set ups for the new storage space
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewStorageSpace_Click(object sender, EventArgs e)
        {
            lblEbookCount.Text = "";
            txtStorageSpaceDescription.Text = "";
            txtNewStorageSpaceName.Visible = true;
            lblStorageSpaceDescription.Visible = true; 
            txtStorageSpaceDescription.ReadOnly = false; 
            btnSaveNewStorageSpace.Visible = true; 
            btnCancelNewStorageSpaceSave.Visible = true;
            previousSelectedSpaceIndex = dlVirtualStorageSpaces.SelectedIndex;
            dlVirtualStorageSpaces.Enabled = false;
            btnAddNewStorageSpace.Enabled = false;

        }

        /// <summary>
        /// Simply calls UpdateStorageSpaceBooks for the selected book to the selected storage space if it isn't the NoSelection or the New
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAddBookToStorageSpace_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedStorageSpaceID = dlVirtualStorageSpaces.SelectedValue.ToString().ToInt();

                if ((selectedStorageSpaceID != (int)_storageSpaceSelection.NoSelection)
                 && (selectedStorageSpaceID != (int)_storageSpaceSelection.New))
                {
                    await UpdateStorageSpaceBooks(selectedStorageSpaceID);
                }
                else throw new Exception("Please select a Storage Space to add your eBook to");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Tries to add a book to the selected storage space
        /// </summary>
        /// <param name="storageSpaceId"></param>
        /// <returns></returns>
        private async Task UpdateStorageSpaceBooks(int storageSpaceId) 
        {
            previousSelectedSpaceIndex = dlVirtualStorageSpaces.SelectedIndex;
            try
            {
                int iCount = (from s in _spaces 
                              where s.ID == storageSpaceId 
                              select s).Count();

                // The space will always exist 
                if (iCount > 0)
                {
                    StorageSpace existingSpace = (from s in _spaces 
                                                  where s.ID == storageSpaceId 
                                                  select s). First(); 
                    List < Document > ebooks = existingSpace.BookList; 

                    //Counts how many books of the same name in the storage space
                    int eBooksExist = (ebooks != null) ? (from b in ebooks 
                                                          where $"{ b.FileName}". Equals( $"{ txtFileName.Text.Trim()}") 
                                                          select b). Count() : 0;

                    //If a book of the same name has been found
                    if (eBooksExist > 0)
                    {

                        //Asks the user if actually wants to update the already existing book with the new one, creating a message box with yes or no options
                        DialogResult dlgResult = MessageBox.Show($" A book with the same name has been found in Storage Space {existingSpace.Name}. Do you want to replace the existing book entry with this one ?",
                            "Duplicate Title", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                        if (dlgResult == DialogResult.Yes) 
                        { 
                            //Looks for the old book that is goind to be replaced
                            Document existingBook = (from book in ebooks 
                                                     where $"{ book.FileName}".Equals($"{ txtFileName.Text.Trim()}") 
                                                     select book).First(); 
                            SetBookFields(existingBook);
                        }
                    }
                    else
                    { 
                        // Insert the new book 
                        Document newBook = new Document();
                        SetBookFields(newBook); 

                        if (ebooks == null) ebooks = new List <Document>();
                        ebooks.Add(newBook);
                        existingSpace.BookList = ebooks;
                    } 
                } 
                //Save the changes into the Json, populates the storage space list and shows a message to user saying that the book was added
                await _spaces.WriteToDataStore(_jsonPath);
                PopulateStorageSpacesList(); 
                MessageBox.Show("Book added"); 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show( ex.Message); 
            }
            dlVirtualStorageSpaces.SelectedIndex = previousSelectedSpaceIndex;
        }

        /// <summary>
        /// Helper function that sets the information field of the book
        /// </summary>
        /// <param name="book"></param>
        private void SetBookFields(Document book)
        {
            book.FileName       = txtFileName.Text;
            book.Extension = txtExtension.Text;
            book.LastAccessed   = dtLastAccessed.Value; 
            book.Created        = dtCreated.Value; 
            book.FilePath       = txtFilePath.Text; 
            book.FileSize       = txtFileSize.Text; 
            book.Title          = txtTitle.Text; 
            book.Author         = txtAuthor.Text; 
            book.Publisher      = txtPublisher.Text; 
            book.Price          = txtPrice.Text; 
            book.ISBN           = txtISBN.Text; 
            book.PublishDate    = dtDatePublished.Value; 
            book.Category       = txtCategory.Text;
        }

        /// <summary>
        /// Simply hides the set up for the new storage spaces when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelNewStorageSpaceSave_Click(object sender, EventArgs e)
        {
            txtNewStorageSpaceName.Clear();
            txtNewStorageSpaceName.Visible  = false;
            lblStorageSpaceDescription.Visible = false;
            txtStorageSpaceDescription.ReadOnly = true;
            txtStorageSpaceDescription.Clear();
            btnSaveNewStorageSpace.Visible = false;
            btnCancelNewStorageSpaceSave.Visible = false;
            dlVirtualStorageSpaces.Enabled = true;
            dlVirtualStorageSpaces.SelectedIndex = previousSelectedSpaceIndex;
            btnAddNewStorageSpace.Enabled = true;
        }
    }

}
